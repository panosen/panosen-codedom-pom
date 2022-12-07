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
        private static XmlNode ToPluginsXmlNode(List<Plugin> plugins)
        {
            if (plugins == null || plugins.Count == 0)
            {
                return null;
            }

            XmlNode pluginsXmlNode = new XmlNode();
            pluginsXmlNode.Name = NodeName.PLUGINS;

            foreach (var plugin in plugins)
            {
                XmlNode pluginXmlNode = pluginsXmlNode.AddChild(NodeName.PLUGIN);
                pluginXmlNode.AddChild(NodeName.GROUP_ID).SetContent(plugin.GroupId);
                pluginXmlNode.AddChild(NodeName.ARTIFACT_ID).SetContent(plugin.ArtifactId);
                if (!string.IsNullOrEmpty(plugin.Version))
                {
                    pluginXmlNode.AddChild(NodeName.VERSION).SetContent(plugin.Version);
                }

                if (plugin.Configurations != null && plugin.Configurations.Count > 0)
                {
                    var configurationXmlNode = pluginXmlNode.AddChild(NodeName.CONFIGURATION);
                    foreach (var item in plugin.Configurations)
                    {
                        configurationXmlNode.AddChild(item.Key).SetContent(item.Value);
                    }
                }

                if (plugin.Executions != null && plugin.Executions.Count > 0)
                {
                    var executionsXmlNode = pluginXmlNode.AddChild(NodeName.EXECUTIONS);
                    foreach (var item in plugin.Executions)
                    {
                        var executionXmlNode = executionsXmlNode.AddChild(NodeName.EXECUTION);
                        if (item.Goals != null && item.Goals.Count > 0)
                        {
                            var goalsXmlNode = executionXmlNode.AddChild(NodeName.GOALS);
                            foreach (var goal in item.Goals)
                            {
                                goalsXmlNode.AddChild(NodeName.GOAL).SetContent(goal);
                            }
                        }
                    }
                }
            }

            return pluginsXmlNode;
        }
    }
}
