using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YPMarsLib;

namespace YPMars
{
    public partial class MainForm : Form
    {
        private UserPgRepository loader_;
        private User currentUser_;

        public MainForm(UserPgRepository loader, User currentUser)
        {
            InitializeComponent();
            loader_ = loader;
            currentUser_ = currentUser;

            if (currentUser_.Role != User.UserRole.SuperUser)
            {
                RegistrButton.Visible = false; 
            }
        }

        private void RegistrButton_Click(object sender, EventArgs e)
        {
            RegistrForm registrForm = new RegistrForm(loader_, currentUser_);
            registrForm.Show();
        }       
    }
}
