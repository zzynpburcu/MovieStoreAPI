using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefresToken { get; set; }
        public DateTime RefreshTokenExpDate { get; set; }
        public virtual ICollection<Genre> FavGenre { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}