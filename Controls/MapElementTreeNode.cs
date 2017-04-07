namespace IndoorNavigator.MapEditor.Controls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Models.Nodes;
    using Properties;

    public class MapElementTreeNode :
        TreeNode
    {
        private readonly bool _haveStaticText;

        public object MapElement { get; }

        public MapElementTreeNode(string text, IEnumerable<MapElementTreeNode> childItems = null, object mapElement = null)
        {
            if (text != null)
            {
                _haveStaticText = true;
                Text = text;
            }
            if (childItems != null)
            {
                foreach (var childItem in childItems)
                {
                    Nodes.Add(childItem);
                }
            }
            if (mapElement == null) return;
            if (!(mapElement is Map || mapElement is Floor || mapElement is NodeBase || mapElement is Link))
                throw new ArgumentException(Resources.InvalidArgument);
            MapElement = mapElement;
        }

        public void Update()
        {
            if (!_haveStaticText) Text = MapElement?.ToString() ?? "";
            foreach (var node in Nodes.OfType<MapElementTreeNode>())
            {
                node.Update();
            }
        }
    }
}
