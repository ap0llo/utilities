using System.Collections.Generic;
using System.IO;
using System.Linq;
using NuGet.Frameworks;
using NuGet.Packaging;
using Xunit;
using Xunit.Sdk;

namespace Grynwald.Utilities.Test
{
    public partial class PackageVerificationTest
    {
        public static IEnumerable<object[]> ReferenceAssemblyData()
        {
            var assemblyFileExtensions = new HashSet<string>() { ".dll", ".exe" };
            var dir = "packagesToVerify";

            foreach (var packageFilePath in Directory.GetFiles(dir, "*.nupkg"))
            {
                using (var stream = File.Open(packageFilePath, FileMode.Open, FileAccess.Read))
                using (var packageReader = new PackageArchiveReader(stream))
                {
                    var runtimeAssemblies = packageReader.GetLibItems()
                        .Single()
                        .Items
                        .Where(x => assemblyFileExtensions.Contains(Path.GetExtension(x)))
                        .ToDictionary(x => Path.GetFileNameWithoutExtension(x));

                    var identity = packageReader.NuspecReader.GetIdentity();
                    foreach (var referenceGroup in packageReader.GetItems("ref"))
                    {
                        var referenceAssemblies = referenceGroup.Items
                            .Where(x => assemblyFileExtensions.Contains(Path.GetExtension(x)))
                            .ToDictionary(x => Path.GetFileNameWithoutExtension(x));

                        foreach (var assemblyName in referenceAssemblies.Keys)
                        {
                            yield return new[]
                            {
                                packageFilePath,
                                referenceGroup.TargetFramework.GetShortFolderName(),
                                referenceAssemblies[assemblyName],
                                runtimeAssemblies[assemblyName],
                            };
                        }

                    }

                }
            }
        }


        [Theory]
        [MemberData(nameof(ReferenceAssemblyData))]
        public void Reference_assembly_contains_the_expected_API_surface(string packageFilePath, string tfm, string referenceAssemblyPath, string runtimeAssemblyPath)
        {
            var framework = NuGetFramework.ParseFolder(tfm);

            // Load both the runtime assembly and the reference assembly
            using (var referenceAssembly = new PackagedAssembly(packageFilePath, referenceAssemblyPath))
            using (var runtimeAssembly = new PackagedAssembly(packageFilePath, runtimeAssemblyPath))
            {
                // Get all members of both assembly
                var runtimeAssemblyMembers = AssemblyMember.GetMembers(runtimeAssembly.AssemblyDefinition).ToArray();
                var referenceAssemblySignatures = AssemblyMember.GetMembers(referenceAssembly.AssemblyDefinition).Select(x => x.Signature).ToArray();

                // For all members of the runtime assembly, check if the member exists in the reference assembly
                Assert.All(runtimeAssemblyMembers, runtimeAssemblyMember =>
                {
                    // if member is marked as hidden from the reference assembly, verify it does not exist
                    if (runtimeAssemblyMember.IsVisibleInFramework(framework))
                    {
                        if (!referenceAssemblySignatures.Contains(runtimeAssemblyMember.Signature))
                        {
                            throw new XunitException(
                                $"Member '{runtimeAssemblyMember.Signature}' missing from reference assembly for target framework '{framework.GetShortFolderName()}'"
                            );
                        }
                    }
                    // if member is not marked as hidden from the reference assembly, verify it does exist in the reference assembly
                    else
                    {
                        if (referenceAssemblySignatures.Contains(runtimeAssemblyMember.Signature))
                        {
                            throw new XunitException(
                                $"Member '{runtimeAssemblyMember.Signature}' exists in reference assembly for target framework '{framework.GetShortFolderName()}'"
                            );
                        }
                    }
                });
            }
        }
    }
}
