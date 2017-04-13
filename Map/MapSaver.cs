namespace IndoorNavigator.MapEditor.Map
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Xml;
    using Models;
    using Models.Nodes;
    using Properties;

    public static class MapSaver
    {
        private const string AttrEndIndex = "EndIndex";
        private const string AttrEndType = "EndType";
        private const string AttrName = "Name";
        private const string AttrNext = "Next";
        private const string AttrPrev = "Prev";
        private const string AttrStartIndex = "StartIndex";
        private const string AttrStartType = "StartType";
        private const string AttrVersion = "Version";
        private const string AttrX = "X";
        private const string AttrY = "Y";
        private const string ElementMap = "Map";
        private const string ElementFloor = "Floor";
        private const string ElementLink = "Link";
        private const string SupportedVersion = "1.0";

        private static XmlElement GenerateLink(Link link, XmlDocument doc)
        {
            Debug.Assert(link != null);
            Debug.Assert(doc != null);

            var linkElement = doc.CreateElement(ElementLink);
            linkElement.SetAttribute(AttrStartType, link.StartType.ToString());
            linkElement.SetAttribute(AttrStartIndex, link.StartIndex.ToString());
            linkElement.SetAttribute(AttrEndType, link.EndType.ToString());
            linkElement.SetAttribute(AttrEndIndex, link.EndIndex.ToString());
            return linkElement;
        }

        private static XmlElement GenerateNode(NodeBase node, XmlDocument doc)
        {
            Debug.Assert(node != null);
            Debug.Assert(doc != null);

            var nodeElement = doc.CreateElement(node.Type.ToString());
            nodeElement.SetAttribute(AttrX, node.X.ToString("F2"));
            nodeElement.SetAttribute(AttrY, node.Y.ToString("F2"));
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

        public static void Save(string filename, Map map)
        {
            Debug.Assert(filename != null);
            Debug.Assert(map != null);

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
                floor.Links.ForEach(link => floorElement.AppendChild(GenerateLink(link, doc)));

                root.AppendChild(floorElement);
            }

            using (var fileStream = new FileStream(filename, FileMode.Create))
            {
                doc.Save(fileStream);
            }
        }
    }
}
