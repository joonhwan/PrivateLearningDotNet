using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PunService.AJAX.WinFormClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void cookieButton_Click(object sender, EventArgs e)
        {
            try
            {
                var id = cookieTextBox.Text;
                var service = new PunClient();
                var cookie = service.GetCookie(id);
                cookieLabel.Text = cookie;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception is caught! : {0}"), ex.Message);
            }
        }

        private void complexCookieButton_Click(object sender, EventArgs e)
        {
            try
            {
                var degree = float.Parse(degreeTextBox.Text);
                var isActive = isActiveCheckBox.Checked;
                var name = nameTextBox.Text;
                var age = int.Parse(ageTextBox.Text);
                
                var service = new PunClient();
                var parameter = new PunComplexCookieParameter()
                {
                    Degree = degree,
                    IsActive = isActive,
                    Age = age,
                    Name = name,
                };
                var cookie = service.GetCookieComplex(parameter);
                complexCookieLabel.Text = cookie.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Exception is caught! : {0}"), ex.Message);
            }
        }
    }
}
