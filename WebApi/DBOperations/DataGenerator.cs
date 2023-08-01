using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }
                  //Aktörler
                context.AddRange(
                    new ActorActress { Name = "Jeff", Surname = "Bridges" },
                    new ActorActress { Name = "Matt", Surname = "Damon" },
                    new ActorActress { Name = "John", Surname = "Goodman" },
                    new ActorActress { Name = "Ben", Surname = "Affleck" },
                    new ActorActress { Name = "Tom", Surname = "Hanks" });

                //Yönetmenler
                context.AddRange(
                    new Director { Name = "Joel", Surname = "Coen" },
                    new Director { Name = "Steven", Surname = "Spielberg" },
                    new Director { Name = "David", Surname = "Fincher" });

                //Janralar
                context.AddRange(
                    new Genre { GenreTitle = "Western" },
                    new Genre { GenreTitle = "Comedy" },
                    new Genre { GenreTitle = "Drama" });

                //Filmler
                context.AddRange(
                    new Movie { DirectorId = 1, GenreId = 2, Price = 49.90, Title = "Big Lebowski" },
                    new Movie { DirectorId = 1, GenreId = 1, Price = 44.90, Title = "True Grit" },
                    new Movie { DirectorId = 2, GenreId = 3, Price = 34.90, Title = "Saving Private Ryan" },
                    new Movie { DirectorId = 3, GenreId = 3, Price = 34.90, Title = "Gone Girl" });

                //Film-Aktör ilişkileri
                context.AddRange(
                    new ActorActressMovieJoint { ActorActressId = 1, MovieId = 1 },
                    new ActorActressMovieJoint { ActorActressId = 3, MovieId = 1 },
                    new ActorActressMovieJoint { ActorActressId = 1, MovieId = 2 },
                    new ActorActressMovieJoint { ActorActressId = 2, MovieId = 3 },
                    new ActorActressMovieJoint { ActorActressId = 4, MovieId = 4 });

                context.SaveChanges();
            }
        }
    }
}