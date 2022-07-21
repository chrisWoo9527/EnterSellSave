using EnterSellSave.Common;
using EnterSellSave.Common.AutoFacManager;
using EnterSellSave.Services.Dto.BasicsDto;
using EnterSellSave.Services.Dto.Input.Menu;
using EnterSellSave.SqlData;
using EnterSellSave.SqlData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public async Task<ResponseDto> AddMenu(MenuAddInputDto input)
        {
            // 父类
            Menu? parentMenu = _dbContext.Menus.FirstOrDefault(p => p.Id == input.ParentId);
            DateTime dateTime = DateTime.Now;
            Menu newMenu = new Menu
            {
                Parent = parentMenu,
                Index = input.Index,
                Name = input.Name,
                NamespaceClassName = input.NamespaceClassName,
                SerialNumber = input.SerialNumber,
                CreatorId = LoginInfo.UserId,
                CreateTime = dateTime,
                LastModifierId = LoginInfo.UserId,
                LastModifyTime = dateTime
            };

            await _dbContext.Menus.AddAsync(newMenu);
            await _dbContext.SaveChangesAsync();
            return new ResponseDto { IsSuccess = true };
        }

        public async Task<ResponseDto> DeleteMenu(long Id)
        {
            var menus = _dbContext.Menus.FirstOrDefault(w => w.Id == Id);

            if (menus == null)
            {
                throw new ValidationException($"查询不到Id : {Id}的菜单~~~");
            }

            menus.Status = LivingStatus.删除;
            await _dbContext.SaveChangesAsync();
            return new ResponseDto { IsSuccess = true };
        }

        public async Task<ResponseDto> UpdateMenu(long Id, MenuUpInputDto input)
        {
            var menus = _dbContext.Menus.FirstOrDefault(w => w.Id == Id);

            if (menus == null)
            {
                throw new ValidationException($"查询不到Id : {Id}的菜单~~~");
            }

            menus.Index = input.Index;
            menus.Name = input.Name;
            menus.NamespaceClassName = input.NamespaceClassName;
            menus.SerialNumber = input.SerialNumber;
            await _dbContext.SaveChangesAsync();
            return new ResponseDto { IsSuccess = true };
        }



    }
}
