namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class GuideNode :
        NodeBase
    {
        public string Name { get; set; }

        public int? Next { get; set; }

        public int? Prev { get; set; }

        public override NodeType Type => NodeType.GuideNode;

        public GuideNode(int x, int y, string name = null, int? prev = null, int? next = null) :
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
