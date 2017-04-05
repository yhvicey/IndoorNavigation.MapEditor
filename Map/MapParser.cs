namespace IndoorNavigator.MapEditor.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Models;
    using Models.Nodes;
    using Share;

    public static class MapParser
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

        private static NodeBase GenerateNode(XmlElement element)
        {
            Contract.EnsureArgsNonNull(element);

            var type = element.GetAttribute(AttrType);
            if (string.IsNullOrEmpty(type))
            {
                throw new Exception("Invalid type");
            }
            if (!double.TryParse(element.GetAttribute(AttrX), out var x)) throw new Exception("Invalid element");
            if (!double.TryParse(element.GetAttribute(AttrY), out var y)) throw new Exception("Invalid element");
            switch (type)
            {
                case TypeEntry:
                {
                    var name = element.GetAttribute(AttrName);
                    var prevEntry = int.TryParse(element.GetAttribute(AttrPrevEntry), out var prev)
                        ? prev
                        : (int?)null;
                    var nextEntry = int.TryParse(element.GetAttribute(AttrNextEntry), out var next)
                        ? next
                        : (int?)null;
                    return new EntryNode(x, y, string.IsNullOrEmpty(name) ? null : name, prevEntry, nextEntry);
                }
                case TypeGuide:
                {
                    var name = element.GetAttribute(AttrName);
                    return new GuideNode(x, y, string.IsNullOrEmpty(name) ? null : name);
                }
                case TypeWall:
                {
                    return new WallNode(x, y);
                }
                default:
                {
                    throw new Exception("Invalid type");
                }
            }
        }

        private static Link GenerateLink(XmlElement element)
        {
            Contract.EnsureArgsNonNull(element);

            if (!int.TryParse(element.GetAttribute(AttrStart), out var start)) throw new Exception("Invalid element");
            if (!int.TryParse(element.GetAttribute(AttrEnd), out var end)) throw new Exception("Invalid element");

            return new Link(start, end);
        }

        public static Map Parse(string fileName)
        {
            Contract.EnsureArgsNonNull(fileName);

            var doc = new XmlDocument();
            doc.Load(fileName);
            var root = doc.DocumentElement;
            Contract.EnsureValuesNonNull(root);
            if (root.Name != ElementMap) throw new Exception("Invalid map file");

            var version = root.GetAttribute(AttrVersion);
            if (version != SupportedVersion) throw new Exception("Unsupported version");
            var name = root.GetAttribute(AttrName);

            var floors = new List<Floor>();
            var floorElements = root.SelectNodes(ElementFloor);
            if (floorElements == null) return new Map(name, floors);
            foreach (var floorElement in floorElements)
            {
                if (!(floorElement is XmlElement floor)) continue;

                var nodeElements = floor.SelectNodes($"{ElementNodes}/{ElementNode}");
                Contract.EnsureValuesNonNull(nodeElements);
                var nodes = nodeElements.OfType<XmlElement>().Select(GenerateNode).Where(newNode => newNode != null).ToList();

                var linkElements = floor.SelectNodes($"{ElementLinks}/{ElementLink}");
                Contract.EnsureValuesNonNull(linkElements);
                var links = linkElements.OfType<XmlElement>().Select(GenerateLink).Where(newLink => newLink != null).ToList();

                floors.Add(new Floor(nodes, links));
            }

            return new Map(name, floors);
        }
    }
}
