using Xunit;

using Services.Implementation;
using System;
using System.Linq;

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

            //Assert
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
    }
}
