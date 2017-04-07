namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class EntryNode :
        NodeBase
    {
        public string Name { get; set; }

        public int? Next { get; }

        public int? Prev { get; }

        public override NodeType Type => NodeType.EntryNode;

        public EntryNode(Floor parent, double x, double y, string name, int? prev, int? next) :
            base(parent, x, y)
        {
            Name = name;
            Next = next;
            Prev = prev;
        }

        public override string ToString()
        {
            return
                $"{base.ToString()} {(Name == null ? "" : $"Name: {Name} ") + (Prev == null ? "" : $"Prev: {Prev} ") + (Next == null ? "" : $"Next: {Next}")}";
        }
    }
}
