﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CAVESocketTest
{
    public partial class Form1 : Form
    {
    	IAsyncResult m_result;
		public AsyncCallback m_pfnCallBack ;
		public Socket m_clientSocket;

        public String m_IPAddress = "127.0.0.1";
        public String m_Port      = "8007";
        static int m_bufferSize   = 1024;

        public enum Commands
        {
            None = 0,
            Forward = 1,
            Backward = 2,
            Left = 3,
            Right = 4,
            Up = 5,
            Down = 6,
            FlatTrim = 7,
            TakeOff = 8,
            Land = 9,
            Emergency = 10,
            StrafeL = 11,
            StrafeR = 12,
            Camera = 13,
            Special = 14,
            Hover = 15,
            Calibrate = 16,
            CalibrationComplete = 17,
            ControlToPatient = 18,
            ControlToSupervisor = 19,
            CheckInToggle = 20,
            SelectPatient = 21,
            SavePatient = 22,
            ViewLogs = 23,
            ViewRecordings = 24,
            StartSimulation = 25,
            EndSimulation = 26,
            PauseSimulation = 27,
            Exit = 28,
            Test = 99
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        // Connect button
        private void connectButton_Click(object sender, EventArgs e)
        {
            try
            {
                UpdateControls(false);
                // Create the socket instance
                m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                // Cet the remote IP address
                IPAddress ip = IPAddress.Parse(m_IPAddress);
                int iPortNo = System.Convert.ToInt16(m_Port);
                // Create the end point 
                IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                // Connect to the remote host
                m_clientSocket.Connect(ipEnd);
                if (m_clientSocket.Connected)
                {

                    UpdateControls(true);
                    //Wait for data asynchronously 
                    WaitForData();
                }
            }
            catch (SocketException se)
            {
                string str;
                str = "\nConnection failed, is the server running?\n" + se.Message;
                MessageBox.Show(str);
                UpdateControls(false);
            }		
        }

        // Disconnect
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
            }
        }

        // ---------------------------------------------------------------- //
        // -------------------------- MAIN CHUNK -------------------------- //
        // ---------------------------------------------------------------- //

        // Left
        private void leftButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Left);
        }

        // Foward
        private void forwardButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Forward);
        }

        // Back
        private void backButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Backward);
        }

        // Right
        private void rightButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Right);
        }

        // Up
        private void upButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Up);
        }

        // Down
        private void downButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Down);
        }

        // Send Flat Trim
        private void flatTrimButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.FlatTrim);
        }

        // Take Off
        private void takeOffButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.TakeOff);
        }

        // Land
        private void landButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Land);
        }

        // Emergency
        private void emergencyButton_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Emergency);
        }

        // Test
        private void test_Click(object sender, EventArgs e)
        {
            sendCommand(Commands.Test);
        }

        // Sends a command
        private void sendCommand(Commands cmd)
        {
            try
            {
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(((int)cmd).ToString());
                if (m_clientSocket != null)
                {
                    m_clientSocket.Send(byData);
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

            /*
            Thread.Sleep(500);
            
            try
            {
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(((int)Commands.None).ToString());
                if (m_clientSocket != null)
                {
                    m_clientSocket.Send(byData);
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
            */
        }

        // ---------------------------------------------------------------- //
        // -------------------------- END  CHUNK -------------------------- //
        // ---------------------------------------------------------------- //

        // Wait for incoming data if needed (unused)
        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }

                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        // Event for data being received (unused)
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                int tempCMD = 0;

                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                // richTextRxMessage.Text = richTextRxMessage.Text + szData;

                try
                {
                    tempCMD = Convert.ToInt32(szData);
                }
                catch (FormatException e)
                {
                    output.Text = output.Text + szData;

                    // TODO: Try to interpret CAVE Calibration data?
                }
                catch (OverflowException e)
                {
                    // Do nothing
                }
                finally
                {
                    if (tempCMD < Int32.MaxValue)
                    {
                        output.Text = output.Text + ((Commands)tempCMD).ToString();
                    }
                    else
                    {
                        output.Text = output.Text + szData;
                    }
                }


                WaitForData();
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }	

        // Gets the machine IP (unused)
        String GetIP()
        {
            String strHostName = Dns.GetHostName();

            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);
            //IPHostEntry iphostentry = Dns.GetHostByName(strHostName);

            // Grab the first IP addresses
            String IPStr = "";
            foreach (IPAddress ipaddress in iphostentry.AddressList)
            {
                IPStr = ipaddress.ToString();
                return IPStr;
            }
            return IPStr;
        }

        // Grays out shit yo
        private void UpdateControls(bool connected)
        {
            connectButton.Enabled = !connected;
            disconnectButton.Enabled = connected;
            string connectStatus = connected ? "Connected" : "Not Connected";
            connectedStatus.Text = connectStatus;
        }

        public class SocketPacket
        {
            public System.Net.Sockets.Socket thisSocket;
            public byte[] dataBuffer = new byte[Form1.m_bufferSize];

        }

        private void sendCalibrationData_Click(object sender, EventArgs e)
        {
            String JSONData = "{\"Up\":{\"lsx\":\"1.000000000000\",\"lsy\":\"2.000000000000\",\"lsz\":\"3.000000000000\",\"rsx\":\"3.000000000000\",\"rsy\":\"2.000000000000\",\"rsz\":\"1.000000000000\"},\"Down\":{\"lsx\":\"4.000000000000\",\"lsy\":\"5.000000000000\",\"lsz\":\"6.000000000000\",\"rsx\":\"6.000000000000\",\"rsy\":\"6.000000000000\",\"rsz\":\"5.000000000000\"},\"Left\":{\"lsx\":\"4.000000000000\",\"lsy\":\"7.000000000000\",\"lsz\":\"8.000000000000\",\"rsx\":\"9.000000000000\",\"rsy\":\"9.000000000000\",\"rsz\":\"8.000000000000\"},\"Right\":{\"lsx\":\"7.000000000000\",\"lsy\":\"0.000000010000\",\"lsz\":\"0.000000300000\",\"rsx\":\"0.000000000500\",\"rsy\":\"0.000000000005\",\"rsz\":\"0.000000000020\"},\"Forward\":{\"lsx\":\"0.000000000070\",\"lsy\":\"0.000000040000\",\"lsz\":\"0.000000000100\",\"rsx\":\"0.000004000000\",\"rsy\":\"0.000000007000\",\"rsz\":\"0.000000020000\"},\"Back\":{\"lsx\":\"0.000000000002\",\"lsy\":\"0.000000000003\",\"lsz\":\"0.000000000006\",\"rsx\":\"0.000000000007\",\"rsy\":\"0.000000000005\",\"rsz\":\"0.000000000050\"}}";

            try
            {
                byte[] byData = System.Text.Encoding.ASCII.GetBytes(JSONData);
                if (m_clientSocket != null)
                {
                    m_clientSocket.Send(byData);
                }
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

            this.sendCommand(Commands.CalibrationComplete);
        }

        private void packet_Click(object sender, EventArgs e)
        {
            for(int o = 0; o < 10; o++)
            {
                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.Forward);
                    Thread.Sleep(20);
                }

                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.Backward);
                    Thread.Sleep(20);
                }

                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.Left);
                    Thread.Sleep(20);
                }

                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.Right);
                    Thread.Sleep(20);
                }

                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.Up);
                    Thread.Sleep(20);
                }

                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.Down);
                    Thread.Sleep(20);
                }

                for (int i = 0; i < 50; i++)
                {
                    sendCommand(Commands.None);
                    Thread.Sleep(20);
                }
            }
        }
    }
}