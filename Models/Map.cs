namespace IndoorNavigator.MapEditor.Models
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Nodes;
    using Share;

    [DebuggerDisplay("Count = {" + nameof(Floors) + ".Count}")]
    public class Map
    {
        public List<Floor> Floors { get; } = new List<Floor>();

        public string Name { get; }

        public string Version => "1.0";

        public Map(string name, List<Floor> floors)
        {
            Contract.EnsureArgsNonNull(name, floors);
            Name = name;
            floors.ForEach(AddFloor);
        }

        public void AddFloor(Floor floor)
        {
            Floors.Add(floor);
        }

        public void AddNode(NodeBase node, int floor)
        {
            Floors[floor].AddNode(node);
        }
    }
}
