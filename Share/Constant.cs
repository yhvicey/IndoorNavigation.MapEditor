namespace IndoorNavigator.MapEditor.Share
{
    using System.Drawing;

    public static class Constant
    {
        public const string GuideNodesLabelText = "Guide nodes";

        public const string WallNodesLabelText = "Wall nodes";

        public const string LinksLabelText = "Links";

        public const int MapNodeLevel = 0;

        public const int FloorNodeLevel = 1;

        public const int CatalogueNodeLevel = 2;

        public const int ElementNodeLevel = 3;

        public const int GuideNodesIndex = 0;

        public const int WallNodesIndex = 1;

        public const int LinksIndex = 2;

        public const int NoSelectedFloor = -1;

        public const int NodeHalfSideLength = 5;

        public const int HighlightedNodeHalfSideLength = 7;

        public const int LinkWidth = 2;

        public const int HighlightedLinkWidth = 4;

        public static readonly Color EntryNodeColor = Color.LawnGreen;

        public static readonly Color GuideNodeColor = Color.Cyan;

        public static readonly Color WallNodeColor = Color.Red;

        public static readonly Color LinkColor = Color.LimeGreen;
    }
}
