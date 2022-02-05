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
    public class ArticleMap : IEntityTypeConfiguration<Article>
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

            builder.HasData(
                new Article
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "csharp 9 ve dotnet yenilikleri",
                    Content = "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                    Thumbnail = "default.jpg",
                    SeoDescription = "csharp 9 ve dotnet yenilikleri",
                    SeoTags = "c#,dotnet",
                    SeoAuthor = "Nuh Çolakkadıoğlu",
                    Date = DateTime.Now,
                    UserId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "csharp 9 ve dotnet yenilikleri ekleme",
                    ViewsCount = 100,
                    CommentCount = 1
                },
                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "MySql yenilikleri",
                    Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "default.jpg",
                    SeoDescription = "MySql yenilikleri",
                    SeoTags = "mysql",
                    SeoAuthor = "Nuh Çolakkadıoğlu",
                    Date = DateTime.Now,
                    UserId = 1,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "MySql yenilikleri ",
                    ViewsCount = 352,
                    CommentCount = 1
                },
                new Article
                 {
                     Id = 3,
                     CategoryId = 3,
                     Title = "ef core 9 ve dotnet yenilikleri",
                     Content = "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                     Thumbnail = "default.jpg",
                     SeoDescription = "ef core 9 ve dotnet yenilikleri",
                     SeoTags = "cefcore",
                     SeoAuthor = "Nuh Çolakkadıoğlu",
                     Date = DateTime.Now,
                     UserId = 1,
                     IsActive = true,
                     IsDeleted = false,
                     CreatedByName = "InitialCreate",
                     CreatedDate = DateTime.Now,
                     ModifiedByName = "InitialCreate",
                     ModifiedDate = DateTime.Now,
                     Note = "ef core 9 ve dotnet yenilikleri",
                     ViewsCount = 1555,
                     CommentCount = 1
                 },
                new Article
                  {
                      Id = 4,
                      CategoryId = 4,
                      Title = "javasript ES6 ve sonrası",
                      Content = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakt",
                      Thumbnail = "default.jpg",
                      SeoDescription = "javasript ES6 ve sonrası",
                      SeoTags = "javascript,es6",
                      SeoAuthor = "Nuh Çolakkadıoğlu",
                      Date = DateTime.Now,
                      UserId = 1,
                      IsActive = true,
                      IsDeleted = false,
                      CreatedByName = "InitialCreate",
                      CreatedDate = DateTime.Now,
                      ModifiedByName = "InitialCreate",
                      ModifiedDate = DateTime.Now,
                      Note = "javasript ES6 ve sonrası",
                      ViewsCount = 78,
                      CommentCount = 1
                  },
                new Article
                   {
                       Id = 5,
                       CategoryId = 1,
                       Title = "test data sonrası",
                       Content = "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakt",
                       Thumbnail = "default.jpg",
                       SeoDescription = "javasript ES6 ve sonrası",
                       SeoTags = "test data sonrası,es6",
                       SeoAuthor = "Nuh Çolakkadıoğlu",
                       Date = DateTime.Now,
                       UserId = 1,
                       IsActive = true,
                       IsDeleted = false,
                       CreatedByName = "InitialCreate",
                       CreatedDate = DateTime.Now,
                       ModifiedByName = "InitialCreate",
                       ModifiedDate = DateTime.Now,
                       Note = "test data sonrası",
                       ViewsCount = 98,
                       CommentCount = 1
                   }
                );

        }
    }
}
