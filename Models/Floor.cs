namespace IndoorNavigator.MapEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Nodes;
    using Share;

    [DebuggerDisplay("Count = {" + nameof(EntryNodes) + ".Count + " + nameof(GuideNodes) + ".Count + " + nameof(WallNodes) + ".Count}")]
    public class Floor
    {
        public IList<EntryNode> EntryNodes { get; } = new List<EntryNode>();

        public IList<GuideNode> GuideNodes { get; } = new List<GuideNode>();

        public IList<WallNode> WallNodes { get; } = new List<WallNode>();

        public Floor(IList<NodeBase> nodes, IEnumerable<Link> links)
        {
            Contract.EnsureArgsNonNull(nodes, links);
            foreach (var link in links)
            {
                nodes[link.Start].AddAdjacentNode(nodes[link.End]);
            }
            foreach (var node in nodes)
            {
                if (node == null) continue;
                switch (node)
                {
                    case EntryNode entry:
                    {
                        EntryNodes.Add(entry);
                        break;
                    }
                    case GuideNode guide:
                    {
                        GuideNodes.Add(guide);
                        break;
                    }
                    case WallNode wall:
                    {
                        WallNodes.Add(wall);
                        break;
                    }
                }
            }
        }

        public void ClearTags()
        {
            foreach (var entryNode in EntryNodes)
            {
                entryNode.ClearTag();
            }
            foreach (var guideNode in GuideNodes)
            {
                guideNode.ClearTag();
            }
            foreach (var wallNode in WallNodes)
            {
                wallNode.ClearTag();
            }
        }

        public IList<EntryNode> FindEntryNode(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return null;
            return
                EntryNodes.Where(entryNode => entryNode.Name != null)
                    .Where(entryNode => Regex.IsMatch(entryNode.Name, pattern))
                    .ToList();
        }

        public IList<GuideNode> FindGuideNodes(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return null;
            return
                GuideNodes.Where(guideNode => guideNode.Name != null)
                    .Where(guideNode => Regex.IsMatch(guideNode.Name, pattern))
                    .ToList();
        }
    }
}
