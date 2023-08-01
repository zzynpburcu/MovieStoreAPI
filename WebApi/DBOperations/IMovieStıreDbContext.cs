using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DBOperations
{
    public interface IMovieStoreDbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorActress> ActorActress { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ActorActressMovieJoint> actorActressMovieJoints { get; set; }

        int SaveChanges();
    }
}