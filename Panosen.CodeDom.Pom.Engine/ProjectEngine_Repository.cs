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
        private static void GenerateRepository(XmlNode distributionManagement, List<DistributionRepository> distributionRepositoryList)
        {
            if (distributionRepositoryList == null || distributionRepositoryList.Count == 0)
            {
                return;
            }

            foreach (var distributionRepository in distributionRepositoryList)
            {
                var repository = new XmlNode { Name = NodeName.REPOSITORY };

                if (distributionRepository.Id != null)
                {
                    repository.AddChild(NodeName.ID).SetContent(distributionRepository.Id);
                }
                if (distributionRepository.Name != null)
                {
                    repository.AddChild(NodeName.NAME).SetContent(distributionRepository.Name);
                }
                if (distributionRepository.Layout != null)
                {
                    repository.AddChild(NodeName.LAYOUT).SetContent(distributionRepository.Layout);
                }
                if (distributionRepository.Url != null)
                {
                    repository.AddChild(NodeName.URL).SetContent(distributionRepository.Url);
                }
                if (distributionRepository.UniqueVersion != null)
                {
                    repository.AddChild(NodeName.UNIQUE_VERSION).SetContent(distributionRepository.UniqueVersion.Value ? "true" : "false");
                }

                if (repository.Children != null && repository.Children.Count > 0)
                {
                    distributionManagement.AddChild(repository);
                }
            }
        }
    }
}
