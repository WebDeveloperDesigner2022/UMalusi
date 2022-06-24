using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UMelusiTrack
{
    public class Lazys<T>
    {
        readonly System.Lazy<Task<T>> instance;

        public Lazys(Func<T> factory)
        {
            instance = new System.Lazy<Task<T>>(() => Task.Run(factory));
        }

        public Lazys(Func<Task<T>> factory)
        {
            instance = new System.Lazy<Task<T>>(() => Task.Run(factory));
        }

        public TaskAwaiter<T> GetAwaiter()
        {
            return instance.Value.GetAwaiter();
        }

        public void Start()
        {
            var unused = instance.Value;
        }

    }
}
