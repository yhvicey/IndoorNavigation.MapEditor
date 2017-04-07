namespace IndoorNavigator.MapEditor.Models
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Nodes;
    using Properties;
    using Share;

    [DebuggerDisplay("Count = {" + nameof(EntryNodes) + ".Count + " + nameof(GuideNodes) + ".Count + " + nameof(WallNodes) + ".Count}")]
    public class Floor
    {
        public List<EntryNode> EntryNodes { get; } = new List<EntryNode>();

        public List<GuideNode> GuideNodes { get; } = new List<GuideNode>();

        public List<WallNode> WallNodes { get; } = new List<WallNode>();

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
            foreach (var node in nodes)
            {
                AddNode(node);
            }
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

        public void OnLoadFinished()
        {
            EntryNodes.ForEach(entryNode => entryNode.OnLoadFinished());
            GuideNodes.ForEach(guideNode => guideNode.OnLoadFinished());
            WallNodes.ForEach(wallNode => wallNode.OnLoadFinished());
        }
    }
}

