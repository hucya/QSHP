namespace QSHP.UI
{
    partial class SystemConfigManger
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panelEx1 = new QSHP.UI.Ctr.PanelEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logDropTime = new QSHP.UI.Ctr.ComboBoxEx();
            this.logDropMode = new QSHP.UI.Ctr.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.autoInit = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.speech = new System.Windows.Forms.CheckBox();
            this.netCtr = new System.Windows.Forms.CheckBox();
            this.majorIO = new System.Windows.Forms.CheckBox();
            this.doubleCutWater = new System.Windows.Forms.CheckBox();
            this.softLight = new System.Windows.Forms.CheckBox();
            this.analogApplay = new System.Windows.Forms.CheckBox();
            this.bldCheck = new System.Windows.Forms.CheckBox();
            this.waterAir = new System.Windows.Forms.CheckBox();
            this.autoCut = new System.Windows.Forms.CheckBox();
            this.noTouchTest = new System.Windows.Forms.CheckBox();
            this.autoFource = new System.Windows.Forms.CheckBox();
            this.doubleCCD = new System.Windows.Forms.CheckBox();
            this.debugMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonEx2 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.buttonEx1 = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.superPassword = new QSHP.UI.Ctr.TextBoxEx();
            this.svnCtr = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.baudRate = new QSHP.UI.Ctr.ComboBoxEx();
            this.portList = new QSHP.UI.Ctr.ComboBoxEx();
            this.changeSpdCfg = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.passWordConfirm = new QSHP.UI.Ctr.TextBoxEx();
            this.newPassWord = new QSHP.UI.Ctr.TextBoxEx();
            this.passwordEdit = new QSHP.UI.Ctr.TextBoxEx();
            this.userType = new QSHP.UI.Ctr.ComboBoxEx();
            this.changePassWord = new QSHP.UI.Ctr.ButtonEx(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panelEx1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.groupBox1);
            this.panelEx1.Controls.Add(this.groupBox2);
            this.panelEx1.Controls.Add(this.groupBox4);
            this.panelEx1.Controls.Add(this.groupBox3);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.panelEx1.HeaderFont = new System.Drawing.Font("微软雅黑", 18F);
            this.panelEx1.LeftMode = false;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(815, 495);
            this.panelEx1.TabIndex = 2;
            this.panelEx1.Text = "配置修改";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logDropTime);
            this.groupBox1.Controls.Add(this.logDropMode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(372, 308);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 79);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "日志管理";
            // 
            // logDropTime
            // 
            this.logDropTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.logDropTime.FormattingEnabled = true;
            this.logDropTime.Items.AddRange(new object[] {
            "一个月",
            "三个月",
            "六个月",
            "一年"});
            this.logDropTime.Location = new System.Drawing.Point(302, 28);
            this.logDropTime.Name = "logDropTime";
            this.logDropTime.Size = new System.Drawing.Size(110, 29);
            this.logDropTime.TabIndex = 0;
            this.logDropTime.Text = "三个月";
            // 
            // logDropMode
            // 
            this.logDropMode.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.logDropMode.FormattingEnabled = true;
            this.logDropMode.Items.AddRange(new object[] {
            "禁止删除",
            "手动授权",
            "自动删除"});
            this.logDropMode.Location = new System.Drawing.Point(100, 29);
            this.logDropMode.Name = "logDropMode";
            this.logDropMode.Size = new System.Drawing.Size(110, 29);
            this.logDropMode.TabIndex = 0;
            this.logDropMode.Text = "自动删除";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "删除周期:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "删除模式:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.buttonEx2);
            this.groupBox2.Controls.Add(this.buttonEx1);
            this.groupBox2.Controls.Add(this.superPassword);
            this.groupBox2.Controls.Add(this.svnCtr);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(354, 456);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "软件功能配置";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.autoInit);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.speech);
            this.panel1.Controls.Add(this.netCtr);
            this.panel1.Controls.Add(this.majorIO);
            this.panel1.Controls.Add(this.doubleCutWater);
            this.panel1.Controls.Add(this.softLight);
            this.panel1.Controls.Add(this.analogApplay);
            this.panel1.Controls.Add(this.bldCheck);
            this.panel1.Controls.Add(this.waterAir);
            this.panel1.Controls.Add(this.autoCut);
            this.panel1.Controls.Add(this.noTouchTest);
            this.panel1.Controls.Add(this.autoFource);
            this.panel1.Controls.Add(this.doubleCCD);
            this.panel1.Controls.Add(this.debugMode);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(9, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 248);
            this.panel1.TabIndex = 9;
            // 
            // autoInit
            // 
            this.autoInit.AutoSize = true;
            this.autoInit.Location = new System.Drawing.Point(6, 36);
            this.autoInit.Name = "autoInit";
            this.autoInit.Size = new System.Drawing.Size(157, 25);
            this.autoInit.TabIndex = 0;
            this.autoInit.Text = "启动后系统初始化";
            this.autoInit.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(170, 186);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(158, 25);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "启用SVN备份数据";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // speech
            // 
            this.speech.AutoSize = true;
            this.speech.Location = new System.Drawing.Point(6, 216);
            this.speech.Name = "speech";
            this.speech.Size = new System.Drawing.Size(125, 25);
            this.speech.TabIndex = 0;
            this.speech.Text = "启用语音播报";
            this.speech.UseVisualStyleBackColor = true;
            // 
            // netCtr
            // 
            this.netCtr.AutoSize = true;
            this.netCtr.Location = new System.Drawing.Point(6, 186);
            this.netCtr.Name = "netCtr";
            this.netCtr.Size = new System.Drawing.Size(125, 25);
            this.netCtr.TabIndex = 0;
            this.netCtr.Text = "启用远程管理";
            this.netCtr.UseVisualStyleBackColor = true;
            // 
            // majorIO
            // 
            this.majorIO.AutoSize = true;
            this.majorIO.Location = new System.Drawing.Point(171, 129);
            this.majorIO.Name = "majorIO";
            this.majorIO.Size = new System.Drawing.Size(139, 25);
            this.majorIO.TabIndex = 0;
            this.majorIO.Text = "启用32 IO 模式";
            this.majorIO.UseVisualStyleBackColor = true;
            // 
            // doubleCutWater
            // 
            this.doubleCutWater.AutoSize = true;
            this.doubleCutWater.Location = new System.Drawing.Point(171, 99);
            this.doubleCutWater.Name = "doubleCutWater";
            this.doubleCutWater.Size = new System.Drawing.Size(157, 25);
            this.doubleCutWater.TabIndex = 0;
            this.doubleCutWater.Text = "启用切割双水传感";
            this.doubleCutWater.UseVisualStyleBackColor = true;
            // 
            // softLight
            // 
            this.softLight.AutoSize = true;
            this.softLight.Location = new System.Drawing.Point(171, 39);
            this.softLight.Name = "softLight";
            this.softLight.Size = new System.Drawing.Size(157, 25);
            this.softLight.TabIndex = 0;
            this.softLight.Text = "启用软件控制光源";
            this.softLight.UseVisualStyleBackColor = true;
            // 
            // analogApplay
            // 
            this.analogApplay.AutoSize = true;
            this.analogApplay.Location = new System.Drawing.Point(6, 157);
            this.analogApplay.Name = "analogApplay";
            this.analogApplay.Size = new System.Drawing.Size(125, 25);
            this.analogApplay.TabIndex = 0;
            this.analogApplay.Text = "启用模拟输入";
            this.analogApplay.UseVisualStyleBackColor = true;
            // 
            // bldCheck
            // 
            this.bldCheck.AutoSize = true;
            this.bldCheck.Location = new System.Drawing.Point(171, 69);
            this.bldCheck.Name = "bldCheck";
            this.bldCheck.Size = new System.Drawing.Size(125, 25);
            this.bldCheck.TabIndex = 0;
            this.bldCheck.Text = "启用刀破检测";
            this.bldCheck.UseVisualStyleBackColor = true;
            // 
            // waterAir
            // 
            this.waterAir.AutoSize = true;
            this.waterAir.Location = new System.Drawing.Point(171, 9);
            this.waterAir.Name = "waterAir";
            this.waterAir.Size = new System.Drawing.Size(125, 25);
            this.waterAir.TabIndex = 0;
            this.waterAir.Text = "启用水帘气帘";
            this.waterAir.UseVisualStyleBackColor = true;
            // 
            // autoCut
            // 
            this.autoCut.AutoSize = true;
            this.autoCut.Location = new System.Drawing.Point(171, 155);
            this.autoCut.Name = "autoCut";
            this.autoCut.Size = new System.Drawing.Size(125, 25);
            this.autoCut.TabIndex = 0;
            this.autoCut.Text = "启用自动划切";
            this.autoCut.UseVisualStyleBackColor = true;
            // 
            // noTouchTest
            // 
            this.noTouchTest.AutoSize = true;
            this.noTouchTest.Location = new System.Drawing.Point(6, 126);
            this.noTouchTest.Name = "noTouchTest";
            this.noTouchTest.Size = new System.Drawing.Size(157, 25);
            this.noTouchTest.TabIndex = 0;
            this.noTouchTest.Text = "支持非接触式测高";
            this.noTouchTest.UseVisualStyleBackColor = true;
            // 
            // autoFource
            // 
            this.autoFource.AutoSize = true;
            this.autoFource.Location = new System.Drawing.Point(6, 96);
            this.autoFource.Name = "autoFource";
            this.autoFource.Size = new System.Drawing.Size(125, 25);
            this.autoFource.TabIndex = 0;
            this.autoFource.Text = "支持自动对焦";
            this.autoFource.UseVisualStyleBackColor = true;
            // 
            // doubleCCD
            // 
            this.doubleCCD.AutoSize = true;
            this.doubleCCD.Location = new System.Drawing.Point(6, 66);
            this.doubleCCD.Name = "doubleCCD";
            this.doubleCCD.Size = new System.Drawing.Size(125, 25);
            this.doubleCCD.TabIndex = 0;
            this.doubleCCD.Text = "双显微镜系统";
            this.doubleCCD.UseVisualStyleBackColor = true;
            // 
            // debugMode
            // 
            this.debugMode.AutoSize = true;
            this.debugMode.Location = new System.Drawing.Point(6, 6);
            this.debugMode.Name = "debugMode";
            this.debugMode.Size = new System.Drawing.Size(93, 25);
            this.debugMode.TabIndex = 0;
            this.debugMode.Text = "调试模式";
            this.debugMode.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label4.Location = new System.Drawing.Point(13, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(330, 63);
            this.label4.TabIndex = 8;
            this.label4.Text = "注意：该区域配置非厂家人员无权更改；\r\n如因客户擅自更改造成的任何损失，概不负责\r\n厂家人员需输入超级密码后校验成功后有效。";
            // 
            // buttonEx2
            // 
            this.buttonEx2.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx2.Flag = 0;
            this.buttonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx2.LED = false;
            this.buttonEx2.LedLocation = new System.Drawing.Point(4, 4);
            this.buttonEx2.Location = new System.Drawing.Point(180, 372);
            this.buttonEx2.Name = "buttonEx2";
            this.buttonEx2.NumText = "";
            this.buttonEx2.Pressed = false;
            this.buttonEx2.Size = new System.Drawing.Size(110, 34);
            this.buttonEx2.TabIndex = 7;
            this.buttonEx2.TabStop = false;
            this.buttonEx2.Text = "获取秘钥";
            this.buttonEx2.UsedLed = false;
            this.buttonEx2.UseVisualStyleBackColor = true;
            this.buttonEx2.Click += new System.EventHandler(this.buttonEx2_Click);
            // 
            // buttonEx1
            // 
            this.buttonEx1.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.buttonEx1.Flag = 0;
            this.buttonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEx1.LED = false;
            this.buttonEx1.LedLocation = new System.Drawing.Point(4, 4);
            this.buttonEx1.Location = new System.Drawing.Point(180, 414);
            this.buttonEx1.Name = "buttonEx1";
            this.buttonEx1.NumText = "";
            this.buttonEx1.Pressed = false;
            this.buttonEx1.Size = new System.Drawing.Size(110, 34);
            this.buttonEx1.TabIndex = 7;
            this.buttonEx1.TabStop = false;
            this.buttonEx1.Text = "密码确认";
            this.buttonEx1.UsedLed = false;
            this.buttonEx1.UseVisualStyleBackColor = true;
            this.buttonEx1.Click += new System.EventHandler(this.buttonEx1_Click);
            // 
            // superPassword
            // 
            this.superPassword.BackColor = System.Drawing.SystemColors.Window;
            this.superPassword.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.superPassword.Location = new System.Drawing.Point(64, 418);
            this.superPassword.MaxLength = 10;
            this.superPassword.Name = "superPassword";
            this.superPassword.PasswordChar = '*';
            this.superPassword.SetError = false;
            this.superPassword.SetWarn = false;
            this.superPassword.Size = new System.Drawing.Size(110, 29);
            this.superPassword.TabIndex = 6;
            this.superPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.superPassword.WordWrap = false;
            // 
            // svnCtr
            // 
            this.svnCtr.AutoSize = true;
            this.svnCtr.Location = new System.Drawing.Point(185, 211);
            this.svnCtr.Name = "svnCtr";
            this.svnCtr.Size = new System.Drawing.Size(158, 25);
            this.svnCtr.TabIndex = 0;
            this.svnCtr.Text = "启用SVN数据管理";
            this.svnCtr.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label6.Location = new System.Drawing.Point(64, 376);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "xxxxx";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.baudRate);
            this.groupBox4.Controls.Add(this.portList);
            this.groupBox4.Controls.Add(this.changeSpdCfg);
            this.groupBox4.Location = new System.Drawing.Point(372, 195);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(431, 107);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "变频器配置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(234, 28);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 21);
            this.label10.TabIndex = 0;
            this.label10.Text = "波特率:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 21);
            this.label11.TabIndex = 0;
            this.label11.Text = "端口号:";
            // 
            // baudRate
            // 
            this.baudRate.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.baudRate.FormattingEnabled = true;
            this.baudRate.Location = new System.Drawing.Point(302, 24);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(110, 29);
            this.baudRate.TabIndex = 2;
            // 
            // portList
            // 
            this.portList.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.portList.FormattingEnabled = true;
            this.portList.Location = new System.Drawing.Point(100, 25);
            this.portList.Name = "portList";
            this.portList.Size = new System.Drawing.Size(110, 29);
            this.portList.TabIndex = 2;
            // 
            // changeSpdCfg
            // 
            this.changeSpdCfg.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.changeSpdCfg.Flag = 0;
            this.changeSpdCfg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeSpdCfg.LED = false;
            this.changeSpdCfg.LedLocation = new System.Drawing.Point(4, 4);
            this.changeSpdCfg.Location = new System.Drawing.Point(302, 62);
            this.changeSpdCfg.Name = "changeSpdCfg";
            this.changeSpdCfg.NumText = "";
            this.changeSpdCfg.Pressed = false;
            this.changeSpdCfg.Size = new System.Drawing.Size(110, 34);
            this.changeSpdCfg.TabIndex = 1;
            this.changeSpdCfg.TabStop = false;
            this.changeSpdCfg.Text = "确认修改";
            this.changeSpdCfg.UsedLed = false;
            this.changeSpdCfg.UseVisualStyleBackColor = true;
            this.changeSpdCfg.Click += new System.EventHandler(this.ChangeSpdCfg_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.passWordConfirm);
            this.groupBox3.Controls.Add(this.newPassWord);
            this.groupBox3.Controls.Add(this.passwordEdit);
            this.groupBox3.Controls.Add(this.userType);
            this.groupBox3.Controls.Add(this.changePassWord);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(372, 36);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(431, 145);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "密码管理";
            // 
            // passWordConfirm
            // 
            this.passWordConfirm.BackColor = System.Drawing.SystemColors.Window;
            this.passWordConfirm.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.passWordConfirm.Location = new System.Drawing.Point(302, 63);
            this.passWordConfirm.MaxLength = 10;
            this.passWordConfirm.Name = "passWordConfirm";
            this.passWordConfirm.PasswordChar = '*';
            this.passWordConfirm.SetError = false;
            this.passWordConfirm.SetWarn = false;
            this.passWordConfirm.Size = new System.Drawing.Size(110, 29);
            this.passWordConfirm.TabIndex = 6;
            this.passWordConfirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passWordConfirm.WordWrap = false;
            // 
            // newPassWord
            // 
            this.newPassWord.BackColor = System.Drawing.SystemColors.Window;
            this.newPassWord.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.newPassWord.Location = new System.Drawing.Point(100, 63);
            this.newPassWord.MaxLength = 10;
            this.newPassWord.Name = "newPassWord";
            this.newPassWord.PasswordChar = '*';
            this.newPassWord.SetError = false;
            this.newPassWord.SetWarn = false;
            this.newPassWord.Size = new System.Drawing.Size(110, 29);
            this.newPassWord.TabIndex = 6;
            this.newPassWord.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.newPassWord.WordWrap = false;
            // 
            // passwordEdit
            // 
            this.passwordEdit.BackColor = System.Drawing.SystemColors.Window;
            this.passwordEdit.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.passwordEdit.Location = new System.Drawing.Point(302, 28);
            this.passwordEdit.MaxLength = 10;
            this.passwordEdit.Name = "passwordEdit";
            this.passwordEdit.PasswordChar = '*';
            this.passwordEdit.SetError = false;
            this.passwordEdit.SetWarn = false;
            this.passwordEdit.Size = new System.Drawing.Size(110, 29);
            this.passwordEdit.TabIndex = 6;
            this.passwordEdit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.passwordEdit.WordWrap = false;
            // 
            // userType
            // 
            this.userType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.userType.FormattingEnabled = true;
            this.userType.Items.AddRange(new object[] {
            "操作人员",
            "设备管理员",
            "系统管理员",
            "锁屏密码",
            "远程密码"});
            this.userType.Location = new System.Drawing.Point(100, 28);
            this.userType.Name = "userType";
            this.userType.Size = new System.Drawing.Size(110, 29);
            this.userType.TabIndex = 2;
            this.userType.Text = "操作人员";
            this.userType.SelectedIndexChanged += new System.EventHandler(this.UserType_SelectedIndexChanged);
            // 
            // changePassWord
            // 
            this.changePassWord.ButtonMode = QSHP.UI.Ctr.BtMode.Normal;
            this.changePassWord.Flag = 0;
            this.changePassWord.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changePassWord.LED = false;
            this.changePassWord.LedLocation = new System.Drawing.Point(4, 4);
            this.changePassWord.Location = new System.Drawing.Point(302, 98);
            this.changePassWord.Name = "changePassWord";
            this.changePassWord.NumText = "";
            this.changePassWord.Pressed = false;
            this.changePassWord.Size = new System.Drawing.Size(110, 34);
            this.changePassWord.TabIndex = 1;
            this.changePassWord.TabStop = false;
            this.changePassWord.Text = "确认修改";
            this.changePassWord.UsedLed = false;
            this.changePassWord.UseVisualStyleBackColor = true;
            this.changePassWord.Click += new System.EventHandler(this.ChangePassWord_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(219, 66);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 21);
            this.label15.TabIndex = 0;
            this.label15.Text = "密码确认:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "原密码:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "新密码:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "账户类型:";
            // 
            // SystemConfigManger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(815, 495);
            this.Controls.Add(this.panelEx1);
            this.Name = "SystemConfigManger";
            this.Text = "配置修改";
            this.CancelClick += new System.EventHandler(this.SystemConfigManger_CancelClick);
            this.ConfirmClick += new System.EventHandler(this.SystemConfigManger_ConfirmClick);
            this.panelEx1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Ctr.PanelEx panelEx1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private Ctr.ComboBoxEx baudRate;
        private Ctr.ComboBoxEx portList;
        private Ctr.ButtonEx changeSpdCfg;
        private System.Windows.Forms.GroupBox groupBox3;
        private Ctr.TextBoxEx passWordConfirm;
        private Ctr.TextBoxEx newPassWord;
        private Ctr.TextBoxEx passwordEdit;
        private Ctr.ComboBoxEx userType;
        private Ctr.ButtonEx changePassWord;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private Ctr.ComboBoxEx logDropTime;
        private Ctr.ComboBoxEx logDropMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox debugMode;
        private System.Windows.Forms.CheckBox autoInit;
        private System.Windows.Forms.CheckBox doubleCCD;
        private System.Windows.Forms.CheckBox noTouchTest;
        private System.Windows.Forms.CheckBox autoFource;
        private System.Windows.Forms.CheckBox autoCut;
        private System.Windows.Forms.CheckBox analogApplay;
        private System.Windows.Forms.CheckBox bldCheck;
        private System.Windows.Forms.CheckBox softLight;
        private System.Windows.Forms.CheckBox majorIO;
        private System.Windows.Forms.CheckBox doubleCutWater;
        private System.Windows.Forms.CheckBox svnCtr;
        private System.Windows.Forms.CheckBox netCtr;
        private System.Windows.Forms.CheckBox waterAir;
        private Ctr.ButtonEx buttonEx1;
        private Ctr.TextBoxEx superPassword;
        private System.Windows.Forms.Label label4;
        private Ctr.ButtonEx buttonEx2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox speech;
    }
}