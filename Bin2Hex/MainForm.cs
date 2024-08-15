using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bin2Hex
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialogMain.InitialDirectory = Environment.CurrentDirectory;
            if (openFileDialogMain.ShowDialog() == DialogResult.OK)
            {
                string strBinaryFileNameAndPath = openFileDialogMain.FileName;
                string strBinaryFileName = openFileDialogMain.SafeFileName;
                string strHexFileNameAndPath = string.Format("{0}.hex", strBinaryFileNameAndPath);
                string strHexFileName = string.Format("{0}.hex", strBinaryFileName);

                byte[] byteBinaryFileContent = File.ReadAllBytes(strBinaryFileNameAndPath);
                int iBinaryFileLength = byteBinaryFileContent.Length;

                using (StreamWriter xStreamWriter = new StreamWriter(strHexFileNameAndPath))
                {
                    xStreamWriter.WriteLine("//********************************************************");
                    xStreamWriter.WriteLine("// Binary file coverter to Hex C structure");
                    xStreamWriter.WriteLine("// Version 1.00, (c) Evieplus");
                    xStreamWriter.WriteLine(string.Format("// Binary File Name    : {0}", strBinaryFileName));
                    xStreamWriter.WriteLine(string.Format("// Binary File Length  : {0}", iBinaryFileLength));
                    xStreamWriter.WriteLine("//********************************************************");
                    xStreamWriter.WriteLine("unsigned char ucaBin2Hex[]=");
                    xStreamWriter.WriteLine("{");

                    string strLineContent = "\t"; ;
                    byte byteValue = 0x00;

                    for (int iIndex = 0; iIndex < iBinaryFileLength; iIndex++)
                    {
                        if (checkBoxInverted.Checked == true)
                            byteValue = (byte)~byteBinaryFileContent[iIndex];
                        else
                            byteValue = byteBinaryFileContent[iIndex];

                        strLineContent += string.Format("0x{0:X02}, ", byteValue);

                        if ((iIndex + 1) % 16 == 0)
                        {
                            xStreamWriter.WriteLine(strLineContent);
                            strLineContent = "\t";
                        }
                    }

                    if (strLineContent != "\t")
                    {
                        xStreamWriter.WriteLine(strLineContent);
                    }

                    xStreamWriter.WriteLine("};");

                    MessageBox.Show("Converted");
                }

            }
            else
            {
                MessageBox.Show("Can not open file!");
            }
        }
    }
}
