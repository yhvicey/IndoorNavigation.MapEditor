﻿namespace IndoorNavigator.MapEditor.Contracts.Nodes
{
    public class WallNode :
        NodeBase
    {
        public override NodeType Type => NodeType.WallNode;

        public WallNode(int x, int y) :
            base(x, y)
        {

        }
    }
}
