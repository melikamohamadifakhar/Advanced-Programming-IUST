using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
//
namespace A4
{
    public static class ActionTools
    {
        public static long CallSequential(params Action[] actions)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var action in actions)
            {
                action();
            }
            return sw.ElapsedMilliseconds;
        }

        public static long CallParallel(params Action[] actions)
        {
            List<Task> tasks_list = new List<Task>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var action in actions)
            {
                Task t = Task.Run(action);
                tasks_list.Add(t);
            }
            Task.WaitAll(tasks_list.ToArray());
            return sw.ElapsedMilliseconds;
        }

        public static long CallParallelThreadSafe(int count, params Action[] actions)
        {
            object lock_obj = new object();
            List<Task> tasks_list = new List<Task>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var action in actions)
            {
                Task t = Task.Run(() =>
                {
                    for (int i=0; i < count; i++)
                    {
                        lock(lock_obj){
                            action();
                        }
                    }
                });
                tasks_list.Add(t);
            }
            Task.WaitAll(tasks_list.ToArray());
            return sw.ElapsedMilliseconds;
        }


        public static async Task<long> CallSequentialAsync(params Action[] actions)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var action in actions)
            {
                Task t = Task.Run(action);
                await t;
            }
            return sw.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelAsync(params Action[] actions)
        {
            List<Task> tasks_list = new List<Task>();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var action in actions)
            {
                // Task t = new Task(action);
                // t.Start();
                Task t = Task.Run(action);
                tasks_list.Add(t);
            }
            foreach (var item in tasks_list)
            {
                // item.Start(); chera inja kar nemikone?
                await item;
            }
            return sw.ElapsedMilliseconds;
        }

        public static async Task<long> CallParallelThreadSafeAsync(int count, params Action[] actions)
        {
            object lock_obj = new object();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            foreach (var action in actions)
            {
                Task t = Task.Run(() =>
                {
                    for (int i=0; i < count; i++)
                    {
                        lock(lock_obj){
                            action();
                        }
                    }
                });
                await t;
            }
            return sw.ElapsedMilliseconds;
        }
    }
}