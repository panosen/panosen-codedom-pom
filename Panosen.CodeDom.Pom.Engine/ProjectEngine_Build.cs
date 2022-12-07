using Panosen.CodeDom.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Pom.Engine
{
    partial class ProjectEngine
    {
        private XmlNode GenerateBuild(Project project)
        {
            var buildXmlNode = new XmlNode { Name = NodeName.BUILD, NewLineBeforeNode = true };

            var resourcesXmlNode = GenerateResource(project.Resources);
            if (resourcesXmlNode != null)
            {
                buildXmlNode.AddChild(resourcesXmlNode);
            }

            var pluginsXmlNode = ToPluginsXmlNode(project.Plugins);
            if (pluginsXmlNode != null)
            {
                buildXmlNode.AddChild(pluginsXmlNode);
            }

            return buildXmlNode;
        }
    }
}
