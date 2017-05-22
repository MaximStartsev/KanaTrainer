using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.ComponentModel;

namespace MaximStartsev.KanaTrainer
{
    class MainViewModel:INotifyPropertyChanged
    {
        private KanaType _kanaType = KanaType.Hiragana;
        public KanaType KanaType
        {
            get { return _kanaType; }
            set
            {
                if(_kanaType != value)
                {
                    var unconvertedText = ConvertTextBack(TextConvert, _kanaType);
                    _kanaType = value;
                    TextConvert = unconvertedText;
                }
            }
        }
        private string _textConvert;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public string TextConvert
        {
            get
            {
                return _textConvert;
            }
            set
            {
                if(_textConvert != value)
                {
                    _textConvert = ConvertText(value, KanaType);
                    InvokePropertyChanged(nameof(TextConvert));
                }
            }
        }

        public MainViewModel()
        {
        }

        private static string ConvertText(string text, KanaType type)
        {
            switch (type)
            {
                case KanaType.Hiragana: return HiraganaConverter.Instance.Convert(text);
                case KanaType.Katakana: return KatakanaConverter.Instance.Convert(text);
                default: throw new NotImplementedException();
            }
        }
        private static string ConvertTextBack(string text, KanaType type)
        {
            switch (type)
            {
                case KanaType.Hiragana: return HiraganaConverter.Instance.ConvertBack(text);
                case KanaType.Katakana: return KatakanaConverter.Instance.ConvertBack(text);
                default:throw new NotImplementedException();
            }
        }
        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
