namespace IndoorNavigator.MapEditor.Models
{
    using System.Diagnostics;
    using Nodes;
    using Share;

    [DebuggerDisplay(nameof(Distance) + " = {" + nameof(Distance) + "}")]
    public class Link :
        IMapModel
    {
        private Floor _parent;

        public double Distance => _parent.GetDistance(StartType, StartIndex, EndType, EndIndex);

        public int EndIndex { get; set; }

        public NodeType EndType { get; set; }

        public int StartIndex { get; set; }

        public NodeType StartType { get; set; }

        public Link(NodeType startType, int startIndex, NodeType endType, int endIndex)
        {
            StartType = startType;
            StartIndex = startIndex;
            EndType = endType;
            EndIndex = endIndex;
        }

        public void OnAdd(Floor parent)
        {
            Debug.Assert(parent != null);

            _parent = parent;
        }

        public override string ToString()
        {
            return $"Link Start({StartType}, {StartIndex}) End({EndType}, {EndIndex})";
        }
    }
}
