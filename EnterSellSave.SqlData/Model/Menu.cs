using EnterSellSave.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.SqlData.Model
{
    public class Menu
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 父节点ID
        /// </summary>
        public Menu? Parent { get; set; }

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


        public User? Creator { get; set; }

        public long CreatorId { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public User? LastModifier { get; set; }

        public long LastModifierId { get; set; }

        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        public LivingStatus Status { get; set; }
    }
}
