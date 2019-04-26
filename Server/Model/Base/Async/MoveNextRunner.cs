using System.Runtime.CompilerServices;

namespace Model.Async
{
    internal class MoveNextRunner<TStateMachine> where TStateMachine : IAsyncStateMachine
    {
        public TStateMachine StateMachine;

        //[DebuggerHidden]
        public void Run()
        {
            StateMachine.MoveNext();
        }
    }
}
