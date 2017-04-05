namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class EntryNode :
        NodeBase
    {
        public string Name { get; set; }

        public int? NextEntry { get; }

        public int? PrevEntry { get; }

        public override NodeType Type => NodeType.EntryNode;

        public EntryNode(double x, double y, string name, int? prevEntry, int? nextEntry) :
            base(x, y)
        {
            Name = name;
            NextEntry = nextEntry;
            PrevEntry = prevEntry;
        }
    }
}
