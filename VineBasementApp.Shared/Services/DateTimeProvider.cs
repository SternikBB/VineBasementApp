using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VineBasementApp.Shared.Services
{
    public class DateTimeProvider
    {
        public static DateTime Now
            => DateTimeProviderContext.Current == null
                    ? DateTime.Now
                    : DateTimeProviderContext.Current.ContextDateTimeNow;

        public static DateTime UtcNow => Now.ToUniversalTime();

        public static DateTime Today => Now.Date;
    }
}
