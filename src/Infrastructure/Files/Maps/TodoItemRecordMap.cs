using System.Globalization;
using CentroEspecialidadesDentales.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace CentroEspecialidadesDentales.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).ConvertUsing(c => c.Done ? "Yes" : "No");
    }
}
