using EnterSellSave.SqlData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.Services.Dto.Input.Menu
{
    public class MenuAddInputDto
    {
        /// <summary>
        /// 父节点ID
        /// </summary>
        public long? ParentId { get; set; }

        /// <summary>
        /// 菜单索引 
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 命名空间.类名
        /// </summary>
        public string NamespaceClassName { get; set; }


        public int? SerialNumber { get; set; }

    }
}
