namespace IndoorNavigator.MapEditor.Controls.Adapter
{
    using Models;
    using Models.Nodes;

    public interface IAdapter
    {
        void OnAddMap(Map map);

        void OnAddFloor(Floor floor);

        void OnAddLink(Link link, int floorIndex);

        void OnAddNode(NodeBase node, int floorIndex);

        void OnFlush();

        void OnRemoveCatalogue(int floorIndex, int catalogueIndex);

        void OnRemoveMap();

        void OnRemoveFloor(int floorIndex);

        void OnRemoveLink(int floorIndex, int linkIndex);

        void OnRemoveNode(int floorIndex, NodeType type, int nodeIndex);

        void OnSelectCatalogue(int floorIndex, int catalogueIndex);

        void OnSelectMap(Map map);

        void OnSelectFloor(int floorIndex);

        void OnSelectLink(int floorIndex, int linkIndex);

        void OnSelectNode(int floorIndex, NodeType type, int nodeIndex);
    }
}
