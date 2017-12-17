using System;
using System.IO;

namespace Grynwald.Utilities.IO
{
    public sealed class TemporaryDirectory : IDisposable
    {

        public string FullName { get; }


        public TemporaryDirectory() : this(Path.GetTempPath())
        {            
        }

        public TemporaryDirectory(string basePath)
        {
            FullName = Path.Combine(basePath, Path.GetRandomFileName());
            Directory.CreateDirectory(FullName);
        }


        public void Dispose()
        {
            try
            {
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

        public static implicit operator string(TemporaryDirectory instance) => instance?.FullName;
    }
}
