using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
namespace COMPortTerminal
{
   
  //  [ global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated() ]
    public partial class MainForm : System.Windows.Forms.Form 
    { 
        
        // Form overrides dispose to clean up the component list.
        [ System.Diagnostics.DebuggerNonUserCode() ]
        protected override void Dispose( bool disposing ) 
        { 
            if ( disposing && components != null ) 
            { 
                components.Dispose(); 
            } 
            base.Dispose( disposing ); 
        } 
        
        
        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components; 
        
        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [ System.Diagnostics.DebuggerStepThrough() ]
        private void InitializeComponent() 
        {
            this.components = new System.ComponentModel.Container();
            this.rtbMonitor = new System.Windows.Forms.RichTextBox();
            this.rtbStatus = new System.Windows.Forms.RichTextBox();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPort = new System.Windows.Forms.Button();
            this.btnOpenOrClosePort = new System.Windows.Forms.Button();
            this.tmrLookForPortChanges = new System.Windows.Forms.Timer(this.components);
            this.btnSent = new System.Windows.Forms.Button();
            this.txtSent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdStrobe = new System.Windows.Forms.Button();
            this.tbStrobeDuration = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tbStrobeIntensity = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbConstant = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboChannel = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGetDeviceSN = new System.Windows.Forms.Button();
            this.btnGetFirmware = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtFirmware = new System.Windows.Forms.TextBox();
            this.btnStartTimer = new System.Windows.Forms.Button();
            this.btnStopTimer = new System.Windows.Forms.Button();
            this.cmdUnlock = new System.Windows.Forms.Button();
            this.cmdLock = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnZeroUserEEData = new System.Windows.Forms.Button();
            this.lblWriteValue = new System.Windows.Forms.Label();
            this.lblReadValue = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnReadAll = new System.Windows.Forms.Button();
            this.txtEEData = new System.Windows.Forms.TextBox();
            this.btnWriteEEData = new System.Windows.Forms.Button();
            this.btnReadEEData = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtWriteValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReadValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHeartBeat = new System.Windows.Forms.TextBox();
            this.btnGetHeartBeat = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cboButton = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboSerialReply = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.cboOutputInverted = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cboOutputNormal = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGetInput = new System.Windows.Forms.Button();
            this.chkInput3 = new System.Windows.Forms.CheckBox();
            this.chkInput2 = new System.Windows.Forms.CheckBox();
            this.chkInput1 = new System.Windows.Forms.CheckBox();
            this.chkInput0 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkOutput7 = new System.Windows.Forms.CheckBox();
            this.chkOutput6 = new System.Windows.Forms.CheckBox();
            this.chkOutput5 = new System.Windows.Forms.CheckBox();
            this.chkOutput4 = new System.Windows.Forms.CheckBox();
            this.chkOutput3 = new System.Windows.Forms.CheckBox();
            this.chkOutput2 = new System.Windows.Forms.CheckBox();
            this.chkOutput1 = new System.Windows.Forms.CheckBox();
            this.chkOutput0 = new System.Windows.Forms.CheckBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.StatusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrobeDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrobeIntensity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConstant)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbMonitor
            // 
            this.rtbMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMonitor.Location = new System.Drawing.Point(11, 0);
            this.rtbMonitor.Name = "rtbMonitor";
            this.rtbMonitor.Size = new System.Drawing.Size(445, 56);
            this.rtbMonitor.TabIndex = 7;
            this.rtbMonitor.Text = "";
            this.rtbMonitor.TextChanged += new System.EventHandler(this.rtbMonitor_TextChanged_1);
            // 
            // rtbStatus
            // 
            this.rtbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.rtbStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbStatus.Location = new System.Drawing.Point(-1, -33);
            this.rtbStatus.Margin = new System.Windows.Forms.Padding(5);
            this.rtbStatus.Name = "rtbStatus";
            this.rtbStatus.ReadOnly = true;
            this.rtbStatus.Size = new System.Drawing.Size(445, 32);
            this.rtbStatus.TabIndex = 8;
            this.rtbStatus.Text = "";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 716);
            this.StatusStrip1.MinimumSize = new System.Drawing.Size(26, 0);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(640, 37);
            this.StatusStrip1.TabIndex = 9;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.AutoSize = false;
            this.ToolStripStatusLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ToolStripStatusLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(5);
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(615, 27);
            this.ToolStripStatusLabel1.Spring = true;
            this.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPort
            // 
            this.btnPort.AutoSize = true;
            this.btnPort.Location = new System.Drawing.Point(472, 12);
            this.btnPort.Name = "btnPort";
            this.btnPort.Size = new System.Drawing.Size(119, 24);
            this.btnPort.TabIndex = 10;
            this.btnPort.Text = "Port Settings";
            this.btnPort.UseVisualStyleBackColor = true;
            this.btnPort.Click += new System.EventHandler(this.btnPort_Click_1);
            // 
            // btnOpenOrClosePort
            // 
            this.btnOpenOrClosePort.AutoSize = true;
            this.btnOpenOrClosePort.Location = new System.Drawing.Point(472, 42);
            this.btnOpenOrClosePort.Name = "btnOpenOrClosePort";
            this.btnOpenOrClosePort.Size = new System.Drawing.Size(119, 24);
            this.btnOpenOrClosePort.TabIndex = 11;
            this.btnOpenOrClosePort.Text = "Open COM Port";
            this.btnOpenOrClosePort.UseVisualStyleBackColor = true;
            this.btnOpenOrClosePort.Click += new System.EventHandler(this.btnOpenOrClosePort_Click_1);
            // 
            // tmrLookForPortChanges
            // 
            this.tmrLookForPortChanges.Interval = 1000;
            // 
            // btnSent
            // 
            this.btnSent.Location = new System.Drawing.Point(11, 62);
            this.btnSent.Name = "btnSent";
            this.btnSent.Size = new System.Drawing.Size(165, 27);
            this.btnSent.TabIndex = 12;
            this.btnSent.Text = "Send String";
            this.btnSent.UseVisualStyleBackColor = true;
            this.btnSent.Click += new System.EventHandler(this.btnSent_Click);
            // 
            // txtSent
            // 
            this.txtSent.Location = new System.Drawing.Point(182, 65);
            this.txtSent.Name = "txtSent";
            this.txtSent.Size = new System.Drawing.Size(274, 20);
            this.txtSent.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdStrobe);
            this.groupBox1.Controls.Add(this.tbStrobeDuration);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbStrobeIntensity);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbConstant);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboChannel);
            this.groupBox1.Controls.Add(this.rtbStatus);
            this.groupBox1.Location = new System.Drawing.Point(12, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 146);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lighting Setting";
            // 
            // cmdStrobe
            // 
            this.cmdStrobe.Location = new System.Drawing.Point(155, 15);
            this.cmdStrobe.Name = "cmdStrobe";
            this.cmdStrobe.Size = new System.Drawing.Size(78, 25);
            this.cmdStrobe.TabIndex = 25;
            this.cmdStrobe.Text = "Strobe Once";
            this.cmdStrobe.UseVisualStyleBackColor = true;
            this.cmdStrobe.Click += new System.EventHandler(this.cmdStrobe_Click);
            // 
            // tbStrobeDuration
            // 
            this.tbStrobeDuration.Location = new System.Drawing.Point(103, 97);
            this.tbStrobeDuration.Maximum = 254;
            this.tbStrobeDuration.Minimum = 1;
            this.tbStrobeDuration.Name = "tbStrobeDuration";
            this.tbStrobeDuration.Size = new System.Drawing.Size(130, 45);
            this.tbStrobeDuration.TabIndex = 24;
            this.tbStrobeDuration.TickFrequency = 10;
            this.tbStrobeDuration.Value = 1;
            this.tbStrobeDuration.Scroll += new System.EventHandler(this.tbStrobeDuration_Scroll);
            this.tbStrobeDuration.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbStrobeDuration_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Strobe Duration";
            // 
            // tbStrobeIntensity
            // 
            this.tbStrobeIntensity.Location = new System.Drawing.Point(104, 68);
            this.tbStrobeIntensity.Maximum = 65535;
            this.tbStrobeIntensity.Name = "tbStrobeIntensity";
            this.tbStrobeIntensity.Size = new System.Drawing.Size(129, 45);
            this.tbStrobeIntensity.TabIndex = 22;
            this.tbStrobeIntensity.TickFrequency = 2;
            this.tbStrobeIntensity.Scroll += new System.EventHandler(this.tbStrobeIntensity_Scroll);
            this.tbStrobeIntensity.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbStrobeIntensity_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Strobe Intensity";
            // 
            // tbConstant
            // 
            this.tbConstant.Location = new System.Drawing.Point(104, 39);
            this.tbConstant.Maximum = 65535;
            this.tbConstant.Name = "tbConstant";
            this.tbConstant.Size = new System.Drawing.Size(129, 45);
            this.tbConstant.SmallChange = 5;
            this.tbConstant.TabIndex = 20;
            this.tbConstant.TickFrequency = 2;
            this.tbConstant.Scroll += new System.EventHandler(this.tbConstant_Scroll);
            this.tbConstant.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbConstant_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Constant Intensity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Lighting Channel ";
            // 
            // cboChannel
            // 
            this.cboChannel.FormattingEnabled = true;
            this.cboChannel.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboChannel.Location = new System.Drawing.Point(116, 15);
            this.cboChannel.Name = "cboChannel";
            this.cboChannel.Size = new System.Drawing.Size(33, 21);
            this.cboChannel.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGetDeviceSN);
            this.groupBox2.Controls.Add(this.btnGetFirmware);
            this.groupBox2.Controls.Add(this.label26);
            this.groupBox2.Controls.Add(this.txtSerialNumber);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtFirmware);
            this.groupBox2.Controls.Add(this.btnStartTimer);
            this.groupBox2.Controls.Add(this.btnStopTimer);
            this.groupBox2.Controls.Add(this.cmdUnlock);
            this.groupBox2.Controls.Add(this.cmdLock);
            this.groupBox2.Location = new System.Drawing.Point(12, 621);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 92);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System";
            this.groupBox2.Visible = false;
            // 
            // btnGetDeviceSN
            // 
            this.btnGetDeviceSN.Location = new System.Drawing.Point(240, 35);
            this.btnGetDeviceSN.Name = "btnGetDeviceSN";
            this.btnGetDeviceSN.Size = new System.Drawing.Size(137, 24);
            this.btnGetDeviceSN.TabIndex = 13;
            this.btnGetDeviceSN.Text = "Get Device Details";
            this.btnGetDeviceSN.UseVisualStyleBackColor = true;
            this.btnGetDeviceSN.Click += new System.EventHandler(this.btnGetDeviceSN_Click);
            // 
            // btnGetFirmware
            // 
            this.btnGetFirmware.Location = new System.Drawing.Point(240, 12);
            this.btnGetFirmware.Name = "btnGetFirmware";
            this.btnGetFirmware.Size = new System.Drawing.Size(137, 24);
            this.btnGetFirmware.TabIndex = 14;
            this.btnGetFirmware.Text = "Get Firmware Revision";
            this.btnGetFirmware.UseVisualStyleBackColor = true;
            this.btnGetFirmware.Click += new System.EventHandler(this.btnGetFirmware_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(12, 38);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(95, 13);
            this.label26.TabIndex = 12;
            this.label26.Text = "Device Unique ID:";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Location = new System.Drawing.Point(111, 35);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(123, 20);
            this.txtSerialNumber.TabIndex = 11;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(12, 16);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(93, 13);
            this.label25.TabIndex = 10;
            this.label25.Text = "Firmware Revision";
            // 
            // txtFirmware
            // 
            this.txtFirmware.Location = new System.Drawing.Point(111, 13);
            this.txtFirmware.Name = "txtFirmware";
            this.txtFirmware.Size = new System.Drawing.Size(123, 20);
            this.txtFirmware.TabIndex = 9;
            // 
            // btnStartTimer
            // 
            this.btnStartTimer.Location = new System.Drawing.Point(245, 61);
            this.btnStartTimer.Name = "btnStartTimer";
            this.btnStartTimer.Size = new System.Drawing.Size(71, 24);
            this.btnStartTimer.TabIndex = 3;
            this.btnStartTimer.Text = "Start Timer";
            this.btnStartTimer.UseVisualStyleBackColor = true;
            this.btnStartTimer.Click += new System.EventHandler(this.btnStartTimer_Click);
            // 
            // btnStopTimer
            // 
            this.btnStopTimer.Location = new System.Drawing.Point(322, 62);
            this.btnStopTimer.Name = "btnStopTimer";
            this.btnStopTimer.Size = new System.Drawing.Size(69, 23);
            this.btnStopTimer.TabIndex = 2;
            this.btnStopTimer.Text = "Stop Timer";
            this.btnStopTimer.UseVisualStyleBackColor = true;
            this.btnStopTimer.Click += new System.EventHandler(this.btnStopTimer_Click);
            // 
            // cmdUnlock
            // 
            this.cmdUnlock.Location = new System.Drawing.Point(117, 61);
            this.cmdUnlock.Name = "cmdUnlock";
            this.cmdUnlock.Size = new System.Drawing.Size(122, 24);
            this.cmdUnlock.TabIndex = 1;
            this.cmdUnlock.Text = "Unlock Front Panel";
            this.cmdUnlock.UseVisualStyleBackColor = true;
            this.cmdUnlock.Click += new System.EventHandler(this.cmdUnlock_Click);
            // 
            // cmdLock
            // 
            this.cmdLock.Location = new System.Drawing.Point(12, 61);
            this.cmdLock.Name = "cmdLock";
            this.cmdLock.Size = new System.Drawing.Size(99, 24);
            this.cmdLock.TabIndex = 0;
            this.cmdLock.Text = "Lock Front Panel";
            this.cmdLock.UseVisualStyleBackColor = true;
            this.cmdLock.Click += new System.EventHandler(this.cmdLock_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnZeroUserEEData);
            this.groupBox3.Controls.Add(this.lblWriteValue);
            this.groupBox3.Controls.Add(this.lblReadValue);
            this.groupBox3.Controls.Add(this.lblAddress);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.btnReadAll);
            this.groupBox3.Controls.Add(this.txtEEData);
            this.groupBox3.Controls.Add(this.btnWriteEEData);
            this.groupBox3.Controls.Add(this.btnReadEEData);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtWriteValue);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtReadValue);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtAddress);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txtHeartBeat);
            this.groupBox3.Controls.Add(this.btnGetHeartBeat);
            this.groupBox3.Location = new System.Drawing.Point(12, 273);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(406, 348);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "MCU Settings";
            this.groupBox3.Visible = false;
            // 
            // btnZeroUserEEData
            // 
            this.btnZeroUserEEData.Location = new System.Drawing.Point(292, 75);
            this.btnZeroUserEEData.Name = "btnZeroUserEEData";
            this.btnZeroUserEEData.Size = new System.Drawing.Size(107, 22);
            this.btnZeroUserEEData.TabIndex = 19;
            this.btnZeroUserEEData.Text = "Zero User EEData";
            this.btnZeroUserEEData.UseVisualStyleBackColor = true;
            this.btnZeroUserEEData.Click += new System.EventHandler(this.btnZeroUserEEData_Click);
            // 
            // lblWriteValue
            // 
            this.lblWriteValue.AutoSize = true;
            this.lblWriteValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWriteValue.Location = new System.Drawing.Point(159, 80);
            this.lblWriteValue.Name = "lblWriteValue";
            this.lblWriteValue.Size = new System.Drawing.Size(35, 14);
            this.lblWriteValue.TabIndex = 32;
            this.lblWriteValue.Text = "0x00";
            // 
            // lblReadValue
            // 
            this.lblReadValue.AutoSize = true;
            this.lblReadValue.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadValue.Location = new System.Drawing.Point(159, 59);
            this.lblReadValue.Name = "lblReadValue";
            this.lblReadValue.Size = new System.Drawing.Size(35, 14);
            this.lblReadValue.TabIndex = 31;
            this.lblReadValue.Text = "0x00";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(159, 39);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(35, 14);
            this.lblAddress.TabIndex = 30;
            this.lblAddress.Text = "0x00";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(9, 316);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 14);
            this.label17.TabIndex = 29;
            this.label17.Text = "0xF0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(9, 301);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 14);
            this.label18.TabIndex = 28;
            this.label18.Text = "0xE0";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(9, 287);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 14);
            this.label19.TabIndex = 27;
            this.label19.Text = "0xD0";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(9, 273);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(35, 14);
            this.label20.TabIndex = 26;
            this.label20.Text = "0xC0";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(9, 259);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(35, 14);
            this.label21.TabIndex = 25;
            this.label21.Text = "0xB0";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(9, 244);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(35, 14);
            this.label22.TabIndex = 24;
            this.label22.Text = "0xA0";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(9, 230);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 14);
            this.label23.TabIndex = 23;
            this.label23.Text = "0x90";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(9, 216);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(35, 14);
            this.label24.TabIndex = 22;
            this.label24.Text = "0x80";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(9, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 14);
            this.label13.TabIndex = 21;
            this.label13.Text = "0x70";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(9, 189);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 14);
            this.label14.TabIndex = 20;
            this.label14.Text = "0x60";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 175);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 14);
            this.label15.TabIndex = 19;
            this.label15.Text = "0x50";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(9, 161);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 14);
            this.label16.TabIndex = 18;
            this.label16.Text = "0x40";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(9, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 14);
            this.label11.TabIndex = 17;
            this.label11.Text = "0x30";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 134);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 14);
            this.label12.TabIndex = 16;
            this.label12.Text = "0x20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(9, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 15;
            this.label10.Text = "0x10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = "0x00";
            // 
            // btnReadAll
            // 
            this.btnReadAll.Location = new System.Drawing.Point(195, 75);
            this.btnReadAll.Name = "btnReadAll";
            this.btnReadAll.Size = new System.Drawing.Size(97, 22);
            this.btnReadAll.TabIndex = 13;
            this.btnReadAll.Text = "Read All EEData";
            this.btnReadAll.UseVisualStyleBackColor = true;
            this.btnReadAll.Click += new System.EventHandler(this.btnReadAll_Click);
            // 
            // txtEEData
            // 
            this.txtEEData.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEEData.Location = new System.Drawing.Point(46, 103);
            this.txtEEData.Multiline = true;
            this.txtEEData.Name = "txtEEData";
            this.txtEEData.Size = new System.Drawing.Size(339, 239);
            this.txtEEData.TabIndex = 12;
            // 
            // btnWriteEEData
            // 
            this.btnWriteEEData.Location = new System.Drawing.Point(195, 54);
            this.btnWriteEEData.Name = "btnWriteEEData";
            this.btnWriteEEData.Size = new System.Drawing.Size(97, 22);
            this.btnWriteEEData.TabIndex = 11;
            this.btnWriteEEData.Text = "Write EEData";
            this.btnWriteEEData.UseVisualStyleBackColor = true;
            this.btnWriteEEData.Click += new System.EventHandler(this.btnWriteEEData_Click);
            // 
            // btnReadEEData
            // 
            this.btnReadEEData.Location = new System.Drawing.Point(195, 33);
            this.btnReadEEData.Name = "btnReadEEData";
            this.btnReadEEData.Size = new System.Drawing.Size(97, 22);
            this.btnReadEEData.TabIndex = 10;
            this.btnReadEEData.Text = "Read EEData\r\n";
            this.btnReadEEData.UseVisualStyleBackColor = true;
            this.btnReadEEData.Click += new System.EventHandler(this.btnReadEEData_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Heart Beat Value";
            // 
            // txtWriteValue
            // 
            this.txtWriteValue.Location = new System.Drawing.Point(114, 77);
            this.txtWriteValue.Name = "txtWriteValue";
            this.txtWriteValue.Size = new System.Drawing.Size(39, 20);
            this.txtWriteValue.TabIndex = 7;
            this.txtWriteValue.TextChanged += new System.EventHandler(this.txtWriteValue_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "EEData Write Value";
            // 
            // txtReadValue
            // 
            this.txtReadValue.Location = new System.Drawing.Point(114, 56);
            this.txtReadValue.Name = "txtReadValue";
            this.txtReadValue.Size = new System.Drawing.Size(39, 20);
            this.txtReadValue.TabIndex = 5;
            this.txtReadValue.TextChanged += new System.EventHandler(this.txtReadValue_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "EEData Read Value";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(114, 35);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(39, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "EEData Address";
            // 
            // txtHeartBeat
            // 
            this.txtHeartBeat.Location = new System.Drawing.Point(114, 13);
            this.txtHeartBeat.Name = "txtHeartBeat";
            this.txtHeartBeat.Size = new System.Drawing.Size(71, 20);
            this.txtHeartBeat.TabIndex = 1;
            // 
            // btnGetHeartBeat
            // 
            this.btnGetHeartBeat.Location = new System.Drawing.Point(195, 12);
            this.btnGetHeartBeat.Name = "btnGetHeartBeat";
            this.btnGetHeartBeat.Size = new System.Drawing.Size(97, 22);
            this.btnGetHeartBeat.TabIndex = 0;
            this.btnGetHeartBeat.Text = "Get Heart Beat";
            this.btnGetHeartBeat.UseVisualStyleBackColor = true;
            this.btnGetHeartBeat.Click += new System.EventHandler(this.btnGetHeartBeat_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label30);
            this.groupBox4.Controls.Add(this.cboButton);
            this.groupBox4.Controls.Add(this.label29);
            this.groupBox4.Controls.Add(this.cboSerialReply);
            this.groupBox4.Controls.Add(this.label28);
            this.groupBox4.Controls.Add(this.cboOutputInverted);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.cboOutputNormal);
            this.groupBox4.Location = new System.Drawing.Point(259, 128);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(332, 145);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output/Input Mode Setting";
            this.groupBox4.Visible = false;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(6, 87);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 13);
            this.label30.TabIndex = 24;
            this.label30.Text = "Button Lock";
            // 
            // cboButton
            // 
            this.cboButton.FormattingEnabled = true;
            this.cboButton.Items.AddRange(new object[] {
            "0 - Button to Control Light",
            "1 - Button Lock, used as Input"});
            this.cboButton.Location = new System.Drawing.Point(93, 83);
            this.cboButton.Name = "cboButton";
            this.cboButton.Size = new System.Drawing.Size(186, 21);
            this.cboButton.TabIndex = 23;
            this.cboButton.SelectedIndexChanged += new System.EventHandler(this.cboButton_SelectedIndexChanged);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 66);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(63, 13);
            this.label29.TabIndex = 22;
            this.label29.Text = "Serial Reply";
            // 
            // cboSerialReply
            // 
            this.cboSerialReply.FormattingEnabled = true;
            this.cboSerialReply.Items.AddRange(new object[] {
            "0 -Serial Reply on GrabDone",
            "1 - No Serial Reply"});
            this.cboSerialReply.Location = new System.Drawing.Point(93, 60);
            this.cboSerialReply.Name = "cboSerialReply";
            this.cboSerialReply.Size = new System.Drawing.Size(186, 21);
            this.cboSerialReply.TabIndex = 21;
            this.cboSerialReply.SelectedIndexChanged += new System.EventHandler(this.cboSerialReply_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 44);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(81, 13);
            this.label28.TabIndex = 20;
            this.label28.Text = "Output Inverted";
            // 
            // cboOutputInverted
            // 
            this.cboOutputInverted.FormattingEnabled = true;
            this.cboOutputInverted.Items.AddRange(new object[] {
            "0 - Output is as Trigger",
            "1 - Output is Inverted"});
            this.cboOutputInverted.Location = new System.Drawing.Point(93, 38);
            this.cboOutputInverted.Name = "cboOutputInverted";
            this.cboOutputInverted.Size = new System.Drawing.Size(186, 21);
            this.cboOutputInverted.TabIndex = 19;
            this.cboOutputInverted.SelectedIndexChanged += new System.EventHandler(this.cboOutputInverted_SelectedIndexChanged);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(6, 21);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(69, 13);
            this.label27.TabIndex = 18;
            this.label27.Text = "Output Mode";
            // 
            // cboOutputNormal
            // 
            this.cboOutputNormal.FormattingEnabled = true;
            this.cboOutputNormal.Items.AddRange(new object[] {
            "0 - Output is Normal",
            "1 - Output Follow Trigger"});
            this.cboOutputNormal.Location = new System.Drawing.Point(93, 15);
            this.cboOutputNormal.Name = "cboOutputNormal";
            this.cboOutputNormal.Size = new System.Drawing.Size(186, 21);
            this.cboOutputNormal.TabIndex = 0;
            this.cboOutputNormal.SelectedIndexChanged += new System.EventHandler(this.cboOutputNormal_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.btnGetInput);
            this.groupBox5.Controls.Add(this.chkInput3);
            this.groupBox5.Controls.Add(this.chkInput2);
            this.groupBox5.Controls.Add(this.chkInput1);
            this.groupBox5.Controls.Add(this.chkInput0);
            this.groupBox5.Location = new System.Drawing.Point(423, 273);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(168, 119);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Status";
            this.groupBox5.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 22;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGetInput
            // 
            this.btnGetInput.Location = new System.Drawing.Point(87, 39);
            this.btnGetInput.Name = "btnGetInput";
            this.btnGetInput.Size = new System.Drawing.Size(63, 40);
            this.btnGetInput.TabIndex = 4;
            this.btnGetInput.Text = "Get Input";
            this.btnGetInput.UseVisualStyleBackColor = true;
            this.btnGetInput.Click += new System.EventHandler(this.btnGetInput_Click);
            // 
            // chkInput3
            // 
            this.chkInput3.AutoSize = true;
            this.chkInput3.Location = new System.Drawing.Point(10, 91);
            this.chkInput3.Name = "chkInput3";
            this.chkInput3.Size = new System.Drawing.Size(59, 17);
            this.chkInput3.TabIndex = 3;
            this.chkInput3.Text = "Input 3";
            this.chkInput3.UseVisualStyleBackColor = true;
            this.chkInput3.Visible = false;
            // 
            // chkInput2
            // 
            this.chkInput2.AutoSize = true;
            this.chkInput2.Location = new System.Drawing.Point(10, 68);
            this.chkInput2.Name = "chkInput2";
            this.chkInput2.Size = new System.Drawing.Size(59, 17);
            this.chkInput2.TabIndex = 2;
            this.chkInput2.Text = "Input 2";
            this.chkInput2.UseVisualStyleBackColor = true;
            // 
            // chkInput1
            // 
            this.chkInput1.AutoSize = true;
            this.chkInput1.Location = new System.Drawing.Point(10, 45);
            this.chkInput1.Name = "chkInput1";
            this.chkInput1.Size = new System.Drawing.Size(59, 17);
            this.chkInput1.TabIndex = 1;
            this.chkInput1.Text = "Input 1";
            this.chkInput1.UseVisualStyleBackColor = true;
            // 
            // chkInput0
            // 
            this.chkInput0.AutoSize = true;
            this.chkInput0.Location = new System.Drawing.Point(10, 22);
            this.chkInput0.Name = "chkInput0";
            this.chkInput0.Size = new System.Drawing.Size(59, 17);
            this.chkInput0.TabIndex = 0;
            this.chkInput0.Text = "Input 0";
            this.chkInput0.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.chkOutput7);
            this.groupBox6.Controls.Add(this.chkOutput6);
            this.groupBox6.Controls.Add(this.chkOutput5);
            this.groupBox6.Controls.Add(this.chkOutput4);
            this.groupBox6.Controls.Add(this.chkOutput3);
            this.groupBox6.Controls.Add(this.chkOutput2);
            this.groupBox6.Controls.Add(this.chkOutput1);
            this.groupBox6.Controls.Add(this.chkOutput0);
            this.groupBox6.Location = new System.Drawing.Point(423, 487);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(168, 219);
            this.groupBox6.TabIndex = 21;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Output Status";
            // 
            // chkOutput7
            // 
            this.chkOutput7.AutoSize = true;
            this.chkOutput7.Location = new System.Drawing.Point(10, 191);
            this.chkOutput7.Name = "chkOutput7";
            this.chkOutput7.Size = new System.Drawing.Size(67, 17);
            this.chkOutput7.TabIndex = 7;
            this.chkOutput7.Text = "Output 7";
            this.chkOutput7.UseVisualStyleBackColor = true;
            this.chkOutput7.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput6
            // 
            this.chkOutput6.AutoSize = true;
            this.chkOutput6.Location = new System.Drawing.Point(10, 168);
            this.chkOutput6.Name = "chkOutput6";
            this.chkOutput6.Size = new System.Drawing.Size(67, 17);
            this.chkOutput6.TabIndex = 6;
            this.chkOutput6.Text = "Output 6";
            this.chkOutput6.UseVisualStyleBackColor = true;
            this.chkOutput6.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput5
            // 
            this.chkOutput5.AutoSize = true;
            this.chkOutput5.Location = new System.Drawing.Point(10, 145);
            this.chkOutput5.Name = "chkOutput5";
            this.chkOutput5.Size = new System.Drawing.Size(67, 17);
            this.chkOutput5.TabIndex = 5;
            this.chkOutput5.Text = "Output 5";
            this.chkOutput5.UseVisualStyleBackColor = true;
            this.chkOutput5.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput4
            // 
            this.chkOutput4.AutoSize = true;
            this.chkOutput4.Location = new System.Drawing.Point(10, 118);
            this.chkOutput4.Name = "chkOutput4";
            this.chkOutput4.Size = new System.Drawing.Size(67, 17);
            this.chkOutput4.TabIndex = 4;
            this.chkOutput4.Text = "Output 4";
            this.chkOutput4.UseVisualStyleBackColor = true;
            this.chkOutput4.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput3
            // 
            this.chkOutput3.AutoSize = true;
            this.chkOutput3.Location = new System.Drawing.Point(10, 91);
            this.chkOutput3.Name = "chkOutput3";
            this.chkOutput3.Size = new System.Drawing.Size(67, 17);
            this.chkOutput3.TabIndex = 3;
            this.chkOutput3.Text = "Output 3";
            this.chkOutput3.UseVisualStyleBackColor = true;
            this.chkOutput3.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput2
            // 
            this.chkOutput2.AutoSize = true;
            this.chkOutput2.Location = new System.Drawing.Point(10, 68);
            this.chkOutput2.Name = "chkOutput2";
            this.chkOutput2.Size = new System.Drawing.Size(67, 17);
            this.chkOutput2.TabIndex = 2;
            this.chkOutput2.Text = "Output 2";
            this.chkOutput2.UseVisualStyleBackColor = true;
            this.chkOutput2.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput1
            // 
            this.chkOutput1.AutoSize = true;
            this.chkOutput1.Location = new System.Drawing.Point(10, 45);
            this.chkOutput1.Name = "chkOutput1";
            this.chkOutput1.Size = new System.Drawing.Size(67, 17);
            this.chkOutput1.TabIndex = 1;
            this.chkOutput1.Text = "Output 1";
            this.chkOutput1.UseVisualStyleBackColor = true;
            this.chkOutput1.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // chkOutput0
            // 
            this.chkOutput0.AutoSize = true;
            this.chkOutput0.Location = new System.Drawing.Point(10, 22);
            this.chkOutput0.Name = "chkOutput0";
            this.chkOutput0.Size = new System.Drawing.Size(67, 17);
            this.chkOutput0.TabIndex = 0;
            this.chkOutput0.Text = "Output 0";
            this.chkOutput0.UseVisualStyleBackColor = true;
            this.chkOutput0.CheckedChanged += new System.EventHandler(this.chkOutput0_CheckedChanged_1);
            // 
            // timer2
            // 
            this.timer2.Interval = 50;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 753);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSent);
            this.Controls.Add(this.btnSent);
            this.Controls.Add(this.btnOpenOrClosePort);
            this.Controls.Add(this.btnPort);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.rtbMonitor);
            this.MaximumSize = new System.Drawing.Size(2000, 2000);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "COM Port Terminal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrobeDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbStrobeIntensity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConstant)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        } 
        
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.RichTextBox rtbMonitor; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.RichTextBox rtbStatus; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.StatusStrip StatusStrip1; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Button btnPort; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Button btnOpenOrClosePort; 
        internal /* TRANSINFO: WithEvents */ System.Windows.Forms.Timer tmrLookForPortChanges;
        private Button btnSent;
        private TextBox txtSent;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cboChannel;
        private Label label2;
        private TrackBar tbConstant;
        private TrackBar tbStrobeIntensity;
        private Label label3;
        private TrackBar tbStrobeDuration;
        private Label label4;
        private Button cmdStrobe;
        private GroupBox groupBox2;
        private Button cmdLock;
        private Button cmdUnlock;
        private Timer timer1;
        private Button btnStopTimer;
        private Button btnStartTimer;
        private GroupBox groupBox3;
        private TextBox txtHeartBeat;
        private Button btnGetHeartBeat;
        private Label label6;
        private TextBox txtAddress;
        private Label label5;
        private Button btnWriteEEData;
        private Button btnReadEEData;
        private Label label8;
        private TextBox txtWriteValue;
        private Label label7;
        private TextBox txtReadValue;
        private Button btnReadAll;
        private TextBox txtEEData;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label11;
        private Label label12;
        private Label label10;
        private Label label9;
        private Label lblWriteValue;
        private Label lblReadValue;
        private Label lblAddress;
        private Button btnZeroUserEEData;
        private Button btnGetDeviceSN;
        private Label label26;
        private TextBox txtSerialNumber;
        private Label label25;
        private TextBox txtFirmware;
        private GroupBox groupBox4;
        private Label label27;
        private ComboBox cboOutputNormal;
        private Label label28;
        private ComboBox cboOutputInverted;
        private Label label29;
        private ComboBox cboSerialReply;
        private Label label30;
        private ComboBox cboButton;
        private GroupBox groupBox5;
        private Button btnGetFirmware;
        private CheckBox chkInput0;
        private Button btnGetInput;
        private CheckBox chkInput3;
        private CheckBox chkInput2;
        private CheckBox chkInput1;
        private GroupBox groupBox6;
        private CheckBox chkOutput3;
        private CheckBox chkOutput2;
        private CheckBox chkOutput1;
        private CheckBox chkOutput0;
        private Timer timer2;
        private Button button1;
        private Button button2;
        private CheckBox chkOutput7;
        private CheckBox chkOutput6;
        private CheckBox chkOutput5;
        private CheckBox chkOutput4;
    } 
    
    
} 
