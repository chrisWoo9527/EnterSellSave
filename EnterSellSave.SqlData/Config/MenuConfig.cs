using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterSellSave.SqlData.Config
{
    public class MenuConfig : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("T_Menu");
            builder.HasIndex(p => p.Index);
            builder.Property(p => p.Name).HasMaxLength(100);
            builder.Property(p => p.NamespaceClassName).HasMaxLength(100);
            //builder.HasOne<User>(m => m.Creator).WithOne().HasForeignKey<Menu>(m => m.CreatorId);
            //builder.HasOne<User>(m => m.LastModifier).WithOne().HasForeignKey<Menu>(m => m.LastModifierId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
