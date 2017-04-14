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

        public NodeType EndType { get; set; }

        public int EndIndex { get; set; } = -1;

        public int Floor { get; set; }

        public NodeType StartType { get; set; }

        public int StartIndex { get; set; } = -1;

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
            _startTypeComboBox.SelectedIndex = (int)StartType;
            _startNodeComboBox.SelectedIndex = StartIndex;
            _endTypeComboBox.SelectedIndex = (int)EndType;
            _endNodeComboBox.SelectedIndex = EndIndex;
        }

        private void FloorComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            StartTypeComboBoxSelectedIndexChanged(sender, e);
            EndTypeComboBoxSelectedIndexChanged(sender, e);
        }

        private void StartTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _startNodeComboBox.Items.Clear();
            var floor = _map.Floors[_floorComboBox.SelectedIndex];
            var startTypeIndex = _startTypeComboBox.SelectedIndex;
            if (_startTypeComboBox.SelectedIndex != -1)
                floor.GetNodes((NodeType)startTypeIndex).ForEach(node => _startNodeComboBox.Items.Add(node));
        }

        private void EndTypeComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            _endNodeComboBox.Items.Clear();
            var floor = _map.Floors[_floorComboBox.SelectedIndex];
            var endTypeIndex = _endTypeComboBox.SelectedIndex;
            if (endTypeIndex != -1)
                floor.GetNodes((NodeType)endTypeIndex).ForEach(node => _endNodeComboBox.Items.Add(node));
        }

        protected override bool Prepare()
        {
            if (_floorComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.PleaseSelectFloorAlert);
                return false;
            }
            if (_startTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }
            if (_startNodeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show(this, Resources.InvalidValueError);
                return false;
            }
            if (_endTypeComboBox.SelectedIndex == -1)
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
            StartType = (NodeType)_startTypeComboBox.SelectedIndex;
            StartIndex = _startNodeComboBox.SelectedIndex;
            EndType = (NodeType)_endTypeComboBox.SelectedIndex;
            EndIndex = _endNodeComboBox.SelectedIndex;

            return true;
        }

        public override Link Make()
        {
            return !Ready ? null : new Link(StartType, StartIndex, EndType, EndIndex);
        }
    }
}
