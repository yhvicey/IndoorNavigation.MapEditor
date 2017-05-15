namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Windows.Forms;
    using Models;
    using Models.Nodes;
    using Properties;

    public partial class AddNodeWizard :
        Wizard<NodeBase>
    {
        private readonly Map _map;

        public int Floor { get; set; }

        public string NodeName { get; set; }

        public int? Next { get; set; }

        public int? Prev { get; set; }

        public NodeType Type { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public AddNodeWizard(Map map)
        {
            Debug.Assert(map != null);

            InitializeComponent();
            _map = map;
            for (var i = 0; i < _map.Floors.Count; i++)
            {
                _floorComboBox.Items.Add($"Floor {i + 1}");
            }
        }

        private void AddNodeWizardLoad(object sender, EventArgs e)
        {
            _nodeTypeComboBox.SelectedIndex = (int)Type;
            _floorComboBox.SelectedIndex = Floor;
            _xTextBox.Text = X.ToString(CultureInfo.CurrentCulture);
            _yTextBox.Text = Y.ToString(CultureInfo.CurrentCulture);
            _nameTextBox.Text = NodeName;
            _prevComboBox.SelectedIndex = (Prev ?? -1) + 1;
            _nextComboBox.SelectedIndex = (Next ?? -1) + 1;
        }

        private void NodeTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_nodeTypeComboBox.SelectedIndex)
            {
                // Entry node, allow all properties
                case 0:
                {
                    _floorComboBox.Enabled = true;
                    _xTextBox.Enabled = true;
                    _yTextBox.Enabled = true;
                    _nameTextBox.Enabled = true;
                    _prevComboBox.Enabled = true;
                    _nextComboBox.Enabled = true;
                    break;
                }
                // Guide node, disable prev and next properties
                case 1:
                {
                    _floorComboBox.Enabled = true;
                    _xTextBox.Enabled = true;
                    _yTextBox.Enabled = true;
                    _nameTextBox.Enabled = true;
                    _prevComboBox.Enabled = false;
                    _nextComboBox.Enabled = false;
                    break;
                }
                // Wall node, disable name property
                case 2:
                {
                    _floorComboBox.Enabled = true;
                    _xTextBox.Enabled = true;
                    _yTextBox.Enabled = true;
                    _nameTextBox.Enabled = false;
                    _prevComboBox.Enabled = false;
                    _nextComboBox.Enabled = false;
                    break;
                }
                // None of them were selected, disable all properties
                default:
                {
                    _floorComboBox.Enabled = false;
                    _xTextBox.Enabled = false;
                    _yTextBox.Enabled = false;
                    _nameTextBox.Enabled = false;
                    _prevComboBox.Enabled = false;
                    _nextComboBox.Enabled = false;
                    break;
                }
            }
        }

        private void FloorComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            var index = _floorComboBox.SelectedIndex;
            _prevComboBox.Items.Clear();
            _prevComboBox.Items.Insert(0, "");
            _prevComboBox.SelectedIndex = 0;
            if (index > 0) _map.Floors[index - 1].GuideNodes.ForEach(entryNode => _prevComboBox.Items.Add(entryNode));
            _nextComboBox.Items.Clear();
            _nextComboBox.Items.Insert(0, "");
            _nextComboBox.SelectedIndex = 0;
            if (index < _map.Floors.Count - 1) _map.Floors[index + 1].GuideNodes.ForEach(entryNode => _nextComboBox.Items.Add(entryNode));
        }

        protected override bool Prepare()
        {
            if (_floorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.PleaseSelectFloorAlert);
                return false;
            }
            if (!int.TryParse(_xTextBox.Text, out var x))
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }
            if (!int.TryParse(_yTextBox.Text, out var y))
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }

            Type = (NodeType)_nodeTypeComboBox.SelectedIndex;
            Floor = _floorComboBox.SelectedIndex;
            X = x;
            Y = y;
            NodeName = _nameTextBox.Text;
            Prev = _prevComboBox.SelectedIndex == 0 ? (int?)null : _prevComboBox.SelectedIndex - 1;
            Next = _nextComboBox.SelectedIndex == 0 ? (int?)null : _nextComboBox.SelectedIndex - 1;

            return true;
        }

        public override NodeBase Make()
        {
            if (!Ready) return null;
            switch (Type)
            {
                case NodeType.GuideNode:
                {
                    return new GuideNode(X, Y, NodeName, Prev, Next);
                }
                case NodeType.WallNode:
                {
                    return new WallNode(X, Y);
                }
                default:
                {
                    return null;
                }
            }
        }
    }
}
