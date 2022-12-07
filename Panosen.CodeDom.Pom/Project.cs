using System;
using System.Collections.Generic;

namespace Panosen.CodeDom.Pom
{
    /// <summary>
    /// 一个pom文件
    /// </summary>
    public class Project
    {
        /// <summary>
        /// groupId
        /// </summary>
        public string GroupId { get; set; }

        /// <summary>
        /// artifactId
        /// </summary>
        public string ArtifactId { get; set; }

        /// <summary>
        /// version
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 父pom
        /// </summary>
        public Package Parent { get; set; }

        /// <summary>
        /// packaging
        /// </summary>
        public string Packaging { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// properies
        /// </summary>
        public List<Property> PropertyList { get; set; }

        /// <summary>
        /// dependencyManagement
        /// </summary>
        public List<Package> DependencyManagement { get; set; }

        /// <summary>
        /// dependencies
        /// </summary>
        public List<Package> DependencyList { get; set; }

        /// <summary>
        /// build/resources
        /// </summary>
        public List<Resource> Resources { get; set; }

        /// <summary>
        /// plugins
        /// </summary>
        public List<Plugin> Plugins { get; set; }

        /// <summary>
        /// 发布正式版
        /// </summary>
        public List<DistributionRepository> DistributionRepositoryList { get; set; }

        /// <summary>
        /// 发布草稿版
        /// </summary>
        public List<DistributionSnapshotRepository> DistributionSnapshotRepositoryList { get; set; }
    }

    /// <summary>
    /// CodeProjectExtension
    /// </summary>
    public static class ProjectExtension
    {
        /// <summary>
        /// AddProperty
        /// </summary>
        public static Property AddProperty(this Project project, string name, string value)
        {
            if (project.PropertyList == null)
            {
                project.PropertyList = new List<Property>();
            }

            Property property = new Property();
            property.Name = name;
            property.Value = value;

            project.PropertyList.Add(property);

            return property;
        }

        /// <summary>
        /// AddDistributionRepository
        /// </summary>
        public static void AddDistributionRepository(this Project project, string id, string url, string name = null, bool? uniqueVersion = null, string layout = null)
        {
            if (project.DistributionRepositoryList == null)
            {
                project.DistributionRepositoryList = new List<DistributionRepository>();
            }

            var distributionRepository = new DistributionRepository();
            distributionRepository.Id = id;
            distributionRepository.Url = url;
            distributionRepository.Name = name;
            distributionRepository.UniqueVersion = uniqueVersion;
            distributionRepository.Layout = layout;

            project.DistributionRepositoryList.Add(distributionRepository);
        }

        /// <summary>
        /// AddDistributionSnapshotRepository
        /// </summary>
        public static void AddDistributionSnapshotRepository(this Project project, string id, string url, string name = null, bool? uniqueVersion = null, string layout = null)
        {
            if (project.DistributionSnapshotRepositoryList == null)
            {
                project.DistributionSnapshotRepositoryList = new List<DistributionSnapshotRepository>();
            }

            var distributionSnapshotRepository = new DistributionSnapshotRepository();
            distributionSnapshotRepository.Id = id;
            distributionSnapshotRepository.Url = url;
            distributionSnapshotRepository.Name = name;
            distributionSnapshotRepository.UniqueVersion = uniqueVersion;
            distributionSnapshotRepository.Layout = layout;

            project.DistributionSnapshotRepositoryList.Add(distributionSnapshotRepository);
        }

        /// <summary>
        /// AddDependencyManagement
        /// </summary>
        public static void AddDependencyManagement(this Project codeProject, Package package)
        {
            if (codeProject.DependencyManagement == null)
            {
                codeProject.DependencyManagement = new List<Package>();
            }

            codeProject.DependencyManagement.Add(package);
        }

        /// <summary>
        /// AddDependencyManagement
        /// </summary>
        public static Package AddDependencyManagement(this Project codeProject, string groupId, string artifactId, string version, string type = null, string scope = null)
        {
            if (codeProject.DependencyManagement == null)
            {
                codeProject.DependencyManagement = new List<Package>();
            }

            Package package = new Package();
            package.GroupId = groupId;
            package.ArtifactId = artifactId;
            package.Version = version;
            package.Type = type;
            package.Scope = scope;

            codeProject.DependencyManagement.Add(package);

            return package;
        }

        /// <summary>
        /// AddDependency
        /// </summary>
        public static void AddDependency(this Project codeProject, Package package)
        {
            if (codeProject.DependencyList == null)
            {
                codeProject.DependencyList = new List<Package>();
            }

            codeProject.DependencyList.Add(package);
        }

        /// <summary>
        /// AddDependency
        /// </summary>
        public static Package AddDependency(this Project codeProject, string groupId, string artifactId, string version = null, string scope = null, bool optional = false)
        {
            if (codeProject.DependencyList == null)
            {
                codeProject.DependencyList = new List<Package>();
            }

            Package package = new Package();
            package.GroupId = groupId;
            package.ArtifactId = artifactId;
            package.Version = version;
            package.Scope = scope;
            package.Optional = optional;

            codeProject.DependencyList.Add(package);

            return package;
        }

        /// <summary>
        /// AddPlugin
        /// </summary>
        public static void AddPlugin(this Project codeProject, Plugin plugin)
        {
            if (codeProject.Plugins == null)
            {
                codeProject.Plugins = new List<Plugin>();
            }

            codeProject.Plugins.Add(plugin);
        }

        /// <summary>
        /// AddPlugin
        /// </summary>
        public static Plugin AddPlugin(this Project codeProject, string groupId, string artifactId, string version = null)
        {
            if (codeProject.Plugins == null)
            {
                codeProject.Plugins = new List<Plugin>();
            }

            Plugin plugin = new Plugin();
            plugin.GroupId = groupId;
            plugin.ArtifactId = artifactId;
            plugin.Version = version;

            codeProject.Plugins.Add(plugin);

            return plugin;
        }

        /// <summary>
        /// AddResource
        /// </summary>
        public static Resource AddResource(this Project codeProject, string directory = null)
        {
            if (codeProject.Resources == null)
            {
                codeProject.Resources = new List<Resource>();
            }

            Resource resource = new Resource();
            resource.Directory = directory;

            codeProject.Resources.Add(resource);

            return resource;
        }
    }
}
