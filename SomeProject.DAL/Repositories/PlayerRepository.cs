using System.Data.Entity;
using SomeProject.DAL.Entities;
using SomeProject.DAL.Repositories.Base;

namespace SomeProject.DAL.Repositories
{

	internal class PlayerRepository : GenericRepository<Team>
	{
		public PlayerRepository(DbContext db) : base(db)
		{

		}
	}
}
