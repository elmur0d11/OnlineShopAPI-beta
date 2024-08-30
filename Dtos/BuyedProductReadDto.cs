using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Dtos
{
    public class BuyedProductReadDto
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public string ProductPrice { get; set; }

        public DateTime BuyedDate { get; set; }
    }
}
