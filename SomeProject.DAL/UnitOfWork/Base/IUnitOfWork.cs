using System;
using SomeProject.DAL.Entities.Base;
using SomeProject.DAL.Repositories.Base;

namespace SomeProject.DAL.UnitOfWork.Base
{
	public interface IUnitOfWork : IDisposable
	{
		void Commit();
		IRepository<T> GetRepository<T>() where T : class, IBaseEntity;
	}
}
