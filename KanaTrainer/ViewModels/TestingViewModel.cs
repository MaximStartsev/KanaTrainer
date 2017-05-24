using MaximStartsev.KanaTrainer.Models;
using MaximStartsev.KanaTrainer.MVVM;
using MaximStartsev.KanaTrainer.Resources;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace MaximStartsev.KanaTrainer.ViewModels
{
    internal sealed class TestingViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _currentMora;
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
        private IEnumerable<string> _variantes;
        public IEnumerable<string> Variantes
        {
            get { return _variantes; }
            set
            {
                if(_variantes != value)
                {
                    _variantes = value;
                    InvokePropertyChanged(nameof(Variantes));
                }
            }
        }
        public KanaType Kana
        {
            get { return _model.Kana; }
            set { _model.Kana = value; }
        }
        public ICommand ReplyCommand { get; private set; }
        public ICommand BackCommand { get; private set; }
        public ICommand ForwardCommand { get; private set; }
        private TestingModel _model;
        
        public TestingViewModel(TestingModel model)
        {
            ReplyCommand = new ActionCommand(InvokeReply, o => true);
            BackCommand = new ActionCommand(o => InvokePrev(), o => true);
            ForwardCommand = new ActionCommand(o => InvokeNext(), o => true);
            _model = model;
            InvokeNext();
        }
        private void InvokePrev()
        {
            var test = _model.GetPrev();
            if (test == null) return;
            CurrentMora = test.Question;
            Variantes = test.Variantes;
            Message = CommonResources.SelectValueMessage;
        }
        private void InvokeNext()
        {
            var test = _model.GetNext();
            CurrentMora = test.Question;
            Variantes = test.Variantes;
            Message = CommonResources.SelectValueMessage;
        }
        private void InvokeReply(object parameter)
        {
            Message = _model.CheckVariant((string)parameter) ? CommonResources.CorrectAnswerMessage : CommonResources.IncorrectAnswerMessage;
        }

        private void InvokePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
