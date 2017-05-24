using System;

namespace MaximStartsev.KanaTrainer.Utilities
{
    internal static class Randomize
    {
        private static Random _random = new Random();
        public static int GetNext()
        {
            return _random.Next();
        }
        public static int GetNext(int max)
        {
            return _random.Next(max);
        }
        public static int GetNext(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
