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
    public partial class Form1 : Form
    {
        private const string filePath = "users.txt"; // File to store user credentials
        public Form1()
        {
            InitializeComponent();
        }



        private void button_click (object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                if (CreateUser(username, password))
                {
                    MessageBox.Show("Signup successful! You can now log in.");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username already exists. Please choose a different username.");
                }
            }
            else
            {
                MessageBox.Show("Please enter both username and password.");
            }
        }

        private bool CreateUser(string username, string password)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            
            string[] existingUsers = File.ReadAllLines(filePath);
            foreach (string line in existingUsers)
            {
                string[] parts = line.Split('|');
                if (parts.Length > 0 && parts[0] == username)
                {
                    return false;
                }
            }

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(username + "|" + password);
            }

            return true; 
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form2 signupForm = new Form2();
            signupForm.ShowDialog();
        }
    }
}
