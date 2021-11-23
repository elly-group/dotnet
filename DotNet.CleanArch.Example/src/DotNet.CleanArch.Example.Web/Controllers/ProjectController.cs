using DotNet.CleanArch.Example.Core.ProjectAggregate;
using DotNet.CleanArch.Example.Core.ProjectAggregate.Specifications;
using DotNet.CleanArch.Example.SharedKernel.Interfaces;
using DotNet.CleanArch.Example.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.CleanArch.Example.Web.Controllers;

[Route("[controller]")]
public class ProjectController : Controller
{
  private readonly IRepository<Project> _projectRepository;

  public ProjectController(IRepository<Project> projectRepository)
  {
    _projectRepository = projectRepository;
  }

  // GET project/{projectId?}
  [HttpGet("{projectId:int}")]
  public async Task<IActionResult> Index(int projectId = 1)
  {
    var spec = new ProjectByIdWithItemsSpec(projectId);
    var project = await _projectRepository.GetBySpecAsync(spec);
    if (project == null)
    {
      return NotFound();
    }

    var dto = new ProjectViewModel
    {
      Id = project.Id,
      Name = project.Name,
      Items = project.Items
                    .Select(item => ToDoItemViewModel.FromToDoItem(item))
                    .ToList()
    };
    return View(dto);
  }
}
