using System;
using Leaf.Commom.Contracts;

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
