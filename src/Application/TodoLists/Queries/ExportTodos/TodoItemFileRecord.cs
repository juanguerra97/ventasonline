using ventasonline.Application.Common.Mappings;
using ventasonline.Domain.Entities;

namespace ventasonline.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}
