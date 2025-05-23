using Domain.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation.Forms
{
    public partial class HomeForm : Form
    {

        private User _user;
        public HomeForm(User user)
        {
            InitializeComponent();
            _user = user;
        }

        private void homeForm_Load(object sender, EventArgs e)
        {
            if (_user != null)
            {
                lblWelcome.Text = $"Welcome, {_user.Username}!";
            }
            else
            {
                lblWelcome.Text = "Welcome!";
            }
        }
    }

}
