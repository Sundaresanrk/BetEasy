using Xunit;

namespace dotnet_code_challenge.Test.DataAccess
{
    public class FileParseHandlerTest
    {
        //ToDo: Add test methods to do more coverage
        [Fact]
        public void GetFileParserInstance_Success_Case1()
        {
            var fileParseHandler = new FileParseHandler();
            string path = "TestData/Caulfield_Race1.xml";
            var fileParser = fileParseHandler.GetFileParserInstance(path);
            Assert.NotNull(fileParser);
        }

        [Fact]
        public void GetFileParserInstance_Success_Case2()
        {
            var fileParseHandler = new FileParseHandler();
            string path = "TestData/Wolferhampton_Race1.json";
            var fileParser = fileParseHandler.GetFileParserInstance(path);
            Assert.NotNull(fileParser);
        }

        [Fact]
        public void GetFileParserInstance_Fail_Case1()
        {
            var fileParseHandler = new FileParseHandler();
            string path = "TestData/Wolferhampton_Race1.abc";
            var fileParser = fileParseHandler.GetFileParserInstance(path);
            Assert.Null(fileParser);
        }

        [Fact]
        public void GetFileParserInstance_Fail_Case2()
        {
            var fileParseHandler = new FileParseHandler();
            string path = "junk";
            var fileParser = fileParseHandler.GetFileParserInstance(path);
            Assert.Null(fileParser);
        }
    }
}