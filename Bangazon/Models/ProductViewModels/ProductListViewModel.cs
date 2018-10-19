using System.Collections.Generic;
using Bangazon.Models;
using Bangazon.Data;
using Microsoft.EntityFrameworkCore;

namespace Bangazon.Models.ProductViewModels
{
  public class ProductListViewModel
  {
        public List<Product> Products { get; set; }

        public ProductListViewModel()
        {
            
        }
  }
}