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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            
        }


        private void LoginButton_Click(object sender, EventArgs e)
        {
            //temp request demo 
            {
                using (var client =  new TcpClient( hostname: "127.0.0.1", port: 80))
                {
                    using (var stream = client.GetStream())
                    using(var writer = new StreamWriter(stream))
                    using (var reader = new StreamReader(stream))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine("GET / HTTP/1.1");/*Get is the verb, / is the root directory, HTTP/1.1 is the protocol*/
                        writer.WriteLine("Host: 127.0.0.1:80");/*the address of the server*/
                        //Double blank line signifies end of header in a HTTP request
                        writer.WriteLine();
                        writer.WriteLine();

                        MessageBox.Show(reader.ReadToEnd());/*This create a message box and dumps the output from the variable reader*/
                    }
                }
            }
        }
        
    }
}