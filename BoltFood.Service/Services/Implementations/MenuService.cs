using BoltFood.Core.Enums;
using BoltFood.Core.IRepositories.BaseIRepositories;
using BoltFood.Core.Models;
using BoltFood.Service.Elaveler;

using BoltFood.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Implementations
{
    public class MenuService : IMenuService
    {
        readonly IProductService _productservice = new ProductService();
        readonly IRestaurantService _restaurantservice= new RestaurantService();
        public async Task ShowMenuAsync()
        {
            ShowAsync();
            string request=Console.ReadLine();
            while (request != "0")
            {
                switch(request)
                {
                    case "1":
                        CreateRestaurantAsync();
                        break;
                    case "2":
                        ShowRestaurantAsync();
                        break;
                    case "3":
                        ShowAllRestaurantAsync();
                        break;
                    case "4":
                        UpdateRestaurantAsync();
                        break;
                    case "5":
                        DeleteRestaurantAsync();
                        break;
                    case "6":
                        CreateProductAsync();
                        break;
                    case "7":
                        ShowProductAsync();
                        break;
                    case "8":
                        ShowAllProductAsync();
                        break;
                    case "9":
                        UpdateProductAsync();
                        break;
                    case "10":
                        DeleteProductAsync();
                        break;
                    default:
                        Consol.MyWriteLine("Yalniz 0-10 reqemlerini daxil ede bilersiniz");
                        break;
                           
                }
                ShowAsync();
                request = Console.ReadLine();
            }
            

            //---------------------------------------Create---------------------------------------------------------------------------------


            async Task CreateRestaurantAsync()
            {
                Consol.MyWriteLine("Restoran adini daxil edin:");
                string name=Console.ReadLine();
                Consol.MyWriteLine("Restoran addresini daxil edin:");
                string  address=Console.ReadLine();
                Consol.MyWriteLine("Restoran Mobil nomresini daxil edin:");
                string phoneNumber=Console.ReadLine();
                                               
                Consol.MyWriteLine("Restoran kategoriyasini secin");
                var Enums = Enum.GetValues(typeof(RestaurantCategoryEnum));
                foreach (var item in Enums)
                {
                    Console.WriteLine((int)item + "." + item);
                }
                int.TryParse(Console.ReadLine(), out int RestaurantCategory);

                try
                {
                    Enums.GetValue(RestaurantCategory - 1);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Restoran kateqoriyasini yanlis daxil etmisiniz");
                    Console.ForegroundColor = ConsoleColor.Green;
                    return;
                }

                string msg = await _restaurantservice.CreateAsync(name, address, phoneNumber, (RestaurantCategoryEnum)RestaurantCategory);
                Console.WriteLine(msg);
            }


            async Task CreateProductAsync()
            {
                Consol.MyWriteLine("Mehsul adini daxil edin:");
                string name = Console.ReadLine();
                Consol.MyWriteLine("Mehsul qiymetini daxil edin:");
                string price1 = Console.ReadLine();

                CheckPrice(price1);
                double price2 = double.Parse(price1);

                Consol.MyWriteLine("Mehsul kategoriyasini secin");
                var Enums = Enum.GetValues(typeof(ProductCategoryEnum));
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var item in Enums)
                {
                    Console.WriteLine((int)item + "." + item);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                int.TryParse(Console.ReadLine(), out int ProductCategory);

                try
                {
                    Enums.GetValue(ProductCategory - 1);
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Mehsul kateqoriyasini yanlis daxil etmisiniz");
                    Console.ForegroundColor = ConsoleColor.Green;
                    return;
                }
                Consol.MyWriteLine("Mehsulu elave etmek istediyiniz restoran adini daxil edin:");
                string Restaurantname = Console.ReadLine();


                string msg = await _productservice.CreateAsync(name, price2, (ProductCategoryEnum)ProductCategory, Restaurantname);
                Console.WriteLine(msg);


               

            }
            async Task CheckPrice(string price1)
            {
                try
                {
                    double price = double.Parse(price1);
                }
                catch (Exception)
                {
                    Consol.MyerrorWriteLine("Qiymeti yanlis daxil etmisiniz");
                }

            }

            //------------------------------------Show-------------------------------------------------------------------------------------------------

            async Task ShowAllRestaurantAsync()
            {
                List<Restaurant> restaurants=await _restaurantservice.GetAllAsync();
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var items in restaurants)
                {
                    Console.WriteLine(items);
                }
                Console.ForegroundColor = ConsoleColor.Green;
            }

            async Task ShowRestaurantAsync()
            {
                Consol.MyWriteLine("Axtardiginiz restoranin ID-sini daxil edin:");
                int.TryParse( Console.ReadLine(), out int id);
                Restaurant restaurant = await _restaurantservice.GetAsync(id);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(restaurant);
                Console.ForegroundColor = ConsoleColor.Green;
            }


            async Task ShowAllProductAsync()
            {
                List<Product> products = await _productservice.GetAllAsync();
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var items in products)
                {
                    Console.WriteLine(items);
                }
                Console.ForegroundColor = ConsoleColor.Green;
            }

            async Task ShowProductAsync()
            {
                Consol.MyWriteLine("Axtardiginiz Mehsulun Id sini daxil edin:");
                int.TryParse(Console.ReadLine(), out int id);

                Product product=await _productservice.GetAsync(id);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(product);
                Console.ForegroundColor = ConsoleColor.Green;

            }

            //--------------------------------------Delete-------------------------------------------------------------------------------------------


            async Task DeleteRestaurantAsync()
            {
                Consol.MyWriteLine("Silmek istediyiniz restoranin ID-sini daxil edin:");
                int.TryParse(Console.ReadLine(), out int id);
                
                Console.WriteLine(await _restaurantservice.DeleteAsync(id));

            }


            async Task DeleteProductAsync()
            {
                Consol.MyWriteLine("Silmek istediyiniz mehsulun Id sini daxil edin:");
                int.TryParse(Console.ReadLine(), out int id);

                string msg = await _productservice.DeleteAsync(id);
                Console.WriteLine(msg);
            }
            //-------------------------------------------Update--------------------------------------------------------------------------------------


            async Task UpdateRestaurantAsync()
            {
                Consol.MyWriteLine("Edit etmek istediyiniz Restoran Id sini daxil edin:");
                int.TryParse(Console.ReadLine(), out int id);

                Consol.MyWriteLine("Restoran adini daxil edin:");
                string name = Console.ReadLine();
                Consol.MyWriteLine("Restoran addresini daxil edin:");
                string address = Console.ReadLine();
                Consol.MyWriteLine("Restoran Mobil nomresini daxil edin:");
                string phoneNumber = Console.ReadLine();

                Consol.MyWriteLine("Restoran kategoriyasini secin");
                var Enums = Enum.GetValues(typeof(RestaurantCategoryEnum));
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var item in Enums)
                {
                    Console.WriteLine((int)item + "." + item);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                int.TryParse(Console.ReadLine(), out int RestaurantCategory);

                try
                {
                    Enums.GetValue(RestaurantCategory - 1);
                }
                catch (Exception)
                {                   
                    Consol.MyerrorWriteLine("Restoran kateqoriyasini yanlis daxil etmisiniz");
                    return;
                }               
                string msg = await _restaurantservice.Update(name,address,phoneNumber,(RestaurantCategoryEnum)RestaurantCategory,id);
                Consol.MyWriteLine(msg);

            }

            async Task UpdateProductAsync()
            {
                Consol.MyWriteLine("Edit etmek istediyiniz mehsulun Id sini daxil edin:");
                int.TryParse(Console.ReadLine(), out int id);

                Consol.MyWriteLine("Mehsul adini daxil edin:");
                string name = Console.ReadLine();
                Consol.MyWriteLine("Mehsul qiymetini daxil edin:");
                string price1 = Console.ReadLine();

                CheckPrice(price1);
                double price2 = double.Parse(price1);

                Consol.MyWriteLine("Mehsul kategoriyasini secin");
                var Enums = Enum.GetValues(typeof(ProductCategoryEnum));
                foreach (var item in Enums)
                {
                    Console.WriteLine((int)item + "." + item);
                }
                int.TryParse(Console.ReadLine(), out int ProductCategory);

                try
                {
                    Enums.GetValue(ProductCategory - 1);
                }
                catch (Exception)
                {
                    

                    Consol.MyerrorWriteLine("Mehsul kateqoriyasini yanlis daxil etmisiniz");
                    return;
                }
                Consol.MyWriteLine("Mehsulu elave etmek istediyiniz restoran adini daxil edin:");
                string Restaurantname = Console.ReadLine();


                string msg = await _productservice.UpdateAsync(name,price2,(ProductCategoryEnum)ProductCategory,Restaurantname,id);
                Consol.MyWriteLine(msg);

                CheckPrice( price1);
                
            }

            //------------------------------------------------------menyu---------------------------------------------------------------------------




            async Task ShowAsync()
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("0:Cixis ucun");
                Console.WriteLine("1:Restoran elave et");
                Console.WriteLine("2:Istediyiniz restoran haqqinda melumat elde etmek ucun");
                Console.WriteLine("3:Butun restoranlar haqqinda melumat elde etmek ucun");
                Console.WriteLine("4:Restoran melumatlarini edit etmek ucun");
                Console.WriteLine("5:Restorani silmek ucun");
                Console.WriteLine("6:Mehsul elave et");
                Console.WriteLine("7:Istediyiniz restoran haqqinda melumat elde etmek ucun");
                Console.WriteLine("8:Butun mehsullar haqqinda melumat elde etmek ucun");
                Console.WriteLine("9:Mehsul melumatlarini edit etmek ucun");
                Console.WriteLine("10:Mehsulu silmek ucun");
                Console.ForegroundColor= ConsoleColor.White;

            }
        }
    }
}
