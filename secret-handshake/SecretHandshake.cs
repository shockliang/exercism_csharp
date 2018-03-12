using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        var funcs = new List<Func<IEnumerable<string>, IEnumerable<string>>>
        {
            l => l.Append("wink"),
            l => l.Append("double blink"),
            l => l.Append("close your eyes"),
            l => l.Append("jump"),
            l => l.Reverse()
        };

        return new BitArray(new[] { commandValue }).Cast<bool>()
                    .Zip(funcs, (b, f) => new { bit = b, func = f })
                    .Aggregate(Enumerable.Empty<string>(), (l, p) => p.bit ? p.func(l) : l)
                    .ToArray();
    }
}