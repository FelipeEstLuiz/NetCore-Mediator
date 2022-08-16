using CleanArch.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace CleanArch.Application.Categories.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
}
