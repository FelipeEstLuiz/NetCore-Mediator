﻿using CleanArch.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductById(int? id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(Product product);
    }
}
