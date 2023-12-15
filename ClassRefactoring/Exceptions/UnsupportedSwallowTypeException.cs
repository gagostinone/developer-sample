using System;

namespace DeveloperSample.ClassRefactoring
{
    public class UnsupportedSwallowTypeException : Exception
    {
        public UnsupportedSwallowTypeException(SwallowType type) : base($"Unsupported swallow type: {type}.") { }
    }
}