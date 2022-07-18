using EnterSellSave.Common.AutoFacManager;
using EnterSellSave.Services.Dto.BasicsDto;
using EnterSellSave.Services.Dto.Input;
using EnterSellSave.SqlData;
using EnterSellSave.SqlData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.BasicsServices.MenuServices
{
    public class MenuService : IMenuService, IScopeService
    {

        private readonly MirDbContext _dbContext;

        public MenuService(MirDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseDto> AddMenu(MenuInputDto input)
        {

            Menu? parentMenu = _dbContext.Menus.FirstOrDefault(p => p.Id == input.ParentId);
           

            throw new NotImplementedException();
        }
    }
}
