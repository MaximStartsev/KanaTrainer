using System.Collections.Generic;

namespace MaximStartsev.KanaTrainer.Models
{
    internal sealed class TestIteration
    {
        public string Question { get; set; }
        public IEnumerable<string> Variantes { get; set; }
    }
}
