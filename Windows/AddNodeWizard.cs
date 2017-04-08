namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;
    using Models;
    using Models.Nodes;
    using Properties;

    public partial class AddNodeWizard : Form
    {
        private readonly Map _map;

        public int Floor { get; set; }

        public string NodeName { get; set; }

        public int? Next { get; set; }

        public int? Prev { get; set; }

        public bool Ready { get; private set; }

        public NodeType Type { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public AddNodeWizard(Map map)
        {
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
            if (index > 0) _map.Floors[index - 1].EntryNodes.ForEach(entryNode => _prevComboBox.Items.Add(entryNode));
            _nextComboBox.Items.Clear();
            _nextComboBox.Items.Insert(0, "");
            _nextComboBox.SelectedIndex = 0;
            if (index < _map.Floors.Count - 1) _map.Floors[index + 1].EntryNodes.ForEach(entryNode => _nextComboBox.Items.Add(entryNode));
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Ready = false;
            Close();
        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {
            if (_floorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(Resources.PleaseSelectFloorAlert);
                return;
            }
            if (!double.TryParse(_xTextBox.Text, out var x))
            {
                MessageBox.Show(Resources.InvalidValueError);
                return;
            }
            if (!double.TryParse(_yTextBox.Text, out var y))
            {
                MessageBox.Show(Resources.InvalidValueError);
                return;
            }

            Type = (NodeType)_nodeTypeComboBox.SelectedIndex;
            Floor = _floorComboBox.SelectedIndex;
            X = x;
            Y = y;
            NodeName = _nameTextBox.Text;
            Prev = _prevComboBox.SelectedIndex == 0 ? (int?)null : _prevComboBox.SelectedIndex - 1;
            Next = _nextComboBox.SelectedIndex == 0 ? (int?)null : _nextComboBox.SelectedIndex - 1;

            DialogResult = DialogResult.Yes;
            Ready = true;
            Close();
        }

        public NodeBase MakeNode()
        {
            if (!Ready) return null;
            switch (Type)
            {
                case NodeType.EntryNode:
                {
                    return new EntryNode(X, Y, NodeName, Prev, Next);
                }
                case NodeType.GuideNode:
                {
                    return new GuideNode(X, Y, NodeName);
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
