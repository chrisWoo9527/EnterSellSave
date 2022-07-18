using EnterSellSave.Services.BasicsServices.LoginServices;
using EnterSellSave.Services.Dto.Input;
using EnterSellSave.Services.Dto.Output;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterSellSave.Host.Controller
{
    [Route("api/[controller]s")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginOutPutDto>> Login([FromBody] LoginInputDto input)
        {
            LoginOutPutDto loginOutPutDto = await _loginService.Login(input);
            return loginOutPutDto;
        } 
    }
}
