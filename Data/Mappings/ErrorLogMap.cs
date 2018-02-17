
using System.Data.Entity.ModelConfiguration;
using Core.Domains;


namespace Data.Mappings
{
    class ErrorLogMap : EntityTypeConfiguration<ErrorLog>
    {
        public ErrorLogMap()
        {
            // Table 
            ToTable("ErrorLog", "dbo");

            // Primary Key
            HasKey(u => u.Id);

            // validations
            Property(c => c.AppName)
                .IsRequired();

            Property(c => c.Thread)
                .IsRequired();

            Property(c => c.Level)
                .IsRequired();

            Property(c => c.Location)
                .IsRequired();

            Property(c => c.Message)
                .IsRequired();

            Property(c => c.Exception)
                .IsRequired();

            Property(c => c.LogDate)
                .IsRequired();
        }
    }
}
