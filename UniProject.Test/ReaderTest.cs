using Xunit;
using System;
using System.Linq;
using System.IO;

using Services.Implementation;

namespace UniProject.Test
{
    public class ReaderTest
    {
        // Invalid file is 06.10.2021.csv
        // Correct file is 07.10.2021.csv

        [Fact]
        public void Return_Emprty_List_When_Reading_Blank_File()
        {
            FilesReader filesReader = new FilesReader();

            var fileDate = @"D:\UniProject\UniProject.Test\06.10.2021.csv";

            var list = filesReader.FileReader(fileDate);

            Assert.Empty(list);

        }

        [Fact]
        public void Reading_Correct_File()
        {
            var fileDate = @"D:\UniProject\UniProject.Test\07.10.2021.csv";

            FilesReader filesReader = new FilesReader();

            var result = filesReader.FileReader(fileDate);

            if (result.Count() == 0)
            {
                throw new ArgumentException(Services.Common.Const.NullElementsMessage);
            }

            Assert.NotNull(result);
        }

        [Fact]
        public void Reading_Incorrect_File_Format()
        {

            Assert.Throws<Exception>(() =>
                {
                    var fileDate = @"D:\UniProject\UniProject.Test\02.10.2021.docx";

                    string extension = Path.GetExtension(fileDate);

                    if (extension != "csv")
                    {
                        throw new Exception();
                    }
                });
        }
    }
}