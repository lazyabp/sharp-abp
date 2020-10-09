﻿using Microsoft.Extensions.DependencyInjection;
using SharpAbp.Abp.FileStoring.Fakes;
using SharpAbp.Abp.FileStoring.TestObjects;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SharpAbp.Abp.FileStoring
{
    [DependsOn(
       typeof(AbpFileStoringModule),
       typeof(AbpTestBaseModule),
       typeof(AbpAutofacModule)
       )]
    public class AbpFileStoringTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddTransient<IFileProvider, FakeFileProvider1>();
            context.Services.AddTransient<IFileProvider, FakeFileProvider2>();

            Configure<AbpFileStoringOptions>(options =>
            {
                options.Containers
                    .ConfigureDefault(container =>
                    {
                        container.SetConfiguration("TestConfigDefault", "TestValueDefault");
                        container.ProviderType = typeof(FakeFileProvider1);
                    })
                    .Configure<TestContainer1>(container =>
                    {
                        container.SetConfiguration("TestConfig1", "TestValue1");
                        container.ProviderType = typeof(FakeFileProvider1);
                    })
                    .Configure<TestContainer2>(container =>
                    {
                        container.SetConfiguration("TestConfig2", "TestValue2");
                        container.ProviderType = typeof(FakeFileProvider2);
                    });
            });
        }
    }
}