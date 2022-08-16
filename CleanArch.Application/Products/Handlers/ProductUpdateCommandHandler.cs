using CleanArch.Application.Products.Commands;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetProductById(request.Id);

            if (product == null)
                throw new ApplicationException("Entity could not be found");

            product.Update(
                request.Name,
                request.Description,
                request.Price,
                request.Stock,
                request.Image,
                request.CategoryId
            );

            return await _productRepository.UpdateAsync(product);
        }
    }
}
