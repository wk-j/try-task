// Add the System.Threading.Tasks.Extensions NuGet to get AsyncMethodBuilderAttribute

namespace TryTask.Maybe {
    public static class OptionExtensions {
        public static MaybeAwaiter<T> GetAwaiter<T>(this Option<T> maybe) => new MaybeAwaiter<T>(maybe);
    }
}