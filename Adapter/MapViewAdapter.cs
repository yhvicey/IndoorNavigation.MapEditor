namespace IndoorNavigator.MapEditor.Adapter
{
    using System.Diagnostics;
    using Controls;
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
            Debug.Assert(mapView != null);
            _mapView = mapView;
        }

        public void OnAddMap(Map map)
        {
            _mapView.Nodes.Clear();
            if (map == null) return;
            _root = new MapView.MapViewTreeNode(mapModel: map);
            map.Floors.ForEach(OnAddFloor);
            _mapView.Nodes.Add(_root);
        }

        public void OnAddFloor(Floor floor)
        {
            var floorNode = new MapView.MapViewTreeNode($"Floor {_root.Nodes.Count + 1}", floor);
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.EntryNodesLabelText, childItems: floor.EntryNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.GuideNodesLabelText, childItems: floor.GuideNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.WallNodesLabelText, childItems: floor.WallNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.LinksLabelText, childItems: floor.Links));
            _root.Nodes.Add(floorNode);
        }

        public void OnAddLink(Link link, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.Add(new MapView.MapViewTreeNode(mapModel: link));
        }

        public void OnAddNode(NodeBase node, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)node.Type].Nodes.Add(new MapView.MapViewTreeNode(mapModel: node));
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
