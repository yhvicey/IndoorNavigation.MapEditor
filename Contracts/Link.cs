namespace IndoorNavigator.MapEditor.Contracts
{
    using System.Diagnostics;

    [DebuggerDisplay("Start = {" + nameof(Start) + "}, End = {" + nameof(End) + "}")]
    public class Link
    {
        public int Start { get; }

        public int End { get; }

        public int? EndFloor { get; }

        public Link(int start, int end, int? endFloor = null)
        {
            Start = start;
            End = end;
            EndFloor = endFloor;
        }
    }
}
