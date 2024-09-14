using System.ComponentModel.DataAnnotations;

namespace DeveloperTask.Models
{
    public class Product
    {
       
        [Key]
        public int ProductId { get; set; }

        [Required (ErrorMessage = "Product Name is required.")]

        public string ProductName { get; set; }

        [Required]
        [Range(0.01, (double)decimal.MaxValue, ErrorMessage = "Price must be a positive number.")]

        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Quantity cannot be negative.")]

        public int Quantity { get; set; }   



    }
}
