using EFramework.Core.Data;
using EFramework.Core.WebRuntime.ViewObject;
using EFramework.Entities.Domain.Account;
using EFramework.Entities.Domain.ControlPanel;
using EFramework.Entities.Domain.ControlPanel.ViewQueryCondition;
using System.Collections.Generic;

namespace EFramework.Services
{
    public class SystemService
    {
        public static IList<SYS_ConfigContentEntity> GetSysConfigs()
        {
            return Factory.Instance.GetSysConfigs() ?? new List<SYS_ConfigContentEntity>();
        }

        public static PagingResult<List<SYS_ConfigContentEntity>> GetConfigsByPager(ViewQueryCondition<ConfigSearchCondition> condition)
        {
            return Factory.Instance.GetConfigsByPager(condition) ?? new PagingResult<List<SYS_ConfigContentEntity>>()
            {
                Result = new List<SYS_ConfigContentEntity>(),
                PagingInfo = condition.PagingInfo
            };
        }

        public static SYS_ConfigContentEntity GetConfigModel(int id)
        {
            return Factory.Instance.GetConfigModel(id) ?? new SYS_ConfigContentEntity();
        }

        public static bool ModifyConfig(SYS_ConfigContentEntity model)
        {
            return Factory.Instance.ModifyConfig(model);
        }

        public static bool AddConfig(SYS_ConfigContentEntity model)
        {
            return Factory.Instance.AddConfig(model);
        }


    }
}
