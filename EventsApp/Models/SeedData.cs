
using EventsApp.Data;
using EventsApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ArticlesApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService
                <DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.Roles.Any())
                {
                    return; // if we have roles we do not create them again
                }


                context.Roles.AddRange(
                    new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", Name = "Admin", NormalizedName = "Admin".ToUpper() },
                    new IdentityRole { Id = "2c5e174e-3b0e-446f-86af-483d56fd7212", Name = "User", NormalizedName = "User".ToUpper() }
                );


                var hasher = new PasswordHasher<ApplicationUser>(); // the password hasher

                // here we add the users when we run the application
                context.Users.AddRange(
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb0",
                        UserName = "admin@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "ADMIN@TEST.COM",
                        Email = "admin@test.com",
                        NormalizedUserName = "ADMIN@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "Admin1!")
                    },
                    new ApplicationUser
                    {
                        Id = "8e445865-a24d-4543-a6c6-9443d048cdb2",
                        UserName = "user@test.com",
                        EmailConfirmed = true,
                        NormalizedEmail = "USER@TEST.COM",
                        Email = "user@test.com",
                        NormalizedUserName = "USER@TEST.COM",
                        PasswordHash = hasher.HashPassword(null, "User1!")
                    }
                );
                // here we needed to create the tags first, and save them , before
                // we could to the events, because an event is required to have a tag
                // so we first did the tags, saved them into a list, and then we assigned
                // to the tagId value, 1 position of that list between 0 and 2.
                var tags = new List<Tag>
                {
                    new Tag { TagName = "IT" },
                    new Tag { TagName = "NEWS" },
                    new Tag { TagName= "FINANCE" }
                };
                context.Tags.AddRange(tags);
                context.SaveChanges();

                // context.x.AddRange just adds a series of elements into your DB
                context.Events.AddRange(

                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test1",
                        Content = "Test1",
                        StartDate = Convert.ToDateTime("05/05/2005"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[2].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2015"),
                        EndDate = Convert.ToDateTime("05/05/2016"),
                        TagId = tags[2].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2017"),
                        EndDate = Convert.ToDateTime("05/05/2018"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test2",
                        Content = "Test2",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2009"),
                        TagId = tags[2].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test3",
                        Content = "Test3",
                        StartDate = Convert.ToDateTime("10/07/2012"),
                        EndDate = Convert.ToDateTime("05/05/2013"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }
                    ,
                    new Event
                    {
                        Title = "Test3",
                        Content = "Test3",
                        StartDate = Convert.ToDateTime("12/07/2022"),
                        EndDate = Convert.ToDateTime("05/05/2023"),
                        TagId = tags[0].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test3",
                        Content = "Test3",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[2].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    },
                    new Event
                    {
                        Title = "Test3",
                        Content = "Test3",
                        StartDate = Convert.ToDateTime("06/07/2008"),
                        EndDate = Convert.ToDateTime("05/05/2006"),
                        TagId = tags[1].Id,
                        Link = "https://nitronlp.rocks/en/schedule"
                    }

                    );

                context.UserRoles.AddRange(
                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb0"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7212",
                        UserId = "8e445865-a24d-4543-a6c6-9443d048cdb2"
                    }
                );
                // we save it and we're done
                context.SaveChanges();

            }
        }
    }
}
