using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PortScaner
{
    //Structure for information about port
    //use for deserializable data from file "info.data"
    [Serializable()]
    struct PortInformation
    {
        public int port;
        public string information;
    }

    //Class for get information about ports
    class PortInformer
    {
        private static bool infoIsOpened = false; //if info file opened
        private static List<PortInformation> portInfoData = new List<PortInformation>(); // list of structure from file
        public PortInformer() => InitializeHelpInfoFromFile(); //Constructor, try to open help file

        private static void InitializeHelpInfoFromFile()
        {
            //open file with info and fill list
            try
            {
                Stream stream = File.Open("info.dat", FileMode.Open); //ATTENTION: FILE info.dat must be
                                                                      //in directory with program, or change path
                var bformater = new BinaryFormatter();
                portInfoData = (List<PortInformation>)bformater.Deserialize(stream);
                infoIsOpened = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Can`not open help file info.dat\n" +
                    "You can`not see info about ports!", "Warning!",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<PortInformation> GetInformationByPortList(List<int> portList)
        {
            // Get information about avaliable ports
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnections = ipGlobalProperties.GetActiveTcpConnections();
            List<PortInformation> portInformationList = new List<PortInformation>();
            PortInformation portInformation;
            foreach (var portForSearch in portList)
            {
                foreach (var port in tcpConnections)
                {
                    if (port.LocalEndPoint.Port == portForSearch)
                    {
                        portInformation.information = $"Local endpoint: " + Convert.ToString(port.LocalEndPoint) +
                            $" | Remote endpoint: " + Convert.ToString(port.RemoteEndPoint) +
                            $" | Connection: " + Convert.ToString(port.State);
                        portInformation.port = port.LocalEndPoint.Port;
                        portInformationList.Add(portInformation);
                    }
                    else if (port.RemoteEndPoint.Port == portForSearch)
                    {
                        portInformation.information = $"Local endpoint: " + Convert.ToString(port.LocalEndPoint) +
                            $" | Remote endpoint: " + Convert.ToString(port.RemoteEndPoint) +
                            $" | Connection: " + Convert.ToString(port.State);
                        portInformation.port = port.RemoteEndPoint.Port;
                        portInformationList.Add(portInformation);
                    }
                }
            }
            return portInformationList;
        }

        public string GetInfoAboutPort(int portNumber) //Method for getting information about some port
                                                       //information from site www.iana.org
        {
            string info = string.Empty;
            if (infoIsOpened) //if file with info was opened
            {
                if (portInfoData[portNumber].information != "Can`not find any info")
                    info += portInfoData[portNumber].information;
                else
                    info += $"PORT:" + Convert.ToString(portInfoData[portNumber].port) +
                        $"\n" + portInfoData[portNumber].information;
            }
            else
            {
                info = $"Can`not load info file";
            }
            return info;
        }

    }
}
