
using System.Data.Entity;
using SomeProject.DAL.Entities;
using System;
using System.Security.Principal;
using SomeProject.DAL.Entities.Base;
using System.Linq;

namespace SomeProject.DAL.Contexts
{
	internal class LigaContext: DbContext
	{
		public LigaContext():base("SomeProjectConnectionString")
		{
			
		}

    public virtual void Save()
    {
      base.SaveChanges();
    }

    public override int SaveChanges()
    {
      TrackChanges();
      return base.SaveChanges();
    }
    
    #region Auditing
    public Func<DateTime> TimestampProvider { get; set; } = () => DateTime.UtcNow;
    public string UserProvider
    {
      get
      {
        if (!string.IsNullOrEmpty(WindowsIdentity.GetCurrent().Name))
          return WindowsIdentity.GetCurrent().Name.Split('\\')[1];
        return string.Empty;
      }
    }
    private void TrackChanges()
    {
      foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
      {
        if (entry.Entity is IAuditable)
        {
          var auditable = entry.Entity as IAuditable;
          if (entry.State == EntityState.Added)
          {
            auditable.CreatedBy = UserProvider;  //  
            auditable.CreatedOn = TimestampProvider();
            auditable.UpdatedOn = TimestampProvider();
          }
          else
          {
            auditable.UpdatedBy = UserProvider;
            auditable.UpdatedOn = TimestampProvider();
          }
        }
      }
    }
    #endregion
    
    public DbSet<Team> Teems { get; set; }
		public DbSet<Player> Players { get; set; }

	}
}
