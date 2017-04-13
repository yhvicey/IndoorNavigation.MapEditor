namespace IndoorNavigator.MapEditor.Models
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Nodes;

    [DebuggerDisplay("Count = {" + nameof(Floors) + ".Count}")]
    public class Map :
        IMapModel
    {
        public List<Floor> Floors { get; } = new List<Floor>();

        public string Name { get; set; }

        public string Version => "1.0";

        public Map(string name, List<Floor> floors)
        {
            Debug.Assert(floors != null);

            Name = name;
            floors.ForEach(AddFloor);
        }

        public void AddFloor(Floor floor)
        {
            Debug.Assert(floor != null);

            Floors.Add(floor);
        }

        public void AddNode(NodeBase node, int floorIndex)
        {
            Debug.Assert(node != null);

            Floors[floorIndex].AddNode(node);
        }

        public void RemoveFloor(int floorIndex)
        {
            Debug.Assert(floorIndex >= 0);

            if (floorIndex > 0) Floors[floorIndex - 1].ResetEntryNodes(next: true);
            if (floorIndex < Floors.Count - 1) Floors[floorIndex + 1].ResetEntryNodes(true);
            Floors.RemoveAt(floorIndex);
        }

        public override string ToString()
        {
            return Name ?? "";
        }
    }
}
