﻿using Ardalis.Specification;
using DotNet.CleanArch.Example.Core.ProjectAggregate;

namespace DotNet.CleanArch.Example.Core.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}
