namespace IndoorNavigator.MapEditor.Controls
{
    using System.Linq;
    using System.Windows.Forms;
    using Models;
    using Models.Nodes;
    using Share;

    public class MapViewAdapter
    {
        public const string EntryNodesLabelText = "Entry nodes";

        public const string GuideNodesLabelText = "Guide nodes";

        public const string WallNodesLabelText = "Wall nodes";

        public const string LinksLabelText = "Links";

        private readonly TreeView _mapView;

        private MapElementTreeNode _root;

        public Map Map
        {
            set
            {
                _mapView.Nodes.Clear();
                if (value == null) return;
                _root = new MapElementTreeNode(value.Name, mapElement: value);
                var index = 0;
                foreach (var floor in value.Floors)
                {
                    AddFloor(index++, floor);
                }
                _mapView.Nodes.Add(_root);
                Flush();
            }
        }

        public MapViewAdapter(TreeView mapView)
        {
            Contract.EnsureArgsNonNull(mapView);
            _mapView = mapView;
        }

        public void AddFloor(int index, Floor floor)
        {
            var floorNode = new MapElementTreeNode($"Floor {index + 1}", mapElement: floor);
            var entryNodes = floor.EntryNodes.Select(entryNode => new MapElementTreeNode(null, mapElement: entryNode));
            var guideNodes = floor.GuideNodes.Select(guideNode => new MapElementTreeNode(null, mapElement: guideNode));
            var wallNodes = floor.WallNodes.Select(wallNode => new MapElementTreeNode(null, mapElement: wallNode));
            var linkNodes = floor.Links.Select(link => new MapElementTreeNode(null, mapElement: link));
            floorNode.Nodes.Add(new MapElementTreeNode(EntryNodesLabelText, entryNodes, floor.EntryNodes));
            floorNode.Nodes.Add(new MapElementTreeNode(GuideNodesLabelText, guideNodes, floor.GuideNodes));
            floorNode.Nodes.Add(new MapElementTreeNode(WallNodesLabelText, wallNodes, floor.WallNodes));
            floorNode.Nodes.Add(new MapElementTreeNode(LinksLabelText, linkNodes, floor.Links));
            _root.Nodes.Insert(index, floorNode);
            Flush();
        }

        public void AddLink(int floorIndex, Link link)
        {
            // "3" is magic - for links
            _root.Nodes[floorIndex].Nodes[3].Nodes.Add(new MapElementTreeNode(null, mapElement: link));
            Flush();
        }

        public void AddNode(int floorIndex, NodeBase node)
        {
            _root.Nodes[floorIndex].Nodes[(int)node.Type].Nodes.Add(new MapElementTreeNode(null, mapElement: node));
            Flush();
        }

        public void Flush()
        {
            _root.Update();
        }

        public void RemoveFloor(int floorIndex)
        {
            _root.Nodes.RemoveAt(floorIndex);
            Flush();
        }

        public void RemoveNode(NodeType type, int floor, int index)
        {
            _root.Nodes[floor].Nodes[(int)type].Nodes.RemoveAt(index);
            Flush();
        }
    }
}
