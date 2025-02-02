﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SharpAbp.Abp.FileStoringManagement
{
    [Area("file-storing")]
    [Route("api/file-provider")]
    public class FileProviderController : FileStoringController
    {
        private readonly IFileProviderAppService _fileProviderAppService;
        public FileProviderController(IFileProviderAppService fileProviderAppService)
        {
            _fileProviderAppService = fileProviderAppService;
        }

        [HttpGet]
        public List<ProviderDto> GetProviders()
        {
            return _fileProviderAppService.GetProviders();
        }

        [HttpGet]
        [Route("has-provider/{provider}")]
        public bool HasProvider(string provider)
        {
            return _fileProviderAppService.HasProvider(provider);
        }

        [HttpGet]
        [Route("{provider}")]
        public ProviderOptionsDto GetOptions(string provider)
        {
            return _fileProviderAppService.GetOptions(provider);
        }

    }
}
