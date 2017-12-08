using QSHP.UI.Ctr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QSHP.Data;
using System.Drawing;
using System.IO;
using QSHP.HW.AmpC;
using QSHP.HW.Video;
using QSHP.UI.Manual;
using QSHP.UI;
using QSHP.UI.Bld;
using System.Security.Cryptography;
using System.Threading;
using QSHP.Com;
using System.Diagnostics;

namespace QSHP.UI
{
    public class HomeScreen : BaseForm
    {
        #region 自动生成
        private System.Windows.Forms.TableLayoutPanel cyoutPanel;
        private ButtonEx bT1;
        private System.ComponentModel.IContainer components;
        private ButtonEx bT2;
        private ButtonEx bT3;
        private ButtonEx bT4;
        private ButtonEx bT6;
        private ButtonEx bT7;
        private Panel panel1;
        private Label managerLable;
        private Label label1;
        private ButtonEx bT8;
        private TextBoxEx passwordEdit;
        private Label label2;
        private TabControlEx tBb1;
        private TabPage passwordPage;
        private TabPage usedTimePage;
        private Label label3;
        private Label usedTime;
        private ButtonEx bT5;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cyoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bT1 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.bT2 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.bT3 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.bT4 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.bT5 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.bT6 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.bT7 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tBb1 = new QSHP.UI.Ctr.TabControlEx();
            this.passwordPage = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordEdit = new QSHP.UI.Ctr.TextBoxEx();
            this.usedTimePage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.usedTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.managerLable = new System.Windows.Forms.Label();
            this.bT8 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.cyoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tBb1.SuspendLayout();
            this.passwordPage.SuspendLayout();
            this.usedTimePage.SuspendLayout();
            this.SuspendLayout();
            // 
            // cyoutPanel
            // 
            this.cyoutPanel.ColumnCount = 6;
            this.cyoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.cyoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cyoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cyoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cyoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.cyoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.cyoutPanel.Controls.Add(this.bT1, 1, 1);
            this.cyoutPanel.Controls.Add(this.bT2, 2, 1);
            this.cyoutPanel.Controls.Add(this.bT3, 3, 1);
            this.cyoutPanel.Controls.Add(this.bT4, 4, 1);
            this.cyoutPanel.Controls.Add(this.bT5, 1, 2);
            this.cyoutPanel.Controls.Add(this.bT6, 2, 2);
            this.cyoutPanel.Controls.Add(this.bT7, 3, 2);
            this.cyoutPanel.Controls.Add(this.panel1, 3, 3);
            this.cyoutPanel.Controls.Add(this.bT8, 4, 2);
            this.cyoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cyoutPanel.Location = new System.Drawing.Point(0, 0);
            this.cyoutPanel.Name = "cyoutPanel";
            this.cyoutPanel.RowCount = 4;
            this.cyoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.cyoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cyoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.cyoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.cyoutPanel.Size = new System.Drawing.Size(815, 495);
            this.cyoutPanel.TabIndex = 0;
            // 
            // bT1
            // 
            this.bT1.BackColor = System.Drawing.SystemColors.Control;
            this.bT1.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT1.Flag = 0;
            this.bT1.FlatAppearance.BorderSize = 0;
            this.bT1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT1.LED = false;
            this.bT1.LedLocation = new System.Drawing.Point(4, -10);
            this.bT1.Location = new System.Drawing.Point(62, 32);
            this.bT1.Margin = new System.Windows.Forms.Padding(15);
            this.bT1.Name = "bT1";
            this.bT1.NumText = "01";
            this.bT1.Pressed = false;
            this.bT1.Size = new System.Drawing.Size(149, 141);
            this.bT1.TabIndex = 0;
            this.bT1.TabStop = false;
            this.bT1.UsedLed = false;
            this.bT1.UseVisualStyleBackColor = false;
            // 
            // bT2
            // 
            this.bT2.BackColor = System.Drawing.SystemColors.Control;
            this.bT2.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT2.Flag = 0;
            this.bT2.FlatAppearance.BorderSize = 0;
            this.bT2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT2.LED = false;
            this.bT2.LedLocation = new System.Drawing.Point(4, -10);
            this.bT2.Location = new System.Drawing.Point(241, 32);
            this.bT2.Margin = new System.Windows.Forms.Padding(15);
            this.bT2.Name = "bT2";
            this.bT2.NumText = "02";
            this.bT2.Pressed = false;
            this.bT2.Size = new System.Drawing.Size(149, 141);
            this.bT2.TabIndex = 1;
            this.bT2.TabStop = false;
            this.bT2.UsedLed = false;
            this.bT2.UseVisualStyleBackColor = false;
            // 
            // bT3
            // 
            this.bT3.BackColor = System.Drawing.SystemColors.Control;
            this.bT3.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT3.Flag = 0;
            this.bT3.FlatAppearance.BorderSize = 0;
            this.bT3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT3.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT3.LED = false;
            this.bT3.LedLocation = new System.Drawing.Point(4, -10);
            this.bT3.Location = new System.Drawing.Point(420, 32);
            this.bT3.Margin = new System.Windows.Forms.Padding(15);
            this.bT3.Name = "bT3";
            this.bT3.NumText = "03";
            this.bT3.Pressed = false;
            this.bT3.Size = new System.Drawing.Size(149, 141);
            this.bT3.TabIndex = 2;
            this.bT3.TabStop = false;
            this.bT3.UsedLed = false;
            this.bT3.UseVisualStyleBackColor = false;
            // 
            // bT4
            // 
            this.bT4.BackColor = System.Drawing.SystemColors.Control;
            this.bT4.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT4.Flag = 0;
            this.bT4.FlatAppearance.BorderSize = 0;
            this.bT4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT4.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT4.LED = false;
            this.bT4.LedLocation = new System.Drawing.Point(4, -10);
            this.bT4.Location = new System.Drawing.Point(599, 32);
            this.bT4.Margin = new System.Windows.Forms.Padding(15);
            this.bT4.Name = "bT4";
            this.bT4.NumText = "04";
            this.bT4.Pressed = false;
            this.bT4.Size = new System.Drawing.Size(149, 141);
            this.bT4.TabIndex = 3;
            this.bT4.TabStop = false;
            this.bT4.UsedLed = false;
            this.bT4.UseVisualStyleBackColor = false;
            // 
            // bT5
            // 
            this.bT5.BackColor = System.Drawing.SystemColors.Control;
            this.bT5.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT5.Flag = 0;
            this.bT5.FlatAppearance.BorderSize = 0;
            this.bT5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT5.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT5.LED = false;
            this.bT5.LedLocation = new System.Drawing.Point(4, -10);
            this.bT5.Location = new System.Drawing.Point(62, 198);
            this.bT5.Margin = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.bT5.Name = "bT5";
            this.bT5.NumText = "05";
            this.bT5.Pressed = false;
            this.bT5.Size = new System.Drawing.Size(149, 146);
            this.bT5.TabIndex = 4;
            this.bT5.TabStop = false;
            this.bT5.UsedLed = false;
            this.bT5.UseVisualStyleBackColor = false;
            // 
            // bT6
            // 
            this.bT6.BackColor = System.Drawing.SystemColors.Control;
            this.bT6.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT6.Flag = 0;
            this.bT6.FlatAppearance.BorderSize = 0;
            this.bT6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT6.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT6.LED = false;
            this.bT6.LedLocation = new System.Drawing.Point(4, -10);
            this.bT6.Location = new System.Drawing.Point(241, 198);
            this.bT6.Margin = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.bT6.Name = "bT6";
            this.bT6.NumText = "06";
            this.bT6.Pressed = false;
            this.bT6.Size = new System.Drawing.Size(149, 146);
            this.bT6.TabIndex = 5;
            this.bT6.TabStop = false;
            this.bT6.UsedLed = false;
            this.bT6.UseVisualStyleBackColor = false;
            // 
            // bT7
            // 
            this.bT7.BackColor = System.Drawing.SystemColors.Control;
            this.bT7.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT7.Flag = 0;
            this.bT7.FlatAppearance.BorderSize = 0;
            this.bT7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT7.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT7.LED = false;
            this.bT7.LedLocation = new System.Drawing.Point(4, -10);
            this.bT7.Location = new System.Drawing.Point(420, 198);
            this.bT7.Margin = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.bT7.Name = "bT7";
            this.bT7.NumText = "07";
            this.bT7.Pressed = false;
            this.bT7.Size = new System.Drawing.Size(149, 146);
            this.bT7.TabIndex = 6;
            this.bT7.TabStop = false;
            this.bT7.UsedLed = false;
            this.bT7.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.cyoutPanel.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.tBb1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.managerLable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(408, 362);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 130);
            this.panel1.TabIndex = 7;
            // 
            // tBb1
            // 
            this.tBb1.Controls.Add(this.passwordPage);
            this.tBb1.Controls.Add(this.usedTimePage);
            this.tBb1.ItemSize = new System.Drawing.Size(1, 1);
            this.tBb1.Location = new System.Drawing.Point(21, 47);
            this.tBb1.Name = "tBb1";
            this.tBb1.SelectedIndex = 0;
            this.tBb1.Size = new System.Drawing.Size(328, 82);
            this.tBb1.TabIndex = 7;
            // 
            // passwordPage
            // 
            this.passwordPage.BackColor = System.Drawing.SystemColors.Control;
            this.passwordPage.Controls.Add(this.label2);
            this.passwordPage.Controls.Add(this.passwordEdit);
            this.passwordPage.Location = new System.Drawing.Point(4, 5);
            this.passwordPage.Name = "passwordPage";
            this.passwordPage.Padding = new System.Windows.Forms.Padding(3);
            this.passwordPage.Size = new System.Drawing.Size(320, 73);
            this.passwordPage.TabIndex = 0;
            this.passwordPage.Text = "tabPage1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "用户密码：";
            // 
            // passwordEdit
            // 
            this.passwordEdit.BackColor = System.Drawing.SystemColors.Window;
            this.passwordEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.passwordEdit.Location = new System.Drawing.Point(165, 7);
            this.passwordEdit.MaxLength = 10;
            this.passwordEdit.Name = "passwordEdit";
            this.passwordEdit.PasswordChar = '*';
            this.passwordEdit.SetError = false;
            this.passwordEdit.SetWarn = false;
            this.passwordEdit.Size = new System.Drawing.Size(149, 29);
            this.passwordEdit.TabIndex = 5;
            this.passwordEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordEdit.WordWrap = false;
            // 
            // usedTimePage
            // 
            this.usedTimePage.BackColor = System.Drawing.SystemColors.Control;
            this.usedTimePage.Controls.Add(this.label3);
            this.usedTimePage.Controls.Add(this.usedTime);
            this.usedTimePage.Location = new System.Drawing.Point(4, 5);
            this.usedTimePage.Name = "usedTimePage";
            this.usedTimePage.Padding = new System.Windows.Forms.Padding(3);
            this.usedTimePage.Size = new System.Drawing.Size(320, 73);
            this.usedTimePage.TabIndex = 1;
            this.usedTimePage.Text = "tabPage2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "操作用时：";
            // 
            // usedTime
            // 
            this.usedTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.usedTime.Font = new System.Drawing.Font("QSHP", 20F);
            this.usedTime.Location = new System.Drawing.Point(165, 7);
            this.usedTime.Name = "usedTime";
            this.usedTime.Size = new System.Drawing.Size(149, 29);
            this.usedTime.TabIndex = 1;
            this.usedTime.Text = "00:00:00";
            this.usedTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户类型：";
            // 
            // managerLable
            // 
            this.managerLable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.managerLable.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.managerLable.Location = new System.Drawing.Point(191, 9);
            this.managerLable.Name = "managerLable";
            this.managerLable.Size = new System.Drawing.Size(149, 34);
            this.managerLable.TabIndex = 1;
            this.managerLable.Text = "操作人员";
            this.managerLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bT8
            // 
            this.bT8.BackColor = System.Drawing.SystemColors.Control;
            this.bT8.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.bT8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bT8.Flag = 0;
            this.bT8.FlatAppearance.BorderSize = 0;
            this.bT8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bT8.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bT8.LED = false;
            this.bT8.LedLocation = new System.Drawing.Point(4, -10);
            this.bT8.Location = new System.Drawing.Point(599, 198);
            this.bT8.Margin = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.bT8.Name = "bT8";
            this.bT8.NumText = "08";
            this.bT8.Pressed = false;
            this.bT8.Size = new System.Drawing.Size(149, 146);
            this.bT8.TabIndex = 8;
            this.bT8.TabStop = false;
            this.bT8.UsedLed = false;
            this.bT8.UseVisualStyleBackColor = false;
            // 
            // HomeScreen
            // 
            this.BtStyle = QSHP.UI.UnderStyle.Default;
            this.CancelText = "菜  单";
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.cyoutPanel);
            this.FmStyle = QSHP.FormStyle.PathModeCancel;
            this.Name = "HomeScreen";
            this.Text = "主界面";
            this.CancelClick += new System.EventHandler(this.HomeScreen_CancelClick);
            this.AutoUpdateEventHander += new System.EventHandler(this.HomeScreen_AutoUpdataEventHander);
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.cyoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tBb1.ResumeLayout(false);
            this.passwordPage.ResumeLayout(false);
            this.passwordPage.PerformLayout();
            this.usedTimePage.ResumeLayout(false);
            this.usedTimePage.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        List<FormArg> bTargs = new List<FormArg>();
        List<ButtonEx> bTs = new List<ButtonEx>();
        string[] manager = { "操作人员", "设备管理员", "系统管理员" };
        Stopwatch watch = new Stopwatch();
        public HomeScreen()
        {
            InitializeComponent();
            if (!DesignMode)
            {
                watch.Restart();
            }
        }

        private void AutoManual_Click(object sender, EventArgs e)
        {
            MidScreen form = new MidScreen("全自动", 3);
            form.BtArray[0].Text = "全自动划切";
            form.BtArray[1].Text = "教   学";
            form.BtArray[2].Text = "对   准";
            ParentForm.PushChildForm(form);
        }

        private void Manual_Click(object sender, EventArgs e)
        {
            MidScreen form = new MidScreen("手动操作", 3);
            form.BtArray[0].Text = "半自动划切";
            form.BtArray[1].Text = "手动划切";
            form.BtArray[2].Text = "测  量";
            form.BtArray[0].Click += delegate (Object se, System.EventArgs arg)
            {
                //if (!Globals.DebugMode)
                //{
                //    if (!Globals.IsInit)//确保系统进行初始化操作
                //    {
                //        Common.ReportCmdKeyProgress(CmdKey.S0104);
                //        return;
                //    }
                //    if (!Globals.TestedHeight)
                //    {
                //        Common.ReportCmdKeyProgress(CmdKey.H0010);
                //        return;u
                //    }
                //    if (!Globals.BladeData.ReadyTest)
                //    {
                //        Common.ReportCmdKeyProgress(CmdKey.B0015);
                //        return;
                //    }
                //}
                ParentForm.ReplaceChildForm(new CutAlignManager());

            };
            ParentForm.PushChildForm(form, true);
        }

        private void CutParameter_Click(object sender, EventArgs e)
        {
            FileManager fileForm = new FileManager(FileStyle.CutFile, Globals.AppCfg.CutFileFullName);
            ParentForm.PushChildForm(fileForm);
        }

        private void BladeMaintain_Click(object sender, EventArgs e)
        {
            int n = Globals.BladeCheck ? 7 : 6;//是否支持刀破检测
            MidScreen form = new MidScreen("刀具管理", n);
            form.BtArray[0].Text = "刀具信息";
            form.BtArray[1].Text = "换  刀";
            form.BtArray[2].Text = "测  高";
            form.BtArray[3].Text = "测高参数";
            form.BtArray[4].Text = "基准线调整";
            form.BtArray[5].Text = "刀具管理";
            form.BtArray[6].Text = "刀破检测";
            form.BtArray[0].Click += delegate (Object se, System.EventArgs arg)
            {
                ParentForm.PushChildForm(new BladeMessageFrom());
            };
            form.BtArray[1].Click += delegate (Object se, System.EventArgs arg)
            {
                if (Common.SPD != null)
                {
                    if (Common.SPD.SpeedZore)
                    {
                        ParentForm.PushChildForm(new BladeRepalceManager());
                    }
                    else
                    {
                        Common.SPD.StopSpd();//关闭主轴
                        Common.ReportCmdKeyProgress(CmdKey.S0607);
                        if (!Globals.DevData.ReplaceBldXNoMove)
                        {
                            Common.X_Axis.AxisJogAbsWork(Globals.DevData.ReplaceBldXPos);
                        }
                        Common.Y_Axis.AxisJogAbsWork(Globals.DevData.ReplaceBldYPos);
                        Common.Z_Axis.AxisJogAbsWork(Globals.DevData.ReplaceBldZPos);
                        //判断是否开启主轴锁
                    }
                }

            };
            form.BtArray[2].Click += delegate (Object se, System.EventArgs arg)
            {
                if (Globals.NoTouchTest)
                {
                    MidScreen f = new MidScreen("测  高", 3);
                    f.BtArray[0].Text = "接触式测高";
                    f.BtArray[1].Text = "非接触测高";
                    f.BtArray[2].Text = "NCS 校正";
                    f.BtArray[0].Click += delegate (Object s, System.EventArgs a)
                    {
                        ParentForm.PushChildForm(new BladeTestHeightManager(0));
                    };
                    f.BtArray[1].Click += delegate (Object s, System.EventArgs a)
                    {
                        ParentForm.PushChildForm(new BladeTestHeightManager(1));
                    };
                    f.BtArray[2].Click += delegate (Object s, System.EventArgs a)
                    {
                        ParentForm.PushChildForm(new BladeTestHeightManager(2));
                    };
                    ParentForm.PushChildForm(f);
                }
                else
                {
                    ParentForm.PushChildForm(new BladeTestHeightManager());
                }
            };
            form.BtArray[3].Click += delegate (Object se, System.EventArgs arg)
             {
                 ParentForm.PushChildForm(new BladeTestDataManager());
             };
            form.BtArray[5].Click += delegate (Object se, System.EventArgs arg)
            {
                ParentForm.PushChildForm(new BladeFileManager());
            };
            ParentForm.PushChildForm(form);
        }

        private void OperMaintain_Click(object sender, EventArgs e)
        {
            int n = Globals.AutoFource ? 4 : 3;
            MidScreen form = new MidScreen("操作维护", n);
            form.BtArray[0].Text = "功能参数";
            form.BtArray[1].Text = "工程维护";
            form.BtArray[2].Text = "外部存储";
            form.BtArray[3].Text = "焦距维护";
            form.BtArray[2].Click += delegate (Object se, System.EventArgs arg)
            {
                bool flag = ProcessCmd.HasMoveHardDisk();
                if (flag)
                {

                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.F0049);
                }
            };
            ParentForm.PushChildForm(form);
        }

        private void DevCfgButton_Click(object sender, EventArgs e)
        {
            if (Globals.UserLeave != 1)
            {
                Globals.UserLeave = 1;
                tBb1.SelectedIndex = 0;
                Common.ReportCmdKeyProgress(CmdKey.S0030);
            }
            else
            {
                //需要检验设备参数密码
                if (CheckMaskIsValid(Globals.UserLeave))
                {
                    int n = Globals.AutoFource ? 7 : 6;
                    MidScreen form = new MidScreen("设备维护", n);
                    form.BtArray[0].Text = "移除工作台";
                    form.BtArray[1].Text = "设备参数";
                    form.BtArray[2].Text = "电气复位";
                    form.BtArray[3].Text = "关  机";
                    form.BtArray[4].Text = "像素测量";
                    form.BtArray[5].Text = "旋转中心校正";
                    form.BtArray[6].Text = "焦距维护";
                    form.BtArray[0].UsedLed = true;
                    form.BtArray[0].LED = false;
                    if (Common.DI != null)
                    {
                        form.CycTime = 5;//500ms刷新一次
                        form.AutoUpdateEventHander += delegate (object s, EventArgs arg)
                        {
                            form.BtArray[0].LED = Common.DI[HW.DiDefine.TAB_AIR];
                        };
                    }
                    form.BtArray[0].Click += delegate (Object se, System.EventArgs arg)
                    {
                        Common.DO[HW.DoDefine.TAB_AIR] = !form.BtArray[0].LED;
                    };
                    form.BtArray[1].Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new DevDataManager());
                    };
                    form.BtArray[2].Click += delegate (Object se, System.EventArgs arg)
                    {
                        if (Globals.Load)
                        {
                            bool flag = true;

                            if (Common.SPD.ResetSpd())
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0618);
                            }
                            else
                            {
                                flag = false;
                                Common.ReportCmdKeyProgress(CmdKey.S0619);
                            }

                            if (Common.X_Axis.ResetAmpC())
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0212);
                            }
                            else
                            {
                                flag = false;
                                Common.ReportCmdKeyProgress(CmdKey.S0213);
                            }

                            if (Common.Y_Axis.ResetAmpC())
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0312);
                            }
                            else
                            {
                                flag = false;
                                Common.ReportCmdKeyProgress(CmdKey.S0313);
                            }
                            if (Common.Z_Axis.ResetAmpC())
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0412);
                            }
                            else
                            {
                                flag = false;
                                Common.ReportCmdKeyProgress(CmdKey.S0413);
                            }
                            if (Common.T_Axis.ResetAmpC())
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0512);
                            }
                            else
                            {
                                flag = false;
                                Common.ReportCmdKeyProgress(CmdKey.S0513);
                            }
                            Globals.IsInit = false;//初始化标志清除
                            if (flag)
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0028);
                            }
                            else
                            {
                                Common.ReportCmdKeyProgress(CmdKey.S0027);
                            }
                        }
                        else
                        {
                            Common.ReportCmdKeyProgress(CmdKey.S0090);
                        }

                    };
                    form.BtArray[3].Click += delegate (Object se, System.EventArgs arg)
                    {
                        Common.ReportCmdKeyProgress(CmdKey.S0021);
                        Common.SystemExit(true,true);//正确关机
                    };
                    form.BtArray[4].Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new PixelFactorManager());
                    };

                    form.BtArray[5].Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new AlignedCenterManager());
                    };
                    ParentForm.PushChildForm(form);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0032);
                }
            }
            managerLable.Text = manager[Globals.UserLeave];
            passwordEdit.Text = String.Empty;
        }

        private void SysMaintain_Click(object sender, EventArgs e)
        {
            if (Globals.UserLeave != 2)
            {
                Globals.UserLeave = 2;
                tBb1.SelectedIndex = 0;
                Common.ReportCmdKeyProgress(CmdKey.S0031);
            }
            else
            {
                if (CheckMaskIsValid(Globals.UserLeave))
                {
                    MidScreen form = new MidScreen("系统维护", 6);
                    form.Load+= delegate (Object se, System.EventArgs arg)//计时开始
                    {
                       
                    };
                    form.FormClosing += delegate (object se, FormClosingEventArgs arg)//用时结束
                    {

                    };
                    form.BtArray[0].Text = "运动控制";
                    form.BtArray[1].Text = "系统参数";
                    form.BtArray[2].Text = "输入输出";
                    form.BtArray[3].Text = "后台管理";
                    form.BtArray[0].Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new SystemAxisCtrManger());
                    };
                    form.BtArray[1].Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new SystemDataManager());
                    };
                    form.BtArray[2].Click += delegate (Object se, System.EventArgs arg)
                    {
                        ParentForm.PushChildForm(new SystemIOControlManager());
                    };
                    form.BtArray[3].Click += delegate (Object se, System.EventArgs arg)
                    {
                        Common.SystemExit(false,true);
                    };
                    form.BtArray[4].Text = "远程终端";
                    form.BtArray[5].Text = "产品信息";
                    ParentForm.PushChildForm(form);
                }
                else
                {
                    Common.ReportCmdKeyProgress(CmdKey.S0032);
                }
            }
            managerLable.Text = manager[Globals.UserLeave];
            passwordEdit.Text = String.Empty;
        }

        private void HomeScreen_CancelClick(object sender, EventArgs e)
        {
            // Globals.LedCmd.Yellow = 0x3;
            //Globals.Group.InitCutRunData();
            //Globals.Group.CH1.RepairCutLines(5);
            //ProcessCmd.RemoveUsbDiskDriver();
        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                LoadButtonList();
                LoadDefaultFrom();
            }
        }
        /// <summary>
        /// 加载默认按键 图片以及触发事件
        /// </summary>
        private void LoadDefaultFrom()
        {
            if (Globals.AutoCut)
            {
                bTargs.Add(new FormArg("全自动", null, AutoManual_Click));
            }
            bTargs.Add(new FormArg("手动操作", null, Manual_Click));
            bTargs.Add(new FormArg("刀具管理", null, BladeMaintain_Click));
            bTargs.Add(new FormArg("划切文件", null, CutParameter_Click));
            bTargs.Add(new FormArg("工程维护", null, OperMaintain_Click));
            bTargs.Add(new FormArg("设备维护", null, DevCfgButton_Click));
            bTargs.Add(new FormArg("系统维护", null, SysMaintain_Click));
            for (int i = 0; i < bTs.Count; i++)
            {
                bTs[i].Visible = i < bTargs.Count;
                if (bTs[i].Visible)
                {
                    bTs[i].Text = bTargs[i].Context;
                    bTs[i].Image = bTargs[i].BackImage;
                    bTs[i].Click += bTargs[i].ClickEventHander;
                }
            }
        }
        /// <summary>
        /// 将按键填入列表便于进行管理
        /// </summary>
        private void LoadButtonList()
        {
            bTs.Add(bT1);
            bTs.Add(bT2);
            bTs.Add(bT3);
            bTs.Add(bT4);
            bTs.Add(bT5);
            bTs.Add(bT6);
            bTs.Add(bT7);
            bTs.Add(bT8);
        }
        /// <summary>
        /// 验证密码是否有效
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        private bool CheckMaskIsValid(int leave = 0)
        {
            string s = Checksum.EncryptWithMD5(passwordEdit.Text);
            if (leave == 1)
            {
                return s == Globals.MacData.AdminKey;
            }
            else if (leave == 2)
            {
                return s == Globals.MacData.DevKey;
            }
            else
            {
                return true;
            }
        }

        public override bool FormLoadReady()
        {
            Globals.UserLeave = 0;
            managerLable.Text = manager[Globals.UserLeave];
            passwordEdit.ResetText();
            tBb1.SelectedIndex = 1;
            usedTime.Text = watch.Elapsed.ToString(@"hh\:mm\:ss");
            return base.FormLoadReady();
        }

        private void HomeScreen_AutoUpdataEventHander(object sender, EventArgs e)
        {
            usedTime.Text = watch.Elapsed.ToString(@"hh\:mm\:ss");
        }
    }
}
