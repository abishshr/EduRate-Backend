using EduRate.Api.Models;

namespace EduRate.Api.Interfaces
{
    public interface IModuleService
    {
        IEnumerable<Module> GetAllModules();
        Module AddModule(Module newModule);
        Module GetModuleById(int moduleId);
        IEnumerable<Module> SearchModules(string query);
        
    }
}