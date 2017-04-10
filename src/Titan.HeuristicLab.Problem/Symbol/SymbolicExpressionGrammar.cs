using System.Collections.Generic;
using HeuristicLab.Common;
using HeuristicLab.Core;
using HeuristicLab.Encodings.SymbolicExpressionTreeEncoding;
using HeuristicLab.Persistence.Default.CompositeSerializers.Storable;

namespace Titan.HeuristicLab.Problem
{
    [StorableClass]
    [Item("Network Grammar", "The grammar for DNN GP problem.")]
    public class Grammar : SymbolicExpressionGrammar
    {

        [StorableConstructor]
        private Grammar(bool deserializing) : base(deserializing)
        {
        }

        private Grammar(Grammar original, Cloner cloner) : base(original, cloner)
        {
        }

        public Grammar() : base("Grammar", "The grammar for DNN GP problem.")
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
            var fc = new FullyConnectedLayerSymbol();
            var pool = new PoolingLayerSymbol();
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
                AddAllowedChildSymbol(conv, s, 0);
                AddAllowedChildSymbol(conv, s, 1);

                AddAllowedChildSymbol(fc, s, 0);
                AddAllowedChildSymbol(fc, s, 1);

                AddAllowedChildSymbol(pool, s, 1);
                AddAllowedChildSymbol(inception, s, 1);
                AddAllowedChildSymbol(resnet, s, 1);

                // ... as root symbol
                AddAllowedChildSymbol(StartSymbol, s, 0);
            }
        }
    }
}