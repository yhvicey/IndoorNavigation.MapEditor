namespace IndoorNavigator.MapEditor.Models
{
    using System.Diagnostics;
    using Nodes;

    [DebuggerDisplay(nameof(Type) + " = {" + nameof(Type) + "}, " + nameof(Index) + " = {" + nameof(Index) + "}, " + nameof(Distance) + " = {" + nameof(Distance) + "}")]
    public class Link
    {
        private readonly NodeBase _parent;

        public double Distance { get; private set; }

        public int Index { get; }

        public NodeType Type { get; }

        public Link(NodeBase parent, NodeType type, int index)
        {
            _parent = parent;
            Type = type;
            Index = index;
        }

        public void OnLoadFinished()
        {
            Distance = _parent.GetDistance(Type, Index);
        }
    }
}
