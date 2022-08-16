using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Categories.Commands
{
    public class CategoryRemoveCommand : IRequest<Category>
    {
        public int Id { get; private set; }

        public CategoryRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
