// Guids.cs
// MUST match guids.h
using System;

namespace OlympicSoftware.RazorConverterExtension
{
    static class GuidList
    {
        public const string guidRazorConverterExtensionPkgString = "34d9236e-e421-4ebe-8bf6-bd21abca1da7";
        public const string guidRazorConverterExtensionCmdSetString = "bd1946b0-1e9e-458b-bc63-6ecb1b66e08c";

        public static readonly Guid guidRazorConverterExtensionCmdSet = new Guid(guidRazorConverterExtensionCmdSetString);
    };
}