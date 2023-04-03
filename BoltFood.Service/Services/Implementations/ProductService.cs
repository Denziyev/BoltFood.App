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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BoltFood.Service.Services.Implementations
{
    public class ProductService : IProductService
    {
        readonly IRestaurantRepository _restaurantRepository = new RestaurantRepository();
        public async Task<string> CreateAsync(string name, double price, ProductCategoryEnum productCategory, string restaurantname)
        {
             Restaurant restaurant= await  _restaurantRepository.GetAsync(x => x.Name== restaurantname);

            if (restaurant==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Bele restoran tapilmadi";
                
            }

            if (!(!string.IsNullOrEmpty(name) && name.Length > 2 && name.Length < 12))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Mehsul adi 3-12 simvoldan ibaret olmalidi";
                
            }

            if (!(price > 0))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "Qiymeti yanlis daxil etmisiniz";
            }
            
            Product product=new Product(name,price,productCategory,restaurant);

            product.CreatedTime = DateTime.Now;
            

            
            restaurant.Products.Add(product);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            return "Mehsul ugurla elave olundu";
        }

        public async Task<string> DeleteAsync(int Id)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(x => x.Id == Id);
                
                if (product != null)
                {
                    item.Products.Remove(product);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    return "Product ugurla silindi";
                }
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Bele mehsul tapilmadi";
        }

        public async Task<List<Product>> GetAllAsync()
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();
            List<Product> products = new List<Product>();

            foreach(Restaurant items  in restaurants)
            {                
                products.AddRange(items.Products);
            }
            return products;
        }


        public async Task<Product> GetAsync(int Id)
        {
            List<Restaurant> restaurants = await _restaurantRepository.GetAllAsync();

            foreach (var item in restaurants)
            {
                Product product = item.Products.Find(x => x.Id == Id); 
                if(product != null)
                {
                    return product;
                }
            }
            return null;
        }

        public async Task<string> UpdateAsync(string name, double price, ProductCategoryEnum productCategory, string restaurantname,int id)
        {
            List<Restaurant> restaurants =await _restaurantRepository.GetAllAsync();

            foreach(var item in restaurants)
            {
                Product product=item.Products.Find(x=>x.Id == id);
                Restaurant restaurant = await _restaurantRepository.GetAsync(x => x.Name == restaurantname);
                if (product != null)
                {
                    if (restaurant == null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        return "Bele restoran tapilmadi";
                    }

                    if (!(!string.IsNullOrEmpty(name) && name.Length > 2 && name.Length < 12))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        return "Mehsul adi 3-12 simvoldan ibaret olmalidi";
                    }

                    if (!(price > 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        return "Qiymeti yanlis daxil etmisiniz";
                    }

                    product.Price = price;
                    product.ProductCategory = productCategory;
                    product.Name = name;
                    product.restaurant = restaurant;
                    product.LastUpdatedTime = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    return "Product ugurla edit olundu";
                }                
            }
            Console.ForegroundColor = ConsoleColor.Red;
            return "Bele mehsul tapilmadi";

        }
    }
}
