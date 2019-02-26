using SomeProject.BLL.DTO;
using SomeProject.BLL.Helpers;
using System.Collections.Generic;

namespace SomeProject.BLL.Interfaces
{
  public interface ITeamService
  {
    ResultOperationInfo<IEnumerable<TeamInfo>> GetAll();
    ResultOperationInfo<TeamInfo> GetId(int itemId);

    ResultOperationInfo Add(TeamInfo item);
    ResultOperationInfo Update(TeamInfo item);
    ResultOperationInfo Delete(int itemId);


	  ResultOperationInfo<TeamInfo> Create(string name);


  }
}
