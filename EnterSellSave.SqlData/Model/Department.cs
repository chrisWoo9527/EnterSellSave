using EnterSellSave.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.SqlData.Model
{
    public class Department
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 上级部门ID
        /// </summary>
        public Department? Parent { get; set; }

        /// <summary>
        /// 部门编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatorId { get; set; }


        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 最后修改人
        /// </summary>
        public long? LastModifierId { get; set; }

        /// <summary>
        /// 最后修改日期
        /// </summary>
        public DateTime? LastModifyTime { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public LivingStatus Status { get; set; }

    }
}
