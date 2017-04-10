namespace IndoorNavigator.MapEditor.Controls
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public sealed class MapElementTreeNode :
        TreeNode
    {
        public static ContextMenuStrip CustomContextMenuStrip { get; set; }

        public object MapElement { get; set; }

        public string StaticText { get; set; }

        public MapElementTreeNode(string text, IEnumerable<MapElementTreeNode> childItems = null, object mapElement = null)
        {
            ContextMenuStrip = CustomContextMenuStrip;
            if (text != null)
            {
                StaticText = text;
            }
            if (childItems != null)
            {
                foreach (var childItem in childItems)
                {
                    Nodes.Add(childItem);
                }
            }
            if (mapElement != null) MapElement = mapElement;
            Update();
        }

        public void Update()
        {
            Text = StaticText ?? MapElement?.ToString() ?? "";
            foreach (var node in Nodes.OfType<MapElementTreeNode>())
            {
                node.Update();
            }
        }
    }
}
