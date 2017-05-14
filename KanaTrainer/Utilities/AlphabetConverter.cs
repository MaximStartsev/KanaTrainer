using System.Collections.Generic;

namespace MaximStartsev.KanaTrainer.Utilities
{
    public abstract class AlphabetConverter
    {
        protected abstract Dictionary<string, string> Alphabet { get; set; }

        public string Convert(string text)
        {
            text = text.ToLower();
            foreach (var pair in Alphabet)
            {
                text = text.Replace(pair.Key, pair.Value);
            }
            return text;
        }
        public string ConvertBack(string text)
        {
            foreach (var pair in Alphabet)
            {
                text = text.Replace(pair.Value, pair.Key);
            }
            return text;
        }
    }
}
