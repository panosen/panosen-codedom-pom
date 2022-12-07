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
        private static XmlNode GenerateResource(List<Resource> resources)
        {
            if (resources == null || resources.Count == 0)
            {
                return null;
            }

            XmlNode resourcesXmlNode = new XmlNode();
            resourcesXmlNode.Name = "resources";

            foreach (var resource in resources)
            {
                XmlNode resourceXmlNode = resourcesXmlNode.AddChild("resource");
                if (resource.Directory != null)
                {
                    resourceXmlNode.AddChild("directory").SetContent(resource.Directory);
                }
            }

            return resourcesXmlNode;
        }
    }
}
