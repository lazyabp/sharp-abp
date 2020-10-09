﻿using Volo.Abp.Modularity;

namespace SharpAbp.Abp.Micro.Discovery.AddressTable
{
    [DependsOn(
        typeof(AbpMicroDiscoveryModule)
    )]
    public class AbpMicroDiscoveryAddressTableModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpMicroDiscoveryOptions>(c =>
            {
                c.ProviderNameMappers.SetProvider(AddressTableDiscoveryProviderConfigurationNames.ProviderName, typeof(AddressTableServiceDiscoveryProvider));
            });
        }

    }
}