using EduRate.Api.Interfaces;
using EduRate.Api.Models;
using EduRate.Api.Data;

namespace EduRate.Api.Services
{
    public class ModuleService : IModuleService
    {
        private readonly AppDbContext _context;

        public ModuleService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Module> GetAllModules()
        {
            return _context.Modules.ToList();
        }

        public Module AddModule(Module newModule)
        {
            _context.Modules.Add(newModule);
            _context.SaveChanges();
            return newModule;
        }

        public Module GetModuleById(int moduleId)
        {
            return _context.Modules.FirstOrDefault(m => m.Id == moduleId);
        }

        public IEnumerable<Module> SearchModules(string query)
        {
            return _context.Modules.Where(m => m.Name.Contains(query) || m.Course.Contains(query) || m.Faculty.Contains(query)).ToList();
        }
    }
}