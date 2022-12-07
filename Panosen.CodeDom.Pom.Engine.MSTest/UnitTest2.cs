using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;

namespace Panosen.CodeDom.Pom.Engine.MSTest
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            var project = PrepareProject();

            var actual = project.TransformText();

            var expected = PrepareExpected();

            Assert.AreEqual(expected, actual);
        }

        static string PrepareExpected()
        {
            return @"<project xmlns=""http://maven.apache.org/POM/4.0.0"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
        xsi:schemaLocation=""http://maven.apache.org/POM/4.0.0 http://maven.apache.org/xsd/maven-4.0.0.xsd"">
    <modelVersion>4.0.0</modelVersion>

    <groupId>abc</groupId>
    <artifactId>defr</artifactId>
    <version>1.0.0</version>

    <distributionManagement>
        <repository>
            <id>a1</id>
            <url>aaa</url>
        </repository>
        <snapshotRepository>
            <id>a2</id>
            <url>bbb</url>
        </snapshotRepository>
    </distributionManagement>

</project>
";
        }

        public Project PrepareProject()
        {
            Project project = new Project();
            project.GroupId = "abc";
            project.ArtifactId = "defr";
            project.Version = "1.0.0";

            project.AddDistributionRepository("a1", "aaa");
            project.AddDistributionSnapshotRepository("a2", "bbb");

            return project;
        }
    }
}
