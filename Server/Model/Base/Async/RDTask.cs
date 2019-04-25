using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Model.Async
{
    public struct RDTask<T> : IEquatable<RDTask<T>>
    {
        private readonly T result;
        private readonly IAwaiter<T> awaiter;

        [DebuggerHidden]
        public RDTask(T result)
        {
            this.result = result;
            this.awaiter = null;
        }

        [DebuggerHidden]
        public RDTask(IAwaiter<T> awaiter)
        {
            this.result = default;
            this.awaiter = awaiter;
        }

        [DebuggerHidden]
        public AwaiterStatus Status => awaiter?.Status ?? AwaiterStatus.Succeeded;

        [DebuggerHidden]
        public bool IsCompleted => awaiter?.IsCompleted ?? true;

        [DebuggerHidden]
        public T Result
        {
            get
            {
                if (awaiter == null)
                {
                    return result;
                }

                return this.awaiter.GetResult();
            }
        }

        public void Coroutine()
        {
        }

        [DebuggerHidden]
        public Awaiter GetAwaiter()
        {
            return new Awaiter(this);
        }

        public bool Equals(RDTask<T> other)
        {
            if (this.awaiter == null && other.awaiter == null)
            {
                return EqualityComparer<T>.Default.Equals(this.result, other.result);
            }

            if (this.awaiter != null && other.awaiter != null)
            {
                return this.awaiter == other.awaiter;
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (this.awaiter == null)
            {
                if (result == null)
                {
                    return 0;
                }

                return result.GetHashCode();
            }

            return this.awaiter.GetHashCode();
        }

        public override string ToString()
        {
            return this.awaiter == null ? result.ToString()
                    : this.awaiter.Status == AwaiterStatus.Succeeded ? this.awaiter.GetResult().ToString()
                    : "(" + this.awaiter.Status + ")";
        }

        public static implicit operator RDTask(RDTask<T> task)
        {
            if (task.awaiter != null)
            {
                return new RDTask(task.awaiter);
            }

            return new RDTask();
        }

        public struct Awaiter : IAwaiter<T>
        {
            private readonly RDTask<T> task;

            [DebuggerHidden]
            public Awaiter(RDTask<T> task)
            {
                this.task = task;
            }

            [DebuggerHidden]
            public bool IsCompleted => task.IsCompleted;

            [DebuggerHidden]
            public AwaiterStatus Status => task.Status;

            [DebuggerHidden]
            void IAwaiter.GetResult()
            {
                GetResult();
            }

            [DebuggerHidden]
            public T GetResult()
            {
                return task.Result;
            }

            [DebuggerHidden]
            public void OnCompleted(Action continuation)
            {
                if (task.awaiter != null)
                {
                    task.awaiter.OnCompleted(continuation);
                }
                else
                {
                    continuation();
                }
            }

            [DebuggerHidden]
            public void UnsafeOnCompleted(Action continuation)
            {
                if (task.awaiter != null)
                {
                    task.awaiter.UnsafeOnCompleted(continuation);
                }
                else
                {
                    continuation();
                }
            }
        }
    }

    public partial struct RDTask : IEquatable<RDTask>
    {
        private readonly IAwaiter awaiter;

        [DebuggerHidden]
        public RDTask(IAwaiter awaiter)
        {
            this.awaiter = awaiter;
        }

        [DebuggerHidden]
        public AwaiterStatus Status => awaiter?.Status ?? AwaiterStatus.Succeeded;

        [DebuggerHidden]
        public bool IsCompleted => awaiter?.IsCompleted ?? true;

        [DebuggerHidden]
        public void GetResult()
        {
            if (awaiter != null)
            {
                awaiter.GetResult();
            }
        }

        public void Coroutine()
        {
        }

        [DebuggerHidden]
        public Awaiter GetAwaiter()
        {
            return new Awaiter(this);
        }

        public bool Equals(RDTask other)
        {
            if (this.awaiter == null && other.awaiter == null)
            {
                return true;
            }

            if (this.awaiter != null && other.awaiter != null)
            {
                return this.awaiter == other.awaiter;
            }

            return false;
        }

        public override int GetHashCode()
        {
            if (this.awaiter == null)
            {
                return 0;
            }

            return this.awaiter.GetHashCode();
        }

        public override string ToString()
        {
            return this.awaiter == null ? "()"
                    : this.awaiter.Status == AwaiterStatus.Succeeded ? "()"
                    : "(" + this.awaiter.Status + ")";
        }

        public struct Awaiter : IAwaiter
        {
            private readonly RDTask task;

            [DebuggerHidden]
            public Awaiter(RDTask task)
            {
                this.task = task;
            }

            [DebuggerHidden]
            public bool IsCompleted => task.IsCompleted;

            [DebuggerHidden]
            public AwaiterStatus Status => task.Status;

            [DebuggerHidden]
            public void GetResult()
            {
                task.GetResult();
            }

            [DebuggerHidden]
            public void OnCompleted(Action continuation)
            {
                if (task.awaiter != null)
                {
                    task.awaiter.OnCompleted(continuation);
                }
                else
                {
                    continuation();
                }
            }

            [DebuggerHidden]
            public void UnsafeOnCompleted(Action continuation)
            {
                if (task.awaiter != null)
                {
                    task.awaiter.UnsafeOnCompleted(continuation);
                }
                else
                {
                    continuation();
                }
            }
        }
    }
}
