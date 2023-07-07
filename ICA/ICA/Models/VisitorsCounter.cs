namespace ICA.Models
{
    public static class VisitorsCounter
    {
        private static readonly object _lockObject = new object();
        private static int _counter = 0;

        public static int Counter
        {
            get
            {
                lock (_lockObject)
                {
                    return _counter;
                }
            }
        }

        public static void Increment()
        {
            lock (_lockObject)
            {
                _counter++;
            }
        }
    }
}
