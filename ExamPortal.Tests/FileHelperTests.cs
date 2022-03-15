using ExamPortal.Helpers;
using System;
using System.IO;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Xunit;
using Moq;

namespace ExamPortal.Tests
{
    public class FileHelperTests
    {
        [Theory]
        [InlineData("test.xml", "xml")]
        [InlineData("image.jpg", "jpg")]
        [InlineData("archive.zip", "zip")]
        [InlineData("test.test.zip", "zip")]
        [InlineData("test!@#test.png", "png")]
        public void GetExtension_Return_Correct_Extension(string value, string expected)
        {

            var assert = FileHelper.GetExtension(value);

            assert.Should().Be(expected);
        }

        [Fact]
        public void CheckIfZipFile_With_Other_Format()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            var assert = FileHelper.CheckIfZipFile(file);

            assert.Should().BeFalse();
        }

        [Fact]
        public void CheckIfZipFile_with_zip_format_return_true()
        {
            var fileMock = new Mock<IFormFile>();
            var fileName = "test.zip";
            fileMock.Setup(_ => _.FileName).Returns(fileName);

            var file = fileMock.Object;

            var assert = FileHelper.CheckIfZipFile(file);

            assert.Should().BeTrue();
        }

        [Fact]
        public void CheckIfXmlFile_With_Other_Format()
        {
            var fileMock = new Mock<IFormFile>();
            var content = "Hello World from a Fake File";
            var fileName = "test.pdf";
            var ms = new MemoryStream();
            var writer = new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
            fileMock.Setup(_ => _.FileName).Returns(fileName);
            fileMock.Setup(_ => _.Length).Returns(ms.Length);

            var file = fileMock.Object;

            var assert = FileHelper.CheckIfXmlFile(file);

            assert.Should().BeFalse();
        }

        [Fact]
        public void CheckIfXmlFile_With_Xml_Format()
        {
            {
                var fileMock = new Mock<IFormFile>();
                var content = "<test></test>";
                var fileName = "test.xml";
                var ms = new MemoryStream();
                var writer = new StreamWriter(ms);
                writer.Write(content);
                writer.Flush();
                ms.Position = 0;
                fileMock.Setup(_ => _.OpenReadStream()).Returns(ms);
                fileMock.Setup(_ => _.FileName).Returns(fileName);
                fileMock.Setup(_ => _.Length).Returns(ms.Length);

                var file = fileMock.Object;

                var assert = FileHelper.CheckIfXmlFile(file);

                assert.Should().BeTrue();
            }
        }
    }
}
