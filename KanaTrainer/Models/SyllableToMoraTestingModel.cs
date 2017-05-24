using MaximStartsev.KanaTrainer.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MaximStartsev.KanaTrainer.Models
{
    internal sealed class SyllableToMoraTestingModel : TestingModel
    {
        private string _currentAnswer = null;
        public override bool CheckVariant(string variant)
        {
            return variant == _currentAnswer;
        }

        public override TestIteration GetNext()
        {
            var tuple = (Tuple<TestIteration, string>)HistoryProcessor.Next();
            if (tuple != null)
            {
                Debug.WriteLine("Next from history");
                _currentAnswer = tuple.Item2;
                return tuple.Item1;
            }
            Debug.WriteLine("New next");
            var test = new TestIteration();
            KeyValuePair<string, string> pair = GetRandomPair();
            _currentAnswer = pair.Value;
            test.Question = pair.Key;
            var variantes = new string[4];
            test.Variantes = variantes;
            variantes[Randomize.GetNext(4)] = pair.Value;
            for (int i = 0; i < 4; i++)
            {
                if (String.IsNullOrEmpty(variantes[i]))
                {
                    var s = GetRandomPair().Value;
                    while (variantes.Contains(s))
                    {
                        s = GetRandomPair().Value;
                    }
                    variantes[i] = s;
                }
            }
            HistoryProcessor.Add(Tuple.Create(test, _currentAnswer));
            return test;
        }

        public override TestIteration GetPrev()
        {
            var tuple = (Tuple<TestIteration, string>)HistoryProcessor.Prev();
            if (tuple != null)
            {
                Debug.WriteLine("Prev from history");
                _currentAnswer = tuple.Item2;
                return tuple.Item1;
            }
            return null;
        }
    }
}
