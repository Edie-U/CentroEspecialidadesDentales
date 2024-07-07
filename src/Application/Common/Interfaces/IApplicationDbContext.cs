using CentroEspecialidadesDentales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CentroEspecialidadesDentales.Application.Common.Interfaces;
public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
