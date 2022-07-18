using EnterSellSave.Services.Dto.BasicsDto;
using EnterSellSave.Services.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.BasicsServices.MenuServices
{
    public interface IMenuService
    {
        Task<ResponseDto> AddMenu(MenuInputDto input);
    }
}
