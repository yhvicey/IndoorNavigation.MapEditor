﻿namespace IndoorNavigator.MapEditor.Controls
{
    using System.Linq;
    using Models;
    using Models.Nodes;
    using Share;

    public class MapViewAdapter
    {
        private readonly MapView _mapView;

        private MapElementTreeNode _root;

        public MapViewAdapter(MapView mapView)
        {
            Contract.EnsureArgsNonNull(mapView);
            _mapView = mapView;
        }

        public void AddMap(Map map)
        {
            _mapView.Nodes.Clear();
            if (map == null) return;
            _root = new MapElementTreeNode(null, mapElement: map);
            map.Floors.ForEach(AddFloor);
            _mapView.Nodes.Add(_root);
            Flush();
        }

        public void AddFloor(Floor floor)
        {
            var floorNode = new MapElementTreeNode($"Floor {_root.Nodes.Count + 1}", mapElement: floor);
            var entryNodes = floor.EntryNodes.Select(entryNode => new MapElementTreeNode(null, mapElement: entryNode));
            var guideNodes = floor.GuideNodes.Select(guideNode => new MapElementTreeNode(null, mapElement: guideNode));
            var wallNodes = floor.WallNodes.Select(wallNode => new MapElementTreeNode(null, mapElement: wallNode));
            var linkNodes = floor.Links.Select(link => new MapElementTreeNode(null, mapElement: link));
            floorNode.Nodes.Add(new MapElementTreeNode(Constant.EntryNodesLabelText, entryNodes, floor.EntryNodes));
            floorNode.Nodes.Add(new MapElementTreeNode(Constant.GuideNodesLabelText, guideNodes, floor.GuideNodes));
            floorNode.Nodes.Add(new MapElementTreeNode(Constant.WallNodesLabelText, wallNodes, floor.WallNodes));
            floorNode.Nodes.Add(new MapElementTreeNode(Constant.LinksLabelText, linkNodes, floor.Links));
            _root.Nodes.Add(floorNode);
            Flush();
        }

        public void AddLink(Link link, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.Add(new MapElementTreeNode(null, mapElement: link));
            Flush();
        }

        public void AddNode(NodeBase node, int floorIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)node.Type].Nodes.Add(new MapElementTreeNode(null, mapElement: node));
            Flush();
        }

        public void Flush()
        {
            _root.Update();
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
            Flush();
        }

        public void RemoveLink(int floorIndex, int linkIndex)
        {
            _root.Nodes[floorIndex].Nodes[Constant.LinksIndex].Nodes.RemoveAt(linkIndex);
            Flush();
        }

        public void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            _root.Nodes[floorIndex].Nodes[(int)type].Nodes.RemoveAt(nodeIndex);
            Flush();
        }

        public void SelectCatalogue(int floorIndex, int catalogueIndex)
        {
            _mapView.SelectedNode = _root.Nodes[floorIndex].Nodes[catalogueIndex];
        }

        public void SelectMap()
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
