namespace IndoorNavigator.MapEditor.Map
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using Models;
    using Models.Nodes;
    using Properties;
    using Share;

    public static class MapParser
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

        private static void GenerateLink(NodeBase parent, XmlElement element)
        {
            Contract.EnsureArgsNonNull(parent, element);

            if (!Enum.TryParse(element.GetAttribute(AttrType), out NodeType type)) throw new Exception(Resources.UnexpectedTypeError);
            if (!int.TryParse(element.GetAttribute(AttrIndex), out var index)) throw new Exception(Resources.InvalidElementError);

            parent.Link(type, index);
        }

        private static NodeBase GenerateNode(Floor parent, XmlElement element)
        {
            Contract.EnsureArgsNonNull(parent, element);

            if (!Enum.TryParse(element.Name, out NodeType type)) throw new Exception(Resources.UnexpectedTypeError);
            if (!double.TryParse(element.GetAttribute(AttrX), out var x)) throw new Exception(Resources.InvalidElementError);
            if (!double.TryParse(element.GetAttribute(AttrY), out var y)) throw new Exception(Resources.InvalidElementError);

            NodeBase node;
            switch (type)
            {
                case NodeType.EntryNode:
                {
                    var name = element.GetAttribute(AttrName);
                    var prev = int.TryParse(element.GetAttribute(AttrPrev), out var prevEntry)
                        ? prevEntry
                        : (int?)null;
                    var next = int.TryParse(element.GetAttribute(AttrNext), out var nextEntry)
                        ? nextEntry
                        : (int?)null;
                    node = new EntryNode(parent, x, y, string.IsNullOrEmpty(name) ? null : name, prev, next);
                    break;
                }
                case NodeType.GuideNode:
                {
                    var name = element.GetAttribute(AttrName);
                    node = new GuideNode(parent, x, y, string.IsNullOrEmpty(name) ? null : name);
                    break;
                }
                case NodeType.WallNode:
                {
                    node = new WallNode(parent, x, y);
                    break;
                }
                default:
                {
                    throw new Exception(Resources.InvalidElementError);
                }
            }
            var linkElements = element.SelectNodes(ElementLink)?.OfType<XmlElement>().ToList();
            if (linkElements == null) return node;
            linkElements.ForEach(linkElement => GenerateLink(node, linkElement));
            return node;
        }

        public static Map Parse(string fileName)
        {
            Contract.EnsureArgsNonNull(fileName);

            var doc = new XmlDocument();
            doc.Load(fileName);
            var root = doc.DocumentElement;
            Contract.EnsureValuesNonNull(root);
            if (root.Name != ElementMap) throw new Exception(Resources.InvalidMapFileError);

            var version = root.GetAttribute(AttrVersion);
            if (version != SupportedVersion) throw new Exception(Resources.UnsupportedVersionError);
            var name = root.GetAttribute(AttrName);

            var floors = new List<Floor>();
            var floorElements = root.SelectNodes(ElementFloor)?.OfType<XmlElement>();
            if (floorElements == null) return new Map(name, floors);
            foreach (var floorElement in floorElements)
            {
                var floor = new Floor();

                var entryNodeElements = floorElement.SelectNodes(NodeType.EntryNode.ToString())?.OfType<XmlElement>();
                Contract.EnsureValuesNonNull(entryNodeElements);
                floor.AddNodes(entryNodeElements.Select(entryNodeElement => GenerateNode(floor, entryNodeElement)));

                var guideNodeElements = floorElement.SelectNodes(NodeType.GuideNode.ToString())?.OfType<XmlElement>();
                Contract.EnsureValuesNonNull(guideNodeElements);
                floor.AddNodes(guideNodeElements.Select(entryNodeElement => GenerateNode(floor, entryNodeElement)));

                var wallNodeElements = floorElement.SelectNodes(NodeType.WallNode.ToString())?.OfType<XmlElement>();
                Contract.EnsureValuesNonNull(wallNodeElements);
                floor.AddNodes(wallNodeElements.Select(entryNodeElement => GenerateNode(floor, entryNodeElement)));

                floors.Add(floor);
            }

            return new Map(name, floors);
        }
    }
}
