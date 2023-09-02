using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Models;
using EduRate.Api.Services;

namespace EduRate.Api.Controllers
{
    [ApiController]
    [Route("api/modules")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(IModuleService moduleService)
        {
            _moduleService = moduleService;
        }

        [HttpGet]
        public IActionResult GetAllModules()
        {
            var modules = _moduleService.GetAllModules();
            return Ok(modules);
        }

        [HttpGet("{moduleId}")]
        public IActionResult GetModuleById(int moduleId)
        {
            var module = _moduleService.GetModuleById(moduleId);
            if (module == null)
                return NotFound();
            return Ok(module);
        }

        [HttpGet("search")]
        public IActionResult SearchModules(string query)
        {
            var modules = _moduleService.SearchModules(query);
            return Ok(modules);
        }
    }
}