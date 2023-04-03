using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Product:Base
    {
        
        public string Name { get; set; }
        public double Price { get; set; }
        public ProductCategoryEnum ProductCategory { get; set; }

        public Restaurant restaurant { get; set; }

        static int _id = 0;

        public Product(string name, double price, ProductCategoryEnum productCategory, Restaurant restaurant)
        {
            _id++;
            Id= _id;

            this.Name = name;
            this.Price = price;
            this.ProductCategory = productCategory;
            this.restaurant = restaurant;
        }

        public override string ToString()
        {
            return $"Product Name:{Name}, RestaurantName:{restaurant.Name}, Price:{Price}, Category:{ProductCategory}, Created_Time:{CreatedTime}, Last_Updated_Time:{LastUpdatedTime}  Id:{Id}";
        }
    }
}
