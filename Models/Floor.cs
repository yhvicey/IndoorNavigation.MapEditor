namespace IndoorNavigator.MapEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Extensions;
    using Nodes;
    using Properties;
    using Share;

    [DebuggerDisplay("Count = {" + nameof(EntryNodes) + ".Count + " + nameof(GuideNodes) + ".Count + " + nameof(WallNodes) + ".Count}")]
    public class Floor :
        IMapModel
    {
        public List<EntryNode> EntryNodes { get; } = new List<EntryNode>();

        public List<GuideNode> GuideNodes { get; } = new List<GuideNode>();

        public List<Link> Links { get; } = new List<Link>();

        public List<WallNode> WallNodes { get; } = new List<WallNode>();

        public void AddLink(Link link)
        {
            Contract.EnsureArgsNonNull(link);
            link.OnAdd(this);
            Links.Add(link);
        }

        public void AddLinks(IEnumerable<Link> links)
        {
            Contract.EnsureArgsNonNull(links);
            links.ForEach(AddLink);
        }

        public void AddNode(NodeBase node)
        {
            Contract.EnsureArgsNonNull(node);
            switch (node)
            {
                case EntryNode entryNode:
                {
                    EntryNodes.Add(entryNode);
                    return;
                }
                case GuideNode guideNode:
                {
                    GuideNodes.Add(guideNode);
                    return;
                }
                case WallNode wallNode:
                {
                    WallNodes.Add(wallNode);
                    return;
                }
                default:
                {
                    throw new ArgumentException(Resources.UnexpectedTypeError, nameof(node));
                }
            }
        }

        public void AddNodes(IEnumerable<NodeBase> nodes)
        {
            Contract.EnsureArgsNonNull(nodes);
            nodes.ForEach(AddNode);
        }

        public IEnumerable<EntryNode> FindEntryNodes(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return new List<EntryNode>();
            return
                EntryNodes.Where(entryNode => entryNode.Name != null)
                    .Where(entryNode => Regex.IsMatch(entryNode.Name, pattern));
        }

        public IEnumerable<GuideNode> FindGuideNodes(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return new List<GuideNode>();
            return
                GuideNodes.Where(guideNode => guideNode.Name != null)
                    .Where(guideNode => Regex.IsMatch(guideNode.Name, pattern));
        }

        public IEnumerable<NodeBase> FindNodes(string pattern)
        {
            return FindEntryNodes(pattern).Union<NodeBase>(FindGuideNodes(pattern));
        }

        public double GetDistance(NodeType startType, int startIndex, NodeType endType, int endIndex)
        {
            return GetNode(startType, startIndex).GetDistance(GetNode(endType, endIndex));
        }

        public EntryNode GetEntryNode(int index)
        {
            return EntryNodes[index];
        }

        public int GetEntryNodeIndex(EntryNode entry)
        {
            return EntryNodes.IndexOf(entry);
        }

        public GuideNode GetGuideNode(int index)
        {
            return GuideNodes[index];
        }

        public int GetGuideNodeIndex(GuideNode guide)
        {
            return GuideNodes.IndexOf(guide);
        }

        public WallNode GetWallNode(int index)
        {
            return WallNodes[index];
        }

        public int GetWallNodeIndex(WallNode wall)
        {
            return WallNodes.IndexOf(wall);
        }

        public NodeBase GetNode(NodeType type, int index)
        {
            switch (type)
            {
                case NodeType.EntryNode:
                {
                    return GetEntryNode(index);
                }
                case NodeType.GuideNode:
                {
                    return GetGuideNode(index);
                }
                case NodeType.WallNode:
                {
                    return GetWallNode(index);
                }
                default:
                {
                    throw new ArgumentException(Resources.UnexpectedTypeError, nameof(type));
                }
            }
        }

        public List<NodeBase> GetNodes(NodeType type)
        {
            switch (type)
            {
                case NodeType.EntryNode:
                {
                    return new List<NodeBase>(EntryNodes);
                }
                case NodeType.GuideNode:
                {
                    return new List<NodeBase>(GuideNodes);
                }
                case NodeType.WallNode:
                {
                    return new List<NodeBase>(WallNodes);
                }
                default:
                {
                    return null;
                }
            }
        }

        public int GetNodeIndex(NodeBase node)
        {
            switch (node)
            {
                case EntryNode entryNode:
                {
                    return GetEntryNodeIndex(entryNode);
                }
                case GuideNode guideNode:
                {
                    return GetGuideNodeIndex(guideNode);
                }
                case WallNode wallNode:
                {
                    return GetWallNodeIndex(wallNode);
                }
                default:
                {
                    return -1;
                }
            }
        }

        public IEnumerable<int> GetLinkIndices(NodeType type, int index)
        {
            for (var i = 0; i < Links.Count; i++)
            {
                var link = Links[i];
                if (link.StartType == type && link.StartIndex == index || link.EndType == type && link.EndIndex == index)
                    yield return i;
            }
        }

        public Link Link(NodeType startType, int startIndex, NodeType endType, int endIndex)
        {
            var target = Links.Find(link =>
                        link.StartType == startType && link.StartIndex == startIndex && link.EndType == endType &&
                        link.EndIndex == endIndex);
            if (target != null) return target;
            target = new Link(startType, startIndex, endType, endIndex);
            AddLink(target);
            return target;
        }

        public void RemoveLink(int index)
        {
            Links.RemoveAt(index);
        }

        public void RemoveNode(NodeType type, int index)
        {
            switch (type)
            {
                case NodeType.EntryNode:
                {
                    EntryNodes.RemoveAt(index);
                    break;
                }
                case NodeType.GuideNode:
                {
                    GuideNodes.RemoveAt(index);
                    break;
                }
                case NodeType.WallNode:
                {
                    WallNodes.RemoveAt(index);
                    break;
                }
            }
            GetLinkIndices(type, index).ForEach(RemoveLink);
            Links.ForEach(link =>
            {
                if (link.StartType == type && link.StartIndex > index) link.StartIndex--;
                if (link.EndType == type && link.EndIndex > index) link.EndIndex--;
            });

        }

        public void ResetEntryNodes(bool prev = false, bool next = false)
        {
            EntryNodes.ForEach(entryNode =>
            {
                if (prev) entryNode.Prev = null;
                if (next) entryNode.Next = null;
            });
        }
    }
}

