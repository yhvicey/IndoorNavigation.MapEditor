namespace IndoorNavigator.MapEditor.Share
{
    using System.Drawing;

    public static class Constant
    {
        public const string EntryNodesLabelText = "Entry nodes";

        public const string GuideNodesLabelText = "Guide nodes";

        public const string WallNodesLabelText = "Wall nodes";

        public const string LinksLabelText = "Links";

        public const int MapNodeLevel = 0;

        public const int FloorNodeLevel = 1;

        public const int CatalogueNodeLevel = 2;

        public const int ElementNodeLevel = 3;

        public const int EntryNodesIndex = 0;

        public const int GuideNodesIndex = 1;

        public const int WallNodesIndex = 2;

        public const int LinksIndex = 3;

        public const int NoSelectedFloor = -1;

        public const int NodeHalfSideLength = 5;

        public const int HighlightedNodeHalfSideLength = 7;

        public const int LinkWidth = 1;

        public const int HighlightedLinkWidth = 2;

        public const int MapPadding = 50;

        public static readonly Color EntryNodeColor = Color.FromArgb(76, 255, 0);

        public static readonly Color GuideNodeColor = Color.FromArgb(0, 148, 255);

        public static readonly Color WallNodeColor = Color.FromArgb(128, 128, 128);

        public static readonly Color LinkColor = Color.Black;
    }
}
