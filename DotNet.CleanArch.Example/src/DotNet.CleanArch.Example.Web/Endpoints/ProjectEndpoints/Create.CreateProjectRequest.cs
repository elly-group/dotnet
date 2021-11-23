using System.ComponentModel.DataAnnotations;

namespace DotNet.CleanArch.Example.Web.Endpoints.ProjectEndpoints;

public class CreateProjectRequest
{
  public const string Route = "/Projects";

  [Required]
  public string? Name { get; set; }
}
