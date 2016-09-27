using System.Collections.Generic;
using System.Data;

namespace DotNet.Framework.DataAccess
{
    interface ICommand
    {
        void SetParamter(string key, object value);

        void SetOutParameter(string name, DbType dbType, int? size);

        void SetReplaceParamter(string name, string value);

        T GetOutParameter<T>(string name);

        int ExecuteNonQuery();

        object ExecuteSingle();

        T ExecuteSingle<T>();

        T ExecuteEntity<T>();

        IList<T> ExecuteEntities<T>();

        DataSet ExecuteDataSet();

        IDataReader ExecuteDataReader();
    }
}
