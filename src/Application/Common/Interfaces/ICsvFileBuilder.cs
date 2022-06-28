using ventasonline.Application.TodoLists.Queries.ExportTodos;

namespace ventasonline.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
}
