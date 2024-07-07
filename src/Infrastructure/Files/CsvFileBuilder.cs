using System.Globalization;
using CentroEspecialidadesDentales.Application.Common.Interfaces;
using CentroEspecialidadesDentales.Application.TodoLists.Queries.ExportTodos;
using CentroEspecialidadesDentales.Infrastructure.Files.Maps;
using CsvHelper;

namespace CentroEspecialidadesDentales.Infrastructure.Files;
public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Configuration.RegisterClassMap<TodoItemRecordMap>();
            csvWriter.WriteRecords(records);
        }

        return memoryStream.ToArray();
    }
}
