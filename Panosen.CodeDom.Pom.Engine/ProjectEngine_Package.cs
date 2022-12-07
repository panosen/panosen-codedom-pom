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
        private static XmlNode ToXmlNode(Package package)
        {
            XmlNode xmlNode = new XmlNode();

            xmlNode.Name = NodeName.DEPENDENCY;
            xmlNode.AddChild(NodeName.GROUP_ID).SetContent(package.GroupId);
            xmlNode.AddChild(NodeName.ARTIFACT_ID).SetContent(package.ArtifactId);
            if (package.Version != null)
            {
                xmlNode.AddChild(NodeName.VERSION).SetContent(package.Version);
            }

            if (package.Type != null)
            {
                xmlNode.AddChild(NodeName.TYPE).SetContent(package.Type);
            }
            if (package.Scope != null)
            {
                xmlNode.AddChild(NodeName.SCOPE).SetContent(package.Scope);
            }
            if (package.Optional)
            {
                xmlNode.AddChild(NodeName.OPTIONAL).SetContent(NodeValue.TRUE);
            }

            if (package.ExclusionList != null && package.ExclusionList.Count > 0)
            {
                var exclusions = xmlNode.AddChild(NodeName.EXCLUSIONS);
                foreach (var item in package.ExclusionList)
                {
                    var exclusion = exclusions.AddChild(NodeName.EXCLUSION);
                    exclusion.AddChild(NodeName.GROUP_ID).SetContent(item.GroupId);
                    exclusion.AddChild(NodeName.ARTIFACT_ID).SetContent(item.ArtifactId);
                }
            }

            return xmlNode;
        }
    }
}
