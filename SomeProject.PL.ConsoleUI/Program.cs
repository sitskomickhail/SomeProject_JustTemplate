using System;
using SomeProject.BLL.Interfaces;
using SomeProject.BLL.Services;
using Unity;


namespace SomeProject.PL.ConsoleUI
{
	class Program
	{
		
		static void Main()
		{

			var container = new UnityContainer();
			container.RegisterType<ITeamService, TeamService>();
			container.RegisterType<IPlayerService, PlayerService>();

			var viewModel = new ViewModel(container);

			var team = viewModel.CreateTeam("FC Barcelona");
			var player = viewModel.CreatePlayer("Messi", "Leonel", new DateTime(1982, 10, 10), team.Id);


			var teams = viewModel.GetTeams();
			foreach (var item in teams)
			{
				Console.WriteLine($"{item.Name} - count: {item.CountPlayers}");
			}


			Console.ReadKey();
		}
	}
}
