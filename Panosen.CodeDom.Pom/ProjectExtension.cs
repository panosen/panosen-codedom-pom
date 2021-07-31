using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.CodeDom.Pom
{
    /// <summary>
    /// CodeProjectExtension
    /// </summary>
    public static class ProjectExtension
    {
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
        public static Package AddDependencyManagement(this Project codeProject, string groupId, string artifactId, string version, string type = "pom", string scope = "import")
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
        public static Plugin AddPlugin(this Project codeProject, string groupId, string artifactId)
        {
            if (codeProject.Plugins == null)
            {
                codeProject.Plugins = new List<Plugin>();
            }

            Plugin plugin = new Plugin();
            plugin.GroupId = groupId;
            plugin.ArtifactId = artifactId;

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
