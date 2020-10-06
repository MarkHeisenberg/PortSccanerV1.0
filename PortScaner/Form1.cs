using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace PortScaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<int> portsNumbers = new List<int>();
        private static List<PortInformation> listOfScanningPort = new List<PortInformation>();
        private static PortInformer portInformer;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            ParserForInput parserInput = new ParserForInput();
            parserInput.InputString(inputTextForm.Text);
            portsNumbers = parserInput.GetListOfNumFromInput();
            listOfPorts.Items.Clear();
            portInformer = new PortInformer();
            listOfScanningPort = portInformer.GetInformationByPortList(portsNumbers);
            foreach (var port in listOfScanningPort)
            {
                listOfPorts.Items.Add(port.information);
            }
        }

        private void listOfPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = portInformer.GetInfoAboutPort(listOfScanningPort[listOfPorts.SelectedIndex].port);
        }
    }
}