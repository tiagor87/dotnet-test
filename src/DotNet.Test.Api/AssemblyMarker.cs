using System.Reflection;

namespace DotNet.Test.Api;

public static class AssemblyMarker
{
    public static readonly Assembly Self = typeof(AssemblyMarker).Assembly;
}