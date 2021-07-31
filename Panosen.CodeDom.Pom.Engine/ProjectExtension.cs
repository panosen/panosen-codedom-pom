using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.CodeDom.Pom.Engine
{
    /// <summary>
    /// CodeProjectExtension
    /// </summary>
    public static class ProjectExtension
    {
        /// <summary>
        /// TransformText
        /// </summary>
        public static string TransformText(this Project project, GenerateOptions options = null)
        {
            var builder = new StringBuilder();

            new ProjectEngine().Generate(project, builder, options);

            return builder.ToString();
        }
    }
}
