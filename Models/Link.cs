namespace IndoorNavigator.MapEditor.Models
{
    using System.Diagnostics;

    [DebuggerDisplay("Start = {" + nameof(Start) + "}, End = {" + nameof(End) + "}")]
    public class Link
    {
        public int Start { get; }

        public int End { get; }

        public Link(int start, int end)
        {
            Start = start;
            End = end;
        }
    }
}
