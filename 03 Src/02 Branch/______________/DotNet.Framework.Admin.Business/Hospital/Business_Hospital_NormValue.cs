using DotNet.Framework.Admin.Entity.Hospital;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNet.Framework.Core.Extends;
using System.Data;
namespace DotNet.Framework.Admin.Business.Hospital
{
    public class Business_Hospital_NormValue
    {
        public static int Create(List<Entity_Hospital_NormValue> entities, int inUser, string OccurrenceTime)
        {
            StringBuilder sbr = new StringBuilder();
            if (entities.Count > 0)
            {
                foreach (var item in entities)
                {
                    sbr.AppendFormat(@"
INSERT INTO [Hospital_NormValue]
           ([NormID]
           ,[DepartmentID]
           ,[Value]
           ,[InDate]
           ,[InUser]
           ,[OccurrenceTime])
     VALUES
           ({0}
           ,{1}
           ,'{2}'
           ,GETDATE()
           ,{3}
           ,'{4}')
", item.NormID, item.DepartmentID, item.Value, inUser, OccurrenceTime);
                }
                Command cmd = CommandManager.CreateCommand(sbr.ToString());
                return cmd.ExecuteNonQuery();
            }
            else
            {
                return 0;
            }
        }

        public static IList<Entity_Hospital_NormValue_Search> GetListByPager(int pageindex, int pagesize, string orderField, string dir
            , int categoryId, int normId, int departmentId, DateTime? startTime, DateTime? endTime
            , out int totolCount)
        {
            totolCount = 0;
            StringBuilder sbrTotal = new StringBuilder();
            sbrTotal.Append(@"
SELECT COUNT(NV.ID)
FROM Hospital_NormValue NV WITH(NOLOCK)
	INNER JOIN Hospital_NormItem NI WITH(NOLOCK)
		ON NI.ID=NV.NormID
	INNER JOIN EDNF_Account_Department DEP WITH(NOLOCK)
		ON DEP.ID = NV.DepartmentID
	LEFT JOIN EDNF_Account_User AU WITH(NOLOCK)
		ON AU.UserID = NV.InUser
    WHERE 1=1 
");

            StringBuilder sbrGet = new StringBuilder();
            sbrGet.AppendFormat(@"
SELECT * FROM 
(
 SELECT 
    ROW_NUMBER() OVER (ORDER BY {0} {1}) R,
    NV.ID AS ID
    ,NV.NormID AS NormID
    ,NI.ItremName AS NormName
    ,NV.DepartmentID AS DepartmentID
    ,DEP.Name AS DepartmentName
    ,NV.Value AS NormValue
    ,NV.InDate AS InDate
    ,NV.InUser AS InUser
    ,
    (CASE 
        WHEN AU.NickName IS NULL THEN '未知'
        ELSE AU.NickName
        END
    ) AS InUserName
    FROM Hospital_NormValue NV
        INNER JOIN Hospital_NormItem NI
            ON NI.ID=NV.NormID
        INNER JOIN EDNF_Account_Department DEP
            ON DEP.ID = NV.DepartmentID
        LEFT JOIN EDNF_Account_User AU
            ON AU.UserID = NV.InUser
    WHERE 1=1 
", orderField, dir);

            if (categoryId > 0)
            {
                sbrTotal.Append(" AND NI.ItemCategory = @categoryId");
                sbrGet.Append(" AND NI.ItemCategory = @categoryId");
            }
            if (normId > 0)
            {
                sbrTotal.Append(" AND NV.NormID=@NormID");
                sbrGet.Append(" AND NV.NormID=@NormID");
            }
            if (departmentId > 0)
            {
                sbrTotal.Append(" AND NV.DepartmentID = @departmentId");
                sbrGet.Append(" AND NV.DepartmentID = @departmentId");
            }

            if (startTime.HasValue && endTime.HasValue)
            {
                sbrTotal.Append(" AND NV.InDate BETWEEN @startTime AND @endTime");
                sbrGet.Append(" AND NV.InDate BETWEEN @startTime AND @endTime");
            }
            else if (startTime.HasValue && !endTime.HasValue)
            {
                sbrTotal.Append(" AND NV.InDate BETWEEN @startTime AND GETDATE()");
                sbrGet.Append(" AND NV.InDate BETWEEN @startTime AND GETDATE()");
            }

            sbrGet.Append(@"                    
) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize");



            Command cmdCount = CommandManager.CreateCommand(sbrTotal.ToString());
            cmdCount.SetParamter("@categoryId", categoryId);
            cmdCount.SetParamter("@NormID", normId);
            cmdCount.SetParamter("@departmentId", departmentId);
            if (startTime.HasValue)
            {
                cmdCount.SetParamter("@startTime", startTime.Value);
            }
            if (endTime.HasValue)
            {
                cmdCount.SetParamter("@endTime", endTime.Value);
            }
            totolCount = cmdCount.ExecuteSingle<int>();


            Command cmd = CommandManager.CreateCommand(sbrGet.ToString());
            cmd.SetParamter("@PageIndex", pageindex);
            cmd.SetParamter("@PageSize", pagesize);
            cmd.SetParamter("@categoryId", categoryId);
            cmd.SetParamter("@NormID", normId);
            cmd.SetParamter("@departmentId", departmentId);
            if (startTime.HasValue)
            {
                cmdCount.SetParamter("@startTime", startTime.Value);
            }
            if (endTime.HasValue)
            {
                cmdCount.SetParamter("@endTime", endTime.Value);
            }

            return cmd.ExecuteEntities<Entity_Hospital_NormValue_Search>();
        }

        public static List<Entity_Hospital_SearchTime> GetSearcjDateList(DateTime? startTime, DateTime? endTime)
        {
            DateTime? start = null;
            DateTime? end = null;
            if (startTime.HasValue && endTime.HasValue)
            {
                start = startTime.Value.ToString("yyyy-MM").ToDateTime2();
                end = endTime.Value.ToString("yyyy-MM").ToDateTime2();
            }
            else if (startTime.HasValue && !endTime.HasValue)
            {
                start = startTime.Value.ToString("yyyy-MM").ToDateTime2();
                end = DateTime.Now.ToString("yyyy-MM").ToDateTime2();
            }

            List<Entity_Hospital_SearchTime> times = new List<Entity_Hospital_SearchTime>();
            if (start.HasValue && end.HasValue && start.Value < end.Value)
            {

                while (end.Value >= start.Value)
                {
                    times.Add(new Entity_Hospital_SearchTime()
                    {
                        Year = start.Value.ToString("yyyy"),
                        Month = start.Value.ToString("MM")
                    });
                    start = start.Value.AddMonths(1);
                }
            }
            return times;
        }

        public static DataSet GetDataSetList(int categoryId, int normId, string departmentIds, DateTime? startTime, DateTime? endTime)
        {
            StringBuilder sbrGet = new StringBuilder();
            sbrGet.AppendFormat(@"
select 
	ad.Name 科室
	,SUM(nv.Value) as '合计'");

            List<Entity_Hospital_SearchTime> times = GetSearcjDateList(startTime, endTime);

            foreach (Entity_Hospital_SearchTime time in times)
            {
                sbrGet.AppendFormat(@"
	,SUM(case when YEAR(nv.OccurrenceTime)='{0}' AND MONTH(nv.OccurrenceTime)='{1}' then nv.Value else 0 end ) as '{2}'"
                    , time.Year, time.Month, time.Year + "年" + time.Month + "月");
            }

            sbrGet.AppendFormat(@" 
  from Hospital_NormValue nv
  inner join EDNF_Account_Department ad
	on ad.ID = nv.DepartmentID and ad.Status='True'
	WHERE 1=1
	AND ad.ID in ({0})
	AND nv.NormID=@NormID", departmentIds);
            if (startTime.HasValue && endTime.HasValue)
            {
                sbrGet.AppendFormat(" AND nv.OccurrenceTime BETWEEN '{0}' AND '{1}' ", startTime.Value, endTime.Value);
            }
            else if (startTime.HasValue && !endTime.HasValue)
            {
                sbrGet.AppendFormat(" AND nv.OccurrenceTime BETWEEN '{0}' AND GETDATE() ", startTime.Value);
            }
            sbrGet.AppendLine(" group by ad.Name");

            Command cmd = CommandManager.CreateCommand(sbrGet.ToString());

            cmd.SetParamter("@NormID", normId);
            if (startTime.HasValue)
            {
                cmd.SetParamter("@startTime", startTime.Value);
            }
            if (endTime.HasValue)
            {
                cmd.SetParamter("@endTime", endTime.Value);
            }


            return cmd.ExecuteDataSet();

        }
        public static IList<Entity_Hospital_NormValue_Search> GetList(int categoryId, int normId, string departmentIds, DateTime? startTime, DateTime? endTime)
        {
            StringBuilder sbrGet = new StringBuilder();
            sbrGet.AppendFormat(@"
select 
	ad.Name 科室
	,SUM(nv.Value) as '合计'
	,SUM(case when MONTH(nv.OccurrenceTime)='01' then nv.Value else 0 end ) 一月
	,SUM(case when MONTH(nv.OccurrenceTime)='02' then nv.Value else 0 end ) 二月
	,SUM(case when MONTH(nv.OccurrenceTime)='03' then nv.Value else 0 end ) 三月
	,SUM(case when MONTH(nv.OccurrenceTime)='04' then nv.Value else 0 end ) 四月
	,SUM(case when MONTH(nv.OccurrenceTime)='05' then nv.Value else 0 end ) 五月
	,SUM(case when MONTH(nv.OccurrenceTime)='06' then nv.Value else 0 end ) 六月
	,SUM(case when MONTH(nv.OccurrenceTime)='07' then nv.Value else 0 end ) 七月
	,SUM(case when MONTH(nv.OccurrenceTime)='08' then nv.Value else 0 end ) 八月
	,SUM(case when MONTH(nv.OccurrenceTime)='09' then nv.Value else 0 end ) 九月
	,SUM(case when MONTH(nv.OccurrenceTime)='10' then nv.Value else 0 end ) 十月
	,SUM(case when MONTH(nv.OccurrenceTime)='11' then nv.Value else 0 end ) 十一月
	,SUM(case when MONTH(nv.OccurrenceTime)='12' then nv.Value else 0 end ) 十二月
  from Hospital_NormValue nv
  inner join EDNF_Account_Department ad
	on ad.ID = nv.DepartmentID and ad.Status='True'
	WHERE 1=1
	AND ad.ID in ({0})
	AND nv.NormID=@NormID
group by ad.Name
", departmentIds);

            Command cmd = CommandManager.CreateCommand(sbrGet.ToString());

            cmd.SetParamter("@NormID", normId);
            if (startTime.HasValue)
            {
                cmd.SetParamter("@startTime", startTime.Value);
            }
            if (endTime.HasValue)
            {
                cmd.SetParamter("@endTime", endTime.Value);
            }


            return cmd.ExecuteEntities<Entity_Hospital_NormValue_Search>();
        }


    }
}
