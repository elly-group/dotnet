using DotNet.CleanArch.Example.Core.ProjectAggregate;
using DotNet.CleanArch.Example.SharedKernel;

namespace DotNet.CleanArch.Example.Core.ProjectAggregate.Events;

public class ToDoItemCompletedEvent : BaseDomainEvent
{
  public ToDoItem CompletedItem { get; set; }

  public ToDoItemCompletedEvent(ToDoItem completedItem)
  {
    CompletedItem = completedItem;
  }
}
