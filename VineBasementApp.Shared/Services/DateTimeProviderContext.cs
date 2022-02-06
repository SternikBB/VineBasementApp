using System;
using System.Collections;
using System.Threading;

namespace VineBasementApp.Shared.Services
{
    public class DateTimeProviderContext:IDisposable
    {
        internal readonly DateTime ContextDateTimeNow;
        private readonly static ThreadLocal<Stack> ThreadScopeStack = new(() => new Stack());

        public DateTimeProviderContext(DateTime contextDateTimeNow)
        {
            ContextDateTimeNow = contextDateTimeNow;
            ThreadScopeStack.Value.Push(this);
        }

        public static DateTimeProviderContext Current
        {
            get
            {
                if (ThreadScopeStack.Value.Count == 0)
                    return null;
                else
                    return ThreadScopeStack.Value.Peek() as DateTimeProviderContext;
            }
        }

        public void Dispose()
        {
            ThreadScopeStack.Value.Pop();
        }
    }
}
