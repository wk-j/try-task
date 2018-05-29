// Add the System.Threading.Tasks.Extensions NuGet to get AsyncMethodBuilderAttribute
using System;
using System.Runtime.CompilerServices;

namespace TryTask.Maybe {
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
}