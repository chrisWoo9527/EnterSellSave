using EnterSellSave.Services.Dto.BasicsDto;
using EnterSellSave.Services.Dto.Input;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterSellSave.Host.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ResponseDto>> AddMenu(MenuInputDto input) {

            return null;
        }
    }
}
