namespace IndoorNavigator.MapEditor.Controls.Adapter
{
    using Extensions;
    using Models;
    using Models.Nodes;
    using Share;

    public class DesignerViewAdapter :
        IAdapter
    {
        private readonly DesignerView _designerView;

        public DesignerViewAdapter(DesignerView designerView)
        {
            Contract.EnsureArgsNonNull(designerView);
            _designerView = designerView;
        }

        public void AddMap(Map map)
        {
            // no-op
        }

        public void AddFloor(Floor floor)
        {
            // no-op
        }

        public void AddLink(Link link, int floorIndex)
        {
            // no-op
        }

        public void AddNode(NodeBase node, int floorIndex)
        {
            // no-op
        }

        public void Flush()
        {
            _designerView.Flush();
        }

        public void RemoveCatalogue(int floorIndex, int catalogueIndex)
        {
            // no-op
        }

        public void RemoveMap()
        {
            // no-op
        }

        public void RemoveFloor(int floorIndex)
        {
            // no-op
        }

        public void RemoveLink(int floorIndex, int linkIndex)
        {
            // no-op
        }

        public void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {
            // no-op
        }

        public void SelectCatalogue(int floorIndex, int catalogueIndex)
        {
            //_designerView.Unhighlight();
            //_designerView.Targets[floorIndex].Targets[catalogueIndex].Targets.ForEach(target => target.Highlighted = true);
        }

        public void SelectMap(Map map)
        {

        }

        public void SelectFloor(int floorIndex)
        {

        }

        public void SelectLink(int floorIndex, int linkIndex)
        {

        }

        public void SelectNode(int floorIndex, NodeType type, int nodeIndex)
        {

        }
    }
}
