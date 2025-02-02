﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace SharpAbp.Abp.MapTenancyManagement
{
    [Area("map-tenancy")]
    [Route("api/map-tenant")]
    public class MapTenantController : MapTenancyController
    {
        private readonly IMapTenantAppService _mapTenantAppService;
        public MapTenantController(IMapTenantAppService mapTenantAppService)
        {
            _mapTenantAppService = mapTenantAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MapTenantDto> GetAsync(Guid id)
        {
            return await _mapTenantAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("get-by-code/{code}")]
        public async Task<MapTenantDto> GetAsync(string code)
        {
            return await _mapTenantAppService.GetByCodeAsync(code);
        }

        [HttpGet]
        public async Task<PagedResultDto<MapTenantDto>> GetPagedListAsync(MapTenantPagedRequestDto input)
        {
            return await _mapTenantAppService.GetPagedListAsync(input);
        }

        [HttpPost]
        public async Task<Guid> CreateAsync([FromBody]CreateMapTenantDto input)
        {
            return await _mapTenantAppService.CreateAsync(input);
        }

        [HttpPut]
        public async Task UpdateAsync([FromBody]UpdateMapTenantDto input)
        {
            await _mapTenantAppService.UpdateAsync(input);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _mapTenantAppService.DeleteAsync(id);
        }
    }
}
