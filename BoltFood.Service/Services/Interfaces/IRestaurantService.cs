using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    public interface IRestaurantService
    {
        public Task<string> CreateAsync(string Name, string Adress,string PhoneNumber,RestaurantCategoryEnum restaurantCategory);
        public Task<string> DeleteAsync(int Id);
        
        public Task<Restaurant> GetAsync(int Id);

        public Task<List<Restaurant>> GetAllAsync();

        public Task<string> Update(string Name, string Adress, string PhoneNumber, RestaurantCategoryEnum restaurantCategory,int id);
      
    }
}
