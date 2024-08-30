using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Dtos
{
    public class BuyedProductCreatedDto
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductPrice { get; set; }
    }
}
