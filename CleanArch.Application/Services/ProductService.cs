using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            IEnumerable<Product> products = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            Product products = await _productRepository.GetProductById(id);
            return _mapper.Map<ProductDto>(products);
        }

        public async Task<ProductDto> GetProductCategoryAsync(int? id)
        {
            Product products = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDto>(products);
        }

        public async Task CreateProductyAsync(ProductDto product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            await _productRepository.CreateAsync(productEntity);
        }

        public async Task UpdateProductyAsync(ProductDto product)
        {
            Product productEntity = _mapper.Map<Product>(product);
            await _productRepository.UpdateAsync(productEntity);
        }

        public async Task DeleteProductyAsync(int? id)
        {
            Product product = _productRepository.GetProductById(id).Result;
            await _productRepository.RemoveAsync(product);
        }
    }
}
