using Microsoft.EntityFrameworkCore;

namespace VineBasementHelpers.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void AddPrefixToColumnAndTableName(this ModelBuilder modelBuilder, string prefix)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                
                entity.SetTableName(entity.GetTableName().Insert(0, prefix));

                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(prefix + property.Name);
                }
            }
        }
    }
}
