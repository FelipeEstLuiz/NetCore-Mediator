using CleanArch.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductByIdAsync(int? id);
        Task<ProductDto> GetProductCategoryAsync(int? id);    
        Task CreateProductyAsync(ProductDto product);
        Task UpdateProductyAsync(ProductDto product);   
        Task DeleteProductyAsync(int? id);  
    }
}
