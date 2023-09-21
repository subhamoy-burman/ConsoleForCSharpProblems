using System;
using NUnit.Framework;

namespace ConsoleNeetCode.RevisionOne.Test;

public class CustomTests
{
    
    [Test]
    public void TestVersion()
    {
        var version = ParseVersion("16.5.2(C)");
    }
    
    internal static Version ParseVersion(string version)
    {
        if (Version.TryParse(version, out var number))
            return number;

        if (int.TryParse(version, out var major))
            return new Version(major, 0);

        return new Version(0, 0);
    }


}