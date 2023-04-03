using BoltFood.Core.Enums;
using BoltFood.Core.Models.BaseModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Core.Models
{
    public class Restaurant:Base
    {
        
        public string Name { get; set; }
        public RestaurantCategoryEnum RestaurantCategory { get; set; }

        public string Address { get;set; }

        public string PhoneNumber { get; set; }
        public List<Product> Products { get; set; }

        static int _id = 0;
        public Restaurant(string Name, string Adress, string PhoneNumber, RestaurantCategoryEnum restaurantCategory)
        {
            _id++;
            Id= _id;

            Products = new List<Product>();
            this.Name = Name;
            this.Address = Adress;
            this.PhoneNumber = PhoneNumber;
            this.RestaurantCategory = restaurantCategory;
        }

        public override string ToString()
        {
            return $"Restaurant Name:{Name}, Category:{RestaurantCategory}, Address:{Address}, Phone_Number:{PhoneNumber} Created_Time:{CreatedTime}, Last_Updated_Time:{LastUpdatedTime}, Id:{Id}";
        }
    }
}
