
using SomeProject.BLL.DTO;
using SomeProject.BLL.Helpers;
using System.Collections.Generic;

namespace SomeProject.BLL.Interfaces
{
  public interface IPlayerService
  {
    ResultOperationInfo<IEnumerable<PlayerFullInfo>> GetAll();
    ResultOperationInfo<PlayerFullInfo> GetId(int itemId);

    ResultOperationInfo Add(PlayerFullInfo item);
    ResultOperationInfo Update(PlayerFullInfo item);
    ResultOperationInfo Delete(int itemId);
		
	  ResultOperationInfo<PlayerFullInfo> Create(PlayerFullInfo itemInfo);

  }
}
