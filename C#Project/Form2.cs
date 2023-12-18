using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Project
{
    public partial class Form2 : Form
    {
        private const string filePath = "users.txt";
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (CheckCredentials(username, password))
            {
                MessageBox.Show("Login successful!");
                
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }

        private bool CheckCredentials(string username, string password)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|'); 
                    if (parts.Length == 2 && parts[0] == username && parts[1] == password)
                    {
                        return true; 
                    }
                }
            }
            return false;
        }

       
        private void label3_Click(object sender, EventArgs e)
        {
            Form1 signupForm = new Form1();
            signupForm.ShowDialog();
        }
    }
    }

