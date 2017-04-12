namespace IndoorNavigator.MapEditor.Controls.Adapter
{
    using Models;
    using Models.Nodes;

    public interface IAdapter
    {
        void AddMap(Map map);

        void AddFloor(Floor floor);

        void AddLink(Link link, int floorIndex);

        void AddNode(NodeBase node, int floorIndex);

        void Flush();

        void RemoveCatalogue(int floorIndex, int catalogueIndex);

        void RemoveMap();

        void RemoveFloor(int floorIndex);

        void RemoveLink(int floorIndex, int linkIndex);

        void RemoveNode(int floorIndex, NodeType type, int nodeIndex);

        void SelectCatalogue(int floorIndex, int catalogueIndex);

        void SelectMap(Map map);

        void SelectFloor(int floorIndex);

        void SelectLink(int floorIndex, int linkIndex);

        void SelectNode(int floorIndex, NodeType type, int nodeIndex);
    }
}
