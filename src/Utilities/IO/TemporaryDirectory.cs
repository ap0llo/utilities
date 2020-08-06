using System;
using System.IO;

namespace Grynwald.Utilities.IO
{
    /// <summary>
    /// Represents a temporary directory. The directory is deleted when the <see cref="TemporaryDirectory"/> object is disposed.
    /// </summary>
    public sealed class TemporaryDirectory : IDisposable
    {
        /// <summary>
        /// The temporary directory's full path.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Creates a new temporary directory in the current user's temp directory (as returned by <see cref="Path.GetTempPath"/>.
        /// </summary>
        public TemporaryDirectory() : this(Path.GetTempPath())
        { }

        /// <summary>
        /// Creates a new temporary directory in the specified directory.
        /// </summary>
        /// <param name="basePath">The path of the directory to create the temporary directory in.</param>
        public TemporaryDirectory(string basePath)
        {
            if (String.IsNullOrWhiteSpace(basePath))
                throw new ArgumentException("Value must not be null or whitespace", nameof(basePath));

            FullName = Path.Combine(basePath, Path.GetRandomFileName());
            Directory.CreateDirectory(FullName);
        }

        /// <summary>
        /// Deletes the temporary directory.
        /// </summary>
        public void Dispose()
        {
            if (!Directory.Exists(FullName))
                return;

            try
            {
                // remove read-only flag from all files
                var files = new DirectoryInfo(FullName).GetFiles("*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    file.IsReadOnly = false;
                }

                // recursively delete the directory
                Directory.Delete(FullName, recursive: true);
            }
            catch (UnauthorizedAccessException)
            {
                // ignore
            }
            catch (IOException)
            {
                // ignore
            }
        }

        /// <summary>
        /// Converts the temporary directory to a string (using the <see cref="FullName"/> property as value).
        /// </summary>        
        public static implicit operator string(TemporaryDirectory instance) => instance?.FullName;

        /// <inheritdoc />
        public override string ToString() => FullName;
    }
}
