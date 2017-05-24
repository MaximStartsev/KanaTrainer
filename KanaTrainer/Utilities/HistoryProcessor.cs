using System.Collections.Generic;

namespace MaximStartsev.KanaTrainer.Utilities
{
    internal sealed class HistoryProcessor
    {
        private const int Limit = 50;
        private readonly List<object> _items = new List<object>();
        private int _position = -1;
        public void Add(object state)
        {
            _items.Add(state);
            _position++;
        }

        public object Next()
        {
            if(_position < _items.Count - 1)
            {
                _position++;
                return _items[_position];
            }
            return null;
        }
        public object Prev()
        {
            if(_position > 0)
            {
                _position--;
                return _items[_position];
            }
            return null;
        }
    }
}
