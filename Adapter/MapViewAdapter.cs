namespace IndoorNavigator.MapEditor.Adapter
{
    using System;
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
            Debug.Assert(map != null);

            _mapView.Nodes.Clear();
            _root = new MapView.MapViewTreeNode(mapModel: map);
            map.Floors.ForEach(OnAddFloor);
            _mapView.Nodes.Add(_root);
        }

        public void OnAddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            var floorNode = new MapView.MapViewTreeNode($"Floor {_root.Nodes.Count + 1}", floor);
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.EntryNodesLabelText, childItems: floor.EntryNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.GuideNodesLabelText, childItems: floor.GuideNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.WallNodesLabelText, childItems: floor.WallNodes));
            floorNode.Nodes.Add(new MapView.MapViewTreeNode(Constant.LinksLabelText, childItems: floor.Links));
            _root.Nodes.Add(floorNode);
        }

        public void OnAddLink(Link link, int floorIndex)
        {
            Debug.Assert(link != null);
            Debug.Assert(floorIndex >= 0);


            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.Add(new MapView.MapViewTreeNode(mapModel: link));
        }

        public void OnAddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);
            Debug.Assert(floorIndex >= 0);


            _root.Nodes[floorIndex].Nodes[(int)node.Type].Nodes.Add(new MapView.MapViewTreeNode(mapModel: node));
        }

        public void OnFlush()
        {
            _root?.Update();
        }

        public void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            _root.Nodes[floorIndex].Nodes[catalogueIndex].Nodes.Clear();
        }

        public void OnRemoveMap()
        {
            _mapView.Nodes.Clear();
        }

        public void OnRemoveFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            _root.Nodes.RemoveAt(floorIndex);
        }

        public void OnRemoveLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.RemoveAt(linkIndex);
        }

        public void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            _root.Nodes[floorIndex].Nodes[(int)type].Nodes.RemoveAt(nodeIndex);
        }

        public void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[catalogueIndex];
        }

        public void OnSelectMap(Map map)
        {
            Debug.Assert(map != null);

            _mapView.SelectedNode = _root;
        }

        public void OnSelectFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            _mapView.SelectedNode = _root.Nodes[floorIndex];
        }

        public void OnSelectLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes[linkIndex];
        }

        public void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[(int)type].Nodes[nodeIndex];
        }
    }
}
