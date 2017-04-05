namespace IndoorNavigator.MapEditor.Map
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using Models;
    using Models.Nodes;
    using Share;

    public static class MapSaver
    {
        private const string SupportedVersion = "1.0";
        private const string AttrVersion = "Version";
        private const string AttrType = "Type";
        private const string AttrX = "X";
        private const string AttrY = "Y";
        private const string AttrName = "Name";
        private const string AttrPrevEntry = "PrevEntry";
        private const string AttrNextEntry = "NextEntry";
        private const string AttrStart = "Start";
        private const string AttrEnd = "End";
        private const string ElementMap = "Map";
        private const string ElementNode = "Node";
        private const string ElementNodes = "Nodes";
        private const string ElementLink = "Link";
        private const string ElementLinks = "Links";
        private const string ElementFloor = "Floor";
        private const string TypeEntry = "Entry";
        private const string TypeGuide = "Guide";
        private const string TypeWall = "Wall";

        private static XmlElement GenerateNode(NodeBase node, XmlDocument doc)
        {
            Contract.EnsureArgsNonNull(node, doc);

            var nodeElement = doc.CreateElement(ElementNode);
            nodeElement.SetAttribute(AttrX, node.X.ToString("F2"));
            nodeElement.SetAttribute(AttrY, node.Y.ToString("F2"));
            switch (node)
            {
                case EntryNode entry:
                {
                    nodeElement.SetAttribute(AttrType, TypeEntry);
                    if (entry.PrevEntry != null) nodeElement.SetAttribute(AttrPrevEntry, entry.PrevEntry.ToString());
                    if (entry.NextEntry != null) nodeElement.SetAttribute(AttrNextEntry, entry.NextEntry.ToString());
                    if (entry.Name != null) nodeElement.SetAttribute(AttrName, entry.Name);
                    break;
                }
                case GuideNode guide:
                {
                    nodeElement.SetAttribute(AttrType, TypeGuide);
                    if (guide.Name != null) nodeElement.SetAttribute(AttrName, guide.Name);
                    break;
                }
                case WallNode wall:
                {
                    nodeElement.SetAttribute(AttrType, TypeWall);
                    break;
                }
                default:
                {
                    throw new Exception("Invalid type");
                }
            }
            return nodeElement;
        }

        private static XmlElement GenerateLink(Link link, XmlDocument doc)
        {
            var linkElement = doc.CreateElement(ElementLink);
            linkElement.SetAttribute(AttrStart, link.Start.ToString());
            linkElement.SetAttribute(AttrEnd, link.End.ToString());
            return linkElement;
        }

        private static XmlElement GenerateNodes(IEnumerable<NodeBase> nodes, XmlDocument doc)
        {
            var nodesElement = doc.CreateElement(ElementNodes);
            foreach (var node in nodes)
            {
                nodesElement.AppendChild(GenerateNode(node, doc));
            }
            return nodesElement;
        }

        private static XmlElement GenerateLinks(IList<NodeBase> nodes, XmlDocument doc)
        {
            Contract.EnsureArgsNonNull(nodes);

            var links = new List<Link>();
            var start = 0;
            foreach (var node in nodes)
            {
                links.AddRange(node.AdjacentNodes.Select(nodes.IndexOf).Select(end => new Link(start, end)));
                start++;
            }

            var linksElement = doc.CreateElement(ElementLinks);
            foreach (var link in links)
            {
                linksElement.AppendChild(GenerateLink(link, doc));
            }

            return linksElement;
        }

        public static void Save(string fileName, Map map)
        {
            Contract.EnsureArgsNonNull(fileName, map);

            var doc = new XmlDocument();
            var decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(decl);
            var root = doc.CreateElement(ElementMap);
            root.SetAttribute(AttrVersion, SupportedVersion);
            root.SetAttribute(AttrName, map.Name);
            doc.AppendChild(root);

            foreach (var floor in map.Floors)
            {
                var floorElement = doc.CreateElement(ElementFloor);

                var nodes = new List<NodeBase>();
                nodes.AddRange(floor.EntryNodes);
                nodes.AddRange(floor.GuideNodes);
                nodes.AddRange(floor.WallNodes);

                var nodesElement = GenerateNodes(nodes, doc);
                var linksElement = GenerateLinks(nodes, doc);

                floorElement.AppendChild(nodesElement);
                floorElement.AppendChild(linksElement);

                root.AppendChild(floorElement);
            }

            doc.Save(new FileStream(fileName, FileMode.OpenOrCreate));
        }
    }
}
