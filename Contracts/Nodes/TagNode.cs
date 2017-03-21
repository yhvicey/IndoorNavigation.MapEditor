namespace IndoorNavigator.MapEditor.Contracts.Nodes
{
    public class TagNode :
        NodeBase
    {
        public string Tag { get; set; }

        public override NodeType Type => NodeType.TagNode;

        public TagNode(int x, int y, string tag = null) :
            base(x, y)
        {
            Tag = tag;
        }
    }
}
