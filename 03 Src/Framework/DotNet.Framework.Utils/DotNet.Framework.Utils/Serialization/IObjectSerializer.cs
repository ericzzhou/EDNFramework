
namespace DotNet.Framework.Utils.Serialization
{
    public interface IObjectSerializer
    {
        string Serialize<T>(T t);

        T Deserialize<T>(string str);
    }
}
