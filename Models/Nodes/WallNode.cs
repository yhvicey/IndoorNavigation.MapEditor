﻿namespace IndoorNavigator.MapEditor.Models.Nodes
{
    public class WallNode :
        NodeBase
    {
        public override NodeType Type => NodeType.WallNode;

        public WallNode(Floor parent, double x, double y) :
            base(parent, x, y)
        {

        }
    }
}
