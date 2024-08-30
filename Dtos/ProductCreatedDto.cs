using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Dtos
{
    public class ProductCreatedDto
    {
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
