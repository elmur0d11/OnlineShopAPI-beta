using System.ComponentModel.DataAnnotations;

namespace CommandAPI.Dtos
{
    public class LikedProductReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Price { get; set; }

        public int Balance { get; set; }
    }
}
