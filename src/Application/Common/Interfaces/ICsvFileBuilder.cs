using CentroEspecialidadesDentales.Application.TodoLists.Queries.ExportTodos;

namespace CentroEspecialidadesDentales.Application.Common.Interfaces;
public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
