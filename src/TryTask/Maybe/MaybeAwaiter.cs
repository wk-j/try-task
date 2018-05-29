// Add the System.Threading.Tasks.Extensions NuGet to get AsyncMethodBuilderAttribute
using System;
using System.Runtime.CompilerServices;

namespace TryTask.Maybe {
    public class MaybeAwaiter<T> : INotifyCompletion {
        Option<T> maybe;

        public MaybeAwaiter(Option<T> maybe) => this.maybe = maybe;

        public bool IsCompleted => maybe is Some<T>;

        public void OnCompleted(Action continuation) {
            /* We never need to execute the continuation cause
             * we only reach here when the result is None which
             * means we are trying to short-circuit everything
             * else
             */
        }

        public T GetResult() => ((Some<T>)maybe).Item;
    }
}