﻿using Model.Base.Async;
using Model.Base.Component;
using Model.Base.Helper;
using Model.Base.Time;
using Model.Base.Util;
using System.Collections.Generic;
using System.Threading;

namespace Model.Component
{
    public class TimerComponent : AComponent
    {
        private readonly Dictionary<long, RDTimer> timers = new Dictionary<long, RDTimer>();

        /// <summary>
        /// key: time, value: timer id
        /// </summary>
        private readonly MultiMap<long, long> timeId = new MultiMap<long, long>();

        private readonly Queue<long> timeOutTime = new Queue<long>();

        private readonly Queue<long> timeOutTimerIds = new Queue<long>();

        // 记录最小时间，不用每次都去MultiMap取第一个值
        private long minTime;

        public void Update()
        {
            if (this.timeId.Count == 0)
            {
                return;
            }

            long timeNow = TimeHelper.Now();

            if (timeNow < this.minTime)
            {
                return;
            }

            foreach (KeyValuePair<long, List<long>> kv in this.timeId.GetDictionary())
            {
                long k = kv.Key;
                if (k > timeNow)
                {
                    minTime = k;
                    break;
                }
                this.timeOutTime.Enqueue(k);
            }

            while (this.timeOutTime.Count > 0)
            {
                long time = this.timeOutTime.Dequeue();
                foreach (long timerId in this.timeId[time])
                {
                    this.timeOutTimerIds.Enqueue(timerId);
                }
                this.timeId.Remove(time);
            }

            while (this.timeOutTimerIds.Count > 0)
            {
                long timerId = this.timeOutTimerIds.Dequeue();
                RDTimer timer;
                if (!this.timers.TryGetValue(timerId, out timer))
                {
                    continue;
                }
                this.timers.Remove(timerId);
                timer.tcs.SetResult();
            }
        }

        private void Remove(long id)
        {
            this.timers.Remove(id);
        }

        public RDTask WaitTillAsync(long tillTime, CancellationToken cancellationToken)
        {
            RDTaskCompletionSource tcs = new RDTaskCompletionSource();
            RDTimer timer = new RDTimer { Id = IdGeneraterHelper.GenerateId(), Time = tillTime, tcs = tcs };
            this.timers[timer.Id] = timer;
            this.timeId.Add(timer.Time, timer.Id);
            if (timer.Time < this.minTime)
            {
                this.minTime = timer.Time;
            }
            cancellationToken.Register(() => { this.Remove(timer.Id); });
            return tcs.Task;
        }

        public RDTask WaitTillAsync(long tillTime)
        {
            RDTaskCompletionSource tcs = new RDTaskCompletionSource();
            RDTimer timer = new RDTimer { Id = IdGeneraterHelper.GenerateId(), Time = tillTime, tcs = tcs };
            this.timers[timer.Id] = timer;
            this.timeId.Add(timer.Time, timer.Id);
            if (timer.Time < this.minTime)
            {
                this.minTime = timer.Time;
            }
            return tcs.Task;
        }

        public RDTask WaitAsync(long time, CancellationToken cancellationToken)
        {
            RDTaskCompletionSource tcs = new RDTaskCompletionSource();
            RDTimer timer = new RDTimer { Id = IdGeneraterHelper.GenerateId(), Time = TimeHelper.Now() + time, tcs = tcs };
            this.timers[timer.Id] = timer;
            this.timeId.Add(timer.Time, timer.Id);
            if (timer.Time < this.minTime)
            {
                this.minTime = timer.Time;
            }
            cancellationToken.Register(() => { this.Remove(timer.Id); });
            return tcs.Task;
        }

        public RDTask WaitAsync(long time)
        {
            RDTaskCompletionSource tcs = new RDTaskCompletionSource();
            RDTimer timer = new RDTimer { Id = IdGeneraterHelper.GenerateId(), Time = TimeHelper.Now() + time, tcs = tcs };
            this.timers[timer.Id] = timer;
            this.timeId.Add(timer.Time, timer.Id);
            if (timer.Time < this.minTime)
            {
                this.minTime = timer.Time;
            }
            return tcs.Task;
        }
    }

}
