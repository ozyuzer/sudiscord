using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace project_client
{
    public partial class Form1 : Form
    {
        bool terminating = false; // Flag to indicate if the application is being terminated.
        bool connected = false; // Flag to indicate if the client is connected to the server.
        Socket clientSocket; // Variable to store the socket connection to the server.

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false; // Disables cross-thread checking (potentially harmful, use with caution).
            InitializeComponent(); // Calls the Windows Forms designer generated initialization code.
            button_Disconnect.Enabled = false; // Disables the Disconnect button initially.
        }

        private void button_Connect_Click(object sender, EventArgs e) // Handles the click event on the Connect button.
        {
        // Connects to server using IP and Port, sends username, handles server response.
        // Sends 'username' to server which is handled in server's `Accept` and `ReceiveUsername` methods.

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Creates a new TCP socket.
            string IP = textBox_IP.Text; // Retrieves the IP address from the textbox.
            int portNum; // Variable to store the port number.
            if (Int32.TryParse(textBox_Port.Text, out portNum)) // Parses the port number from the textbox.
            {
                try  // Attempts to connect to the server.
                {
                    clientSocket.Connect(IP, portNum); // Connects to the server at the specified IP and port.
                    connected = true; // Sets the connected flag to true.
                    terminating = false; // Resets the terminating flag.
                    button_Connect.Enabled = false; // Disables the Connect button.
                    button_Disconnect.Enabled = true; // Enables the Disconnect button.
                    

                    if (connected)
                    {
                        string username = textBox_Username.Text;
                        Byte[] buffer = Encoding.ASCII.GetBytes(username);
                        clientSocket.Send(buffer);

                        
                        buffer = new byte[64];
                        int rec = clientSocket.Receive(buffer);
                        string response = Encoding.ASCII.GetString(buffer, 0, rec).Trim();

                        if (response == "NO")
                        {
                            logs_Connection.AppendText("Username is already in use. Please try a different one.\n");
                            clientSocket.Close();
                            connected = false;
                            button_Connect.Enabled = true;
                            button_Disconnect.Enabled = false;
                        }
                        else if (response == "OK")
                        {
                            
                            logs_Connection.AppendText("Username accepted.\n");
                            Thread receiveThread = new Thread(Receive);
                            receiveThread.Start();
                        }
                    } 
                }
                catch // Catches any exceptions during connection.
                {
                    logs_Connection.AppendText("Could not connect to the server!\n");
                }
            }
            else
            {
                logs_Connection.AppendText("Check the port.\n");
            }
        }

        private void button_Disconnect_Click(object sender, EventArgs e)
        {
        // Sends a disconnect message to server and handles UI updates.
        // Sends 'e' to server indicating the client wants to disconnect.
        
            if (connected)
            {
                Byte[] buffer = Encoding.ASCII.GetBytes("e");
                clientSocket.Send(buffer);
            }

            terminating = true;
            connected = false;
            button_Connect.Enabled = true;
            button_Disconnect.Enabled = false;
            logs_Connection.AppendText("Disconnected from the server.\n");
            logs_SPS.Clear();
            logs_IF.Clear();

            if (clientSocket != null)
            {
                clientSocket.Close();
            }
        }

        private void Receive()
        {
        // Receives messages from the server and processes them.
        // Handles messages based on their content, especially for channel-specific messages.
            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[64];
                    int rec = clientSocket.Receive(buffer);
                    if (rec <= 0)
                    {
                        throw new SocketException();
                    }

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    
                    if (incomingMessage.Contains(":"))
                    {
                        ProcessIncomingMessage(incomingMessage);
                    }
                    else
                    {
                        logs_Connection.AppendText(incomingMessage);
                    }


                }
                catch
                {
                    if (!terminating)
                    {
                        logs_Connection.AppendText("The server has disconnected.\n");
                    }
                    button_Connect.Enabled = true;
                    button_Disconnect.Enabled = false;
                    connected = false;
                }
            }
        }

        private void ProcessIncomingMessage(string message) // Processes and displays messages based on their channel (SPS101 or IF100).
        {
            var parts = message.Split(new[] { ':' }, 3); // Splits the message into parts based on colon characters.
            if (parts.Length == 3)  // Checks if the message is correctly formatted with 3 parts.
            {
                string channel = parts[0]; // Extracts the channel name.
                string actualMessage = parts[1] + ": " + parts[2]; // Formats the actual message.

                if (channel == "SPS101") // Checks the channel and updates the corresponding log.
                {
                    logs_SPS.Invoke((MethodInvoker)(() => logs_SPS.AppendText(actualMessage + "\n"))); // Appends the message to the SPS101 log.
                    logs_SPS.Invoke((MethodInvoker)(() => logs_SPS.AppendText("\n"))); 
                }
                else if (channel == "IF100")
                {
                    logs_IF.Invoke((MethodInvoker)(() => logs_IF.AppendText(actualMessage + "\n"))); // Appends the message to the IF100 log.
                    logs_IF.Invoke((MethodInvoker)(() => logs_IF.AppendText("\n")));
                }
            }
        }

        // Subscribe/Unsubscribe and Send buttons for SPS101 and IF100 channels
        // These buttons send specific codes ('a', 'b', 'c', 'd', 'f', 'g') to the server for respective actions.

        private void button_SPS_Subscribe_Click (object sender, EventArgs e) 
        {
            // Handles the SPS101 subscribe button click event.
            // Sends a subscribe request to the server and updates the UI accordingly.
            if (connected)
            {
                Byte[] buffer = Encoding.ASCII.GetBytes("a"); 
                clientSocket.Send(buffer);
            }
        }

        private void button_SPS_Unsubscribe_Click(object sender, EventArgs e)
        {
            // Handles the SPS101 unsubscribe button click event.
            // Sends an unsubscribe request to the server and updates the UI accordingly.
            if (connected)
            {
                Byte[] buffer = Encoding.ASCII.GetBytes("b"); 
                clientSocket.Send(buffer);
                logs_SPS.Clear();
            }
        }

        private void button_IF_Subscribe_Click(object sender, EventArgs e)
        {
            // Handles the IF100 subscribe button click event.
            // Sends an subscribe request to the server and updates the UI accordingly.
            if (connected)
            {
                Byte[] buffer = Encoding.ASCII.GetBytes("c"); 
                clientSocket.Send(buffer);
            }
        }

        private void button_IF_Unsubscribe_Click(object sender, EventArgs e)
        {
            // Handles the IF100 unsubscribe button click event.
            // Sends an unsubscribe request to the server and updates the UI accordingly.
            if (connected)
            {
                Byte[] buffer = Encoding.ASCII.GetBytes("d"); 
                clientSocket.Send(buffer);
                logs_IF.Clear();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e) 
        {
            // Handles form closing event, disconnects from server.
            // Ensures proper shutdown of the client socket and exits the application.
            terminating = true; // Sets the terminating flag.
            connected = false; // Sets the connected flag to false.
            base.OnFormClosing(e);
            if (clientSocket != null)
            {
                clientSocket.Close();
            }
            Application.Exit();
        }

        private void button_SPS_Send_Click(object sender, EventArgs e)
        {
            // Handles sending messages to the SPS101 channel.
            // Formats and sends a message to the SPS101 channel.
            if (connected)
            {
                string message = "f" + textBox_SPS_Message.Text;
                clientSocket.Send(Encoding.ASCII.GetBytes(message));
                textBox_SPS_Message.Text = "";
            }
        }

        private void button_IF_Send_Click(object sender, EventArgs e)
        {
            // Handles sending messages to the IF100 channel.
            // Formats and sends a message to the IF100 channel.
            if (connected)
            {
                string message = "g" + textBox_IF_Message.Text;
                clientSocket.Send(Encoding.ASCII.GetBytes(message));
                textBox_IF_Message.Text = "";
            }
        }
    }
}

