namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class GuideNode :
        NodeBase
    {
        public string Name { get; set; }

        public override NodeType Type => NodeType.GuideNode;

        public GuideNode(Floor parent, double x, double y, string name = null) :
            base(parent, x, y)
        {
            Name = name;
        }

        public override string ToString()
        {
            return
                $"{base.ToString()} {(Name == null ? "" : $"Name: {Name} ")}";
        }
    }
}
