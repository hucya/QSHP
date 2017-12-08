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
    public partial class LogerViewManager : BaseForm
    {
        List<CmdOles> cmds=new List<CmdOles>();
        string tabName;
        int leaveIndex = 0;
        int typeIndex = 0;
        int rowIndex = 0;
        int maxRowCount = 16;
        public LogerViewManager()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                InitLogerView();
                Common.ReportCmdKeyProgress(CmdKey.S0039);
                if (Globals.MacData.LogDropMode == 1 && Globals.UserLeave > 1)
                {
                    BT1Content = "删除日志";
                    BT1Click += LogerViewManager_BT1Click;
                }
                rowIndex = 0;
            }
            
        }
        private void InitLogerView()
        {
            dateList.Items.Clear();
            tabName = DateTime.Now.ToString("yyyyMMdd");
            cmds = LogHelper.GetLogerTable(tabName);
            logGridView.DataSource = cmds;
            dateList.Items.AddRange(LogHelper.GetTableNames().OrderByDescending(s => s).ToArray());
            dateList.Text = tabName;
            logLeaveList.SelectedIndex = 0;
            LogTypeList.SelectedIndex = 0;
        }
        private void LogerViewManager_BT1Click(object sender, EventArgs e)
        {
            if (!tabName.Equals(DateTime.Now.ToString("yyyyMMdd")))
            {
                LogHelper.DeleteLogerTable(tabName);
                InitLogerView();
                Common.ReportCmdKeyProgress(CmdKey.S0037);
            }
            else
            {
                Common.ReportCmdKeyProgress(CmdKey.S0038);
            }
            rowIndex = 0;
        }

        private void ChangeTable_Click(object sender, EventArgs e)
        {
            if (dateList.Text != tabName)
            {
                rowIndex = 0;
                tabName = dateList.Text;
                cmds = LogHelper.GetLogerTable(tabName);
                logGridView.DataSource = cmds;
                leaveIndex = 0;
                logLeaveList.SelectedIndex = leaveIndex;
                typeIndex = 0;
                LogTypeList.SelectedIndex = 0;
            }
        }

        private void ChangeLeaveBt_Click(object sender, EventArgs e)
        {
            if (logLeaveList.SelectedIndex != leaveIndex)
            {
                rowIndex = 0;
                leaveIndex = logLeaveList.SelectedIndex;
                switch (leaveIndex)
                {
                    case 0:
                        {
                            logGridView.DataSource = cmds;
                        } break;
                    default:
                        {
                            CmdLeave leave = (CmdLeave)leaveIndex;
                            logGridView.DataSource = cmds.Where(d=>d.Leave==leave).ToList();
                        }
                        break;
                }
                typeIndex = 0;
                LogTypeList.SelectedIndex = 0;
            }
        }

        private void ChangeTypeBt_Click(object sender, EventArgs e)
        {
            if (LogTypeList.SelectedIndex != typeIndex)
            {
                typeIndex = LogTypeList.SelectedIndex;
                rowIndex = 0;
                switch (typeIndex)
                {
                    case 1: //系统操作
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key<CmdKey.S0100).ToList();
                        } break;
                    case 2://初始化
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key > CmdKey.S0099&&d.Key<CmdKey.S0200).ToList();
                        } break;
                    case 3://电气硬件
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key >= CmdKey.S0200 && d.Key < CmdKey.P0100).ToList();
                        } break;
                    case 4://测高操作
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key >= CmdKey.H0000 && d.Key <= CmdKey.H0010).ToList();
                        } break;
                    case 5://程序操作
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key >= CmdKey.P0100 && d.Key <= CmdKey.P0311).ToList();
                        } break;
                    case 6://对准操作
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key >= CmdKey.A0001 && d.Key <= CmdKey.A0030).ToList();
                        } break;
                    case 7://文件操作
                        {
                            logGridView.DataSource = cmds.Where(d => d.Key >= CmdKey.F0001 && d.Key <= CmdKey.F0050).ToList();
                        } break;
                    default:
                        {
                            logGridView.DataSource = cmds;
                        }
                        break;
                }
                leaveIndex = 0;
                logLeaveList.SelectedIndex = 0;
            }
        }

        private void LogerViewManager_ConfirmClick(object sender, EventArgs e)
        {
            if (rowIndex < logGridView.RowCount - maxRowCount)
            {
                rowIndex += maxRowCount;
                logGridView.CurrentCell = logGridView.Rows[rowIndex].Cells[0];
            }
            else
            {
                rowIndex = logGridView.RowCount - 1;
                logGridView.CurrentCell = logGridView.Rows[rowIndex].Cells[0]; 
            }
        }

        private void LogerViewManager_NextClick(object sender, EventArgs e)
        {
            if (rowIndex - maxRowCount > 0)
            {
                rowIndex -= maxRowCount;
                logGridView.CurrentCell = logGridView.Rows[rowIndex].Cells[0];
            }
            else
            {
                logGridView.CurrentCell = logGridView.Rows[0].Cells[0];
            }
        }

        private void logGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            rowIndex = e.RowIndex;
        }
    }
}
