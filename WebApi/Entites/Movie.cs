using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
     public class Movie
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public Director Director { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public double Price { get; set; }
        public virtual ICollection<ActorActressMovieJoint> ActorActressMovieJoint { get; set; }
    }
}