using System.Collections.Generic;

namespace MaximStartsev.KanaTrainer.Utilities
{
    public sealed class HiraganaConverter:AlphabetConverter
    {
        public override Dictionary<string, string> Alphabet { get; protected set; } = new Dictionary<string, string>
        {
            { "ka", "か" },
            { "sa", "さ" },
            { "ta", "た" },
            { "na", "な" },
            { "ha", "は" },
            { "ma", "ま" },
            { "ya", "や" },
            { "ra", "ら" },
            { "wa", "わ" },
            { "ki", "き" },
            { "si", "し" },//shi
            { "ti", "ち" },//chi
            { "ni", "に" },
            { "hi", "ひ" },
            { "mi", "み" },
            { "ri", "み" },
            { "wi", "ゐ" },
            { "ku", "く" },
            { "su", "す" },
            { "tsu", "つ" },
            { "nu", "ぬ" },
            { "fu", "ふ" },
            { "mu", "む" },
            { "yu", "ゆ" },
            { "ru", "る" },
            { "ke", "け" },
            { "se", "せ" },
            { "te", "て" },
            { "ne", "ね" },
            { "he", "へ" },
            { "me", "め" },
            { "re", "れ" },
            { "we", "ゑ" },
            { "ko", "こ" },
            { "so", "そ" },
            { "to", "と" },
            { "no", "の" },
            { "ho", "ほ" },
            { "mo", "も" },
            { "yo", "よ" },
            { "ro", "ろ" },
            { "wo", "を" },
            { "n", "ん" },
            { "a", "あ" },
            { "i", "い" },
            { "u", "う" },
            { "e", "え" },
            { "o", "お" },
        };
        private HiraganaConverter() {}
        private static HiraganaConverter _instance;
        public static HiraganaConverter Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new HiraganaConverter();
                }
                return _instance;
            }
        }
    }
}
