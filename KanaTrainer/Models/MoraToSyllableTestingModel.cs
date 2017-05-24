using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximStartsev.KanaTrainer.Models
{
    internal sealed class MoraToSyllableTestingModel: TestingModel
    {
        private string _currentAnswer = null;
        public override TestIteration GetNext()
        {
            var tuple = (Tuple<TestIteration, string>)HistoryProcessor.Next();
            if (tuple != null)
            {
                _currentAnswer = tuple.Item2;
                return tuple.Item1;
            }
            var test = new TestIteration();
            KeyValuePair<string, string> pair = GetRandomPair();
            _currentAnswer = pair.Key;
            test.Question = pair.Value;
            var variantes = new string[4];
            test.Variantes = variantes;
            variantes[Randomize.GetNext(4)] = pair.Key;
            for (int i = 0; i < 4; i++)
            {
                if (String.IsNullOrEmpty(variantes[i]))
                {
                    var s = GetRandomPair().Key;
                    while (variantes.Contains(s))
                    {
                        s = GetRandomPair().Key;
                    }
                    variantes[i] = s;
                }
            }
            HistoryProcessor.Add(Tuple.Create(test, _currentAnswer));
            return test;
        }
        public override bool CheckVariant(string variant)
        {
            return variant == _currentAnswer;
        }

        public override TestIteration GetPrev()
        {
            var tuple = (Tuple<TestIteration, string>)HistoryProcessor.Prev();
            if (tuple != null)
            {
                _currentAnswer = tuple.Item2;
                return tuple.Item1;
            }
            return null;
        }
    }
}
