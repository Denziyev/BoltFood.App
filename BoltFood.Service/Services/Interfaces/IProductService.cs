
using BoltFood.Core.Enums;
using BoltFood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
    public interface IProductService
    {
        public Task<string> CreateAsync(string name, double price, ProductCategoryEnum productCategory, string restaurantname);
        public Task<string> DeleteAsync(int Id);

        public Task<Product> GetAsync(int Id);

        public Task<string> UpdateAsync(string name, double price, ProductCategoryEnum productCategory, string restaurantname,int id);

        public Task<List<Product>> GetAllAsync();
    }
}
