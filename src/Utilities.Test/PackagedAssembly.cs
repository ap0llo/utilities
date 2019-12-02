using System;
using System.IO;
using Mono.Cecil;
using NuGet.Packaging;

namespace Grynwald.Utilities.Test
{
    /// <summary>
    /// Represents an assembly inside a NuGet package
    /// </summary>
    internal class PackagedAssembly : IDisposable
    {
        private readonly Lazy<Stream> m_FileStream;
        private readonly Lazy<PackageArchiveReader> m_PackageReader;
        private readonly Lazy<Stream> m_AssemblyStream;
        private readonly Lazy<AssemblyDefinition> m_AssemblyDefinition;


        public AssemblyDefinition AssemblyDefinition => m_AssemblyDefinition.Value;


        public PackagedAssembly(string packageFilePath, string assemblyRelativePath)
        {
            m_FileStream = new Lazy<Stream>(() => File.Open(packageFilePath, FileMode.Open, FileAccess.Read, FileShare.Read));
            m_PackageReader = new Lazy<PackageArchiveReader>(() => new PackageArchiveReader(m_FileStream.Value));
            m_AssemblyStream = new Lazy<Stream>(() =>
            {
                var memoryStream = new MemoryStream();
                using (var sourceStream = m_PackageReader.Value.GetStream(assemblyRelativePath))
                {
                    sourceStream.CopyTo(memoryStream);
                }

                memoryStream.Seek(0, SeekOrigin.Begin);
                return memoryStream;
            });
            m_AssemblyDefinition = new Lazy<AssemblyDefinition>(() => AssemblyDefinition.ReadAssembly(m_AssemblyStream.Value));
        }


        public void Dispose()
        {
            m_AssemblyDefinition.DisposeIfCreated();
            m_AssemblyStream.DisposeIfCreated();
            m_PackageReader.DisposeIfCreated();
            m_FileStream.DisposeIfCreated();
        }
    }
}
