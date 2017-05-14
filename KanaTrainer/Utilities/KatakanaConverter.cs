using System.Collections.Generic;

namespace MaximStartsev.KanaTrainer.Utilities
{
    public sealed class KatakanaConverter: AlphabetConverter
    {
        protected override Dictionary<string, string> Alphabet { get; set; } = new Dictionary<string, string>
        {
            { "ka", "カ" },
            { "sa", "サ" },
            { "ta", "タ" },
            { "na", "ナ" },
            { "ha", "ハ" },
            { "ma", "マ" },
            { "ya", "ヤ" },
            { "ra", "ラ" },
            { "wa", "ワ" },
            { "ki", "キ" },
            { "si", "シ" },//shi
            { "ti", "チ" },//chi
            { "ni", "ニ" },
            { "hi", "ヒ" },
            { "mi", "ミ" },
            { "ri", "リ" },
            { "wi", "ヰ" },
            { "ku", "ク" },
            { "su", "ス" },
            { "tsu", "ツ" },
            { "nu", "ヌ" },
            { "fu", "フ" },
            { "mu", "ム" },
            { "yu", "ユ" },
            { "ru", "ル" },
            { "wu", "于" },
            { "ke", "ケ" },
            { "se", "セ" },
            { "te", "テ" },
            { "ne", "ネ" },
            { "he", "ヘ" },
            { "me", "メ" },
            { "re", "レ" },
            { "we", "ヱ" },
            { "ko", "コ" },
            { "so", "ソ" },
            { "to", "ト" },
            { "no", "ノ" },
            { "ho", "ホ" },
            { "mo", "モ" },
            { "yo", "ヨ" },
            { "ro", "ロ" },
            { "wo", "ヲ" },
            { "n", "ン" },
            { "a", "ア" },
            { "i", "イ" },
            { "u", "ウ" },
            { "e", "エ" },
            { "o", "オ" },
        };
        private KatakanaConverter() { }
        private static KatakanaConverter _instance;
        public static KatakanaConverter Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new KatakanaConverter();
                }
                return _instance;
            }
        }
    }
}
