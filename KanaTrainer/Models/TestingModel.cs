using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximStartsev.KanaTrainer.Models
{
    internal abstract class TestingModel
    {
        public KanaType Kana { get; set; } = KanaType.Hiragana;
        protected readonly Random _random = new Random();
        public abstract TestIteration GetNext();
        public abstract bool CheckVariant(string variant);

        protected KeyValuePair<string, string> GetRandomPair()
        {
            switch (Kana)
            {
                case KanaType.Hiragana:
                    {
                        var index = _random.Next(HiraganaConverter.Instance.Alphabet.Count - 1);
                        return HiraganaConverter.Instance.Alphabet.ElementAt(index);
                    }
                case KanaType.Katakana:
                    {
                        var index = _random.Next(KatakanaConverter.Instance.Alphabet.Count - 1);
                        return KatakanaConverter.Instance.Alphabet.ElementAt(index);
                    }
                default: throw new NotImplementedException();
            }
        }
    }
}
