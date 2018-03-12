using System;
using System.Linq;
using System.Collections.Generic;

public static class SecretHandshake
{
    private static IDictionary<int, string> decodeMapping = new Dictionary<int, string>()
    {
        [0b01] = "wink",
        [0b10] = "double blink",
        [0b100] = "close your eyes",
        [0b1000] = "jump",
    };
    public static string[] Commands(int commandValue)
    {
        var decodes = new List<string>();

        foreach (var item in decodeMapping)
        {
            if ((commandValue | item.Key) == commandValue)
                decodes.Add(item.Value);
        }

        if ((commandValue | 0b10000) == commandValue)
            decodes.Reverse();

        return decodes.ToArray();
    }
}
