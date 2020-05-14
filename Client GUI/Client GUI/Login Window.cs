using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            //Sends GET request to the server in order to validate the login details
            {
                using (var client =  new TcpClient( hostname: "127.0.0.1", port: 8000))
                {
                    using (var stream = client.GetStream())
                    using(var writer = new StreamWriter(stream))
                    using (var reader = new StreamReader(stream))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine("GET /Login HTTP/1.1");//Get is the verb, /Login is the directory handling the login process, HTTP/1.1 is the protocol
                        writer.WriteLine("Username: " +UsernameField.Text);//Sends a header with the username info gathered from the UsernameField text box
                        writer.WriteLine("Password: " + PasswordField.Text);//Sends a header with the password info gathered from the PasswordField text box
                        //Double blank line signifies end of header in a HTTP request
                        writer.WriteLine();
                        writer.WriteLine();
                        
                        string[] lines = reader.ReadToEnd().Split('\n');
                        if (lines[0].Contains("401"))
                        {
                            MessageBox.Show(lines[6]);//This create a message box and dumps the output from the variable reader    
                        }

                        if (lines[0].Contains("200"))
                        {
                            
                            Client clientwindow = new Client();
                            clientwindow.SetToken(lines[6]);
                            this.Hide();
                            clientwindow.Show();
                        }
                    }
                }
            }
        }
    }
}