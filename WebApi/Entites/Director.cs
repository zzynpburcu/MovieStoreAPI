namespace WebApi.Entities;
using System.ComponentModel.DataAnnotations.Schema;
public class Director
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    // public List<Movie> MoviesDirected { get; set; }
}