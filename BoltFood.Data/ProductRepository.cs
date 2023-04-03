using BoltFood.Core.Models;
using BoltFood.Core.Repositories;
using BoltFood.Data.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Data
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

    }
}
