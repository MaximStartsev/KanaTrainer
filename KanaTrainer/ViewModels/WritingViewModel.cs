using MaximStartsev.KanaTrainer.Models;
using MaximStartsev.KanaTrainer.MVVM;
using MaximStartsev.KanaTrainer.Resources;
using System.ComponentModel;
using System.Windows.Input;

namespace MaximStartsev.KanaTrainer.ViewModels
{
    internal sealed class WritingViewModel : INotifyPropertyChanged
    {
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
                if (_message != value)
                {
                    _message = value;
                    InvokePropertyChanged(nameof(Message));
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

        private readonly WritingModel _model;
        public WritingViewModel(WritingModel model)
        {
            ReplyCommand = new ActionCommand(InvokeReply, o => true);
            BackCommand = new ActionCommand(o => InvokePrev(), o => true);
            ForwardCommand = new ActionCommand(o => InvokeNext(), o => true);
            _model = model;
            InvokeNext();
        }
        private void InvokePrev()
        {
            var prev = _model.GetPrev();
            if(prev != null)
            {
                CurrentMora = prev;
                Message = CommonResources.InputTranscriptionMessage;
            }
        }
        private void InvokeNext()
        {
            CurrentMora = _model.GetNext();
            Message = CommonResources.InputTranscriptionMessage;
        }
        private void InvokeReply(object parameter)
        {
            Message = _model.CheckVariant((string)parameter) ? CommonResources.CorrectAnswerMessage : CommonResources.IncorrectAnswerMessage;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void InvokePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
