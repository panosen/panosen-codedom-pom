using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Pom
{
    /// <summary>
    /// Execution
    /// </summary>
    public class Execution
    {
        /// <summary>
        /// goals
        /// </summary>
        public List<string> Goals { get; set; }
    }

    /// <summary>
    /// ExecutionExtension
    /// </summary>
    public static class ExecutionExtension
    {
        /// <summary>
        /// AddGoal
        /// </summary>
        public static void AddGoal(this Execution execution, string goal)
        {
            if (execution.Goals == null)
            {
                execution.Goals = new List<string>();
            }

            execution.Goals.Add(goal);
        }
    }
}
