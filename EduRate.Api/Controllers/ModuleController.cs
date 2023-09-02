using EduRate.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using EduRate.Api.Models;

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
            {
                return NotFound();
            }
            return Ok(module);
        }

        [HttpGet("search")]
        public IActionResult SearchModules(string query)
        {
            var modules = _moduleService.SearchModules(query);
            return Ok(modules);
        }

        [HttpPost]
        public IActionResult CreateModule([FromBody] Module newModule)
        {
            if (newModule == null)
            {
                return BadRequest("Module cannot be null");
            }

            // Validate the module object here before you save it to the database
            if (string.IsNullOrEmpty(newModule.Name) || string.IsNullOrEmpty(newModule.Faculty))
            {
                return BadRequest("Name and Faculty fields must not be empty");
            }

            var createdModule = _moduleService.AddModule(newModule);

            return CreatedAtAction(nameof(GetModuleById), new { moduleId = createdModule.Id }, createdModule);
        }
    }
}