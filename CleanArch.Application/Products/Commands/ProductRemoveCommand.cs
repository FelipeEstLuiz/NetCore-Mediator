using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Products.Commands
{
    public struct ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; private set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
