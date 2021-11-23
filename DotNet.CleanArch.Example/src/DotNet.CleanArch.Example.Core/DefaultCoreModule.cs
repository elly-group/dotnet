using Autofac;
using DotNet.CleanArch.Example.Core.Interfaces;
using DotNet.CleanArch.Example.Core.Services;

namespace DotNet.CleanArch.Example.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
