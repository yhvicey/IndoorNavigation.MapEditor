namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class WallNode :
        NodeBase
    {
        public override NodeType Type => NodeType.WallNode;

        public WallNode(double x, double y) :
            base(x, y)
        {

        }
    }
}
