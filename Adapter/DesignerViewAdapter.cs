namespace IndoorNavigator.MapEditor.Adapter
{
    using System;
    using System.Diagnostics;
    using Controls;
    using Models;
    using Models.Nodes;
    using Share;

    public class DesignerViewAdapter :
        IAdapter
    {
        private readonly DesignerView _designerView;

        public DesignerViewAdapter(DesignerView designerView)
        {
            Debug.Assert(designerView != null);

            _designerView = designerView;
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

            _designerView.Unhighlight();
            _designerView.Targets[floorIndex].Targets[catalogueIndex].Highlight();
        }

        public void OnSelectMap(Map map)
        {
            Debug.Assert(map != null);

            _designerView.UpdateFloorSize();
            _designerView.Unhighlight();
        }

        public void OnSelectFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            _designerView.UpdateFloorSize();
            _designerView.Unhighlight();
        }

        public void OnSelectLink(int floorIndex, int linkIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(linkIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            _designerView.Unhighlight();
            _designerView.Targets[floorIndex].Targets[Constant.LinksIndex].Targets[linkIndex].Highlight();
        }

        public void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {
            Debug.Assert(floorIndex >= 0);
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(nodeIndex >= 0);

            if (floorIndex != _designerView.CurrentFloorIndex) return;

            _designerView.Unhighlight();
            _designerView.Targets[floorIndex].Targets[(int)type].Targets[nodeIndex].Highlight();
        }
    }
}
