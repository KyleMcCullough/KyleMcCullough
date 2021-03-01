using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatLib;
using ChatLog;

namespace Assignment2
{
    public partial class GameScreen : Form
    {
        Events.streamReceieveMessageHandler streamNewMessageEvent;
        Events.streamSendMessageHandler streamSendMessageEvent;
        Thread clientMessageListener;
        Client client;
        ChatLog.ChatLog log;

        //Passes an ILoggingService class in as the logger
        public GameScreen(ILoggingService logging)
        {
            client = new Client();
            log = new ChatLog.ChatLog(logging);

            streamNewMessageEvent += new Events.streamReceieveMessageHandler(Event_SetMessage);
            streamNewMessageEvent += new Events.streamReceieveMessageHandler(log.WriteToFile);

            streamSendMessageEvent += new Events.streamSendMessageHandler(Event_SendMessage);
            streamSendMessageEvent += new Events.streamSendMessageHandler(Event_SetMessage);
            streamSendMessageEvent += new Events.streamSendMessageHandler(log.WriteToFile);

            InitializeComponent();
            NetworkDisconnectButton.Enabled = false;
        }

        //
        // Summary:
        //     Starts two threads, one to connect the client to the server,
        //     the other will constantly listen for messages.
        //     
        //
        private void NetworkConnectButton_Click(object sender, EventArgs e)
        {
            //Starts thread to start client
            Thread startClient = new Thread(client.StartTcpClient);
            startClient.Name = "Connecting client.";
            startClient.Start();

            //Waits for the previous thread to finish setting up the connection to the stream has not been created.
            while (client.stream == null) Thread.Sleep(1);

            //Starts message listener thread and logs connection
            clientMessageListener = new Thread(Event_CheckMessages);
            clientMessageListener.Name = "Network message listener";
            clientMessageListener.Start();


            log.BeginConnection();
            NetworkDisconnectButton.Enabled = true;
            NetworkConnectButton.Enabled = false;
        }

        //
        // Summary: Disconnects the client from the server and logs the event. 
        //     
        private void NetworkDisconnectButton_Click(object sender, EventArgs e)
        {
            client.Disconnect();
            log.EndConnection();
            NetworkDisconnectButton.Enabled = false;
            NetworkConnectButton.Enabled = true;
        }

        //
        // Summary: This will constantly check for an incoming message. If a message
        //          is detected, it will trigger the streamNewMessageEvent event.
        private void Event_CheckMessages()
        {

            MethodInvoker invoker = new MethodInvoker(delegate ()
            {
                this.streamNewMessageEvent(this, new Events.StreamMessageArgs() { Message = this.client.GetMessage(), LocalMessage = false });
            });

            while (client.stream != null)
            {
                try
                {
                    if (client.stream.DataAvailable)
                    {
                        this.Invoke(invoker);
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
        }

        //
        // Summary: Updates the visual display to include the message for the client.
        //    
        private void Event_SetMessage(object sender, Events.StreamMessageArgs e)
        {
            if (e.LocalMessage)
            {
                GameMessageBox.Text +=  ">> " + e.Message + Environment.NewLine;
                UserMessageBox.Text = "";
            }
            else
            {
                GameMessageBox.Text += e.Message + Environment.NewLine;
            }
        }

        //
        // Summary: Creates a thread and calls the client SendMessage function.
        //    
        private void Event_SendMessage(object sender, Events.StreamMessageArgs e)
        {
            Thread thread = new Thread(() => this.client.SendMessage(e.Message));
            thread.Name = "Message Sending";
            thread.Start();
        }

        //
        // Summary: Calls the Event_Close() function and then closes the form.
        //    
        private void GameExitButton_Click(object sender, EventArgs e)
        {
            Event_Close();
            this.Close();
        }

        //
        // Summary: Calls the Event_Close() function.
        //  
        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Event_Close();
        }

        private void Event_Close()
        {
            try
            {
                
                //Allows for the dedicated listening thread to end before closing.
                if (client.stream != null) client.Disconnect();
                
                if (clientMessageListener != null) clientMessageListener.Join();

            }
            catch(Exception)
            {
                return;
            }
        }

        //
        // Summary: Creates a new thread to call Event_ProcessSubmit()
        //  
        private void UserTextSubmitButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Event_ProcessSubmit);
            thread.Name = "Message processing";
            thread.Start();
        }

        //
        // Summary: Send the user inputted message to the server.
        //  
        private void Event_ProcessSubmit()
        {
            if (UserMessageBox.Text == "") return;
            if (!client.stream.CanWrite) return;

            MethodInvoker invoker = new MethodInvoker(delegate ()
            {
                this.streamSendMessageEvent(this, new Events.StreamMessageArgs() { Message = UserMessageBox.Text, LocalMessage = true});
            });

            this.BeginInvoke(invoker);
        }
    }
}
