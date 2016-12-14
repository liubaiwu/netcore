using Microsoft.Extensions.Configuration;

namespace Co.Utils
{
    ///配置文件获取工具类
    public class ConfigUtils
    {
        IConfigurationRoot _configuration;
        public ConfigUtils(IConfigurationRoot configuration)
        {
            _configuration=configuration;
        }
        ///获取appsettings.json ConnectionStrings 配置文件
        public string GetValue(string key)
        {
            if(string.IsNullOrEmpty(key))
                return null;
            return  _configuration.GetConnectionString(key);
        }
    }
}