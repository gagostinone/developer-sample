using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        /* 
        The original method used Parallel.ForEach, which is not suitable for async tasks as it doesn't properly await them.
        These revisions handles async code in parallel by converting each item into a Task using LINQ's Select and Task.Run,
        then awaits all these tasks using Task.WhenAll. This ensures all async operations are completed before proceeding.
        */
        public async Task<List<string>> InitializeListAsync(IEnumerable<string> items)
        {
            //Instead of using Parallel.ForEach, I use LINQ's Select to project each item into an asynchronous task that gets started immediately. 
            var tasks = items.Select(i =>
            {
                return Task.Run(() => i);
            });

            //I then use Task.WhenAll to asynchronously wait until all the tasks in the collection have completed.
            var results = await Task.WhenAll(tasks);

            //The results of these tasks are converted into a list and returned. This list contains the outcomes of all the asynchronous operations.
            return results.ToList();
        }

        /*
        The original method had problems each thread processes the entire range of items. 
        The proper way to utlizing multiple threads is to divide the work.
        This can be done by having each thread start on a unique index and increment each index by the number of threads.
        With this logic, there will be no overlap.
        */
        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var numberOfThreads = 3;
            var threads = Enumerable.Range(0, numberOfThreads)
                .Select(i => new Thread(() => {
                    for (int j = i; j < itemsToInitialize.Count; j+=numberOfThreads){
                        concurrentDictionary.AddOrUpdate(itemsToInitialize[j], getItem, (_, s) => s);
                    }

                }))
                .ToList();

            foreach (var thread in threads)
            {
                thread.Start();
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}