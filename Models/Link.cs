namespace IndoorNavigator.MapEditor.Models
{
    using System.Diagnostics;
    using Nodes;
    using Share;

    [DebuggerDisplay(nameof(Distance) + " = {" + nameof(Distance) + "}")]
    public class Link
    {
        public double Distance { get; private set; }

        public int EndIndex { get; set; }

        public NodeType EndType { get; set; }

        public int StartIndex { get; set; }

        public NodeType StartType { get; set; }

        public void OnAdd(Floor parent)
        {
            Contract.EnsureArgsNonNull(parent);
            Distance = parent.GetDistance(StartType, StartIndex, EndType, EndIndex);
        }

        public Link(NodeType startType, int startIndex, NodeType endType, int endIndex)
        {
            StartType = startType;
            StartIndex = startIndex;
            EndType = endType;
            EndIndex = endIndex;
        }

        public override string ToString()
        {
            return $"Link Start({StartType}, {StartIndex}) End({EndType}, {EndIndex})";
        }
    }
}
