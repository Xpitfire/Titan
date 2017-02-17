using System;
using System.Collections.Generic;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public sealed class ResidualLayerSyntax : LayerSyntax
    {
        public ImmutableList<LayerSyntax> LeftBranch { get; internal set; }
        public ImmutableList<LayerSyntax> RightBranch { get; internal set; }

        private ResidualLayerSyntax(string name, string input) : base(SyntaxKind.Residual, input) { }
        internal ResidualLayerSyntax(string name, string input,
            ImmutableList<LayerSyntax> leftBranch,
            ImmutableList<LayerSyntax> rightBranch) : base(SyntaxKind.Residual, input)
        {
            LeftBranch = leftBranch;
            RightBranch = rightBranch;
        }
        public LayerSyntax AddLeftLayer(LayerSyntax layer)
        {
            // TODO: not correct -> implement right behavior
            var clone = this.DeepClone();
            return clone;
        }

        public LayerSyntax AddRightLayer(LayerSyntax layer)
        {
            // TODO: not correct -> implement right behavior
            var clone = this.DeepClone();
            return clone;
        }
        
        internal override LayerSyntax FindLayerByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            if (Name == name) return this;
            if (LeftBranch != null)
            {
                foreach (var n in LeftBranch)
                {
                    var res = n.FindLayerByName(name);
                    if (res != null) return res;
                }
            }
            if (RightBranch != null)
            {
                foreach (var n in RightBranch)
                {
                    var res = n.FindLayerByName(name);
                    if (res != null) return res;
                }
            }
            return null;
        }

        public override void Traverse()
        {
            base.Traverse();
            OnNodeEnterEvent();
            OnNodeVisitEvent(this);
            foreach (var layer in LeftBranch)
            {
                layer.Traverse();
            }
            foreach (var layer in RightBranch)
            {
                layer.Traverse();
            }
            OnNodeLeaveEvent();
        }
    }
}
