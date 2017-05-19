using System;
using System.Collections.Generic;

namespace MaximStartsev.KanaTrainer.Utilities
{
    public abstract class AlphabetConverter
    {
        public abstract Dictionary<string, string> Alphabet { get; protected set; }

        public string Convert(string text)
        {
            if (String.IsNullOrEmpty(text)) return String.Empty;
            text = text.ToLower();
            foreach (var pair in Alphabet)
            {
                text = text.Replace(pair.Key, pair.Value);
            }
            return text;
        }
        public string ConvertBack(string text)
        {
            if (String.IsNullOrEmpty(text)) return String.Empty;
            foreach (var pair in Alphabet)
            {
                text = text.Replace(pair.Value, pair.Key);
            }
            return text;
        }
    }
}
