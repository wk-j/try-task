using System.Runtime.CompilerServices;
using System;

namespace TryTask.Empty {
    [AsyncMethodBuilder(typeof(MyTaskMethodBuilder<>))]
    public class MyTask<T> {

    }
    public class MyTaskMethodBuilder<T> {
        public static MyTaskMethodBuilder<T> Create() {
            return null;
        }

        public MyTask<T> Task {
            get {
                return null;
            }
        }

        public void SetException(Exception exception) {

        }

        public void SetResult(T result) {

        }

        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine {

        }

        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine {

        }

        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine {

        }

        public void SetStateMachine(IAsyncStateMachine stateMachine) {

        }
    }
}