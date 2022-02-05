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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
            builder.HasIndex(m => m.Email).IsUnique();
            builder.Property(m => m.UserName).IsRequired().HasMaxLength(20);
            builder.HasIndex(m => m.UserName).IsUnique();
            builder.Property(m => m.PasswordHash).IsRequired().HasColumnType("VARBINARY(500)");
            builder.Property(m => m.Description).HasMaxLength(500);
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(30);
            builder.Property(m => m.Picture).IsRequired().HasMaxLength(250);

            builder.Property(m => m.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();
            builder.Property(m => m.Note).HasMaxLength(500);

            builder.HasOne<Role>(r => r.Role).WithMany(u => u.Users).HasForeignKey(r => r.RoleId);

            builder.ToTable("Users");

            builder.HasData(new User
            {
                Id=1,
                RoleId=1,
                FirstName = "nuh",
                LastName ="çolakkadıoğlu",
                UserName="nck",
                Email = "nck@gmail.com",
                IsActive = true,
                IsDeleted =false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Admin eklendi",
                Description = "ilk admin eklendi",
                Picture = "https://hasanberatcihan.com/wp-content/uploads/2020/09/user-man.png",
                PasswordHash = Encoding.ASCII.GetBytes("a8f5f167f44f4964e6c998dee827110c")
            });

        }
    }
}
