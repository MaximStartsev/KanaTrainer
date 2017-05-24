
using System;

namespace MaximStartsev.KanaTrainer.Models
{
    internal sealed class MoraToSyllableWritingModel : WritingModel
    {
        private string _currentAnswer = null;
        public override bool CheckVariant(string variant)
        {
            if (variant == null) return false;
            return variant.ToLower() == _currentAnswer;
        }

        public override string GetNext()
        {
            var tuple = (Tuple<string, string>)HistoryProcessor.Next();
            if (tuple != null)
            {
                _currentAnswer = tuple.Item2;
                return tuple.Item1;
            }
            var pair = GetRandomPair();
            _currentAnswer = pair.Key;
            HistoryProcessor.Add(Tuple.Create(pair.Value, pair.Key));
            return pair.Value;
        }

        public override string GetPrev()
        {
            var tuple = (Tuple<string, string>)HistoryProcessor.Prev();
            if (tuple != null)
            {
                _currentAnswer = tuple.Item2;
                return tuple.Item1;
            }
            return null;
        }
    }
}
