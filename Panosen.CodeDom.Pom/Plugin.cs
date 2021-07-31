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
        /// example &lt;source&gt;1.6&lt;/source&gt;
        /// </summary>
        public Dictionary<string, string> Configurations { get; set; }

        /// <summary>
        /// Executions
        /// </summary>
        public List<Execution> Executions { get; set; }
    }
}
