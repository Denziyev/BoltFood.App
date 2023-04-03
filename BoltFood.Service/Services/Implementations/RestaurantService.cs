using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using BoltFood.Core.Repositories;
using BoltFood.Data;
using BoltFood.Service.Elaveler;
using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoltFood.Service.Services.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();
        
        public async Task<string> CreateAsync(string Name, string Adress, string PhoneNumber, RestaurantCategoryEnum restaurantCategory)
        {
            if (!(!string.IsNullOrEmpty(Name) && Name.Length > 2 && Name.Length < 12))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Mehsul adi 3-12 simvoldan ibaret olmalidi";
            }
            if (!(!string.IsNullOrEmpty(Adress) && Adress.Length > 6 && Adress.Length < 22))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Adress 7-22 simvoldan ibaret olmalidi";
            }
            if (!(!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.Length > 7 && PhoneNumber.Length <= 12))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Phone Number 8-12 simvoldan ibaret olmalidi";
            }
           



            Restaurant restaurant=new Restaurant(Name, Adress, PhoneNumber, restaurantCategory);
            restaurant.CreatedTime= DateTime.Now;
            await _restaurantRepository.AddAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return "Restoran ugurla elave olundu";

        }

        public async Task<string> DeleteAsync(int Id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == Id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Restoran tapilmadi";
            }
            _restaurantRepository.DeleteAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return "Restoran ugurla silindi";
        }

        public async Task<List<Restaurant>> GetAllAsync()=>await _restaurantRepository.GetAllAsync();

        public async Task<Restaurant> GetAsync(int Id)
        {
            Restaurant Restaurant = await _restaurantRepository.GetAsync(x => x.Id == Id);
            if (Restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Consol.MyerrorWriteLine("Axtardiniz ID-ye uygun restoran tapilmadi");
                
            }
            return Restaurant;
        }

        public async Task<string> Update(string Name, string Adress, string PhoneNumber, RestaurantCategoryEnum restaurantCategory,int id)
        {
            Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Id == id);
            if (restaurant == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Restoran tapilmadi";
            }
            if(!(!string.IsNullOrEmpty(Name) && Name.Length > 2 && Name.Length < 12))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Mehsul adi 3-12 simvoldan ibaret olmalidi";
            }
            if (!(!string.IsNullOrEmpty(Adress) && Adress.Length > 6 && Adress.Length < 22))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Adress 7-22 simvoldan ibaret olmalidi";
            }
            if (!(!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.Length > 7 && PhoneNumber.Length <= 12))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Phone Number 8-12 simvoldan ibaret olmalidi";
            }
            restaurant.Name = Name;
            restaurant.Address= Adress;
            restaurant.PhoneNumber= PhoneNumber;
            restaurant.RestaurantCategory= restaurantCategory;
            restaurant.LastUpdatedTime= DateTime.Now;
            await _restaurantRepository.UpdateAsync(restaurant);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return "Restoran ugurla edit olundu";
        }
    }
}
