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

            builder.HasOne<Article>(m => m.Article).WithMany(c => c.Comments).HasForeignKey(m => m.ArticleId);
            builder.ToTable("Comments");

            builder.HasData(

            new Comment
            {
                Id = 1,
                ArticleId = 1,
                Text = "rçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır ",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Javascript Kategori ekleme"
            },
            new Comment
            {
                Id = 2,
                ArticleId = 1,
                Text = "rçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır ",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Javascript Kategori ekleme"
            }
            , new Comment
            {
                Id = 3,
                ArticleId = 2,
                Text = "rçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır ",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "Javascript Kategori ekleme"
            },
             new Comment
             {
                 Id = 4,
                 ArticleId = 3,
                 Text = "rçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır ",
                 IsActive = true,
                 IsDeleted = false,
                 CreatedByName = "InitialCreate",
                 CreatedDate = DateTime.Now,
                 ModifiedByName = "InitialCreate",
                 ModifiedDate = DateTime.Now,
                 Note = "Javascript Kategori ekleme"
             },
              new Comment
              {
                  Id = 5,
                  ArticleId = 4,
                  Text = "rçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır ",
                  IsActive = true,
                  IsDeleted = false,
                  CreatedByName = "InitialCreate",
                  CreatedDate = DateTime.Now,
                  ModifiedByName = "InitialCreate",
                  ModifiedDate = DateTime.Now,
                  Note = "Javascript Kategori ekleme"
              },
               new Comment
               {
                   Id = 6,
                   ArticleId = 4,
                   Text = "rçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır ",
                   IsActive = true,
                   IsDeleted = false,
                   CreatedByName = "InitialCreate",
                   CreatedDate = DateTime.Now,
                   ModifiedByName = "InitialCreate",
                   ModifiedDate = DateTime.Now,
                   Note = "Javascript Kategori ekleme"
               }


            );
        }
    }
}
