using System.ComponentModel.DataAnnotations;

namespace WebStoreApi.Models
{
    public class SingleProductDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "The Address should be at least 5 characters")]
        [MaxLength(1000, ErrorMessage = "The Address should be less than 1000 characters")]
        public string Title { get; set; } = "";

        [Required]
        public int Price { get; set; }
    }

    public class ProductListDto
    {
        [Required]
        public List<SingleProductDto> products { get; set; } = new List<SingleProductDto>();
    }
}

