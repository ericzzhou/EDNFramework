
namespace DotNet.Framework.DataAccess
{
    interface IBuildSqlString
    {
        string BuildeUpdateString<T>(int? updateCount, string tableName, string updateWhere);
        string BuildeUpdateString<T>(T dataSource, int? updateCount, string tableName, string updateWhere);
    }
}
