using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.ControlPanel;
using EFramework.Entities.Domain.ControlPanel.ViewQueryCondition;
using System.Collections.Generic;

namespace EFramework.Core.Data
{
    public partial interface IDataStrategy
    {
        IList<SYS_ConfigContentEntity> GetSysConfigs();
        PagingResult<List<SYS_ConfigContentEntity>> GetConfigsByPager(ViewQueryCondition<ConfigSearchCondition> condition);
        SYS_ConfigContentEntity GetConfigModel(int id);
        bool ModifyConfig(SYS_ConfigContentEntity model);
        bool AddConfig(Entities.Domain.ControlPanel.SYS_ConfigContentEntity model);
    }
}
