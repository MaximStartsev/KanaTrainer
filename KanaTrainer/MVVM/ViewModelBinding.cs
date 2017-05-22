using System;
using System.Windows.Markup;

namespace MaximStartsev.KanaTrainer.MVVM
{
    class ViewModelBinding : MarkupExtension
    {
        public Type ModelType { get; set; }
        public Type ViewModelType { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if(ModelType == null)
                throw new ArgumentNullException(nameof(ModelType));
            if (ViewModelType == null)
                throw new ArgumentNullException(nameof(ViewModelType));
            var model = Activator.CreateInstance(ModelType);
            var viewModel = Activator.CreateInstance(ViewModelType, model);
            return viewModel;
        }
    }
}
