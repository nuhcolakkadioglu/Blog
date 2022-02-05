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
   public class ArticleMap:IEntityTypeConfiguration<Article>
    {
 
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Title).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Content).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(m => m.Date).IsRequired();
            builder.Property(m => m.SeoAuthor).IsRequired().HasMaxLength(50);
            builder.Property(m => m.SeoDescription).IsRequired().HasMaxLength(150);
            builder.Property(m => m.SeoTags).IsRequired().HasMaxLength(70);
            builder.Property(m => m.ViewsCount).IsRequired();
            builder.Property(m => m.CommentCount).IsRequired();
            builder.Property(m => m.Thumbnail).IsRequired().HasMaxLength(250);

            builder.Property(m => m.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();
            builder.Property(m => m.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Articles).HasForeignKey(m => m.CategoryId);
            builder.HasOne<User>(a => a.User).WithMany(u => u.Articles).HasForeignKey(m => m.UserId);
            builder.ToTable("Articles");

           
        }
    }
}
