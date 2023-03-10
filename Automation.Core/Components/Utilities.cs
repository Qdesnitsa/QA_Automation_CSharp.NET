using System.Reflection;

namespace Automation.Core.Components
{
    internal static class Utilities
    {
        public static Type GetTypeByName(string type)
        {
            // get all assemblies path
            var assemblyFiles = Directory.GetFiles(Environment.CurrentDirectory, "*.dll", SearchOption.AllDirectories);
            
            var assemblies = new List<Assembly>();
            foreach (var file in assemblyFiles)
            {
                assemblies.Add(Assembly.Load(AssemblyName.GetAssemblyName(file)));
            }
            return assemblies
                .SelectMany(i => i.GetTypes())
                .FirstOrDefault(i => i.FullName.Equals(type, StringComparison.OrdinalIgnoreCase));
        }
    }
}
