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
    public partial class ProjectEngine
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
            projectXmlNode.NewLineBeforeEnd = true;

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
                var properties = projectXmlNode.AddChild(NodeName.PROPERTIES, true);
                foreach (var property in project.PropertyList)
                {
                    properties.AddChild(property.Name).SetContent(property.Value);
                }
            }

            {
                var distributionManagement = new XmlNode { Name = NodeName.DISTRIBUTION_MANAGEMENT, NewLineBeforeNode = true };

                GenerateRepository(distributionManagement, project.DistributionRepositoryList);

                GenerateSnapshotRepository(distributionManagement, project.DistributionSnapshotRepositoryList);

                if (distributionManagement.Children != null && distributionManagement.Children.Count > 0)
                {
                    projectXmlNode.AddChild(distributionManagement);
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

            {
                var buildXmlNode = GenerateBuild(project);
                if (buildXmlNode.Children != null && buildXmlNode.Children.Count > 0)
                {
                    projectXmlNode.AddChild(buildXmlNode);
                }
            }

            if (project.DependencyList != null && project.DependencyList.Count > 0)
            {
                var dependencies = projectXmlNode.AddChild(NodeName.DEPENDENCIES, true);
                foreach (var package in project.DependencyList)
                {
                    var dependency = ToXmlNode(package);
                    dependencies.AddChild(dependency);
                }
            }

            return projectXmlNode;
        }
    }
}
