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
    using Extensions;

    public static class MapParser
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

        private static Link GenerateLink(XmlElement element)
        {
            Contract.EnsureArgsNonNull(element);

            if (!Enum.TryParse(element.GetAttribute(AttrStartType), out NodeType startType)) throw new Exception(Resources.UnexpectedTypeError);
            if (!int.TryParse(element.GetAttribute(AttrStartIndex), out var startIndex)) throw new Exception(Resources.InvalidElementError);
            if (!Enum.TryParse(element.GetAttribute(AttrEndType), out NodeType endType)) throw new Exception(Resources.UnexpectedTypeError);
            if (!int.TryParse(element.GetAttribute(AttrEndIndex), out var endIndex)) throw new Exception(Resources.InvalidElementError);

            return new Link(startType, startIndex, endType, endIndex);
        }

        private static NodeBase GenerateNode(XmlElement element)
        {
            Contract.EnsureArgsNonNull(element);

            if (!Enum.TryParse(element.Name, out NodeType type)) throw new Exception(Resources.UnexpectedTypeError);
            if (!double.TryParse(element.GetAttribute(AttrX), out var x)) throw new Exception(Resources.InvalidElementError);
            if (!double.TryParse(element.GetAttribute(AttrY), out var y)) throw new Exception(Resources.InvalidElementError);

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
                    return new EntryNode(x, y, string.IsNullOrEmpty(name) ? null : name, prev, next);
                }
                case NodeType.GuideNode:
                {
                    var name = element.GetAttribute(AttrName);
                    return new GuideNode(x, y, string.IsNullOrEmpty(name) ? null : name);
                }
                case NodeType.WallNode:
                {
                    return new WallNode(x, y);
                }
                default:
                {
                    throw new Exception(Resources.InvalidElementError);
                }
            }
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
                floor.AddNodes(entryNodeElements.Select(GenerateNode));

                var guideNodeElements = floorElement.SelectNodes(NodeType.GuideNode.ToString())?.OfType<XmlElement>();
                Contract.EnsureValuesNonNull(guideNodeElements);
                floor.AddNodes(guideNodeElements.Select(GenerateNode));

                var wallNodeElements = floorElement.SelectNodes(NodeType.WallNode.ToString())?.OfType<XmlElement>();
                Contract.EnsureValuesNonNull(wallNodeElements);
                floor.AddNodes(wallNodeElements.Select(GenerateNode));

                var linkElements = floorElement.SelectNodes(ElementLink)?.OfType<XmlElement>();
                Contract.EnsureValuesNonNull(linkElements);
                floor.AddLinks(linkElements.Select(GenerateLink));

                floors.Add(floor);
            }

            return new Map(name, floors);
        }
    }
}
