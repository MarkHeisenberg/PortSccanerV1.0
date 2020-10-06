using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortScaner
{
    class ParserForInput
    {
        private static string inputData;
        
        public ParserForInput()
        {
            inputData = string.Empty;
        }
        public void InputString( string inputString)
        {
            inputData = inputString;
        }
        public List<int> GetListOfNumFromInput()
        {
            List<int> returnList = new List<int>();
            string temp = string.Empty;
            bool isRange = false;
            try
            {
                foreach (var item in inputData)
                {
                    if (item == '-')
                    {
                        if(isRange == true)
                        {
                            MessageBox.Show("Not correct range!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            returnList.Clear();
                            return returnList;
                        }
                        returnList.Add(Convert.ToInt32(temp));
                        temp = string.Empty;
                        isRange = true;
                    }
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

                if (isRange)
                {
                    int fromNum = returnList.Last();
                    int toNum = Convert.ToInt32(temp);
                    while(fromNum < toNum)
                    {
                        fromNum++;
                        returnList.Add(fromNum);
                    }
                }
                else
                {
                    returnList.Add(Convert.ToInt32(temp));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Wrong user input!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return returnList;
        }
    }
}
