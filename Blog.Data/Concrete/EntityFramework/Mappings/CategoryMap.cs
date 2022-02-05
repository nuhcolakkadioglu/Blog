using Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(80);
            builder.Property(m => m.Description).HasMaxLength(250);

            builder.Property(m => m.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();
            builder.Property(m => m.Note).HasMaxLength(500);

            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "C#",
                    Description = "csharp ile ilgili makaleler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Javascript Kategori ekleme"
                },
                new Category
                {
                    Id = 2,
                    Name = "Mssql",
                    Description = "Mssql ile ilgili makaleler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = " Javascript Kategori ekleme"
                },
                 new Category
                 {
                     Id = 3,
                     Name = "Ef Core",
                     Description = "Ef Core ile ilgili makaleler",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Javascript Kategori ekleme"
                 },
                 new Category
                 {
                     Id = 4,
                     Name = "Javascript",
                     Description = "Javascript ile ilgili makaleler",
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "Kategori Javascript ekleme"
                 }
            );
        }
    }
}
