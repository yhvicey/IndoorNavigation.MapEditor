namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class GuideNode :
        NodeBase
    {
        public string Name { get; set; }

        public override NodeType Type => NodeType.GuideNode;

        public GuideNode(int x, int y, string name = null) :
            base(x, y)
        {
            Name = name;
        }

        public override string ToString()
        {
            return
                $"{base.ToString()}{(Name == null ? "" : $" Name: {Name}")}";
        }
    }
}
