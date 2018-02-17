
using System.Data.Entity.ModelConfiguration;
using Core.Domains;

namespace Data.Mappings
{
    class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Table 
            ToTable("Account", "dbo");
            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.Username)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.PasswordHash)
                .IsRequired();

            Property(c => c.PasswordSalt)
                .IsRequired();
        }
    }
}
