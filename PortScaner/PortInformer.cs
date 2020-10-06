using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;
using IronXL;

namespace PortScaner
{
    struct PortInformation
    {
        public int port;
        public string information;
    }
    class PortInformer
    {
        private static WorkBook workBook = new WorkBook();
        public static WorkSheet worksheet;
        private static bool infoIsOpened = false;

        public PortInformer() => InitializeHelpInfoFromXls();

        private static void InitializeHelpInfoFromXls()
        {
            try
            {
                workBook = WorkBook.Load("port_info.xls");
                worksheet = workBook.WorkSheets.First();
                infoIsOpened = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Can`not open help file port_info.xls\nYou can`not see info about ports!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public List<PortInformation> GetInformationByPortList(List<int> portList)
        {
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] tcpConnections = ipGlobalProperties.GetActiveTcpConnections();
            IPEndPoint[] tcpEndPoints = ipGlobalProperties.GetActiveTcpListeners();
            IPEndPoint[] udpEndPoints = ipGlobalProperties.GetActiveUdpListeners();
            List<PortInformation> portInformationList = new List<PortInformation>();
            PortInformation portInformation;
            foreach(var portForSearch in portList)
            {
                foreach (var port in tcpConnections)
                {
                   if(port.LocalEndPoint.Port == portForSearch)
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

        public string GetInfoAboutPort(int portNumber)
        {
            string info = $"INFO:\n";
            bool infoIsReached = false;
            if(infoIsOpened)
            {
                foreach(var cell in worksheet["B2:B14249"])
                {
                    if(cell.IntValue == portNumber)
                    {
                        infoIsReached = true;
                        info += $"Port " + cell.Text + $"\nService name: ";

                        if (worksheet.GetCellAt(cell.Address.LastRow , 0) == null)
                            info += "no info";
                        else if (worksheet.GetCellAt(cell.Address.LastRow , 0).IsEmpty)
                            info += "no info";
                        else
                            info += Convert.ToString(worksheet.GetCellAt(cell.Address.LastRow, 0).Value);

                        info += $"\nTransport protocol: ";
                        if (worksheet.GetCellAt(cell.Address.LastRow, 2) == null)
                            info += "no info";
                        else if (worksheet.GetCellAt(cell.Address.LastRow, 2).IsEmpty)
                            info += "no info";
                        else
                            info += Convert.ToString(worksheet.GetCellAt(cell.Address.LastRow, 2).Value);

                        info += $"\nDescription: ";
                        if (worksheet.GetCellAt(cell.Address.LastRow, 3) == null)
                            info += "no info";
                        else if (worksheet.GetCellAt(cell.Address.LastRow, 3).IsEmpty)
                            info += "no info";
                        else
                            info += Convert.ToString(worksheet.GetCellAt(cell.Address.LastRow, 3).Value);

                        info += $"\nAssignment Notes: ";
                        if (worksheet.GetCellAt(cell.Address.LastRow, 4) == null)
                            info += "no info";
                        else if (worksheet.GetCellAt(cell.Address.LastRow, 4).IsEmpty)
                            info += "no info";
                        else
                            info += Convert.ToString(worksheet.GetCellAt(cell.Address.LastRow, 4).Value);
                        info += $"\n";
                    }
                }
            }
            else
            {
                info = $"Can`not load info file";
            }
            return infoIsReached ? info : "Can`not find any info";
        }
    }
}
