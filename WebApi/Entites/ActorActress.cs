namespace WebApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
public class ActorActress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public int MovieId { get; set; }
        //public Movie Movie { get; set; } // rol aldığı filmler

    }