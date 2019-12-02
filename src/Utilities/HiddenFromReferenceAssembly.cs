using System;

namespace Grynwald.Utilities
{
    /// <summary>
    /// Marks a type or method as being hidden from the reference assembly for the specified target framework.
    /// Marking a member as hidden for a TFM also implies it should be hidden from later versions of that framework,
    /// e.g. hidden from net461 also means hidden from net48.
    /// </summary>
    /// <remarks>
    /// Applying the attribute does not automatically exclude the attribute target from the reference
    /// assembly, but applying the attribute allows verification (see PackageVerificationTest)
    /// </remarks>
    [AttributeUsage(
        AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface,
        AllowMultiple = true,
        Inherited = false)]
    internal class HiddenFromReferenceAssembly : Attribute
    {
        public HiddenFromReferenceAssembly(string tfm)
        { }
    }
}
