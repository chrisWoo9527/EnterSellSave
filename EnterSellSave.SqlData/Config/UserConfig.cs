using EnterSellSave.Common;
using EnterSellSave.SqlData.Model;

namespace EnterSellSave.SqlData.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("T_User");
            builder.Property(p => p.Code).HasMaxLength(50);
            builder.Property(p => p.RealName).HasMaxLength(50);
            builder.Property(p => p.IdCard).HasMaxLength(50);
            builder.Property(p => p.Status).HasDefaultValue(LivingStatus.启用);
            builder.Property(p => p.Gender).HasDefaultValue(Gender.未知);
        }
    }
}
