namespace IndoorNavigator.MapEditor.Contracts.Nodes
{
    using System.Diagnostics;

    [DebuggerDisplay("{" + nameof(X) + "}, {" + nameof(Y) + "}")]
    public abstract class NodeBase
    {
        public abstract NodeType Type { get; }

        public double X { get; set; }

        public double Y { get; set; }

        protected NodeBase(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
