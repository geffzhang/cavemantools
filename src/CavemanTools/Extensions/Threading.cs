﻿using CavemanTools.Logging;

namespace System.Threading.Tasks
{
    public static class TasksUtils
    {
        public static void FireAndForget(this Task task,string taskName,Action<Task> errorHandler=null)
        {
            if (errorHandler == null)
            {
                errorHandler = t => taskName.LogError(t.Exception);
            }
            task.ContinueWith(errorHandler, TaskContinuationOptions.OnlyOnFaulted);
        }

        /// <summary>
        /// Thread.Sleep alternative, using Task.Delay
        /// </summary>
        /// <param name="item"></param>
        /// <param name="duration"></param>
        public static void Sleep(this object item, TimeSpan duration)
        {
            Task.Delay(duration).Wait();
        }

        public static Task EmptyTask()
        {
            return Task.WhenAll();
        }
    }
}