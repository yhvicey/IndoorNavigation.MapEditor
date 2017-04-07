namespace IndoorNavigator.MapEditor.Models.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Share;

    [DebuggerDisplay("{" + nameof(X) + "}, {" + nameof(Y) + "}")]
    public abstract class NodeBase
    {
        protected Floor Parent { get; }

        public List<Link> Links { get; } = new List<Link>();

        public abstract NodeType Type { get; }

        public double X { get; set; }

        public double Y { get; set; }

        protected NodeBase(Floor parent, double x, double y)
        {
            Contract.EnsureArgsNonNull(parent);
            Parent = parent;
            X = x;
            Y = y;
        }

        public double GetDistance(NodeType type, int index)
        {
            var target = Parent.GetNode(type, index);
            return GetDistance(target);
        }

        public double GetDistance(NodeBase other)
        {
            Contract.EnsureArgsNonNull(other);
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }

        public void Link(NodeType type, int index)
        {
            if (Links.Any(link => link.Type == type && link.Index == index)) return;
            Links.Add(new Link(this, type, index));
        }

        public void Link(NodeBase node)
        {
            Contract.EnsureArgsNonNull(node);
            var index = Parent.GetNodeIndex(node);
            Link(node.Type, index);
        }

        public void OnLoadFinished()
        {
            Links.ForEach(link => link.OnLoadFinished());
        }

        public override string ToString()
        {
            return $"{Type}({X}, {Y})";
        }
    }
}
