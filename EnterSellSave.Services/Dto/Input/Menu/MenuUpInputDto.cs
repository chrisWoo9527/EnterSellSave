using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.Dto.Input.Menu
{
    public class MenuUpInputDto
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public string NamespaceClassName { get; set; }

        public int SerialNumber { get; set; }
    }
}
