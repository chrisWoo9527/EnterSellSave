using EnterSellSave.Common.AutoFacManager;
using EnterSellSave.Common.BaseOptions;
using EnterSellSave.Services.Dto.Input;
using EnterSellSave.Services.Dto.Output;
using EnterSellSave.SqlData.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.BasicsServices.LoginServices
{
    public class LoginService : ILoginService, ISingletonService
    {
        private readonly UserManager<User> _userManager;
        private readonly IOptionsSnapshot<JwtOptions> _jwtOptions;

        public LoginService(UserManager<User> userManager,
            IOptionsSnapshot<JwtOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtOptions = jwtOptions;
        }

        /// <summary>
        /// 用户登陆系统
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<LoginOutPutDto> Login(LoginInputDto input)
        {
            User user = await _userManager.FindByNameAsync(input.UserName);

            if (user == null)
            {
                return new LoginOutPutDto { IsSuccess = false, Message = "用户名或密码错误~~~" };
            }

            bool result = await _userManager.CheckPasswordAsync(user, input.Password);

            if (!result)
            {
                return new LoginOutPutDto { IsSuccess = false, Message = "用户名或密码错误~~~" };
            }

            // 开始生成jwt文件
            user.JwtVersion++;
            IdentityResult identityResult = await _userManager.UpdateAsync(user);
            if (!identityResult.Succeeded)
            {
                string errors = JsonConvert.SerializeObject(identityResult.Errors);
                return new LoginOutPutDto { IsSuccess = false, Message = errors };
            }

            var jwtInput = new JwtInputDto { UserName = input.UserName, JwtVersion = user.JwtVersion };
            List<Claim> claims = new();
            Type type = jwtInput.GetType();
            PropertyInfo[] propertyInfos = type.GetProperties();
            foreach (var item in propertyInfos)
            {
                claims.Add(new Claim(item.Name, item.GetValue(jwtInput, null).ToString()));
            }

            byte[] secKeyBytes = Encoding.UTF8.GetBytes(_jwtOptions.Value.SecKey);
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(secKeyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey,
                        SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(claims: claims,
                        expires: DateTime.Now.AddSeconds(_jwtOptions.Value.ExpireSeconds),
                        signingCredentials: signingCredentials);
            string jwtString = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return new LoginOutPutDto { IsSuccess = true, Jwt = jwtString };
        }
    }
}
