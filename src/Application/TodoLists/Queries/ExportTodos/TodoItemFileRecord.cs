using CentroEspecialidadesDentales.Application.Common.Mappings;
using CentroEspecialidadesDentales.Domain.Entities;

namespace CentroEspecialidadesDentales.Application.TodoLists.Queries.ExportTodos;
public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
