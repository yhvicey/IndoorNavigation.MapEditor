namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class EntryNode :
        NodeBase
    {
        public string Name { get; set; }

        public int? Next { get; set; }

        public int? Prev { get; set; }

        public override NodeType Type => NodeType.EntryNode;

        public EntryNode(double x, double y, string name, int? prev, int? next) :
            base(x, y)
        {
            Name = name;
            Next = next;
            Prev = prev;
        }

        public override string ToString()
        {
            return
                $"{base.ToString()}{(Name == null ? "" : $" Name: {Name}") + (Prev == null ? "" : $" Prev: {Prev}") + (Next == null ? "" : $" Next: {Next}")}";
        }
    }
}
