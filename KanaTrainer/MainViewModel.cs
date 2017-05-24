using MaximStartsev.KanaTrainer.MVVM;
using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.ComponentModel;
using System.Windows.Input;

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
        public event PropertyChangedEventHandler PropertyChanged;
        private string _textConvert;
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
                    _textConvert = value;
                    InvokePropertyChanged(nameof(TextConvert));
                }
            }
        }
        public ICommand TranslateCommand { get; private set; }
        public MainViewModel()
        {
            TranslateCommand = new ActionCommand(o => InvokeTranslate(), o => true);
        }
        private void InvokeTranslate()
        {
            TextConvert = ConvertText(TextConvert, KanaType);
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
