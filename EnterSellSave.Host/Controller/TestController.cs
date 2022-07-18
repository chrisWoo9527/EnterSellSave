using EnterSellSave.SqlData;
using EnterSellSave.SqlData.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EnterSellSave.Host.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly MirDbContext mirDbContext;

        public TestController(UserManager<User> userManager, MirDbContext mirDbContext)
        {
            _userManager = userManager;
            this.mirDbContext = mirDbContext;
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddUser()
        {

            User user = new User() { UserName = "admin", Code = "admin" ,RealName="系统管理员"};
            IdentityResult identityResult = await _userManager.CreateAsync(user, "054805");
            if (!identityResult.Succeeded) { 
            return JsonConvert.SerializeObject(identityResult.Errors);
            }
            return "ok";
        }
    }
}
