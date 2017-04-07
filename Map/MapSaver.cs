namespace IndoorNavigator.MapEditor.Map
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using Models;
    using Models.Nodes;
    using Properties;
    using Share;

    public static class MapSaver
    {
        private const string AttrIndex = "Index";
        private const string AttrName = "Name";
        private const string AttrNext = "Next";
        private const string AttrPrev = "Prev";
        private const string AttrType = "Type";
        private const string AttrVersion = "Version";
        private const string AttrX = "X";
        private const string AttrY = "Y";
        private const string ElementMap = "Map";
        private const string ElementFloor = "Floor";
        private const string ElementLink = "Link";
        private const string SupportedVersion = "1.0";

        private static XmlElement GenerateLink(Link link, XmlDocument doc)
        {
            Contract.EnsureArgsNonNull(link, doc);
            var linkElement = doc.CreateElement(ElementLink);
            linkElement.SetAttribute(AttrType, link.Type.ToString());
            linkElement.SetAttribute(AttrIndex, link.Index.ToString());
            return linkElement;
        }

        private static XmlElement GenerateNode(NodeBase node, XmlDocument doc)
        {
            Contract.EnsureArgsNonNull(node, doc);

            var nodeElement = doc.CreateElement(node.Type.ToString());
            nodeElement.SetAttribute(AttrX, node.X.ToString("F2"));
            nodeElement.SetAttribute(AttrY, node.Y.ToString("F2"));
            node.Links.ForEach(link => nodeElement.AppendChild(GenerateLink(link, doc)));
            switch (node)
            {
                case EntryNode entryNode:
                {
                    if (entryNode.Name != null) nodeElement.SetAttribute(AttrName, entryNode.Name);
                    if (entryNode.Prev != null) nodeElement.SetAttribute(AttrPrev, entryNode.Prev.ToString());
                    if (entryNode.Next != null) nodeElement.SetAttribute(AttrNext, entryNode.Next.ToString());
                    break;
                }
                case GuideNode guideNode:
                {
                    if (guideNode.Name != null) nodeElement.SetAttribute(AttrName, guideNode.Name);
                    break;
                }
                case WallNode wallNode:
                {
                    break;
                }
                default:
                {
                    throw new ArgumentException(Resources.UnexpectedTypeError, nameof(node));
                }
            }
            return nodeElement;
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

                floor.EntryNodes.ForEach(entryNode => floorElement.AppendChild(GenerateNode(entryNode, doc)));
                floor.GuideNodes.ForEach(guideNode => floorElement.AppendChild(GenerateNode(guideNode, doc)));
                floor.WallNodes.ForEach(wallNode => floorElement.AppendChild(GenerateNode(wallNode, doc)));

                root.AppendChild(floorElement);
            }

            doc.Save(new FileStream(fileName, FileMode.OpenOrCreate));
        }
    }
}
