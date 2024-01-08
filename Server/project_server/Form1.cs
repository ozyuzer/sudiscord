using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project_server
{
    public partial class Form1 : Form
    {

        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Socket to listen for incoming client connections.
        Dictionary<string, Socket> userSockets = new Dictionary<string, Socket>(); // Maps usernames to their sockets.
        Dictionary<Socket, string> socketToUsernameMap = new Dictionary<Socket, string>(); // Maps sockets to usernames.
        Dictionary<string, List<string>> channelSubscriptions = new Dictionary<string, List<string>> { // Maps channel names to lists of subscribed usernames.
            { "SPS101", new List<string>() },
            { "IF100", new List<string>() }
        };

        bool terminating = false; // Flag for termination state.
        bool listening = false; // Flag for listening state.

        public Form1() // Constructor for the server form.
        {
            Control.CheckForIllegalCrossThreadCalls = false; // Disables cross-thread call checking for UI updates.
            this.FormClosing += new FormClosingEventHandler(Form1_FormClosing); // Attaches an event handler for form closing.
            InitializeComponent(); // Initializes form components.
        }

        private void button_Listen_Click(object sender, EventArgs e) // Event handler for the Listen button.
        {
            //Parses server port and sets up the server socket to listen for incoming connections.
            //Starts a new thread for accepting connections.

            int serverPort;

            if(Int32.TryParse(textBox_Port.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                button_Listen.Enabled = false;

                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                logs.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                logs.AppendText("Please check port number \n");
            }
        }

        private void Accept() // Runs on a separate thread to accept incoming client connections. 
        {
            //Processes client messages and performs actions based on message content.
            //Handles subscription, unsubscription, and message forwarding based on action codes ('a', 'b', 'c', 'd', 'e', 'f', 'g').
            while (listening) // Loops continuously while the server is listening.
            {
                try
                {
                    Socket newUser = serverSocket.Accept(); // Accepts a new connection from a client.
                    string username = ReceiveUsername(newUser); // Receives the username sent by the connecting client.

                    if (username != null) // If username is received successfully.
                    {
                        if (!userSockets.ContainsKey(username)) // Checks if the username is already connected.
                        {
                            // Username is accepted
                            newUser.Send(Encoding.ASCII.GetBytes("OK")); // Sends a confirmation message

                            userSockets.Add(username, newUser);
                            socketToUsernameMap.Add(newUser, username);
                            logs.AppendText($"User {username} is connected. \n");

                            UpdateClientLists();
                            Thread receiveThread = new Thread(() => Receive(newUser));
                            receiveThread.Start();
                        }
                        else
                        {
                            // Username is rejected
                            newUser.Send(Encoding.ASCII.GetBytes("NO"));
                            newUser.Close();
                        }
                    }
                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        logs.AppendText("The socket stopped working.\n");
                    }

                }
            }
        }

        private void Receive(Socket thisUser)
        {
            bool connected = true; // Flag indicating connection status.

            if (!socketToUsernameMap.ContainsKey(thisUser))
            {
                connected = false;
            }

            string username = socketToUsernameMap[thisUser]; // Retrieves username associated with the socket.

            while (connected && !terminating)
            {
                try
                {
                    byte[] buffer = new byte[64];
                    int byteCount = thisUser.Receive(buffer);

                    if (byteCount > 0)
                    {
                        string incomingMessage = Encoding.Default.GetString(buffer, 0, byteCount);
                        char actionCode = incomingMessage[0];
                        
                        switch (actionCode)
                        {
                            case 'a':
                                Subscribe(username, "SPS101"); // Subscribe to SPS101 channel.
                                break;
                            case 'b':
                                Unsubscribe(username, "SPS101"); // Unsubscribe to SPS101 channel.
                                break;
                            case 'c':
                                Subscribe(username, "IF100"); // Subscribe to IF100 channel.
                                break;
                            case 'd':
                                Unsubscribe(username, "IF100"); // Unsubscribe to IF100 channel.
                                break;
                            case 'e':
                                HandleUserDisconnection(thisUser); // Handle user disconnection.
                                connected = false;
                                break;
                            case 'f':
                                HandleChannelMessage(username, "SPS101", incomingMessage.Substring(1)); // Handle message sent to SPS101 channel.
                                break;
                            case 'g':
                                HandleChannelMessage(username, "IF100", incomingMessage.Substring(1)); // Handle message sent to IF100 channel.
                                break;
                            default:
                                logs.AppendText($"Invalid action code received from {username}\n"); // Log invalid action code received.
                                break;
                        }
                    }
                }
                catch // Outside the loop, handle user disconnection if not connected anymore.
                {
                    HandleUserDisconnection(thisUser);

                    connected = false;
                }
            }
        }

        private void HandleChannelMessage(string username, string channel, string message)
        // This function processes and forwards channel messages.
        {
            if (channelSubscriptions.ContainsKey(channel) && channelSubscriptions[channel].Contains(username)) // Checks if channel exists and user is subscribed.
            {
                string formattedMessage = $"{channel}:{username}: {message}"; // Formats message with channel, username, and message content.
                logs.AppendText(formattedMessage + "\n"); // Logs the formatted message.
                foreach (var subscriber in channelSubscriptions[channel]) // Loops through subscribers of the channel.
                {
                    Socket subscriberSocket; // Retrieves subscriber socket associated with each username.
                    if (userSockets.TryGetValue(subscriber, out subscriberSocket))
                    {
                        subscriberSocket.Send(Encoding.ASCII.GetBytes(formattedMessage)); // Sends the formatted message to each subscriber socket (if available).
                    }
                }
            }
        }

        private void Subscribe(string username, string channel)
        // This function adds a user to a channel's subscription list.
        {
            if (channelSubscriptions.ContainsKey(channel) && !channelSubscriptions[channel].Contains(username)) // Checks if channel exists and user isn't already subscribed.
            {
                channelSubscriptions[channel].Add(username); // Adds the username to the channel's subscriber list.
                logs.AppendText($"{username} subscribed to {channel}\n"); // Logs the user's subscription.
                NotifyChannelSubscribers(channel, $"{channel}:{username}: (has joined)"); // Notifies all subscribers of the joined user.
                UpdateClientLists(); // Updates client lists for display.
            }
        }

        private void Unsubscribe(string username, string channel)
        // This function removes a user from a channel's subscription list.
        {
            if (channelSubscriptions[channel].Contains(username)) // Checks if the user is subscribed to the channel.
            {
                channelSubscriptions[channel].Remove(username); // Removes the username from the channel's subscriber list.
                logs.AppendText($"{username} unsubscribed from {channel}\n"); // Logs the user's unsubscription.
                NotifyChannelSubscribers(channel, $"{channel}:{username}: (has left)"); // Notifies all subscribers of the left user.
                UpdateClientLists(); // Updates client lists for display.
            }
        }

        private void NotifyChannelSubscribers(string channel, string message)
        // This function sends a message to all subscribers of a specific channel.
        {
            foreach (var subscriber in channelSubscriptions[channel]) // Loops through all subscribers of the channel.
            {
                Socket subscriberSocket;
                if (userSockets.TryGetValue(subscriber, out subscriberSocket)) // Retrieves subscriber socket associated with each username.
                {
                    try
                    {
                        subscriberSocket.Send(Encoding.ASCII.GetBytes(message)); // Tries to send the message to each subscriber socket (ignoring any failures).
                    }
                    catch
                    {
                        
                    }
                }
            }
        }

        private string ReceiveUsername(Socket socket)
        // This function receives the initial username sent by a connecting client.
        {
            try
            {
                byte[] buffer = new byte[64];
                int received = socket.Receive(buffer); // Attempts to receive data using a buffer.
                if(received > 0)
                {
                    string username = Encoding.ASCII.GetString(buffer, 0, received); // If data received, extracts the username string and trims whitespace.
                    return username.Trim();
                }
                return null;
            }
            catch // Returns null if receiving fails.
            {
                return null;
            }
        }
        private void HandleUserDisconnection(Socket thisUser)
        // This function handles disconnecting a user and updating subscriptions.
        {
            string username;
            if (socketToUsernameMap.TryGetValue(thisUser, out username)) // Retrieves the username associated with the disconnecting socket.
            {
                foreach (var channel in channelSubscriptions.Keys.ToList()) // Loops through all channels, removing the user from any subscriptions.
                {
                    if (channelSubscriptions[channel].Contains(username))
                    {
                        channelSubscriptions[channel].Remove(username);
                        logs.AppendText($"{username} unsubscribed from {channel} due to disconnection.\n"); // Logs the user's disconnection from each channel.
                        NotifyChannelSubscribers(channel, $"{channel}:{username}: (has left)"); // Notifies all subscribers of the left user for each channel.
                    }
                }
                  
                userSockets.Remove(username);
                socketToUsernameMap.Remove(thisUser); // Removes the user and socket from server data structures.

                try
                {
                    thisUser.Shutdown(SocketShutdown.Both); // Closes the socket connection.
                }
                catch
                {

                }
                finally
                {
                    thisUser.Close();
                }

                logs.AppendText($"{username} has disconnected.\n"); // Logs the user's complete disconnection.
                UpdateClientLists(); // Updates client lists for display.
            }
        }

        private void UpdateClientLists()
        // This function updates the display of connected clients, SPS subscribers, and IF subscribers.
        {
            // Generates strings by joining usernames from respective data structures.
            string connectedClients = string.Join(Environment.NewLine, userSockets.Keys);
            string spsSubscribers = string.Join(Environment.NewLine, channelSubscriptions["SPS101"]);
            string ifSubscribers = string.Join(Environment.NewLine, channelSubscriptions["IF100"]);

            // Sets the text of corresponding RichTextBox controls with the generated strings.
            SetText(logs_Connected_Clients, connectedClients);
            SetText(logs_SPS_Subscribers, spsSubscribers);
            SetText(logs_IF_Subscribers, ifSubscribers);
        }

        private void SetText(RichTextBox richTextBox, string text)
        //  This function safely updates the text of a RichTextBox from another thread.
        {
            if (richTextBox.InvokeRequired) // Checks if the control needs to be updated on another thread.
            {
                richTextBox.Invoke(new Action<RichTextBox, string>(SetText), new object[] { richTextBox, text }); // If required, uses Invoke to safely update the text on the UI thread.
            }
            else
            {
                richTextBox.Text = text; // Otherwise, directly updates the control's text.
            }
        }


        private void Form1_FormClosing(object sender, System.ComponentModel.CancelEventArgs e) // Handles the form closing event.
        {
            //Sets flags to stop listening and terminate the server, then exits the application.
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

    }
}
