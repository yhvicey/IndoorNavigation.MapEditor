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

    [DebuggerDisplay("Count = {" + nameof(EntryNodes) + ".Count + " + nameof(WallNodes) + ".Count}")]
    public class Floor :
        IMapModel
    {
        public List<GuideNode> EntryNodes { get; } = new List<GuideNode>();

        public List<Link> Links { get; } = new List<Link>();

        public List<WallNode> WallNodes { get; } = new List<WallNode>();

        public void AddLink(Link link)
        {
            Debug.Assert(link != null);

            link.OnAdd(this);
            Links.Add(link);
        }

        public void AddLinks(IEnumerable<Link> links)
        {
            Debug.Assert(links != null);

            links.ForEach(AddLink);
        }

        public void AddNode(NodeBase node)
        {
            Debug.Assert(node != null);

            switch (node)
            {
                case GuideNode entryNode:
                {
                    EntryNodes.Add(entryNode);
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
            Debug.Assert(nodes != null);

            nodes.ForEach(AddNode);
        }

        public IEnumerable<GuideNode> FindEntryNodes(string pattern)
        {
            if (string.IsNullOrEmpty(pattern)) return new List<GuideNode>();
            return
                EntryNodes.Where(entryNode => entryNode.Name != null)
                    .Where(entryNode => Regex.IsMatch(entryNode.Name, pattern));
        }

        public double GetDistance(NodeType startType, int startIndex, NodeType endType, int endIndex)
        {
            return GetNode(startType, startIndex).GetDistance(GetNode(endType, endIndex));
        }

        public GuideNode GetEntryNode(int index)
        {
            Debug.Assert(index >= 0);

            return EntryNodes[index];
        }

        public int GetEntryNodeIndex(GuideNode guide)
        {
            Debug.Assert(guide != null);

            return EntryNodes.IndexOf(guide);
        }

        public WallNode GetWallNode(int index)
        {
            Debug.Assert(index >= 0);

            return WallNodes[index];
        }

        public int GetWallNodeIndex(WallNode wall)
        {
            Debug.Assert(wall != null);

            return WallNodes.IndexOf(wall);
        }

        public NodeBase GetNode(NodeType type, int index)
        {
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(index >= 0);

            switch (type)
            {
                case NodeType.GuideNode:
                {
                    return GetEntryNode(index);
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
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));

            switch (type)
            {
                case NodeType.GuideNode:
                {
                    return new List<NodeBase>(EntryNodes);
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
            Debug.Assert(node != null);

            switch (node)
            {
                case GuideNode entryNode:
                {
                    return GetEntryNodeIndex(entryNode);
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

        public IEnumerable<int> GetRelatedLinkIndices(NodeType type, int index)
        {
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(index >= 0);

            for (var i = Links.Count - 1; i >= 0; i--)
            {
                var link = Links[i];
                if (link.Type == type && (link.StartIndex == index ||  link.EndIndex == index))
                    yield return i;
            }
        }

        public Link Link(NodeType type, int startIndex, int endIndex)
        {
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(startIndex >= 0);
            Debug.Assert(endIndex >= 0);

            var target = Links.Find(link => link.Type == type && link.StartIndex == startIndex &&
                                            link.EndIndex == endIndex);
            if (target != null) return target;
            target = new Link(type, startIndex, endIndex);
            AddLink(target);
            return target;
        }

        public void RemoveLink(int index)
        {
            Debug.Assert(index >= 0);

            Links.RemoveAt(index);
        }

        public void RemoveNode(NodeType type, int index)
        {
            Debug.Assert(Enum.IsDefined(typeof(NodeType), type));
            Debug.Assert(index >= 0);

            switch (type)
            {
                case NodeType.GuideNode:
                {
                    EntryNodes.RemoveAt(index);
                    break;
                }
                case NodeType.WallNode:
                {
                    WallNodes.RemoveAt(index);
                    break;
                }
            }
            Links.ForEach(link =>
            {
                if (link.Type == type && link.StartIndex > index) link.StartIndex--;
                if (link.Type == type && link.EndIndex > index) link.EndIndex--;
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

