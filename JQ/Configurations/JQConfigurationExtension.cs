using JQ.Logger.NLogger;
using JQ.Serialization.DefaultBinary;
using JQ.Serialization.NewtonsoftJson;
using JQ.Serialization.Protobuf;
using JQ.Utils;
using JQ.Container.Autofac;

namespace JQ.Configurations
{
    /// <summary>
    /// Copyright (C) 2017 yjq 版权所有。
    /// 类名：JQConfigurationExtension.cs
    /// 类属性：公共类（静态）
    /// 类功能描述：JQConfigurationExtension
    /// 创建标识：yjq 2017/6/11 17:56:08
    /// </summary>
    public static class JQConfigurationExtension
    {
        public static JQConfiguration UseDefaultConfig(this JQConfiguration configuration)
        {
            configuration.UseAutofac()
                         .UseJsnoNet()
                         //.UseDefaultBinarySerializer()
                         .UseDefaultBinarySerializer()
                         .UseProtobufBinarySerializer()
                         .UseNLog()
                         .AddUnstallAction(() => FileWatchUtil.UnInstall());
            ;

            return configuration;
        }
    }
}