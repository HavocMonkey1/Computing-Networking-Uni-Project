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
            InitializeComponent();//initilizes
            
        }

        public void SetToken(string token)
        {
            this.token = token;//token updating between login window and other functions
        }
        
        public void NotesList()
            //Sends GET request to the server in order to retrieve a list of notes
        {
            using (var client = new TcpClient(hostname: "127.0.0.1", port: 8000))//connect to server
            {
                using (var stream = client.GetStream())//stream to and from server
                using (var writer = new StreamWriter(stream))
                using (var reader = new StreamReader(stream))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine("GET /ListNotes HTTP/1.1"); //Get is the verb, /Login is the directory handling the login process, HTTP/1.1 is the protocol
                    writer.WriteLine("Token: " + token); //Sends a header with the token that the user recieved
                    //Double blank line signifies end of header in a HTTP request
                    writer.WriteLine();
                    writer.WriteLine();

                    string[] lines = reader.ReadToEnd().Split('\n');//reads body of returned message and splits based on new lines
                    if (lines[0].Contains("401"))
                    {
                        MessageBox.Show(
                            lines[6]); //This create a message box and dumps the output from the variable reader
                        return;
                    }

                    string outputText = "";//blank string
                    if (lines[0].Contains("200"))//if ok recieved
                    {
                        int MaxIndex = lines.Length - 7;//reads through the lines and grabs the lines with the header names
                        for (int i = 0; i < MaxIndex; i++)
                        {
                            outputText += lines[6 + i];//appends to a string the header files
                        }
                        
                    }

                    string[] outputArray = outputText.Split('\r');//splits the text based on the 
                    string[] tempArray = new string[outputArray.Length - 1];//creates a temporary array with 1 less item in thna the outputa array to remove the excess line due to the formating of how the data is sent
                    
                    for (int i = 0; i < tempArray.Length; i++)//itterates through and puts all the items minus the last item (which is a blank line into the temporary array
                    {
                        tempArray[i] = outputArray[i];
                    }
                    this.ListNotes.Items.Clear();//clears the items in the list
                    this.ListNotes.Items.AddRange(tempArray);//adds all the items in the temporary array to the list which is displayed sorted alphabetically
                }
            }
        }


        private void Load_Click(object sender, EventArgs e)
        {
            //Sends GET request to the server in order to load a new note
            {
                using (var client = new TcpClient(hostname: "127.0.0.1", port: 8000))//as above
                {
                    using (var stream = client.GetStream())//as above
                    using (var writer = new StreamWriter(stream))
                    using (var reader = new StreamReader(stream))
                    {
                        writer.AutoFlush = true;
                        writer.WriteLine("GET /LoadNote HTTP/1.1"); //Get is the verb, /Login is the directory handling the login process, HTTP/1.1 is the protocol
                        writer.WriteLine("NoteHeading: " + ListNotes.Text); //Sends a header with the NoteHeading pulled from the list box
                        writer.WriteLine("Token: " + token); //Sends a header with the token that the user recieved
                        //Double blank line signifies end of header in a HTTP request
                        writer.WriteLine();
                        writer.WriteLine();
                        //Body of the request
                        
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
                            for (int i = 0; i < MaxIndex; i++)//iterates through lines and pulls all the lines with note contents in them
                            {
                                outputText += lines[7 + i] + "\n";
                            }
                        
                        }

                        string[] outputArray = outputText.Split('\r');//splits based on the return
                        string Notebody = "";//blank string used later
                        for (int i = 0; i < outputArray.Length; i++)//itterates through and adds the items to the body
                        {
                            Notebody += outputArray[i] + "\r\n";//appends to an array
                        }

                        NoteContent.Lines = outputArray;//outputs the notebody
                    }
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            //Sends GET request to the server in order to save files
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
                        writer.WriteLine(NoteContent.Text);//sends the contents of the note in the body of the request

                    }
                }
                NotesList(); //once saved updates the list of notes accounting for the creation of a new note
            }
        }
    }
}