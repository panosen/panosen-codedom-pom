using System;
using System.Collections.Generic;

namespace Savory.CodeDom.Pom
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
    }
}
