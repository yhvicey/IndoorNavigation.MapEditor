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

        public double Distance => _parent.GetDistance(Type, StartIndex, Type, EndIndex);

        public int EndIndex { get; set; }

        public int StartIndex { get; set; }

        public NodeType Type { get; set; }

        public Link(NodeType type, int startIndex, int endIndex)
        {
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(startIndex >= 0);
            Debug.Assert(endIndex >= 0);

            Type = type;
            StartIndex = startIndex;
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
            return Type == link.Type && (StartIndex == link.StartIndex && EndIndex == link.EndIndex ||
                                         StartIndex == link.EndIndex && EndIndex == link.StartIndex);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = EndIndex;
                hashCode = (hashCode * 397) ^ StartIndex;
                hashCode = (hashCode * 397) ^ (int) Type;
                return hashCode;
            }
        }

        public override string ToString()
        {
            return $"Link Type = {Type} ({StartIndex}, {EndIndex})";
        }
    }
}
