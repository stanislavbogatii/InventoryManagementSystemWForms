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
    public partial class CreateUserForm: Form
    {
        public CreateUserForm()
        {
            InitializeComponent();
            this.AcceptButton = btnCreateUser;
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            // Placeholder for create logic
        }
    }
}
