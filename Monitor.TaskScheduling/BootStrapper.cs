﻿using Autofac;
using Hangfire;
using Hangfire.Redis;
using JQ.Configurations;
using JQ.Container;
using JQ.Hangfire;
using JQ.Intercept;
using JQ.MongoDb;
using JQ.MQ.Logger;
using JQ.MQ.RabbitMQ;
using JQ.MQ.Serialization;
using JQ.Redis.StackExchangeRedis;
using JQ.Utils;
using Monitor.Infrastructure.MQ;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Monitor.TaskScheduling
{
    /// <summary>
    /// Copyright (C) 2015 备胎 版权所有。
    /// 类名：Bootstrap.cs
    /// 类属性：公共类（非静态）
    /// 类功能描述：启动程序
    /// 创建标识：yjq 2017/6/26 12:59:38
    /// </summary>
    public sealed class BootStrapper
    {
        private LoggerSubscribeTask _loggerSubcribe;
        private BackgroundJobServer _server;
        private List<Action> _removeJobActionList = new List<Action>();

        /// <summary>
        /// 启动时执行
        /// </summary>
        public void Install()
        {
            var repositoryAssembly = Assembly.Load("Monitor.Domain.Repository");
            var domainServiceAssembly = Assembly.Load("Monitor.Domain.DomainServer");
            var userApplicationAssembly = Assembly.Load("Monitor.UserApplication");

            var builder = new ContainerBuilder();

            JQConfiguration.Install(
                                    domainName: "Monitor.TaskScheduling",
                                    isStartConfigWatch: true,
                                    defaultLoggerName: "Monitor.Public.*"
                                    )
                            .UseDefaultConfig(builder)
                            .UseMongoDb()
                            .UseMQProtobufBinarySerializer()
                            .UseMQJsonBinarySerializer()
                            .UseRabbitMQ()
                            .UseStackExchageRedis()
                            .UseMQLogger(() => MQLoggerUtil.GetMQLoggerConfig())
                            .RegisterAssemblyTypes(repositoryAssembly, m => m.Namespace != null && m.Name.EndsWith("Repository"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(domainServiceAssembly, m => m.Namespace != null && m.Name.EndsWith("DomainServer"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .RegisterAssemblyTypes(userApplicationAssembly, new Type[] { typeof(BusinessDealIntercept) }, m => m.Namespace != null && m.Name.EndsWith("Application"), lifeStyle: LifeStyle.PerLifetimeScope)
                            .SetDefault<LoggerSubscribeTask>(lifeStyle: LifeStyle.PerLifetimeScope)
                ;

            ConfigWacherUtil.Install();
            UseHangfire();
        }

        /// <summary>
        /// 停止时执行
        /// </summary>
        public void UnInstall()
        {
            _loggerSubcribe?.Dispose();
            foreach (var removeJobAction in _removeJobActionList)
            {
                removeJobAction?.Invoke();
            }
            _server.Dispose();
            JQConfiguration.UnInstall();
        }

        /// <summary>
        /// 使用hangfire
        /// </summary>
        private void UseHangfire()
        {
            var options = new RedisStorageOptions
            {
                Prefix = "hangfire:",
                InvisibilityTimeout = TimeSpan.FromHours(3)
            };
            GlobalConfiguration.Configuration
              .UseColouredConsoleLogProvider()
              .UseJQActivator(ContainerManager.Current)
              .UseRedisStorage(ConfigUtil.GetValue("Redis.Connection"), options: options)
              ;
            _server = new BackgroundJobServer();
            InstallTasks();
        }

        /// <summary>
        /// 注册任务
        /// </summary>
        private void InstallTasks()
        {
            _loggerSubcribe = JQConfiguration.Resolve<LoggerSubscribeTask>();
            BackgroundJob.Enqueue(() => _loggerSubcribe.Start());
        }
    }
}