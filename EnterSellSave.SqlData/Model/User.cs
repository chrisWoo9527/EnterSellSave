using EnterSellSave.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.SqlData.Model
{
    public class User : IdentityUser<long>
    {
        /// <summary>
        /// 工号
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string? IdCard { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public Department? Department { get; set; }

        //public long DepartmentId { get; set; }

        /// <summary>
        /// JwtVersion
        /// </summary>
        public long JwtVersion { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public LivingStatus Status { get; set; }
    }
}
