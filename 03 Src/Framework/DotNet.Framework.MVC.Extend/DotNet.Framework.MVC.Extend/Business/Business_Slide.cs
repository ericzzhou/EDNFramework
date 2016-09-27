using DotNet.Framework.DataAccess;
using DotNet.Framework.MVC.Extend.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.MVC.Extend.Business
{
    public class Business_Slide
    {
        public static IList<Entity_Slide> GetSlideByID(int slideID)
        {
            string sql = @"
SELECT 
S.ID
,S.Height
,S.Width
,SI.Description
,SI.FilePath
,SI.Href
,S.ItemType
,SI.Name
,SI.sequence
,S.delay
 FROM EDNF_CMS_Slide S WITH(NOLOCK)
INNER JOIN EDNF_CMS_Slide_Item SI WITH(NOLOCK)
	ON S.ID = SI.SlideID
WHERE S.ID = @SlideID AND SI.Enable = 1 
ORDER BY SI.sequence
";
            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@SlideID", slideID);
            return cmd.ExecuteEntities<Entity_Slide>();

        }
    }
}
