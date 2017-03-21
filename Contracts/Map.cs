namespace IndoorNavigator.MapEditor.Contracts
{
    using System.Collections.Generic;
    using System.Diagnostics;

    [DebuggerDisplay("Version = {" + nameof(Version) + "}, Count = {" + nameof(Floors) + ".Count}")]
    public class Map
    {
        public string Version => "1.0";

        public IList<Floor> Floors { get; }

        public Map(IList<Floor> floors)
        {
            Floors = floors;
        }
    }
}
