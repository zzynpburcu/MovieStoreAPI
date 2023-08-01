using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class ActorActressMovieJoint
    {
       
             [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ActorActressId { get; set; }
        public ActorActress actorActress { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}