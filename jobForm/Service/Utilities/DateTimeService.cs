using jobForm.Common.Interfaces;

namespace jobForm.Service.Utilities
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
