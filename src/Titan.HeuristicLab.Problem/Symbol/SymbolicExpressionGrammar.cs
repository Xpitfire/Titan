using System.Collections.Generic;
using HeuristicLab.Common;
using HeuristicLab.Core;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    [Item("Lawn Mower Grammar", "The grammar for the lawn mower demo GP problem.")]
    public class Grammar : SymbolicExpressionGrammar
    {

        [StorableConstructor]
        private Grammar(bool deserializing) : base(deserializing)
        {
        }

        private Grammar(Grammar original, Cloner cloner) : base(original, cloner)
        {
        }

        public Grammar() : base("Grammar", "The grammar for the lawn mower demo GP problem.")
        {
            Initialize();
        }

        public override IDeepCloneable Clone(Cloner cloner) {
            return new Grammar(this, cloner);
        }

        // initialize set of allowed symbols and define
        // the allowed combinations of symbols
        private void Initialize() {
            // create all symbols
            var conv = new ConvolutionalLayerSymbol();
            var fc = new FullyConnectedSymbol();
            var pool = new PoolingSymbol();
            var inception = new InceptionLayerSymbol();
            var resnet = new ResNetLayerSymbol();

            var allSymbols = new List<ISymbol>()
            {
                conv,
                fc,
                pool,
                inception,
                resnet
            };

            // add all symbols to the grammar
            foreach (var s in allSymbols)
                AddSymbol(s);

            // define grammar rules
            // all symbols are allowed ...
            foreach (var s in allSymbols) {
                
                // ... as root symbol
                AddAllowedChildSymbol(StartSymbol, s, 0);
            }
        }
    }
}