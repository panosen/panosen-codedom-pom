using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.CodeDom.Pom
{
    /// <summary>
    /// PluginExtension
    /// </summary>
    public static class PluginExtension
    {
        /// <summary>
        /// AddConfiguration
        /// </summary>
        public static void AddConfiguration(this Plugin plugin, string key, string value)
        {
            if (plugin.Configurations == null)
            {
                plugin.Configurations = new Dictionary<string, string>();
            }

            plugin.Configurations.Add(key, value);
        }

        /// <summary>
        /// AddExecution
        /// </summary>
        public static void AddExecution(this Plugin plugin, Execution execution)
        {
            if (plugin.Executions == null)
            {
                plugin.Executions = new List<Execution>();
            }

            plugin.Executions.Add(execution);
        }

        /// <summary>
        /// AddExecution
        /// </summary>
        public static Execution AddExecution(this Plugin plugin)
        {
            if (plugin.Executions == null)
            {
                plugin.Executions = new List<Execution>();
            }

            Execution execution = new Execution();

            plugin.Executions.Add(execution);

            return execution;
        }
    }
}
