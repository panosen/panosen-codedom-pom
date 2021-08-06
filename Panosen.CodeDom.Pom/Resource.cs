using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Pom
{
    /// <summary>
    /// Resource
    /// </summary>
    public class Resource
    {
        /// <summary>
        /// &lt;directory&gt;${Directory}&lt;/directory&gt;
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// &lt;include&gt;${Include}&gt;/include&gt;
        /// </summary>
        public List<string> Includes { get; set; }

        /// <summary>
        /// &lt;filtering&gt;${Filtering}&lt;/filtering&gt;
        /// </summary>
        public bool Filtering { get; set; }
    }
}
