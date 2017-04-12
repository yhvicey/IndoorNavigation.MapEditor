namespace IndoorNavigator.MapEditor.Controls.Adapter
{
    using System.Diagnostics;
    using Models;
    using Models.Nodes;

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
            // no-op
        }

        public void OnAddFloor(Floor floor)
        {
            // no-op
        }

        public void OnAddLink(Link link, int floorIndex)
        {
            // no-op
        }

        public void OnAddNode(NodeBase node, int floorIndex)
        {
            // no-op
        }

        public void OnFlush()
        {
            _designerView.Flush();
        }

        public void OnRemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            // no-op
        }

        public void OnRemoveMap()
        {
            // no-op
        }

        public void OnRemoveFloor(int floorIndex)
        {
            // no-op
        }

        public void OnRemoveLink(int floorIndex, int linkIndex)
        {
            // no-op
        }

        public void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            // no-op
        }

        public void OnSelectCatalogue(int floorIndex, int catalogueIndex)
        {
            //_designerView.Unhighlight();
            //_designerView.Targets[floorIndex].Targets[catalogueIndex].Targets.ForEach(target => target.Highlighted = true);
        }

        public void OnSelectMap(Map map)
        {

        }

        public void OnSelectFloor(int floorIndex)
        {

        }

        public void OnSelectLink(int floorIndex, int linkIndex)
        {

        }

        public void OnSelectNode(int floorIndex, NodeType type, int nodeIndex)
        {

        }
    }
}
