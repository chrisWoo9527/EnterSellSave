using EnterSellSave.Services.Dto.Input;
using EnterSellSave.Services.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.BasicsServices.LoginServices
{
    public interface ILoginService
    {
        Task<LoginOutPutDto> Login(LoginInputDto input);
    }
}
