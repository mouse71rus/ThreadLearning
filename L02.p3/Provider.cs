using System;

namespace L02.p3
{
    internal class Provider
    {
        [ThreadStatic] // Using this attribute give you unique field for every Thread
        internal static int Data;
    }
}