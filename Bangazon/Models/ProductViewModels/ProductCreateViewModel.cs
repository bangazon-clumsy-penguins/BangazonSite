using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bangazon.Models.ProductViewModels
{
    public class ProductCreateViewModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime DateCreated { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [StringLength(55, ErrorMessage = "Please shorten the product title to 55 characters")]
        public string Title { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The Value must be a positive integer greater than 0")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [LessThan10k]
        public double Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The Value must be a positive integer greater than 0")]
        public int Quantity { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Product Category")]
        public int ProductTypeId { get; set; }

        public SelectList Products { get; set; }

        public ProductType ProductType { get; set; }

        public class LessThan10k : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                Product product = (Product)validationContext.ObjectInstance;

                if (product.Price > 10000)
                {
                    return new ValidationResult("Item price cannot exceed $10,000.");
                }

                return ValidationResult.Success;
            }
        }
    }
}
