using System.IO;
using Xunit;

namespace dotnet_code_challenge.Test.DataAccess
{
    public class XmlFileParseTest
    {
        [Fact]
        public void GetHorseDetails_Success_Case1()
        {
            var fileParser = new XmlFileParser();
            string path = "TestData/Caulfield_Race1.xml";
            var horses = fileParser.GetHorseDetails(path);
            Assert.NotNull(horses);
            Assert.True(horses.Count > 0);
        }

        [Fact]
        public void GetHorseDetails_Fail_Case1()
        {
            var fileParser = new XmlFileParser();
            string path = "TestData/IncompleXml.xml";
            var horses = fileParser.GetHorseDetails(path);
            Assert.NotNull(horses);
            Assert.True(horses.Count == 0);
        }

        [Fact]
        public void GetHorses_FromXmlFile_FileNotFoundException()
        {
            var fileParser = new XmlFileParser();
            string path = "TestData/DoesNotExist.xml";
            Assert.Throws<FileNotFoundException>(() => fileParser.GetHorseDetails(path));
        }
    }
}