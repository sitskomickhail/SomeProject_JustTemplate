﻿using System;
using System.Collections;
using System.Data.Entity;
using SomeProject.DAL.Contexts;
using SomeProject.DAL.Entities.Base;
using SomeProject.DAL.Repositories.Base;
using SomeProject.DAL.UnitOfWork.Base;

namespace SomeProject.DAL.UnitOfWork
{
	internal class UnitOfWork : IUnitOfWork
	{

		private bool _disposed;
		private Hashtable _repositories;
		private readonly DbContext _dbContext;

		public UnitOfWork()
		{
			_dbContext = new LigaContext();
			_dbContext.Configuration.LazyLoadingEnabled = false;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public void Commit()
		{
			_dbContext.SaveChanges();
		}

		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
				if (disposing)
					_dbContext.Dispose();

			_disposed = true;
		}

		public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IBaseEntity
		{
			if (_repositories == null)
				_repositories = new Hashtable();

			var type = typeof(TEntity).Name;

			if (_repositories.ContainsKey(type)) return (GenericRepository<TEntity>)_repositories[type];

			var repositoryType = typeof(GenericRepository<>);
			var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _dbContext);

			_repositories.Add(type, repositoryInstance);

			return (GenericRepository<TEntity>)_repositories[type];
		}
	}
}
