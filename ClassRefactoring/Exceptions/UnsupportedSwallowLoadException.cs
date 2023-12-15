using System;

namespace DeveloperSample.ClassRefactoring
{
    public class UnsupportedSwallowLoadException : Exception
    {
        public UnsupportedSwallowLoadException(SwallowLoad load) : base($"Unsupported swallow load: {load}.") { }
    }
}