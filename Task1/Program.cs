using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        private const int TASK_COUNT = 100;
        private const int ITERATION_COUNT = 100;

        static void Main(string[] args)
        {
            var taskCount = TASK_COUNT;
            if (args.Length > 0) int.TryParse(args[0], out taskCount);

            var taskList = new List<Task>(taskCount);

            for (int taskNum = 1; taskNum <= taskCount; taskNum++)
            {
                taskList.Add(Task.Factory.StartNew(() => Iteration(taskNum)));
            }

            Task.WaitAll(taskList.ToArray());
            Console.ReadLine();
        }

        private delegate void Iterate(int j);

        private static void Iteration(int taskNum)
        {
            for (int iterationNum = 1; iterationNum <= ITERATION_COUNT; iterationNum++)
            {
                Console.WriteLine(String.Format("Task #{0} - {1}", taskNum, iterationNum));
            }
        }
    }
}
