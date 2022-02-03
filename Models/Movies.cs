using System.ComponentModel.DataAnnotations;
namespace Assessment5.Models
{
    public class Movies
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Movie_Type { get; set; }
        public string Language { get; set; }
    }
}
