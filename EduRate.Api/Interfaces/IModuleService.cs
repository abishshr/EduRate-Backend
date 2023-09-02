using EduRate.Api.Models;

namespace EduRate.Api.Interfaces
{
    public interface IModuleService
    {
        IEnumerable<Module> GetAllModules();
        Module GetModuleById(int moduleId);
        IEnumerable<Module> SearchModules(string query);
    }
}