using System; //all the modules it needs are loaded at the beginning
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_GUI//sets the scope of Client_GUI
{
    public partial class Client : Form
    {
        private string token;//

        public Client()
        {
            InitializeComponent();
            
        }

        public void SetToken(string token)
        {
            this.token = token;
        }
        
        public void NotesList()
            //Sends GET request to the server in order to retrieve a list of notes
        {
            using (var client = new TcpClient(hostname: "127.0.0.1", port: 8000))
            {
                using (var stream = client.GetStream())
                using (var writer = new StreamWriter(stream))
                using (var reader = new StreamReader(stream))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine("GET /ListNotes HTTP/1.1"); //Get is the verb, /Login is the directory handling the login process, HTTP/1.1 is the protocol
                    writer.WriteLine("Token: " + token); //Sends a header with the token that the user recieved
                    //Double blank line signifies end of header in a HTTP request
                    writer.WriteLine();
                    writer.WriteLine();

                    string[] lines = reader.ReadToEnd().Split('\n');
                    if (lines[0].Contains("401"))
                    {
                        MessageBox.Show(
                            lines[6]); //This create a message box and dumps the output from the variable reader
                        return;
                    }

                    string outputText = "";
                    if (lines[0].Contains("200"))
                    {
                        int MaxIndex = lines.Length - 7;
                        for (int i = 0; i < MaxIndex; i++)
                        {
                            outputText += lines[6 + i];
                        }
                        
                    }

                    string[] outputArray = outputText.Split('\r');
                    string[] tempArray = new string[outputArray.Length - 1];
                    
                    for (int i = 0; i < tempArray.Length; i++)
                    {
                        tempArray[i] = outputArray[i];
                    }
                    this.ListNotes.Items.Clear();
                    this.ListNotes.Items.AddRange(tempArray);
                }
            }
        }


        private void Load_Click(object sender, EventArgs e)
        {
            //Sends GET request to the server in order to validate the login details
            {
                using (var client = new TcpClient(hostname: "127.0.0.1", port: 8000))
                {
                    using (var stream = client.GetStream())
                    using (var writer = new StreamWriter(stream))
                    using (var reader = new StreamReader(stream))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine("GET /LoadNote HTTP/1.1"); //Get is the verb, /Login is the directory handling the login process, HTTP/1.1 is the protocol
                        writer.WriteLine("NoteHeading: " + ListNotes.Text); //Sends a header with the NoteHeading pulled from the text box
                        writer.WriteLine("Token: " + token); //Sends a header with the token that the user recieved
                        //Double blank line signifies end of header in a HTTP request
                        writer.WriteLine();
                        writer.WriteLine();
                        //Body of the request

                        // string output = reader.ReadToEnd();
                        NoteHeading.Text = ListNotes.Text;
                        
                        string[] lines = reader.ReadToEnd().Split('\n');
                        if (lines[0].Contains("401"))
                        {
                            MessageBox.Show(
                                lines[6]); //This create a message box and dumps the output from the variable reader 
                            return;
                        }

                        string outputText = "";
                        if (lines[0].Contains("200"))
                        {
                            int MaxIndex = lines.Length - 7;
                            for (int i = 0; i < MaxIndex; i++)
                            {
                                outputText += lines[7 + i] + "\n";
                            }
                        
                        }

                        string[] outputArray = outputText.Split('\r');
                        string Notebody = "";
                        for (int i = 0; i < outputArray.Length; i++)
                        {
                            Notebody += outputArray[i] + "\r\n";
                        }

                        NoteContent.Lines = outputArray;
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
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
                        writer.WriteLine("GET /SaveNote HTTP/1.1");//Get is the verb, /Login is the directory handling the login process, HTTP/1.1 is the protocol
                        writer.WriteLine("Content-type: text/plain");
                        writer.WriteLine("Content-length: " + (NoteContent.TextLength + 2).ToString());
                        writer.WriteLine("NoteHeading: " + NoteHeading.Text);//Sends a header with the NoteHeading pulled from the text box
                        writer.WriteLine("Token: " + token);//Sends a header with the token that the user recieved
                        //Double blank line signifies end of header in a HTTP request
                        writer.WriteLine();
                        writer.WriteLine();
                        //Body of the request
                        writer.WriteLine(NoteContent.Text);

                    }
                }
                NotesList();
            }
        }
    }
}