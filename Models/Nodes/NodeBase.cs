namespace IndoorNavigator.MapEditor.Models.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Share;

    [DebuggerDisplay("{" + nameof(X) + "}, {" + nameof(Y) + "}")]
    public abstract class NodeBase
    {
        private readonly Dictionary<NodeBase, double> _distanceTable = new Dictionary<NodeBase, double>();

        public IList<NodeBase> AdjacentNodes { get; protected set; } = new List<NodeBase>();

        public string Tag { get; set; }

        public abstract NodeType Type { get; }

        public double X { get; set; }

        public double Y { get; set; }

        protected NodeBase(double x, double y)
        {
            X = x;
            Y = y;
        }

        public void AddAdjacentNode(NodeBase node)
        {
            Contract.EnsureArgsNonNull(node);
            if (AdjacentNodes.Contains(node)) return;
            GetDistance(node);
            AdjacentNodes.Add(node);
        }

        public void ClearTag()
        {
            Tag = null;
        }

        public double GetDistance(NodeBase other)
        {
            Contract.EnsureArgsNonNull(other);
            if (_distanceTable.ContainsKey(other)) return _distanceTable[other];
            var distance = Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
            _distanceTable[other] = distance;
            return distance;
        }

        public override string ToString()
        {
            return $"{Type}({X}, {Y})";
        }
    }
}
