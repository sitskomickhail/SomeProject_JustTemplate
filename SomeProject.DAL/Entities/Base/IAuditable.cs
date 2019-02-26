﻿
using System;

namespace SomeProject.DAL.Entities.Base
{
	internal interface IAuditable 
	{
		string CreatedBy { get; set; }
		DateTime? CreatedOn { get; set; }
		string UpdatedBy { get; set; }
		DateTime? UpdatedOn { get; set; }
	}
}
