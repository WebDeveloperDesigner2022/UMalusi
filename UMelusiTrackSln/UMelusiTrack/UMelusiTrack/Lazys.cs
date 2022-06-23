using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UMelusiTrack
{
    public class Lazy<T>
    {
        readonly System.Lazy<Task<T>> instance;

        public Lazy(Func<T> factory)
        {
            instance = new System.Lazy<Task<T>>(() => Task.Run(factory));
        }

        public Lazy(Func<Task<T>> factory)
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
