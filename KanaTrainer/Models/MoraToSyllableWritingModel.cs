
namespace MaximStartsev.KanaTrainer.Models
{
    internal sealed class MoraToSyllableWritingModel : WritingModel
    {
        private string _currentAnswer = null;
        public override bool CheckVariant(string variant)
        {
            if (variant == null) return false;
            return variant.ToLower() == _currentAnswer;
        }

        public override string GetNext()
        {
            var pair = GetRandomPair();
            _currentAnswer = pair.Key;
            return pair.Value;
        }
    }
}
