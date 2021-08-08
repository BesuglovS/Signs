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
using Signs.domain;

namespace Signs
{
    public partial class Definitions : Form
    {
        readonly List<Definition> _list = new List<Definition>();
        private Definition item;
        private int mode;

        public Definitions()
        {
            InitializeComponent();
        }

        private void showAnswer_Click(object sender, EventArgs e)
        {
            description.Clear();
            description.AppendText(item.Description);
        }

        private void Definitions_Load(object sender, EventArgs e)
        {
            LoadInfo();
            ShowCase();
        }

        private void ShowCase()
        {
            var r = new Random();
            List<Definition> l = (onlyImportant.Checked) ? 
                _list.Where(d => d.Important).ToList() : 
                _list;
            item = l[r.Next(l.Count)];
            term.Text = item.Term;
            mode = 0;
        }

        private void LoadInfo()
        {
            _list.Clear();

            using (StreamReader sr = new StreamReader("data\\defs.txt"))
            {
                string line;
                int mode = 1;
                Boolean important = false;
                Definition newItem = new Definition();
                while ((line = sr.ReadLine()) != null)
                {
                    switch (mode)
                    {
                        case 1:
                            line = sr.ReadLine();
                            important = (line == "***!");

                            mode = 2;
                            break;
                        case 2:
                            newItem = new Definition();
                            newItem.Term = line;
                            mode = 3;
                            break;

                        case 3:
                            var desc = line + Environment.NewLine;
                            while (((line = sr.ReadLine()) != null) && 
                                   (line != "***") &&
                                   (line != "***!"))
                            {
                                if ((line != "***") && (line != "***!"))
                                {
                                    desc += line + Environment.NewLine;
                                }
                            }
                            
                            newItem.Description = desc;
                            newItem.Important = important;

                            _list.Add(newItem);

                            important = (line == "***!");
                            mode = 2;
                            break;
                    }
                }
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            description.Clear();
            ShowCase();
        }

        private void Definitions_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            switch (key)
            {
                case Keys.Space:
                    switch (mode)
                    {
                        case 0:
                            showAnswer.PerformClick();
                            mode = 1;
                            break;
                        case 1:
                            next.PerformClick();
                            mode = 0;
                            break;
                    }
                    break;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void term_TextChanged(object sender, EventArgs e)
        {

        }

        private void description_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void onlyImportant_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
