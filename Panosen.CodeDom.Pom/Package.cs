using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.CodeDom.Pom
{
    /// <summary>
    /// 包
    /// </summary>
    public class Package
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
        /// 注释
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// scope
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// optional
        /// </summary>
        public bool Optional { get; set; }

        /// <summary>
        /// exclusion
        /// </summary>
        public List<Package> ExclusionList { get; set; }
    }

    /// <summary>
    /// PackageExtension
    /// </summary>
    public static class PackageExtension
    {
        /// <summary>
        /// AddExclusion
        /// </summary>
        public static Package AddExclusion(this Package package, string groupId, string artifactId)
        {
            if (package.ExclusionList == null)
            {
                package.ExclusionList = new List<Package>();
            }

            Package exclusion = new Package();
            exclusion.GroupId = groupId;
            exclusion.ArtifactId = artifactId;

            package.ExclusionList.Add(exclusion);

            return exclusion;
        }
    }
}
