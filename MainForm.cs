using Signs.domain;
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

namespace Signs
{
    public partial class MainForm : Form
    {
        readonly List<Sign> _list = new List<Sign>();
        int correctAnswer = -1;
        List<Sign> options;        
        const string BasePath = @"";
        private List<CheckBox> _cbList;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _cbList = new List<CheckBox>()
            {
                signs1, signs2, signs3, signs4, signs5, signs6, signs7, signs8
            };

            LoadInfo();
            ShowCase();
        }

        private void ShowCase()
        {
            var r = new Random();

            var _l = _list.Where(elem => (_cbList.Select(cb => cb.Checked).ToList())
                [int.Parse(elem.SignId.Split('.')[0]) - 1]).ToList();
            if (_l.Count == 0) return;

            var answer = _l[r.Next(_l.Count)];
            options = new List<Sign>();
            options.Add(answer);

            var wrongOptions = _list
                .GroupBy(item => item.Name)
                .Select(gr => gr.First())
                .Where(s => s.Name != answer.Name)
                .OrderBy(x => r.Next()).Take(5);

            options.AddRange(wrongOptions);
            options = options.OrderBy(x => r.Next()).ToList();

            correctAnswer = options.FindIndex(x => x.Name == answer.Name);


            signPic.Image = Image.FromFile("data\\pics\\png\\" + answer.Filename);
            signId.Text = answer.SignId;

            button1.Text = options[0].Name;
            button2.Text = options[1].Name;
            button3.Text = options[2].Name;
            button4.Text = options[3].Name;
            button5.Text = options[4].Name;
            button6.Text = options[5].Name;
        }

        private void LoadInfo()
        {
            _list.Clear();

            using (StreamReader sr = new StreamReader("data\\signs.txt"))
            {
                string line;
                int mode = 1;
                Sign newItem = new Sign();
                while ((line = sr.ReadLine()) != null)
                {
                    switch (mode) {
                        case 1:                        
                            line = line.Substring(5);
                            newItem = new Sign();
                            newItem.SignId = line;
                            newItem.Filename = line + ".png";
                            mode = 2;
                            break;

                        case 2:                        
                            newItem.Name = line;
                            mode = 3;
                            break;

                        case 3:
                            var desc = line + Environment.NewLine;
                            while (((line = sr.ReadLine()) != null) && (line != "***"))
                            {
                                if (line != "***")
                                {
                                    desc += line + Environment.NewLine;
                                }
                            }

                            newItem.Description = desc;

                            _list.Add(newItem);
                            mode = 1;
                            break;                        
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GotAnswer(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GotAnswer(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GotAnswer(2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GotAnswer(3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GotAnswer(4);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GotAnswer(5);
        }

        private void GotAnswer(int answerId)
        {
            if (answerId == correctAnswer)
            {
                labelResult.Text = "OK. " + options[correctAnswer].Name;
            } else
            {
                labelResult.Text = "Нет. "  + options[correctAnswer].Name;
            }

            signInfo.Clear();
            signInfo.AppendText(options[correctAnswer].Description);

            next.Visible = true;
            next.Focus();
        }

        private void next_Click(object sender, EventArgs e)
        {
            labelResult.Text = "";
            next.Visible = false;
            ShowCase();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyCode;
            switch (key)
            {
                case Keys.NumPad1:
                    button1.PerformClick();
                    break;
                case Keys.NumPad2:
                    button2.PerformClick();
                    break;
                case Keys.NumPad3:
                    button3.PerformClick();
                    break;
                case Keys.NumPad4:
                    button4.PerformClick();
                    break;
                case Keys.NumPad5:
                    button5.PerformClick();
                    break;
                case Keys.NumPad6:
                    button6.PerformClick();
                    break;
                case Keys.Enter:
                    next.PerformClick();
                    break;
            }
        }

        private void определения12ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var defForm = new Definitions();
            defForm.Show();
        }

        private void пДДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var pddForm = new PddTest();
            pddForm.Show();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            foreach (var cb in _cbList)
            {
                cb.Checked = false;
            }
        }

        private void selectAll_Click(object sender, EventArgs e)
        {
            foreach (var cb in _cbList)
            {
                cb.Checked = true;
            }
        }

        private void UntilLastSelected_Click(object sender, EventArgs e)
        {
            var lastIndex = -1;

            for (int i = 0; i < _cbList.Count; i++)
            {
                if (_cbList[i].Checked)
                {
                    lastIndex = i;
                }
            }

            if (lastIndex != -1)
            {
                for (int i = 0; i < lastIndex; i++)
                {
                    _cbList[i].Checked = true;
                }
            }
        }
    }
}
