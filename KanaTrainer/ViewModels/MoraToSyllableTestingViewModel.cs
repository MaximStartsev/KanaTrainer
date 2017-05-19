using MaximStartsev.KanaTrainer.MVVM;
using MaximStartsev.KanaTrainer.Resources;
using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MaximStartsev.KanaTrainer.ViewModels
{
    internal sealed class MoraToSyllableTestingViewModel:BaseViewModel,INotifyPropertyChanged
    {
        private string _currentMora;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CurrentMora
        {
            get { return _currentMora; }
            set
            {
                if(value != _currentMora)
                {
                    _currentMora = value;
                    InvokePropertyChanged(nameof(CurrentMora));
                }
            }
        }
        private string _variantA;
        public string VariantA
        {
            get { return _variantA; }
            set
            {
                if(_variantA != value)
                {
                    _variantA = value;
                    InvokePropertyChanged(nameof(VariantA));
                }
            }
        }
        private string _variantB;
        public string VariantB
        {
            get { return _variantB; }
            set
            {
                if(_variantB != value)
                {
                    _variantB = value;
                    InvokePropertyChanged(nameof(VariantB));
                }
            }
        }
        private string _variantC;
        public string VariantC
        {
            get { return _variantC; }
            set
            {
                if(_variantC != value)
                {
                    _variantC = value;
                    InvokePropertyChanged(nameof(VariantC));
                }
            }
        }
        private string _variantD;
        public string VariantD
        {
            get { return _variantD; }
            set
            {
                if(_variantD != value)
                {
                    _variantD = value;
                    InvokePropertyChanged(nameof(VariantD));
                }
            }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                if(_message != value)
                {
                    _message = value;
                    InvokePropertyChanged(nameof(Message));
                }
            }
        }
        public KanaType Kana { get; set; }
        public ICommand ReplyCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand ForwardCommand { get; private set; }
        private KeyValuePair<string, string> _currentPair;
        private Random _random = new Random();
        public MoraToSyllableTestingViewModel()
        {
            ReplyCommand = new ActionCommand(InvokeReply, o => true);
            BackCommand = new ActionCommand(o => InvokePrev(), o => true);
            ForwardCommand = new ActionCommand(o => InvokeNext(), o => true);
            InvokeNext();
        }
        private void InvokePrev()
        {

        }
        private void InvokeNext()
        {
            _currentPair = GetRandomPair();
            CurrentMora = _currentPair.Value;
            var arr = new string[4];
            arr[_random.Next(4)] = _currentPair.Key;
            for (int i = 0; i < 4; i++)
            {
                if (String.IsNullOrEmpty(arr[i]))
                {
                    var s = GetRandomPair().Key;
                    while (arr.Contains(s))
                    {
                        s = GetRandomPair().Key;
                    }
                    arr[i] = s;
                }
            }
            VariantA = arr[0];
            VariantB = arr[1];
            VariantC = arr[2];
            VariantD = arr[3];
            Message = CommonResources.SelectValueMessage;
        }
        private KeyValuePair<string,string> GetRandomPair()
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

        private void InvokeReply(object parameter)
        {
            Message = _currentPair.Key == (string)parameter ? CommonResources.CorrectAnswerMessage : CommonResources.IncorrectAnswerMessage;
        }

        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
