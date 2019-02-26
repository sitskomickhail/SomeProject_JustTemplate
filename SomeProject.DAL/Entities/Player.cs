
using System;
using SomeProject.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SomeProject.DAL.Entities
{
  [Table("Players")]
	internal class Player:IBaseEntity, IAuditable
	{
		public int Id { get; set; }

		public string LastName { get; set; }
		public string SecondName { get; set; }
		public DateTime BirthDay { get; set; }

		public int TeamId { get; set; }
		public virtual Team Team { get; set; }

		public string CreatedBy { get; set; }
		public DateTime? CreatedOn { get; set; }
		public string UpdatedBy { get; set; }
		public DateTime? UpdatedOn { get; set; }
	}
}
