namespace IndoorNavigator.MapEditor.Windows
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Models;
    using Models.Nodes;
    using Properties;

    public partial class AddLinkWizard :
        Wizard<Link>
    {
        private readonly Map _map;
        
        public int EndIndex { get; set; } = -1;

        public int Floor { get; set; }

        public int StartIndex { get; set; } = -1;

        public NodeType Type { get; set; }

        public AddLinkWizard(Map map)
        {
            Debug.Assert(map != null);

            InitializeComponent();
            _map = map;
            for (var i = 0; i < _map.Floors.Count; i++)
            {
                _floorComboBox.Items.Add($"Floor {i + 1}");
            }
        }

        private void AddLinkWizardLoad(object sender, EventArgs e)
        {
            _floorComboBox.SelectedIndex = Floor;
            _typeComboBox.SelectedIndex = (int)Type;
            _startNodeComboBox.SelectedIndex = StartIndex;
            _endNodeComboBox.SelectedIndex = EndIndex;
        }

        private void FloorComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            TypeComboBoxSelectedIndexChanged(sender, e);
        }

        private void TypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _startNodeComboBox.Items.Clear();
            var floor = _map.Floors[_floorComboBox.SelectedIndex];
            var startTypeIndex = _typeComboBox.SelectedIndex;
            if (_typeComboBox.SelectedIndex != -1)
                floor.GetNodes((NodeType)startTypeIndex).ForEach(node => _startNodeComboBox.Items.Add(node));
        }

        protected override bool Prepare()
        {
            if (_floorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.PleaseSelectFloorAlert);
                return false;
            }
            if (_typeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }
            if (_startNodeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }
            if (_endNodeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }

            Floor = _floorComboBox.SelectedIndex;
            Type = (NodeType)_typeComboBox.SelectedIndex;
            StartIndex = _startNodeComboBox.SelectedIndex;
            EndIndex = _endNodeComboBox.SelectedIndex;

            return true;
        }

        public override Link Make()
        {
            return !Ready ? null : new Link(Type, StartIndex, EndIndex);
        }
    }
}
