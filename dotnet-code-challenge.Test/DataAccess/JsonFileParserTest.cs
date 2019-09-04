using System.IO;
using Xunit;

namespace dotnet_code_challenge.Test.DataAccess
{
    public class JsonFileParserTest
    {
        [Fact]
        public void GetHorseDetails_Success_Case1()
        {
            var fileParser = new JsonFileParser();
            string path = "TestData/Wolferhampton_Race1.json";
            var horses = fileParser.GetHorseDetails(path);
            Assert.NotNull(horses);
            Assert.True(horses.Count > 0);
        }

        [Fact]
        public void GetHorseDetails_Fail_Case1()
        {
            var fileParser = new XmlFileParser();
            string path = "TestData/DoesNotExist.json";
            Assert.Throws<FileNotFoundException>(() => fileParser.GetHorseDetails(path));
        }

        [Fact]
        public void GetHorsesDetails_Fail_Case2()
        {
            var fileParser = new JsonFileParser();
            string path = "";
            var horses = fileParser.GetHorseDetails(path);
            Assert.NotNull(horses);
            Assert.True(horses.Count == 0);
        }
    }
}