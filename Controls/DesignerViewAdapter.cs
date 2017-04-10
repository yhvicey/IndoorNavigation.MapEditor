namespace IndoorNavigator.MapEditor.Controls
{
    using System.Collections.Generic;
    using Models;
    using Models.Nodes;
    using Share;

    public class DesignerViewAdapter
    {
        private readonly DesignerView _designerView;

        public DesignerViewAdapter(DesignerView designerView)
        {
            Contract.EnsureArgsNonNull(designerView);
            _designerView = designerView;
        }

        public void AddMap(Map map)
        {

        }

        public void AddFloor(Floor floor)
        {

            Flush();
        }

        public void AddLink(Link link, int floorIndex)
        {

            Flush();
        }

        public void AddNode(NodeBase node, int floorIndex)
        {

            Flush();
        }

        public void Flush()
        {

        }

        public void RemoveCatalogue(int floorIndex, int catalogueIndex)
        {

        }

        public void RemoveMap()
        {

        }

        public void RemoveFloor(int floorIndex)
        {

            Flush();
        }

        public void RemoveLink(int floorIndex, int linkIndex)
        {

            Flush();
        }

        public void RemoveNode(int floorIndex, NodeType type, int nodeIndex)
        {

            Flush();
        }

        public void SelectCatalogue(int floorIndex, int catalogueIndex)
        {

        }

        public void SelectMap()
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
