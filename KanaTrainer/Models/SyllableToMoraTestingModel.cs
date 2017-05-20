using System;
using System.Collections.Generic;
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
            var test = new TestIteration();
            KeyValuePair<string, string> pair = GetRandomPair();
            _currentAnswer = pair.Value;
            test.Question = pair.Key;
            var variantes = new string[4];
            test.Variantes = variantes;
            variantes[_random.Next(4)] = pair.Value;
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
            return test;
        }
    }
}
