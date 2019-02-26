using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SomeProject.DAL.Entities.Base;

namespace SomeProject.DAL.Entities
{
	[Table("Teams")]
	internal class Team : IBaseEntity, IAuditable
	{
		public int Id { get; set; }
		public string Name { get; set; }
	
		public ICollection<Player> Players { get; set; }

		public string CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }
	}
}
