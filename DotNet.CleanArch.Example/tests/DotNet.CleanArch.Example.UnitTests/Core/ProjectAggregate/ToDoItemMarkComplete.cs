﻿using DotNet.CleanArch.Example.Core.ProjectAggregate.Events;
using Xunit;

namespace DotNet.CleanArch.Example.UnitTests.Core.ProjectAggregate;

public class ToDoItemMarkComplete
{
  [Fact]
  public void SetsIsDoneToTrue()
  {
    var item = new ToDoItemBuilder()
        .WithDefaultValues()
        .Description("")
        .Build();

    item.MarkComplete();

    Assert.True(item.IsDone);
  }

  [Fact]
  public void RaisesToDoItemCompletedEvent()
  {
    var item = new ToDoItemBuilder().Build();

    item.MarkComplete();

    Assert.Single(item.Events);
    Assert.IsType<ToDoItemCompletedEvent>(item.Events.First());
  }
}
