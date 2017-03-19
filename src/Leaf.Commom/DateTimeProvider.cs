using System;

namespace Leaf.Commom
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrenTime()
        {
            return DateTime.Now;
        }
    }
}
