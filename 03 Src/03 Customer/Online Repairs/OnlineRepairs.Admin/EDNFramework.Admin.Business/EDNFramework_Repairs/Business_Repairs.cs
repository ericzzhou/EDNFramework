using DotNet.Framework.Admin.Entity.EDNFramework_Repairs;
using DotNet.Framework.Core.Exceptions;
using DotNet.Framework.Core.Web.Data.ViewObject;
using DotNet.Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.Framework.Admin.Business.EDNFramework_Repairs
{
    public class Business_Repairs
    {
        public static PagingResult<IList<Entity_Brand>> GetListByPager(ViewQueryCondition<object> query)
        {
            PagingResult<IList<Entity_Brand>> result = new PagingResult<IList<Entity_Brand>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(ID) 
FROM [EDNF_Repairs_Brand] CON WITH(NOLOCK)
WHERE Deleted = 0 or Deleted is null
#strWhere#

SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
	CON.*
FROM EDNF_Repairs_Brand CON WITH(NOLOCK)
WHERE Deleted = 0 or Deleted is null

#strWhere#

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            string where = "";

            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            result.Result = cmd.ExecuteEntities<Entity_Brand>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static int Add(Entity_Brand entity)
        {
            string sqlStr = @"
INSERT INTO [EDNF_Repairs_Brand]
           ([Name]
           ,[Descriptino]
           ,[Deleted])
     VALUES
           (@Name
           ,@Descriptino
           ,0)
";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Descriptino", entity.Descriptino);

            return cmd.ExecuteNonQuery();
        }

        public static int Delete(int id)
        {
            string sqlStr = @"
UPDATE TOP (1) [EDNF_Repairs_Brand]
   SET [Deleted] = 1
 WHERE [ID] = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetParamter("@ID", id);

            return cmd.ExecuteNonQuery();
        }

        public static Entity_Brand GetModel(int id)
        {
            string sqlStr = @"
SELECT TOP 1 [ID]
      ,[Name]
      ,[Descriptino]
      ,[Deleted]
  FROM [EDNF_Repairs_Brand]
    WHERE ID = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Brand>();
        }

        public static int Update(Entity_Brand entity)
        {
            string sqlStr = @"
UPDATE TOP (1) [EDNF_Repairs_Brand]
   SET [Name] = @Name
      ,[Descriptino] = @Descriptino
 WHERE [ID] = @ID
";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetParamter("@ID", entity.ID);
            cmd.SetParamter("@Name", entity.Name);
            cmd.SetParamter("@Descriptino", entity.Descriptino);

            return cmd.ExecuteNonQuery();
        }

        public static PagingResult<IList<Entity_Order_List>> GetOrderListByPager(ViewQueryCondition<Entity_Order_List> query)
        {
            PagingResult<IList<Entity_Order_List>> result = new PagingResult<IList<Entity_Order_List>>();
            string sqlStr = @"
SELECT @TotalCount= COUNT(o.ID)
FROM    ENDF_Repairs_Order o WITH ( NOLOCK )
        JOIN EDNF_Repairs_Brand b WITH ( NOLOCK ) ON b.ID = o.BrandID
        JOIN EDNF_Account_User u WITH ( NOLOCK ) ON u.UserID = o.UserID
WHERE   o.Statu <> -1
#strWhere#

SELECT * FROM 
(
SELECT 
ROW_NUMBER() OVER (ORDER BY #OrderField# #SortDir#) R,
        o.ID ,
        o.OrderNumber ,
        u.NickName ,
        ( CASE o.ComputerType
            WHEN 0 THEN '台式机'
            WHEN 1 THEN '笔记本'
          END ) AS ComputerType ,
        b.Name AS BrandName ,
        o.Model ,
        o.Statu
FROM    ENDF_Repairs_Order o WITH ( NOLOCK )
        JOIN EDNF_Repairs_Brand b WITH ( NOLOCK ) ON b.ID = o.BrandID
        JOIN EDNF_Account_User u WITH ( NOLOCK ) ON u.UserID = o.UserID
WHERE    o.Statu <> -1

#strWhere#

) DATA
WHERE DATA.R BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex * @PageSize

";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            string where = "";

            cmd.SetReplaceParamter("#strWhere#", where);
            cmd.SetReplaceParamter("#OrderField#", query.PagingInfo.OrderField);
            cmd.SetReplaceParamter("#SortDir#", query.PagingInfo.SortDir);
            cmd.SetOutParameter("@TotalCount", System.Data.DbType.Int32, null);
            cmd.SetParamter("@PageIndex", query.PagingInfo.PageIndex);
            cmd.SetParamter("@PageSize", query.PagingInfo.PageSize);
            result.Result = cmd.ExecuteEntities<Entity_Order_List>();
            result.PagingInfo = query.PagingInfo;
            int totalCount = cmd.GetOutParameter<Int32>("@TotalCount");
            result.TotalCount = totalCount;
            return result;
        }

        public static bool DeleteOrder(int id, int operationUserID, string operationUserName)
        {
            string sqlStr = @"
UPDATE TOP (1) [ENDF_Repairs_Order]
   SET [Statu] = -1,ModifyTime=getdate()
 WHERE [ID] = @ID

INSERT INTO [ENDF_Repairs_OrderHistory]
           ([OrderID]
           ,[Status]
           ,[CreateTime]
           ,[Note])
     VALUES
           (@ID
           ,-1
           ,getdate()
           ,@Note)
";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            cmd.SetParamter("@ID", id);
            cmd.SetParamter("@Note", string.Format("用户{0}[{1}]删除订单", operationUserName, operationUserID));
            return cmd.ExecuteNonQuery() > 0;
        }

        public static Entity_Order GetOrderInfo(int ID)
        {
            string sqlStr = @"SELECT top 1 * FROM [ENDF_Repairs_Order] WITH(NOLOCK) WHERE ID=@ID";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ID", ID);
            return cmd.ExecuteEntity<Entity_Order>();
        }

        public static Entity_Order GetOrderInfo(string id)
        {
            string sqlStr = @"SELECT top 1 * FROM [ENDF_Repairs_Order] WITH(NOLOCK) WHERE OrderNumber=@OrderNumber";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@OrderNumber", id);
            return cmd.ExecuteEntity<Entity_Order>();
        }

        public static IList<Entity_Order_History> GetOrderHistory(int ID)
        {
            string sqlStr = @"SELECT * FROM [ENDF_Repairs_OrderHistory] WITH(NOLOCK) WHERE OrderID = @OrderID ORDER BY CreateTime ASC";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@OrderID", ID);
            return cmd.ExecuteEntities<Entity_Order_History>();
        }

        public static IList<Entity_Order_History> GetOrderHistory(string id)
        {
            string sqlStr = @"
SELECT  h.*,h.CreateTime as CreateTime2,u.NickName,u.Phone
FROM    [ENDF_Repairs_OrderHistory] h WITH ( NOLOCK )
        JOIN ENDF_Repairs_Order o WITH ( NOLOCK ) ON o.ID = h.OrderID
        JOIN EDNF_Account_User u WITH ( NOLOCK ) ON u.UserID = o.AssignedTo
WHERE   o.OrderNumber = @OrderNumber
ORDER BY h.CreateTime ASC ";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@OrderNumber", id.Trim());
            return cmd.ExecuteEntities<Entity_Order_History>();
        }

        public static Entity_Order_ContactsAddress GetContactsAddress(int id)
        {
            string sqlStr = @"SELECT TOP 1 *  FROM [ENDF_Repairs_ContactsAddress] WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Order_ContactsAddress>();
        }

        public static Entity_Order_Brand GetBrand(int id)
        {
            string sqlStr = @"SELECT TOP 1 *  FROM [EDNF_Repairs_Brand] WHERE ID = @ID";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ID", id);
            return cmd.ExecuteEntity<Entity_Order_Brand>() ?? new Entity_Order_Brand();
        }

        public static IList<Entity_GetAssignedTo> GetAssignedTos()
        {
            string sqlStr = @"
SELECT  u.[UserID] ,
        u.[UserName] ,
        u.[NickName] ,
        u.[TrueName]
FROM    [EDNF_Account_User] u WITH ( NOLOCK )
        JOIN EDNF_Account_UserRoles ur WITH ( NOLOCK ) ON u.UserID = ur.UserID
WHERE   ur.RoleID = 3
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            return cmd.ExecuteEntities<Entity_GetAssignedTo>();
        }


        /// <summary>
        /// 修改订单状态
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="userid">status=2(指派任务)时候，给定AssignedTo user id</param>
        /// <param name="status"></param>
        /// <param name="status">订单备注，一般是客户添加</param>
        /// <returns></returns>
        public static bool ChangeOrderStatus(int orderid, int userid, int status, string remark = "", string makedate = "", string maketime="")
        {
            if (orderid <= 0)
            {
                throw new BusinessException("订单编号错误");
            }
            string sqlStr = @"
UPDATE TOP (1) [ENDF_Repairs_Order]
   SET [Statu] = @Status,ModifyTime=getdate(),Remark=@Remark";
            if (status == 2)
            {
                sqlStr += " ,AssignedTo=@AssignedTo ,makedate=@makedate, maketime=@maketime";
            }

            sqlStr += @" WHERE [ID] = @OrderID

INSERT INTO [ENDF_Repairs_OrderHistory]
           ([OrderID]
           ,[Status]
           ,[CreateTime]
           ,[Note])
     VALUES
           (@OrderID
           ,@Status
           ,getdate()
           ,@Note)
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@Remark", remark);
            cmd.SetParamter("@OrderID", orderid);
            cmd.SetParamter("@Status", status);
            if (status == 2)
            {
                cmd.SetParamter("@AssignedTo", userid);
            }

            string note = "";
            switch (status)
            {
                case 0:
                    note = "订单创建";
                    break;
                case 1:
                    note = "系统确认订单";
                    break;
                case 2:
                    note = "订单已分派"; break;
                case 3:
                    note = "工作已完成"; break;
                case 4:
                    note = "订单完成"; break;
                case 5:
                    note = "订单已关闭"; break;
                case -1:
                    note = "订单被删除"; break;
                default:
                    break;
            }
            cmd.SetParamter("@Note", note);
            return cmd.ExecuteNonQuery() > 0;
        }

        public static IList<Entity_Brand> GetBrands()
        {
            string sqlStr = @"
SELECT [ID]
      ,[Name]
      ,[Descriptino]
      ,[Deleted]
  FROM [EDNF_Repairs_Brand] WITH(NOLOCK)
";
            Command cmd = CommandManager.CreateCommand(sqlStr);

            return cmd.ExecuteEntities<Entity_Brand>();
        }



        public static int SaveUserOrder(Entity_Order order, Entity_Order_ContactsAddress contact)
        {
            string sql = @"
DECLARE @conId INT ;
DECLARE @oid INT ;
INSERT  INTO [ENDF_Repairs_ContactsAddress]
        ( [UserID] , [ContactsName] , [ContactsMobile] , [ContactsAddress] )
VALUES  ( @UserID , @ContactsName , @ContactsMobile , @ContactsAddress ) 
SELECT  @conId = @@IDENTITY
           
INSERT  INTO [ENDF_Repairs_Order]
        ( [OrderNumber] , [UserID] , [UserContactID] , [BrandID] , [Model] , [RepairsDescription] , 
          [ComputerType] , [CreateTime] , [AssignedTo] , [Statu] )
VALUES  ( @OrderNumber , @UserID , @conId , @BrandID , @Model , @RepairsDescription ,
          @ComputerType , GETDATE() , 0 , 0
        )
SELECT  @oid = @@IDENTITY
           
INSERT  INTO [ENDF_Repairs_OrderHistory]
        ( [OrderID] , [Status] , [CreateTime] , [Note]
        )
VALUES  ( @oid , 0 , GETDATE() , '客户创建订单'
        )

SELECT  @oid


";

            Command cmd = CommandManager.CreateCommand(sql);
            cmd.SetParamter("@UserID", contact.UserID);
            cmd.SetParamter("@ContactsName", contact.ContactsName);
            cmd.SetParamter("@ContactsMobile", contact.ContactsMobile);
            cmd.SetParamter("@ContactsAddress", contact.ContactsAddress);
            cmd.SetParamter("@OrderNumber", order.OrderNumber);
            cmd.SetParamter("@BrandID", order.BrandID);
            cmd.SetParamter("@Model", order.Model);
            cmd.SetParamter("@RepairsDescription", order.RepairsDescription);
            cmd.SetParamter("@ComputerType", order.ComputerType);


            return cmd.ExecuteSingle<int>();

        }

        public static IList<Entity_AssignedOrder> GetOrdersByAssignedTo(int userID)
        {
            string sqlStr = @"
SELECT   o.ID, 
        o.OrderNumber ,
        o.Model ,
        o.RepairsDescription ,
        o.ComputerType ,
        o.CreateTime ,
        o.Statu ,
        u.UserName ,
        u.NickName ,
        u.phone ,
        b.Name AS BrandName
FROM    ENDF_Repairs_Order o WITH ( NOLOCK )
        JOIN EDNF_Account_User u WITH ( NOLOCK ) ON u.UserID = o.UserID
        JOIN  EDNF_Account_User uu WITH ( NOLOCK ) ON uu.UserID = o.AssignedTo AND O.AssignedTo > 0
        JOIN ENDF_Repairs_ContactsAddress ca WITH ( NOLOCK ) ON ca.ID = o.UserContactID
                                                              AND ca.UserID = o.UserID
        JOIN EDNF_Repairs_Brand b WITH ( NOLOCK ) ON b.ID = o.BrandID
WHERE   o.AssignedTo = @UserID
ORDER BY o.CreateTime DESC ";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@UserID", userID);
            return cmd.ExecuteEntities<Entity_AssignedOrder>();
        }
        public static IList<Entity_UserOrder> GetUserOrders(int userID)
        {
            string sqlStr = @"
SELECT   o.ID, 
        o.OrderNumber ,
        o.Model ,
        o.RepairsDescription ,
        o.ComputerType ,
        o.CreateTime ,
        o.Statu ,
        u.UserName ,
        u.NickName ,
        u.phone ,
        b.Name AS BrandName
FROM    ENDF_Repairs_Order o WITH ( NOLOCK )
        JOIN EDNF_Account_User u WITH ( NOLOCK ) ON u.UserID = o.UserID
        JOIN ENDF_Repairs_ContactsAddress ca WITH ( NOLOCK ) ON ca.ID = o.UserContactID
                                                              AND ca.UserID = o.UserID
        JOIN EDNF_Repairs_Brand b WITH ( NOLOCK ) ON b.ID = o.BrandID
WHERE   o.UserID = @UserID
ORDER BY o.CreateTime DESC ";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@UserID", userID);
            return cmd.ExecuteEntities<Entity_UserOrder>();
        }


        public static int SaveSmsMessage(string phone, string message, int status, bool IsAdmin = false, bool IsBatch = false)
        {
            string sqlStr = @"
INSERT INTO [ENDF_Repairs_SMS]
           ([Mobile]
           ,[Message]
           ,[Status]
           ,[IsAdmin]
           ,[IsBatch])
     VALUES
           (@Mobile
           ,@Message
           ,@Status
           ,@IsAdmin
           ,@IsBatch);SELECT @@IDENTITY
";

            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@Mobile", phone);
            cmd.SetParamter("@Message", message);
            cmd.SetParamter("@Status", status);
            cmd.SetParamter("@IsAdmin", IsAdmin);
            cmd.SetParamter("@IsBatch", IsBatch);

            return cmd.ExecuteSingle<int>();
        }

        public static int ModifySmsStatus(int smsId, int Status, string StatusDescriptoin)
        {
            string sqlStr = @"
UPDATE TOP (1) [ENDF_Repairs_SMS]
   SET [Status] = @Status
      ,[StatusDescriptoin] = @StatusDescriptoin
      ,[ModifyTime] = GETDATE()
 WHERE ID = @ID
";

            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@ID", smsId);
            cmd.SetParamter("@Status", Status);
            cmd.SetParamter("@StatusDescriptoin", StatusDescriptoin);

            return cmd.ExecuteNonQuery();
        }

        public static Entity_Order_Notify GetOrderNotify(int orderId)
        {
            string sqlStr = @"
SELECT  o.[ID] ,
        o.[OrderNumber] ,
        [AssignedTo] ,
        ca.ContactsName ,
        ca.ContactsMobile ,
        ca.ContactsAddress ,
        u.NickName AS masterName,
        u.Phone AS masterPhone
FROM    [OnlineRepairsDB].[dbo].[ENDF_Repairs_Order] o
        JOIN dbo.ENDF_Repairs_ContactsAddress ca ON ca.ID = o.UserContactID
        JOIN dbo.EDNF_Account_User u ON u.UserID = o.AssignedTo
WHERE   o.Statu = 2
        AND o.ID = @OrderID
";
            Command cmd = CommandManager.CreateCommand(sqlStr);
            cmd.SetParamter("@OrderID", orderId);
            return cmd.ExecuteEntity<Entity_Order_Notify>() ?? new Entity_Order_Notify();
        }
    }
}
