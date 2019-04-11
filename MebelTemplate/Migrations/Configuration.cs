namespace MebelTemplate.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MebelTemplate.DAL.Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MebelTemplate.DAL.Db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(h => new { h.CatName, h.Id },
              new Models.CategoryDTO
              {
                  Id = 1,
                  CatName = "BAMBOO BASKET"
              },
              new Models.CategoryDTO
              {
                  Id = 2,
                  CatName = "CLASSIC DESK LAM"
              },
              new Models.CategoryDTO
              {
                  Id = 3,
                  CatName = "FURNITURE"
              },
              new Models.CategoryDTO
              {
                  Id = 4,
                  CatName = "KITCHEN & BAR"
              },
              new Models.CategoryDTO
              {
                  Id = 5,
                  CatName = "BATHROOM"
              });
            context.SaveChanges();

            context.Homes.AddOrUpdate(h => new { h.HeaderTitle, h.Image },
                new Models.HomeDTO
                {
                    Id = 1,
                    HeaderTitle = "WOOFLAMP",
                    HeaderPrice = "$99.11",
                    Image = "1.jpg"
                },
                new Models.HomeDTO
                {
                    Id = 2,
                    HeaderTitle = "WOOFLkjhAMP",
                    HeaderPrice = "10% of all products",
                    Image = "2.jpg"
                });

            context.Services.AddOrUpdate(h => new { h.ServicesTitle, h.ServicesContent, h.Image },
                 new Models.ServicesDTO
                 {
                     ServicesTitle = "FREE SHIPPING ON ODER OVER 500$",
                     ServicesContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit auctor nibh.",
                     Image = "1.png"
                 },
                 new Models.ServicesDTO
                 {
                     ServicesTitle = "ONLINE SUPPORT 24/7",
                     ServicesContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit auctor nibh.",
                     Image = "2.png"
                 },
                 new Models.ServicesDTO
                 {
                     ServicesTitle = "100% MONEY BACK GUARANTEE",
                     ServicesContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit auctor nibh.",
                     Image = "3.png"
                 });

            context.Banners.AddOrUpdate(h => new { h.BannerContent, h.CategoryId, h.Image },
                new Models.BannerDTO
                {
                    Id = 1,
                    CategoryId = 1,
                    BannerContent = "Pellentesque eu porttitor magna. Donec aliquet elementum eros, et elementum purus varius sit amet.",
                    Image = "4_1.jpg"
                },
                new Models.BannerDTO
                {
                    Id = 1,
                    CategoryId = 2,
                    BannerContent = "Pellentesque eu porttitor magna. Donec aliquet elementum eros, et elementum purus varius sit amet.",
                    Image = "6_1.jpg"
                },
                new Models.BannerDTO
                {
                    Id = 1,
                    CategoryId = 3,
                    BannerContent = "Pellentesque eu porttitor magna. Donec aliquet elementum eros, et elementum purus varius sit amet.",
                    Image = "7_1.jpg"
                },
                new Models.BannerDTO
                {
                    Id = 1,
                    CategoryId = 4,
                    BannerContent = "Pellentesque eu porttitor magna. Donec aliquet elementum eros, et elementum purus varius sit amet.",
                    Image = "8_1.jpg"
                },
                new Models.BannerDTO
                {
                    Id = 2,
                    CategoryId = 5,
                    BannerContent = "Pellentesque eu porttitor magna. Donec aliquet elementum eros, et elementum purus varius sit amet.",
                    Image = "9_1.jpg"
                });

            context.Users.AddOrUpdate(h => new { h.FirstName, h.LastName, h.Password, h.Username },
              new Models.UserDTO
              {
                  Id = 1,
                  FirstName = "Asef",
                  LastName = "Almemmedov",
                  Username = "Asef",
                  Password = "123456"
              }, new Models.UserDTO
              {
                  Id = 2,
                  FirstName = "Aslan",
                  LastName = "Aslanov",
                  Username = "Aslan",
                  Password = "123456"
              });
            context.Roles.AddOrUpdate(h => new { h.Id, h.Name },
             new Models.RoleDTO
             {
                 Id = 1,
                 Name = "Admin"
             }, new Models.RoleDTO
             {
                 Id = 2,
                 Name = "User"
             });
            context.UserRols.AddOrUpdate(h => new { h.Id, h.RoleId,h.UserId },
          new Models.UserRolsDTO
          {
              Id = 1,
              UserId = 1,
              RoleId=1
          }, new Models.UserRolsDTO
          {
              Id = 2,
              UserId =2,
              RoleId=2
          });

        }
    }
}
