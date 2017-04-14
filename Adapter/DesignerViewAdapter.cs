namespace IndoorNavigator.MapEditor.Adapter
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using Controls;
    using Models;
    using Models.Nodes;
    using Share;

    public class DesignerViewAdapter :
        IAdapter
    {
        private readonly Dictionary<int, Image> _backgroundTable = new Dictionary<int, Image>();

        private readonly Dictionary<int, Size> _canvasSizeTable = new Dictionary<int, Size>();

        private readonly DesignerView _designerView;

        public DesignerViewAdapter(DesignerView designerView)
        {
            Debug.Assert(designerView != null);

            _designerView = designerView;
        }

        public void ChangeCanvasSize(Size size, int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            var minimalSize = _designerView.GetMininalDisplaySize(floorIndex);
            size.Width = size.Width < minimalSize.Width ? minimalSize.Width : size.Width;
            size.Height = size.Height < minimalSize.Height ? minimalSize.Height : size.Height;

            _designerView.CanvasSize = size;
            _canvasSizeTable[floorIndex] = size;
        }

        public void LoadBackground(Image image, int floorIndex)
        {
            _backgroundTable[floorIndex] = image;
            _designerView.Background = image;
        }

        public void RemoveBackground()
        {
            _backgroundTable[_designerView.CurrentFloorIndex] = null;
            _designerView.Background = null;
        }

        public void OnAddMap(Map map)
        {
            Debug.Assert(map != null);

            _designerView.Targets.Clear();
            map.Floors.ForEach(OnAddFloor);
        }

        public void OnAddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            var floorTarget = new DesignerView.RenderTarget(_designerView, floor);
            floorTarget.Targets.Add(new DesignerView.RenderTarget(_designerView, childItems: floor.EntryNodes));
            floorTarget.Targets.Add(new DesignerView.RenderTarget(_designerView, childItems: floor.GuideNodes));
            floorTarget.Targets.Add(new DesignerView.RenderTarget(_designerView, childItems: floor.WallNodes));
            floorTarget.Targets.Add(new DesignerView.RenderTarget(_designerView, childItems: floor.Links));
            _designerView.Targets.Add(floorTarget);
        }

        public void OnAddLink(Link link, int floorIndex)
        {
            Debug.Assert(link != null);
            Debug.Assert(floorIndex >= 0);


            _designerView.Targets[floorIndex].Targets[Constant.LinksIndex].Targets.Add(
                new DesignerView.RenderTarget(_designerView, link));
        }

        public void OnAddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);
            Debug.Assert(floorIndex >= 0);

            _designerView.Targets[floorIndex].Targets[(int)node.Type].Targets.Add(
                new DesignerView.RenderTarget(_designerView, node));
        }

        public void OnFlush()
        {
            _designerView.Flush();
        }

        public void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            _designerView.Targets[floorIndex].Targets[catalogueIndex].Targets.Clear();
        }

        public void OnRemoveMap()
        {
            _designerView.Targets.Clear();
        }

        public void OnRemoveFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            _designerView.Targets.RemoveAt(floorIndex);
        }

        public void OnRemoveLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            _designerView.Targets[floorIndex].Targets[Constant.LinksIndex].Targets.RemoveAt(linkIndex);
        }

        public void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            _designerView.Targets[floorIndex].Targets[(int)type].Targets.RemoveAt(nodeIndex);
        }

        public void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(catalogueIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            _designerView.SelectTarget(_designerView.Targets[floorIndex].Targets[catalogueIndex]);
        }

        public void OnSelectMap(Map map)
        {
            Debug.Assert(map != null);

            _designerView.SelectTarget(null);
        }

        public void OnSelectFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            if (!_canvasSizeTable.ContainsKey(floorIndex)) _canvasSizeTable[floorIndex] = new Size();
            ChangeCanvasSize(_canvasSizeTable[floorIndex], floorIndex);
            if (!_backgroundTable.ContainsKey(floorIndex)) _backgroundTable[floorIndex] = null;
            _designerView.Background = _backgroundTable[floorIndex];
            _designerView.SelectTarget(_designerView.Targets[floorIndex], false);
        }

        public void OnSelectLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            _designerView.SelectTarget(_designerView.Targets[floorIndex].Targets[Constant.LinksIndex].Targets[linkIndex]);
        }

        public void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            _designerView.SelectTarget(_designerView.Targets[floorIndex].Targets[(int)type].Targets[nodeIndex]);
        }
    }
}
