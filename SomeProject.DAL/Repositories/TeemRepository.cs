
using System.Data.Entity;
using SomeProject.DAL.Entities;
using SomeProject.DAL.Repositories.Base;

namespace SomeProject.DAL.Repositories
{
	internal class TeemRepository:GenericRepository<Team>
	{
		public TeemRepository(DbContext db):base(db)
		{
			
		}
	}
}
