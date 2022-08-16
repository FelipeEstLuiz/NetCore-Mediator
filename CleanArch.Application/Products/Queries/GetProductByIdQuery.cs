﻿using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Queries
{
    public struct GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; private set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}