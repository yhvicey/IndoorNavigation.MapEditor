namespace IndoorNavigator.MapEditor.Models
{
    using System;
    using System.Diagnostics;
    using Nodes;

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
            Debug.Assert(Enum.IsDefined(typeof(NodeType), startType));
            Debug.Assert(startIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), endType));
            Debug.Assert(endIndex >= 0);

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

        public override bool Equals(object obj)
        {
            var link = obj as Link;
            if (link == null) return false;
            return StartType == link.StartType && StartIndex == link.StartIndex && EndType == link.EndType &&
                   EndIndex == link.EndIndex ||
                   StartType == link.EndType && StartIndex == link.EndIndex && EndType == link.StartType &&
                   EndIndex == link.StartIndex;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var leftHashCode = StartIndex;
                leftHashCode = (leftHashCode * 397) ^ (int)StartType;
                var rightHashCode = EndIndex;
                rightHashCode = (rightHashCode * 397) ^ (int)EndType;
                return leftHashCode ^ rightHashCode;
            }
        }

        public override string ToString()
        {
            return $"Link Start({StartType}, {StartIndex}) End({EndType}, {EndIndex})";
        }
    }
}
