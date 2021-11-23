using Ardalis.Specification;

namespace DotNet.CleanArch.Example.SharedKernel.Interfaces;

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}
