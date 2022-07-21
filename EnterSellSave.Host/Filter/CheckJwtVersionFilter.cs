using EnterSellSave.Common;
using EnterSellSave.Services.Attributes;
using EnterSellSave.Services.BasicsServices.HelperServices;
using EnterSellSave.SqlData.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EnterSellSave.Host.Filter
{
    public class CheckJwtVersionFilter : IAsyncActionFilter
    {
        private readonly UserManager<User> userManager;
        private readonly IDistributedCacheHelper _distributedCache;

        public CheckJwtVersionFilter(UserManager<User> userManager,
            IDistributedCacheHelper distributedCache)
        {
            this.userManager = userManager;
            _distributedCache = distributedCache;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            bool checkJwtVersionattribute = false;
            if (context.ActionDescriptor is ControllerActionDescriptor)
            {
                ControllerActionDescriptor actionDescriptor = (ControllerActionDescriptor)context.ActionDescriptor;
                checkJwtVersionattribute = actionDescriptor.MethodInfo.GetCustomAttributes(typeof(CheckJwtVersion), false).Any();
            }

            if (!checkJwtVersionattribute)
            {
                await next();
                return;
            }

            try
            {
                var claimUserName = context.HttpContext.User.FindFirst("UserName");

                string cacheKey = $"{claimUserName.Value}";

                User? user = await _distributedCache.GetOrCreateAsync<User>(cacheKey, async e =>
                {
                    return await userManager.FindByNameAsync(claimUserName.Value);
                });

                // 登陆信息存储
                LoginInfo.UserName = user.UserName;
                LoginInfo.UserId = user.Id;
                //LoginInfo.DepartmentId = user.Department.Id;

                if (user.JwtVersion > Convert.ToInt64(context.HttpContext.User.FindFirst("JwtVersion").Value))
                {
                    ObjectResult objectResult = new ObjectResult("令牌失效")
                    {
                        StatusCode = 401
                    };
                    context.Result = objectResult;
                    return;
                }
                else
                {
                    await next();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
