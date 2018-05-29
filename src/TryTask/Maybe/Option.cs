// Add the System.Threading.Tasks.Extensions NuGet to get AsyncMethodBuilderAttribute
using System.Runtime.CompilerServices;

namespace TryTask.Maybe {

    [AsyncMethodBuilder(typeof(MaybeAsyncMethodBuilder<>))]
    public interface Option<T> { }

    // Could use the closed type hierarchy Roslyn feature
    // to be an approximation of a discriminated union
    // https://github.com/dotnet/csharplang/issues/485
    public sealed class None<T> : Option<T> { public static readonly None<T> Value = new None<T>(); }
    public sealed class Some<T> : Option<T> {
        public readonly T Item;
        public Some(T item) => Item = item;
        public static explicit operator T(Some<T> maybe) => maybe.Item;
    }

    public static class Some {
        public static Some<T> Of<T>(T value) => new Some<T>(value);
    }
}