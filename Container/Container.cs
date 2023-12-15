using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> bindings = new();

        /// <summary>
        /// Binds an interface or abstract class type to a concrete implementation type.
        /// </summary>
        /// <param name="interfaceType">The type of the interface or abstract class to bind.</param>
        /// <param name="implementationType">The concrete implementation type to bind to the interface or abstract class.</param>
        /// <exception cref="ArgumentException">Thrown when the interfaceType is not an interface or abstract class, or if the implementationType does not implement or extend the interfaceType.</exception>
        public void Bind(Type interfaceType, Type implementationType)
        {
            // Check if the interfaceType is actually an interface or abstract class.
            if (!interfaceType.IsInterface && !interfaceType.IsAbstract)
            {
                throw new ArgumentException("interfaceType must be an interface or abstract class.");
            }

            // Check if implementationType is a valid subclass of interfaceType.
            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException("implementationType must be a subclass of interfaceType.");
            }

            // Add the binding to the dictionary.
            bindings[interfaceType] = implementationType;
        }

        /// <summary>
        /// Retrieves an instance of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the instance to retrieve.</typeparam>
        /// <returns>An instance of the specified type.</returns>
        /// <exception cref="InvalidOperationException">Thrown when no binding is found for the specified type.</exception>
        public T Get<T>()
        {
            // Check if there's a binding for the requested type.
            if (!bindings.TryGetValue(typeof(T), out var implementationType))
            {
                throw new InvalidOperationException($"No binding found for {typeof(T)}");
            }

            // Create an instance of the implementationType and return it as T.
            return (T)Activator.CreateInstance(implementationType);
        }
    }
}