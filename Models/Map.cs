namespace IndoorNavigator.MapEditor.Models
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using Share;

    [DebuggerDisplay("Count = {" + nameof(Floors) + ".Count}")]
    public class Map
    {
        public IList<Floor> Floors { get; }

        public string Name { get; }

        public string Version => "1.0";

        public Map(string name, IList<Floor> floors)
        {
            Contract.EnsureArgsNonNull(name, floors);
            Floors = floors;
            Name = name;
        }
    }
}
