using System;
using System.Collections.ObjectModel;
using SomeProject.BLL.DTO;
using SomeProject.BLL.Interfaces;
using Unity.ServiceLocator;

namespace SomeProject.PL.Desktop.ViewModels
{
	public class TeamViewModel
	{
		private ObservableCollection<TeamInfo> _teams;
		private readonly ITeamService _teamService;
		public TeamViewModel()
		{
			_teamService = ServiceLocator.Current.GetInstance<ITeamService>();
		}

		public ObservableCollection<TeamInfo> Teams
		{
			get
			{
				if (_teams == null)
				{
					var result = _teamService.GetAll();
					if (result.IsSuccess)
					{
						_teams = new ObservableCollection<TeamInfo>(result.Value);
					}
					else
					{
						throw  new Exception(result.Message);
					}
				}

				return _teams;
			}
		}


	}
}
