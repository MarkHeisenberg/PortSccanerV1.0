using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PortScaner
{
    class ParserForInput
    {
        private static string inputData; // Input string

        public ParserForInput() //Constructor create empty string
        {
            inputData = string.Empty;
        }
        public void InputString(string inputString) // Filling string by parametr
        {
            inputData = inputString;
        }
        public List<int> GetListOfNumFromInput() // Parsing input
        {
            List<int> returnList = new List<int>(); // List of resultat
            string temp = string.Empty; // Temporatory string for algorithm 
            bool isRange = false; // Boolean for check range

            //Start parsing algorithm
            try
            {
                foreach (var item in inputData) //Get every char from string
                {
                    if (item == '-')
                    {
                        //If range was before
                        if (isRange == true)
                        {
                            MessageBox.Show("Not correct range!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            returnList.Clear();
                            return returnList;
                        }
                        //If range don`t use before
                        returnList.Add(Convert.ToInt32(temp));
                        temp = string.Empty;
                        isRange = true;
                    }
                    //If get comma, form integer and clear temp string
                    else if (item == ',')
                    {
                        returnList.Add(Convert.ToInt32(temp));
                        temp = string.Empty;
                    }
                    else
                    {
                        temp += item;
                    }
                }
                //If range 
                if (isRange)
                {
                    int fromNum = returnList.Last(); // Start range
                    int toNum = Convert.ToInt32(temp); //End range
                    while (fromNum < toNum)
                    {
                        //Fill list by range
                        fromNum++;
                        returnList.Add(fromNum);
                    }
                }
                else // if no range
                {
                    //add last value
                    returnList.Add(Convert.ToInt32(temp));
                }
            }
            //if user input somth wrong
            catch (Exception)
            {
                MessageBox.Show("Wrong user input!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return returnList;
        }
    }
}
