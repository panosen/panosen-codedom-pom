using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.CodeDom.Pom
{
    /// <summary>
    /// Plugin
    /// </summary>
    public class Plugin
    {
        /// <summary>
        /// GroupId
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// ArtifactId
        /// </summary>
        public string ArtifactId { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// example &lt;source&gt;1.6&lt;/source&gt;
        /// </summary>
        public Dictionary<string, string> Configurations { get; set; }

        /// <summary>
        /// Executions
        /// </summary>
        public List<Execution> Executions { get; set; }
    }

    /// <summary>
    /// PluginExtension
    /// </summary>
    public static class PluginExtension
    {
        /// <summary>
        /// AddConfiguration
        /// </summary>
        public static Plugin AddConfiguration(this Plugin plugin, string key, string value)
        {
            if (plugin.Configurations == null)
            {
                plugin.Configurations = new Dictionary<string, string>();
            }

            plugin.Configurations.Add(key, value);

            return plugin;
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
