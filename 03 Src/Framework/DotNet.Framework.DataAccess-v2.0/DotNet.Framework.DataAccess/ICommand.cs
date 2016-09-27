using System.Collections.Generic;
using System.Data;

namespace DotNet.Framework.DataAccess
{
    interface ICommand
    {
        void SetParamter(string key, object value);

        int ExecuteNonQuery();

        object ExecuteSingle();

        T ExecuteEntity<T>();

        IList<T> ExecuteEntities<T>();

        DataSet ExecuteDataSet();
    }
}
