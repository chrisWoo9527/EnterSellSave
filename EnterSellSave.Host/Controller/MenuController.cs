using EnterSellSave.Services.Attributes;
using EnterSellSave.Services.BasicsServices.MenuServices;
using EnterSellSave.Services.Dto.BasicsDto;
using EnterSellSave.Services.Dto.Input.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnterSellSave.Host.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }


        [CheckJwtVersion]
        [HttpPost("AddMenu")]
        public async Task<ActionResult<ResponseDto>> AddMenu(MenuAddInputDto input)
        {

            ResponseDto responseDto = await _menuService.AddMenu(input);
            return responseDto;
        }

        [CheckJwtVersion]
        [HttpPost("UpdateMenu/{Id}")]
        public async Task<ActionResult<ResponseDto>> UpdateMenu(long Id, MenuUpInputDto input)
        {
            ResponseDto responseDto = await _menuService.UpdateMenu(Id, input);
            return responseDto;
        }


        [CheckJwtVersion]
        [HttpDelete("DeleteMenu/{Id}")]
        public async Task<ActionResult<ResponseDto>> DeleteMenu(long Id)
        {
            ResponseDto responseDto = await _menuService.DeleteMenu(Id);
            return responseDto;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseDto>> QueryMenu()
        {
            return null;
        }
    }
}
