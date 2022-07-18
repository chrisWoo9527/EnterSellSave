using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.Dto.Input
{
    public class JwtInputDto
    {
        public string UserName { get; set; }
        public long JwtVersion { get; set; }
    }
}
