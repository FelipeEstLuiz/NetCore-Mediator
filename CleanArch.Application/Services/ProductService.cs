﻿using AutoMapper;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Products.Commands;
using CleanArch.Application.Products.Queries;
using CleanArch.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            GetProductsQuery productsQuery = new();

            if (productsQuery == null)
                throw new Exception("Entity could not be load.");

            IEnumerable<Product> result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDto>>(result);
        }

        public async Task<ProductDto> GetProductByIdAsync(int? id)
        {
            GetProductByIdQuery productByIdQuery = new(id.Value);

            if (productByIdQuery == null)
                throw new Exception("Entity could not be load.");

            Product result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDto>(result);
        }

        public async Task CreateProductyAsync(ProductDto product)
        {
            ProductCreateCommand productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateProductyAsync(ProductDto product)
        {
            ProductUpdateCommand productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task DeleteProductyAsync(int? id)
        {
            ProductRemoveCommand productRemoveCommand = new(id.Value);

            if (productRemoveCommand == null)
                throw new Exception("Entity could not be load.");

            await _mediator.Send(productRemoveCommand);
        }
    }
}
