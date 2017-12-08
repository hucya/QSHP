using QSHP.UI.Ctr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QSHP.UI
{
    public partial class MidScreen : BaseForm
    {
        public List<ButtonEx> BtArray = new List<ButtonEx>();
        public MidScreen()
        {
            InitializeComponent();
            LoadButtonList();
        }
        private void LoadButtonList()
        {
            BtArray.Clear();
            BtArray.Add(BT1);
            BtArray.Add(BT2);
            BtArray.Add(BT3);
            BtArray.Add(BT4);
            BtArray.Add(BT5);
            BtArray.Add(BT6);
            BtArray.Add(BT7);
            BtArray.Add(BT8);
        }
        public MidScreen(string name)
        {
            InitializeComponent();
            LoadButtonList();
            this.Text = name;
        }
        public MidScreen(string name, int couter)
        {
            InitializeComponent();
            LoadButtonList();
            this.Text = name;
            for (int i = 0; i < BtArray.Count; i++)
            {
                BtArray[i].Visible = i < couter;
            }
        }

    }
}
