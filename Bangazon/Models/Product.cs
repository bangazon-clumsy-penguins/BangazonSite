using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bangazon.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Date Created")]
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
        [PriceValidation]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "The Value must be a positive integer greater than 0")]
        [Display (Name = "Quantity Remaining")]
        public int Quantity { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [Display(Name = "User")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        [NotZero]
        [Display(Name = "Product Category ID")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Product Category")]
        public ProductType ProductType { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public class NotZero : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                Product product = (Product)validationContext.ObjectInstance;

                if (product.ProductTypeId == 0)
                {
                    return new ValidationResult("Must Select a product type");
                }
                return ValidationResult.Success;
            }
        }

        public class PriceValidation : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                Product product = (Product)validationContext.ObjectInstance;

                if (product.Price <= 0)
                {
                    return new ValidationResult("Please enter a value greater than 0");
                }

                if (product.Price > 10000)
                {
                    return new ValidationResult("Item price cannot exceed $10,000.");
                }

                return ValidationResult.Success;
            }
        }

    }
}
