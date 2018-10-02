using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionals
{
    public class Optional<T> //where T : new()
    {
        /// <summary>
        /// The encapsulated value.
        /// </summary>
        private T value;

        /// <summary>
        /// Constructs Empty Optional.
        /// </summary>
        internal Optional()
        {
            this.value = default(T);
        }

        /// <summary>
        /// Constructs an optional with a value.
        /// </summary>
        /// <param name="any">The value to encapsulated.</param>
        internal Optional(T any)
        {
            this.value = any;
        }

        /// <summary>
        /// Get what is encapsulated.
        /// </summary>
        /// <returns>The value if it exists, or default(T)</returns>
        public T Get() => value;

        /// <summary>
        /// Checks to see if the Optional contains anything. Use this method before getting.
        /// </summary>
        /// <returns>Whether a value is encapsulated.</returns>
        public virtual bool IsPresent() => !EqualityComparer<T>.Default.Equals(this.value, default(T)); //this.value = default(T) && this.value != default(T);

        /// <summary>
        /// Short for "GetOrElseThis(T value)
        /// </summary>
        /// <param name="orElse">An alternate value to return.</param>
        /// <returns>The encapsulated value, if one exists, or orElse.</returns>
        public T OrElse(T orElse) => IsPresent() ? value : orElse;

        /// <summary>
        /// Short for GetOrElseReturnDefault(T value)
        /// </summary>
        /// <returns>The encapsulated value, or the default of the datatype held within.</returns>
        public T orDefault() => IsPresent() ? value : default(T);

        /// <summary>
        /// If Present, perform this function. 
        /// </summary>
        /// <param name="function"></param>
        public void IfPresent (Action<T> function)
        {
            if (IsPresent())
                function.Invoke(this.value);
        }

        /// <summary>
        /// If present, do that function and return it.
        /// </summary>
        /// <param name="function">Function to be invoked.</param>
        /// <returns>The result fo the function, or default(T)</returns>
        public T IfPresent(Func<T, T> function) 
        {
            if (IsPresent())
                return function.Invoke(this.value);
            return this.value;
        }

        /// <summary>
        /// To make it more Java like. 
        /// </summary>
        /// <returns>Empty optional.</returns>
        internal static Optional<T> Empty() => new Optional<T>();

        /// <summary>
        /// To make it more Java like.
        /// </summary>
        /// <param name="value">Value to be encapsulated.</param>
        /// <returns>Optional containing the thing.</returns>
        internal static Optional<T> Of(T value) => new Optional<T>(value);

        public override string ToString()
        {
            return "Optional(" + value.ToString() + ")";
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    /// <summary>
    /// Accessors for Optionals
    /// </summary>
    public class Optionals
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The datatype of the argument</typeparam>
        /// <param name="value">The value to be encapsulated.</param>
        /// <returns>Optional containing the thing</returns>
        public static Optional<T> Of<T>(T value) => Optional<T>.Of(value);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The datatype of the variable in which you would pass in to make a full optional.</typeparam>
        /// <returns>Empty Optional</returns>
        public static Optional<T> Empty<T>() => Optional<T>.Empty();
    }

    /*
    public class Nothing : Optional<object>
    {
        public override bool IsPresent() => false;
    }

    public class Some<T> : Optional<T> where T: new()
    {

    }
    */
}
