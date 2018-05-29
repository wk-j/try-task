using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace TryTask.Empty {

    [AsyncMethodBuilder(typeof(MyTaskMethodBuilder))]
    public class MyTask {

    }

    public class MyTaskMethodBuilder {
        public static MyTaskMethodBuilder Create() {
            return null;
        }

        public MyTask Task {
            get {
                return null;
            }
        }

        public void SetException(Exception exception) {

        }

        public void SetResult() {

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