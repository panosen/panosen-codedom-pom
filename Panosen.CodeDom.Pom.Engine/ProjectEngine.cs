using Panosen.CodeDom;
using Panosen.CodeDom.Xml;
using Panosen.CodeDom.Xml.Engine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Pom.Engine
{
    /// <summary>
    /// PomCodeEngine
    /// </summary>
    public class ProjectEngine
    {
        /// <summary>
        /// Generate
        /// </summary>
        public void Generate(Project codePom, CodeWriter codeWriter, GenerateOptions options = null)
        {
            if (codePom == null) { return; }
            if (codeWriter == null) { return; }
            options = options ?? new GenerateOptions();

            var projectNode = BuildProjectNode(codePom, options);

            new XmlCodeEngine().Generate(projectNode, codeWriter, new Panosen.CodeDom.Xml.Engine.GenerateOptions
            {
                TabString = "    ",
                AttribuesPerLine = 2
            });
        }

        private XmlNode BuildProjectNode(Project project, GenerateOptions options)
        {
            XmlNode projectXmlNode = new XmlNode();
            projectXmlNode.Name = NodeName.PROJECT;

            projectXmlNode.AddAttribute("xmlns", "http://maven.apache.org/POM/4.0.0");
            projectXmlNode.AddAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            projectXmlNode.AddAttribute("xsi:schemaLocation", "http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd");

            projectXmlNode.AddChild("modelVersion").SetContent("4.0.0");

            if (project.Parent != null)
            {
                var parent = projectXmlNode.AddChild(NodeName.PARENT, newLineBeforeNode: true);
                parent.AddChild(NodeName.GROUP_ID).SetContent(project.Parent.GroupId);
                parent.AddChild(NodeName.ARTIFACT_ID).SetContent(project.Parent.ArtifactId);
                parent.AddChild(NodeName.VERSION).SetContent(project.Parent.Version);
            }

            projectXmlNode.AddChild(NodeName.GROUP_ID, newLineBeforeNode: true).SetContent(project.GroupId);
            projectXmlNode.AddChild(NodeName.ARTIFACT_ID).SetContent(project.ArtifactId);
            projectXmlNode.AddChild(NodeName.VERSION).SetContent(project.Version);

            if (project.Packaging != null)
            {
                projectXmlNode.AddChild(NodeName.PACKAGING).SetContent(project.Packaging);
            }
            if (project.Name != null)
            {
                projectXmlNode.AddChild(NodeName.NAME).SetContent(project.Name);
            }
            if (project.Description != null)
            {
                projectXmlNode.AddChild(NodeName.DESCRIPTION).SetContent(project.Description);
            }

            if (project.PropertyList != null && project.PropertyList.Count > 0)
            {
                var properties = projectXmlNode.AddChild(NodeName.PROPERTIES);
                foreach (var property in project.PropertyList)
                {
                    properties.AddChild(property.Name).SetContent(property.Value);
                }
            }

            if (project.DependencyManagement != null && project.DependencyManagement.Count > 0)
            {
                var dependencies = projectXmlNode.AddChild(NodeName.DEPENDENCY_MANAGEMENT, newLineBeforeNode: true).AddChild(NodeName.DEPENDENCIES);
                foreach (var package in project.DependencyManagement)
                {
                    dependencies.AddChild(ToXmlNode(package));
                }
            }

            var resourcesXmlNode = ToResourcesXmlNode(project.Resources);
            var pluginsXmlNode = ToPluginsXmlNode(project.Plugins);
            if (resourcesXmlNode != null || pluginsXmlNode != null)
            {
                var buildXmlNode = projectXmlNode.AddChild(NodeName.BUILD);
                if (resourcesXmlNode != null)
                {
                    buildXmlNode.AddChild(resourcesXmlNode);
                }
                if (pluginsXmlNode != null)
                {
                    buildXmlNode.AddChild(pluginsXmlNode);
                }
            }

            if (project.DependencyList != null && project.DependencyList.Count > 0)
            {
                var dependencies = projectXmlNode.AddChild(NodeName.DEPENDENCIES, true);
                foreach (var package in project.DependencyList)
                {
                    var dependency = ToXmlNode(package);
                    dependency.NewLineBeforeNode = true;
                    dependencies.AddChild(dependency);
                }
            }

            return projectXmlNode;
        }

        private static XmlNode ToResourcesXmlNode(List<Resource> resources)
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
