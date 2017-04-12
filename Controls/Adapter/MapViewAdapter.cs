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

        public void OnAddMap(Map map)
        {
            _mapView.Nodes.Clear();
            if (map == null) return;
            _root = new MapView.MapViewTreeNode(null, mapElement: map);
            map.Floors.ForEach(OnAddFloor);
            _mapView.Nodes.Add(_root);
        }

        public void OnAddFloor(Floor floor)
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

        public void OnAddLink(Link link, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.Add(new MapView.MapViewTreeNode(null, mapElement: link));
        }

        public void OnAddNode(NodeBase node, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)node.Type].Nodes.Add(new MapView.MapViewTreeNode(null, mapElement: node));
        }

        public void OnFlush()
        {
            _root?.Update();
        }

        public void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            _root.Nodes[floorIndex].Nodes[catalogueIndex].Nodes.Clear();
        }

        public void OnRemoveMap()
        {
            _mapView.Nodes.Clear();
        }

        public void OnRemoveFloor(int floorIndex)
        {
            _root.Nodes.RemoveAt(floorIndex);
        }

        public void OnRemoveLink(int floorIndex, int linkIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.RemoveAt(linkIndex);
        }

        public void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)type].Nodes.RemoveAt(nodeIndex);
        }

        public void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[catalogueIndex];
        }

        public void OnSelectMap(Map map)
        {
            _mapView.SelectedNode = _root;
        }

        public void OnSelectFloor(int floorIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex];
        }

        public void OnSelectLink(int floorIndex, int linkIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes[linkIndex];
        }

        public void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[(int)type].Nodes[nodeIndex];
        }
    }
}
