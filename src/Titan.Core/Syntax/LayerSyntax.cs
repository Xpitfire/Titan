﻿using System;
using System.Linq;
using Titan.Core.Collection;

namespace Titan.Core.Syntax
{
    [Serializable]
    public abstract class LayerSyntax : SyntaxNode
    {
        [Serializable]
        public enum SyntaxKind
        {
            Convolutional,
            Pooling,
            Scaling,
            BatchNormalization,
            FullyConnected,
            Residual,
            Inception,
            Softmax
        }

        public SyntaxKind Kind { get; internal set; }
        public LayerSyntax ParentLayer { get; internal set; }
        public ImmutableList<LayerSyntax> ChildLayers { get; internal set; }
        
        protected LayerSyntax(SyntaxKind kind, string name = null) : base(name)
        {
            Kind = kind;
        }

        public LayerSyntax FindParentLayerByIdentifier(IdentifierSyntax id)
            => (id == null) ? null : FindParentLayerByName(id.Id);
        public LayerSyntax FindParentLayerByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            return RecursiveFindParentLayerByName(this, name);
        }
        private LayerSyntax RecursiveFindParentLayerByName(LayerSyntax node, string name)
        {
            if (node == null) return null;
            if (node.Name == name) return node;
            if (node.ParentLayer == null) return null;
            return RecursiveFindParentLayerByName(node.ParentLayer, name);
        }

        public LayerSyntax FindChildLayerrByIdentifier(IdentifierSyntax id)
            => (id == null) ? null : FindChildLayerByName(id.Id);
        public LayerSyntax FindChildLayerByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            return RecursiveFindChildLayerByName(this, name);
        }
        private LayerSyntax RecursiveFindChildLayerByName(LayerSyntax node, string name)
        {
            if (node == null) return null;
            if (node.Name == name) return node;
            if (node.ChildLayers == null) return null;
            foreach (var n in node.ChildLayers)
            {
                var res = RecursiveFindChildLayerByName(n, name);
                if (res != null) return res;
            }
            return null;
        }
    }
}
