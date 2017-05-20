using MaximStartsev.KanaTrainer.Models;
using MaximStartsev.KanaTrainer.MVVM;
using MaximStartsev.KanaTrainer.Utilities;
using MaximStartsev.KanaTrainer.ViewModels;
using Microsoft.Practices.Unity;
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

        public ICommand StartTrainingCommand { get; private set; }
        private TestingViewModel _moraToSyllableTesting;
        public TestingViewModel MoraToSyllableTesting
        {
            get
            {
                if(_moraToSyllableTesting == null)
                {
                    _moraToSyllableTesting = new TestingViewModel(new MoraToSyllableTestingModel());
                }
                return _moraToSyllableTesting;
            }
        }
        private TestingViewModel  _syllableToMoraTesting;
        public TestingViewModel SyllableToMoraTesting
        {
            get
            {
                if (_syllableToMoraTesting == null)
                {
                    _syllableToMoraTesting = new TestingViewModel(new SyllableToMoraTestingModel());
                }
                return _syllableToMoraTesting;
            }
        }

        private readonly UnityContainer _container;
        public MainViewModel()
        {
            _container = new UnityContainer();
            _container.RegisterInstance(typeof(TestingViewModel));
            _container.RegisterInstance(typeof(MoraToSillableWritingViewModel));
            StartTrainingCommand = new ActionCommand(o => StartTraining(), o => true);
        }
        public void StartTraining()
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
