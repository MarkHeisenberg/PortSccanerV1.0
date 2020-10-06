using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PortScaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static ParserForInput parserInput = new ParserForInput(); //Object for user input
        private static List<int> portsNumbers = new List<int>(); //List for user ports
        private static List<PortInformation> listOfScanningPort = new List<PortInformation>(); //Information about ports
        private static PortInformer portInformer = new PortInformer(); //Object for get information about port
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, "PShelp.chm"); //Open help file, must be in some directory with programm
            }
            catch (Exception)
            {
                MessageBox.Show("Can`not find file\"info.dat\"\nSorry, but I can not help you :(",
                    "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StartButton_Click(object sender, EventArgs e) // if start button presed
        {
            parserInput.InputString(inputTextForm.Text); //Parsing input
            portsNumbers = parserInput.GetListOfNumFromInput(); // Fill port numbers by user input
            listOfPorts.Items.Clear(); // Clear list of ports in GUI
            listOfScanningPort = portInformer.GetInformationByPortList(portsNumbers); // Fill information about ports
            
            // Fill info about ports
            foreach (var port in listOfScanningPort)
            {
                listOfPorts.Items.Add(port.information);
            }
        }

        private void listOfPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show info about selected item from file "info.dat"
            richTextBox1.Text = portInformer.GetInfoAboutPort(listOfScanningPort[listOfPorts.SelectedIndex].port);
        }
    }
}