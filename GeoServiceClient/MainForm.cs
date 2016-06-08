using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeoService;

namespace GeoServiceClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void getZipCodeButton_Click(object sender, EventArgs e)
        {
            using (var service = new GeoSerivceProxy())
            {
                var zipCodes = service.GetZipCodes();

                zipCodeComboBox.Items.Clear();
                zipCodeComboBox.DisplayMember = "Description";
                foreach (var zipCode in zipCodes)
                {
                    zipCodeComboBox.Items.Add(new ComboItem(zipCode));
                }
                if (zipCodeComboBox.Items.Count > 0)
                {
                    zipCodeComboBox.SelectedIndex = 0;
                }
            }
        }

        private void getInfoButton_Click(object sender, EventArgs e)
        {
            var selectedItem = zipCodeComboBox.SelectedItem as ComboItem;
            if(selectedItem == null)
                return;
            using (var service = new GeoSerivceProxy())
            {
                var info = service.GetGeoInfoByZipCode(selectedItem.ZipCode.Code);
                InfoTextBox.Text = info.ToString();
            }
        }
    }

    internal class ComboItem
    {
        public ComboItem(ZipCode zipCode)
        {
            ZipCode = zipCode;
        }

        public ZipCode ZipCode { get; private set; }

        public string Description
        {
            get
            {
                return string.Format("{0} - {1}", ZipCode.Code, ZipCode.State);
            }
        }
    }
}
