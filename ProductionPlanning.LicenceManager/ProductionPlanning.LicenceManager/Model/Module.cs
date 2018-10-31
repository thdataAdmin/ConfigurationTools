using System.Collections.Generic;

namespace ProductionPlanning.LicenceManager.Model
{
    
    public class Module
    {
        public long Id { get; set; }
        public string ModuleName { get; set; }
        public bool IsBaseModule { get; set; }
        public string DisplayName { get; set; }

    }

    public class ModulesConfig
    {
        public static List<Module> Modules = new List<Module>
        {
            new Module
            {
                ModuleName = "Planning objects",
                IsBaseModule = true,
                DisplayName = "Planungsobjekte"
            },
            new Module
            {
                ModuleName = "Planning",
                IsBaseModule = true,
                DisplayName = "Planung"
            },
            new Module
            {
                ModuleName = "Base data",
                IsBaseModule = true,
                DisplayName = "Stammdaten"
            },
            new Module
            {
                ModuleName = "Administration",
                IsBaseModule = true,
                DisplayName = "Administration"
            },
            new Module
            {
                ModuleName = "Konfiguration",
                IsBaseModule = true,
                DisplayName = "Configuration"
            },
            new Module
            {
                ModuleName = "Dashboard",
                IsBaseModule = false,
                DisplayName = "Dashboard"
            },
            new Module
            {
                ModuleName = "Workbench",
                IsBaseModule = false,
                DisplayName = "Workbench"
            },
            new Module
            {
                ModuleName = "Konflikt Radar",
                IsBaseModule = false,
                DisplayName = "Conflict radar"
            },
            new Module
            {
                ModuleName = "Import",
                IsBaseModule = false,
                DisplayName = "Import"
            }
        };
    }
}
