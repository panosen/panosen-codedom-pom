using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savory.CodeDom.Pom
{
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
