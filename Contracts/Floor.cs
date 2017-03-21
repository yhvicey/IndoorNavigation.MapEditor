namespace IndoorNavigator.MapEditor.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Nodes;

    [DebuggerDisplay("Scale = {" + nameof(Scale) + "}, NodeCount = {" + nameof(Nodes) + ".Count}, LinkCount = {" + nameof(Links) + ".Count}")]
    [Serializable]
    public class Floor
    {
        public int Scale { get; set; }

        public IList<NodeBase> Nodes { get; }

        public IList<Link> Links { get; }

        public Floor(int scale, IList<NodeBase> nodes, IList<Link> links)
        {
            Scale = scale;
            Nodes = nodes;
            Links = links;
        }
    }
}
