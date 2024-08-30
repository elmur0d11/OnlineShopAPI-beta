using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Models
{
    public class BuyedProduct
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductPrice { get; set; }

        [Required]
        public DateTime BuyedDate { get; set; }
    }
}
