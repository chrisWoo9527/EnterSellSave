using EnterSellSave.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.SqlData.Config
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("T_Department");
            builder.Property(p => p.Code).HasMaxLength(50);
            builder.Property(p => p.Name).HasMaxLength(200);
            builder.Property(p => p.Status).HasDefaultValue(LivingStatus.启用);
            //builder.HasOne<User>(k => k.LastModifier).WithOne(v => v.Department).HasForeignKey<User>(v => v.DepartmentId);
            //builder.HasOne<User>(k => k.LastModifier).WithOne(v => v.Department);
        }
    }
}
