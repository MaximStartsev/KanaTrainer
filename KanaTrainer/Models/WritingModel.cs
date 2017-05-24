using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximStartsev.KanaTrainer.Models
{
    internal abstract class WritingModel
    {
        protected HistoryProcessor HistoryProcessor = new HistoryProcessor();
        public KanaType Kana { get; set; } = KanaType.Hiragana;
        public abstract string GetNext();
        public abstract string GetPrev();
        public abstract bool CheckVariant(string variant);
        protected KeyValuePair<string, string> GetRandomPair()
        {
            switch (Kana)
            {
                case KanaType.Hiragana:
                    {
                        var index = Randomize.GetNext(HiraganaConverter.Instance.Alphabet.Count - 1);
                        return HiraganaConverter.Instance.Alphabet.ElementAt(index);
                    }
                case KanaType.Katakana:
                    {
                        var index = Randomize.GetNext(KatakanaConverter.Instance.Alphabet.Count - 1);
                        return KatakanaConverter.Instance.Alphabet.ElementAt(index);
                    }
                default: throw new NotImplementedException();
            }
        }
    }
}
