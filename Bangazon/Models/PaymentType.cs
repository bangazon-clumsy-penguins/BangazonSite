using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bangazon.Models
{
  public class PaymentType
  {
    [Key]
    public int PaymentTypeId { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime DateCreated { get; set; }

    [Required]
    [StringLength(20)]
    public string Description { get; set; }

    [Required]
    [StringLength(20)]
    public string AccountNumber { get; set; }

    [Required]
    public string ApplicationUserId {get; set;}

    [Required]
    public ApplicationUser ApplicationUser { get; set; }

    public ICollection<Order> Orders { get; set; }
  }
}
