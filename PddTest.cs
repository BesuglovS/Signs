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
    public partial class PddTest : Form
    {
        readonly List<PddItem> _list = new List<PddItem>();
        private PddItem item;
        private int mode;

        private List<CheckBox> _cbList
            ;
        public PddTest()
        {
            InitializeComponent();
        }

        private void showAnswer_Click(object sender, EventArgs e)
        {
            description.Clear();
            description.AppendText(item.Description);
        }

        private void PddTest_Load(object sender, EventArgs e)
        {
            _cbList = new List<CheckBox>()
            {
                pdd01, pdd02, pdd03, pdd04, pdd05, pdd06, pdd07, pdd08, pdd09, pdd10,
                pdd11, pdd12, pdd13, pdd14, pdd15, pdd16, pdd17, pdd18, pdd19, pdd20,
                pdd21, pdd22, pdd23, pdd24, pdd25, pdd26
            };
            LoadInfo();
            ShowCase();
        }

        private void ShowCase()
        {
            var r = new Random();
            List<PddItem> l = (onlyImportant.Checked) ?
                _list.Where(d => d.Important).ToList() :
                _list;
            l = l.Where(elem => (_cbList.Select(cb => cb.Checked).ToList())
                [int.Parse(elem.Id.Split('.')[0]) - 1]).ToList();
            if (l.Count > 0)
            {
                item = l[r.Next(l.Count)];
                term.Text = item.Id;
                mode = 0;
            }
        }

        private void LoadInfo()
        {
            _list.Clear();

            using (StreamReader sr = new StreamReader("data\\pdd.txt"))
            {
                string line;
                int mode = 1;
                Boolean important = false;
                PddItem newItem = new PddItem();
                while ((line = sr.ReadLine()) != null)
                {
                    switch (mode)
                    {
                        case 1:
                            important = (line == "***!");

                            mode = 2;
                            break;
                        case 2:
                            newItem = new PddItem();
                            newItem.Id = line;
                            mode = 3;
                            break;

                        case 3:
                            var desc = line + Environment.NewLine;
                            while (((line = sr.ReadLine()) != null) &&
                                   (line.Trim() != "***") &&
                                   (line.Trim() != "***!"))
                            {
                                if ((line.Trim() != "***") && (line.Trim() != "***!"))
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

        private void PddTest_KeyDown(object sender, KeyEventArgs e)
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
