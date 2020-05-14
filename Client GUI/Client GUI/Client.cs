using System;
using System.Windows.Forms;

namespace Client_GUI
{
    public partial class Client : Form
    {
        private string token;
        public Client()
        {
            InitializeComponent();
        }

        public void SetToken(string token)
        {
            this.token = token;
        }


        private void Load_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void New_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
        
    }
}