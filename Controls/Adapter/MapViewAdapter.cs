namespace IndoorNavigator.MapEditor.Controls.Adapter
{
    using System.Linq;
    using Models;
    using Models.Nodes;
    using Share;

    public class MapViewAdapter :
        IAdapter
    {
        private readonly MapView _mapView;

        private MapView.MapViewTreeNode _root;

        public MapViewAdapter(MapView mapView)
        {
            Contract.EnsureArgsNonNull(mapView);
            _mapView = mapView;
        }

        public void AddMap(Map map)
        {
            _mapView.Nodes.Clear();
            if (map == null) return;
            _root = new MapView.MapViewTreeNode(null, mapElement: map);
            map.Floors.ForEach(AddFloor);
            _mapView.Nodes.Add(_root);
        }

        public void AddFloor(Floor floor)
        {
            var floorNode = new MapView.MapViewTreeNode($"Floor {_root.Nodes.Count + 1}", mapElement: floor);
            var entryNodes = floor.EntryNodes.Select(entryNode => new MapView.MapViewTreeNode(null, mapElement: entryNode));
            var guideNodes = floor.GuideNodes.Select(guideNode => new MapView.MapViewTreeNode(null, mapElement: guideNode));
            var wallNodes = floor.WallNodes.Select(wallNode => new MapView.MapViewTreeNode(null, mapElement: wallNode));
            var linkNodes = floor.Links.Select(link => new MapView.MapViewTreeNode(null, mapElement: link));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.EntryNodesLabelText, entryNodes, floor.EntryNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.GuideNodesLabelText, guideNodes, floor.GuideNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.WallNodesLabelText, wallNodes, floor.WallNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.LinksLabelText, linkNodes, floor.Links));
            _root.Nodes.Add(floorNode);
        }

        public void AddLink(Link link, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.Add(new MapView.MapViewTreeNode(null, mapElement: link));
        }

        public void AddNode(NodeBase node, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)node.Type].Nodes.Add(new MapView.MapViewTreeNode(null, mapElement: node));
        }

        public void Flush()
        {
            _root?.Update();
        }

        public void RemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            _root.Nodes[floorIndex].Nodes[catalogueIndex].Nodes.Clear();
        }

        public void RemoveMap()
        {
            _mapView.Nodes.Clear();
        }

        public void RemoveFloor(int floorIndex)
        {
            _root.Nodes.RemoveAt(floorIndex);
        }

        public void RemoveLink(int floorIndex, int linkIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.RemoveAt(linkIndex);
        }

        public void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)type].Nodes.RemoveAt(nodeIndex);
        }

        public void SelectCatalogue(int floorIndex, int catalogueIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[catalogueIndex];
        }

        public void SelectMap(Map map)
        {
            _mapView.SelectedNode = _root;
        }

        public void SelectFloor(int floorIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex];
        }

        public void SelectLink(int floorIndex, int linkIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes[linkIndex];
        }

        public void SelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[(int)type].Nodes[nodeIndex];
        }
    }
}
