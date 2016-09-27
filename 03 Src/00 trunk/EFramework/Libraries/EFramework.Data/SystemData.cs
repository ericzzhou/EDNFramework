using EFramework.Core.Data;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.ControlPanel;
using EFramework.Entities.Domain.ControlPanel.ViewQueryCondition;
using System.Collections.Generic;

namespace EFramework.Data
{
    public class SystemData
    {
        public static IList<SYS_ConfigContentEntity> GetSysConfigs()
        {
            return Factory.Instance.GetSysConfigs();
        }

        public static PagingResult<List<SYS_ConfigContentEntity>> GetConfigsByPager(ViewQueryCondition<ConfigSearchCondition> condition)
        {
            return Factory.Instance.GetConfigsByPager(condition);
        }
    }
}
