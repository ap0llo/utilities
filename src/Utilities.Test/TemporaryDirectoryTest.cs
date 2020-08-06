using System.IO;
using Grynwald.Utilities.IO;
using Xunit;

namespace Grynwald.Utilities.Test
{
    /// <summary>
    /// Tests for <see cref="TemporaryDirectory"/>
    /// </summary>
    public class TemporaryDirectoryTest
    {
        [Fact]
        public void Creating_the_TemporaryDirectory_creates_the_directory_on_disk()
        {
            using var sut = new TemporaryDirectory();
            Assert.True(Directory.Exists(sut.FullName));
        }

        [Fact]
        public void Disposing_the_temporary_directory_deletes_the_directory()
        {
            var sut = new TemporaryDirectory();
            File.WriteAllText(Path.Combine(sut, "file1.txt"), "Test");

            sut.Dispose();

            Assert.False(Directory.Exists(sut.FullName));
        }

        [Fact]
        public void Disposing_the_temporary_directory_deletes_read_only_files()
        {
            var sut = new TemporaryDirectory();

            var fileInfo = new FileInfo(Path.Combine(sut, "file1.txt"));
            File.WriteAllText(fileInfo.FullName, "Test");
            fileInfo.Refresh();

            fileInfo.IsReadOnly = true;

            sut.Dispose();

            Assert.False(Directory.Exists(sut.FullName));
        }

        [Fact]
        public void Directory_can_be_disposed_multiple_times()
        {
            var sut = new TemporaryDirectory();

            sut.Dispose();
            sut.Dispose();
        }
    }
}
