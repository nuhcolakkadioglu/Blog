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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();
            builder.Property(m => m.Text).IsRequired().HasMaxLength(1000);

            builder.Property(m => m.CreatedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.ModifiedByName).IsRequired().HasMaxLength(50);
            builder.Property(m => m.CreatedDate).IsRequired();
            builder.Property(m => m.ModifiedDate).IsRequired();
            builder.Property(m => m.IsActive).IsRequired();
            builder.Property(m => m.IsDeleted).IsRequired();
            builder.Property(m => m.Note).HasMaxLength(500);

            builder.HasOne<Article>(m => m.Article).WithMany(c => c.Comments).HasForeignKey(m=>m.ArticleId);
            builder.ToTable("Comments");
        }
    }
}
