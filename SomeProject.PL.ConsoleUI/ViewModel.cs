using System;
using System.Collections.Generic;
using SomeProject.BLL.DTO;
using SomeProject.BLL.Helpers;
using SomeProject.BLL.Interfaces;
using Unity;

namespace SomeProject.PL.ConsoleUI
{
	public class ViewModel
	{
		private readonly ITeamService _teamService;
		private readonly IPlayerService _playerService;

		public ViewModel(IUnityContainer container)
		{
			_teamService = container.Resolve<ITeamService>();
			_playerService= container.Resolve<IPlayerService>();
		}


		public IEnumerable<TeamInfo> GetTeams()
		{
			var result = _teamService.GetAll();
			if (result.IsSuccess)
			{
				return result.Value;
			}

			throw new Exception(result.Message);
		}

		public TeamInfo CreateTeam(string name)
		{
			var result = _teamService.Create(name);
			if(result.IsSuccess)
			{
				return result.Value;
			}

			throw new Exception(result.Message);
		}

		public PlayerFullInfo CreatePlayer(string lastName, string firstName, DateTime birthDay, int teamId)
		{
			var itemInfo = new PlayerFullInfo()
			{
				LastName = lastName,
				FirstName = firstName,
				BirthDay = birthDay,
				TeamId = teamId
			};
			var result = _playerService.Create(itemInfo);
			if (result.IsSuccess)
			{
				return result.Value;
			}

			throw new Exception(result.Message);
		}



		public void AddPlayerToTeam(int teamId, int playerId)
		{

		}

	}
}
