﻿using DotNet.CleanArch.Example.Core.ProjectAggregate;
using Xunit;

namespace DotNet.CleanArch.Example.UnitTests.Core.ProjectAggregate;

public class Project_AddItem
{
  private Project _testProject = new Project("some name");

  [Fact]
  public void AddsItemToItems()
  {
    var _testItem = new ToDoItem
    {
      Title = "title",
      Description = "description"
    };

    _testProject.AddItem(_testItem);

    Assert.Contains(_testItem, _testProject.Items);
  }

  [Fact]
  public void ThrowsExceptionGivenNullItem()
  {
#nullable disable
    Action action = () => _testProject.AddItem(null);
#nullable enable

    var ex = Assert.Throws<ArgumentNullException>(action);
    Assert.Equal("newItem", ex.ParamName);
  }
}
