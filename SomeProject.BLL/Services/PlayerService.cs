using AutoMapper;
using SomeProject.BLL.Interfaces;
using SomeProject.BLL.Services.Base;
using System;
using SomeProject.BLL.DTO;
using SomeProject.BLL.Helpers;
using System.Collections.Generic;
using SomeProject.DAL.Entities;

namespace SomeProject.BLL.Services
{
	internal class PlayerService : BaseService, IPlayerService
	{
		protected override Action<IMapperConfigurationExpression> MapperCustomConfiguration =>
		 cfg =>
		 {
			 cfg.CreateMap<Player, PlayerFullInfo>()
				 .ForPath(x => x.TeamId,
					 m => m.MapFrom(a => a.TeamId))
				 .ForPath(x => x.TeamName,
					 m => m.MapFrom(a => a.Team.Name))
				 .ReverseMap();

			 cfg.CreateMap<Player, PlayerInfo>().ReverseMap();

		 };

		public ResultOperationInfo<IEnumerable<PlayerFullInfo>> GetAll()
		{
			var collection = UnitOfWork.GetRepository<Player>().GetAllIncluding(p => p.Team);
			var collectionInfo = MapperInstance.Map<IEnumerable<Player>, IEnumerable<PlayerFullInfo>>(collection);
			return new ResultOperationInfo<IEnumerable<PlayerFullInfo>>(collectionInfo, true, Localization.Success_OperationComplited);
		}

		public ResultOperationInfo<PlayerFullInfo> GetId(int itemId)
		{
			var item = UnitOfWork.GetRepository<Player>().GetIncluding(itemId, p => p.Team);
			var itemInfo = MapperInstance.Map<Player, PlayerFullInfo>(item);
			return new ResultOperationInfo<PlayerFullInfo>(itemInfo, true, Localization.Success_OperationComplited);
		}

		public ResultOperationInfo Add(PlayerFullInfo itemInfo)
		{
			var item = MapperInstance.Map<PlayerInfo, Player>(itemInfo);
			item.Team = null;
			var addedItem = UnitOfWork.GetRepository<Player>().Add(item);
			return addedItem == null
				? new ResultOperationInfo(false, Localization.Error_OperationComplited)
				: new ResultOperationInfo(true, Localization.Success_OperationComplited);
		}

		public ResultOperationInfo Delete(int itemId)
		{
			var deletedRows = UnitOfWork.GetRepository<Player>().DeleteBy(itemId);
			return deletedRows == 0
				? new ResultOperationInfo(false, Localization.Error_OperationComplited)
				: new ResultOperationInfo(true, Localization.Success_OperationComplited);
		}

		public ResultOperationInfo Update(PlayerFullInfo itemInfo)
		{
			var item = MapperInstance.Map<PlayerFullInfo, Player>(itemInfo);
			var updatedItem = UnitOfWork.GetRepository<Player>().Update(item, item.Id);
			return updatedItem == null
				? new ResultOperationInfo(false, Localization.Error_OperationComplited)
				: new ResultOperationInfo(true, Localization.Success_OperationComplited);
		}


		public ResultOperationInfo<PlayerFullInfo> Create(PlayerFullInfo itemInfo)
		{
			var item = MapperInstance.Map<PlayerInfo, Player>(itemInfo);
			item.Team = null;
			var addedItem = UnitOfWork.GetRepository<Player>().Add(item);
			var addedItemInfo = MapperInstance.Map<Player, PlayerFullInfo>(addedItem);
			return addedItem == null
				? new ResultOperationInfo<PlayerFullInfo>(null, false, Localization.Error_OperationComplited)
				: new ResultOperationInfo<PlayerFullInfo>(addedItemInfo, true, Localization.Success_OperationComplited);
		}
	}
}
