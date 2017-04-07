namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class WallNode :
        NodeBase
    {
        public override NodeType Type => NodeType.Wall;

        public WallNode(double x, double y) :
            base(x, y)
        {

        }
    }
}
