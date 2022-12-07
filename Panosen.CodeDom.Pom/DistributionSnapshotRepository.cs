namespace Panosen.CodeDom.Pom
{
    /// <summary>
    /// DistributionSnapshotRepository
    /// </summary>
    public class DistributionSnapshotRepository
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Layout
        /// </summary>
        public string Layout { get; set; }

        /// <summary>
        /// UniqueVersion
        /// </summary>
        public bool? UniqueVersion { get; set; }
    }
}
