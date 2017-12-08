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
    public partial class DataManager : BaseForm
    {
        private FileStyle style = FileStyle.Stand;
        public DataManager()
        {
            InitializeComponent();
        }
        public DataManager(string text)
        {
            InitializeComponent();
            this.Text = text;
        }

        public DataManager(string text,FileStyle style)
        {
            InitializeComponent();
            this.Text = text;
            Style = style;
        }
        public FileStyle Style
        {
            get
            {
                return style;
            }
            set
            {
                style = value;
                switch (value)
                {
                    case FileStyle.AnyCh:
                        {
                            tabControlEx1.SelectedIndex = 2;
                        }
                        break;
                    case FileStyle.MulStep:
                        {
                            tabControlEx1.SelectedIndex = 1;
                        }
                        break;
                    case FileStyle.QFN:
                        {
                            tabControlEx1.SelectedIndex = 3;
                        }
                        break;
                    case FileStyle.PreCut:
                        {
                            tabControlEx1.SelectedIndex = 0;
                        }
                        break;
                    default:
                        {
                            tabControlEx1.SelectedIndex = 0;
                        }
                        break;
                }
            }
        }
    }
}
