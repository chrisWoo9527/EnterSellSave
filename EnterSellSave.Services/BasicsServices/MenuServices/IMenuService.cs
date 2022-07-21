using EnterSellSave.Services.Dto.BasicsDto;
using EnterSellSave.Services.Dto.Input.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.BasicsServices.MenuServices
{
    public interface IMenuService
    {
        Task<ResponseDto> AddMenu(MenuAddInputDto input);

        Task<ResponseDto> UpdateMenu(long Id, MenuUpInputDto input);

        Task<ResponseDto> DeleteMenu(long Id);
    }
}
