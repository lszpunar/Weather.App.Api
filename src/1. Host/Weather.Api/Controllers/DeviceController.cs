using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Api.Controllers
{
    public class DeviceController : BaseController
    {
        private readonly IMapper _mapper;
        public DeviceController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> BrowseAsync()
        {
            await Task.CompletedTask;
            return NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            await Task.CompletedTask;
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync()
        {
            await Task.CompletedTask;
            return NotFound();
        }

    }
}
