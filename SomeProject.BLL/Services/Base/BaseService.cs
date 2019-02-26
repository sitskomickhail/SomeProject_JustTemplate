using AutoMapper;
using SomeProject.DAL.UnitOfWork;
using SomeProject.DAL.UnitOfWork.Base;
using System;

namespace SomeProject.BLL.Services.Base
{
  internal class BaseService
  {
    private MapperConfiguration _mapperConfiguration;

    public IMapper MapperInstance => _mapperConfiguration?.CreateMapper();

    protected virtual Action<IMapperConfigurationExpression> MapperCustomConfiguration { get; set; } = cfg => { };

    public IUnitOfWork UnitOfWork { get; }

    public BaseService()
    {
      UnitOfWork = new UnitOfWork();
      MapperInitialize();
    }

    private void MapperInitialize()
    {
      _mapperConfiguration = new MapperConfiguration(MapperCustomConfiguration);
    }
  }
}
