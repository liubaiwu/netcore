namespace Co.Core.Cache
{
    public interface ICacheManager
    {
        /// 获取
        T Get<T>(string key);
        ///设置
        bool Set<T>(string key,T t);

        bool Set(string key,string value);
    }
}