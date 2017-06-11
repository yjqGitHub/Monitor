using JQ.Configurations;

namespace JQ.Serialization.NewtonsoftJson
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：NewtonsoftJsonConfigExtension.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：NewtonsoftJsonConfigExtension
    /// 创建标识：yjq 2017/6/11 18:01:26
    /// </summary>
    public static class NewtonsoftJsonConfigExtension
    {
        public static JQConfiguration UseJsnoNet(this JQConfiguration configuration)
        {
            configuration.SetDefault<IJsonSerializer, NewtonsoftJsonSerializer>();
            return configuration;
        }

        private const string REGISTER_NAME_JSONBINARY = "JsonBinary";

        public static JQConfiguration UseJsonBinarySerializer(this JQConfiguration configuration)
        {
            configuration.SetDefault<IBinarySerializer, NewtonsoftJsonBinarySerializer>(serviceName: REGISTER_NAME_JSONBINARY);
            configuration.AddRegisterName(typeof(NewtonsoftJsonBinarySerializer).TypeHandle, REGISTER_NAME_JSONBINARY);
            return configuration;
        }
    }
}