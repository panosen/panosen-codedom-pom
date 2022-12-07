using Panosen.CodeDom.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.CodeDom.Pom.Engine
{
    partial class ProjectEngine
    {


        private static void GenerateSnapshotRepository(XmlNode distributionManagement, List<DistributionSnapshotRepository> distributionSnapshotRepositoryList)
        {
            if (distributionSnapshotRepositoryList == null || distributionSnapshotRepositoryList.Count == 0)
            {
                return;
            }

            foreach (var distributionSnapshotRepository in distributionSnapshotRepositoryList)
            {
                var snapshotRepository = new XmlNode { Name = NodeName.SNAPSHOT_REPOSITORY };

                if (distributionSnapshotRepository.Id != null)
                {
                    snapshotRepository.AddChild(NodeName.ID).SetContent(distributionSnapshotRepository.Id);
                }
                if (distributionSnapshotRepository.Name != null)
                {
                    snapshotRepository.AddChild(NodeName.NAME).SetContent(distributionSnapshotRepository.Name);
                }
                if (distributionSnapshotRepository.Layout != null)
                {
                    snapshotRepository.AddChild(NodeName.LAYOUT).SetContent(distributionSnapshotRepository.Layout);
                }
                if (distributionSnapshotRepository.Url != null)
                {
                    snapshotRepository.AddChild(NodeName.URL).SetContent(distributionSnapshotRepository.Url);
                }
                if (distributionSnapshotRepository.UniqueVersion != null)
                {
                    snapshotRepository.AddChild(NodeName.UNIQUE_VERSION).SetContent(distributionSnapshotRepository.UniqueVersion.Value ? "true" : "false");
                }
                if (snapshotRepository.Children != null && snapshotRepository.Children.Count > 0)
                {
                    distributionManagement.AddChild(snapshotRepository);
                }
            }
        }
    }
}
