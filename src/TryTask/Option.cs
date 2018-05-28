// Add the System.Threading.Tasks.Extensions NuGet to get AsyncMethodBuilderAttribute
using System;
using System.Runtime.CompilerServices;

namespace XXX {

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

    public class MaybeAsyncMethodBuilder<T> {
        Option<T> result = None<T>.Value;

        public static MaybeAsyncMethodBuilder<T> Create() => new MaybeAsyncMethodBuilder<T>();

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine {
            // Simply start the state machine which will execute our code
            stateMachine.MoveNext();
        }

        public Option<T> Task => result;
        public void SetResult(T result) => this.result = Some.Of(result);
        public void SetException(Exception ex) { /* We leave the result to None */ }


        // Unused methods
        public void SetStateMachine(IAsyncStateMachine stateMachine) { }

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
           where TAwaiter : INotifyCompletion
           where TStateMachine : IAsyncStateMachine {
        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine)
           where TAwaiter : ICriticalNotifyCompletion
           where TStateMachine : IAsyncStateMachine {
        }
    }

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

    public static class OptionExtensions {
        public static MaybeAwaiter<T> GetAwaiter<T>(this Option<T> maybe) => new MaybeAwaiter<T>(maybe);
    }
}