using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using NuGet.Frameworks;

namespace Grynwald.Utilities.Test
{
    /// <summary>
    /// Represents a member of a assembly (a type, method, field ...)
    /// </summary>
    internal class AssemblyMember
    {
        private readonly ICustomAttributeProvider m_CustomAttributes;

        public string Signature { get; }


        public AssemblyMember(string signature, ICustomAttributeProvider customAttributes)
        {
            Signature = signature;
            m_CustomAttributes = customAttributes;
        }


        public bool IsVisibleInFramework(NuGetFramework framework)
        {
            var hiddenFromFrameworks = m_CustomAttributes.CustomAttributes
                .Where(a => a.AttributeType.FullName == typeof(HiddenFromReferenceAssembly).FullName)
                .Select(x => Convert.ToString(x.ConstructorArguments.Single().Value))
                .Select(NuGetFramework.ParseFolder)
                .ToArray();

            var hidden = hiddenFromFrameworks.Any(x => x.Framework == framework.Framework && x.Version <= framework.Version);
            return !hidden;
        }


        public static IEnumerable<AssemblyMember> GetMembers(AssemblyDefinition assembly)
        {
            foreach (var type in assembly.MainModule.Types.Where(x => x.IsPublic))
            {
                yield return new AssemblyMember(type.FullName, type);

                foreach (var property in type.Properties.Where(t => t.GetMethod?.IsPublic == true || t.SetMethod?.IsPublic == true))
                {
                    yield return new AssemblyMember(property.ToString(), property);
                }

                foreach (var method in type.Methods.Where(m => m.IsPublic))
                {
                    yield return new AssemblyMember(method.ToString(), method);
                }

                foreach (var field in type.Fields.Where(f => f.IsPublic))
                {
                    yield return new AssemblyMember(field.ToString(), field);
                }

                foreach (var ev in type.Events.Where(t => t.AddMethod?.IsPublic == true || t.RemoveMethod?.IsPublic == true))
                {
                    yield return new AssemblyMember(ev.ToString(), ev);
                }
            }
        }
    }
}
