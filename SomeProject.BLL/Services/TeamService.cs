using System;
using System.Collections.Generic;
using SomeProject.BLL.DTO;
using SomeProject.BLL.Helpers;
using SomeProject.BLL.Interfaces;
using SomeProject.BLL.Services.Base;
using AutoMapper;
using SomeProject.DAL.Entities;

namespace SomeProject.BLL.Services
{
  internal class TeamService : BaseService, ITeamService
  {

		protected override Action<IMapperConfigurationExpression> MapperCustomConfiguration =>
			cfg =>
			{
				cfg.CreateMap<Team, TeamInfo>()
					.ForPath(x => x.CountPlayers,
						m => m.MapFrom(a => a.Players!=null && a.Players.Count>0))
					.ReverseMap();
			};

	  public ResultOperationInfo<IEnumerable<TeamInfo>> GetAll()
	  {
		  var collection = UnitOfWork.GetRepository<Team>().GetAllIncluding(p => p.Players);
		  var collectionInfo = MapperInstance.Map<IEnumerable<Team>, IEnumerable<TeamInfo>>(collection);
		  return new ResultOperationInfo<IEnumerable<TeamInfo>>(collectionInfo, true, Localization.Success_OperationComplited);
	  }

	  public ResultOperationInfo<TeamInfo> GetId(int itemId)
	  {
		  var item = UnitOfWork.GetRepository<Team>().GetIncluding(itemId, p => p.Players);
		  var itemInfo = MapperInstance.Map<Team, TeamInfo>(item);
		  return new ResultOperationInfo<TeamInfo>(itemInfo, true, Localization.Success_OperationComplited);
	  }

		public ResultOperationInfo Add(TeamInfo itemInfo)
		{
			var item = MapperInstance.Map<TeamInfo, Team>(itemInfo);
			var addedItem = UnitOfWork.GetRepository<Team>().Add(item);
			return addedItem==null 
				? new ResultOperationInfo(false, Localization.Error_OperationComplited) 
				: new ResultOperationInfo(true, Localization.Success_OperationComplited);
		}

	  public ResultOperationInfo<TeamInfo> Create(string name)
	  {
		  var item = new Team(){Name = name};
		  var addedItem = UnitOfWork.GetRepository<Team>().Add(item);
		  var addedItemInfo = MapperInstance.Map<Team, TeamInfo>(addedItem);
			return addedItem == null
			  ? new ResultOperationInfo<TeamInfo>(null, false, Localization.Error_OperationComplited)
			  : new ResultOperationInfo<TeamInfo>(addedItemInfo, true, Localization.Success_OperationComplited);
	  }


		public ResultOperationInfo Delete(int itemId)
    {
      var deletedRows = UnitOfWork.GetRepository<Team>().DeleteBy(itemId);
	    return deletedRows == 0
		    ? new ResultOperationInfo(false, Localization.Error_OperationComplited)
		    : new ResultOperationInfo(true, Localization.Success_OperationComplited);
		}
		
    public ResultOperationInfo Update(TeamInfo itemInfo)
    {
	   	var item = MapperInstance.Map<TeamInfo, Team>(itemInfo);
			var updatedItem = UnitOfWork.GetRepository<Team>().Update(item, item.Id);
	    return updatedItem == null
		    ? new ResultOperationInfo(false, Localization.Error_OperationComplited)
		    : new ResultOperationInfo(true, Localization.Success_OperationComplited);
		}
  }
}
