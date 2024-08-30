using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int Balance { get; set; }
    }
}
