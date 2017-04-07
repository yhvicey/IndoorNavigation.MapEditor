namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class EntryNode :
        NodeBase
    {
        public string Name { get; set; }

        public int? NextEntry { get; }

        public int? PrevEntry { get; }

        public override NodeType Type => NodeType.Entry;

        public EntryNode(double x, double y, string name, int? prevEntry, int? nextEntry) :
            base(x, y)
        {
            Name = name;
            NextEntry = nextEntry;
            PrevEntry = prevEntry;
        }

        public override string ToString()
        {
            return
                $"{base.ToString()} {(Name == null ? "" : $"Name: {Name} ") + (PrevEntry == null ? "" : $"Prev: {PrevEntry}") + (NextEntry == null ? "" : $"Next: {NextEntry}")}";
        }
    }
}
