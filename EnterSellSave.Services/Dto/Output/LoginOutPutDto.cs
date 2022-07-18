using EnterSellSave.Services.Dto.BasicsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.Dto.Output
{
    public class LoginOutPutDto : ResponseDto
    {
        public string Jwt { get; set; }
    }
}
