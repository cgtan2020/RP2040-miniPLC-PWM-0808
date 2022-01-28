using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.Text; 

using COMPortTerminal.Properties;

namespace COMPortTerminal
{   
    /// <summary>
    /// com_port_terminal 
    /// Visual C# .NET application. Created with Visual Studio 2008.
    /// Converted from Visual Basic with C Sharpener for VB (www.elegancetech.com)
    ///
    /// Demonstrates communications using .NET 2.0's SerialPort class
    /// Displays a text box where users can enter text to send to a COM port 
    /// and view text received from a COM port.
    /// 
    /// The user can select a COM port, bit rate, and handshaking.
    /// A ToolStripStatusLabel displays the current port settings.
    /// A second text box displays error messages and other information.
    /// 
    /// Created using Visual Basic 2005 Express (free download from Microsoft).
    ///
    /// By Jan Axelson
    /// Version 1.2
    /// This application and more information about serial ports are available at Lvr.com
    /// </summary>
    /// 
    /// <remarks>
    /// The COM port can be any RS-232 port, including USB/RS-232 converters
    /// or another device (such as FTDI FT245BM) that uses COM-port drivers on the PC.
    ///
    /// The ComPorts class stores information about the system's COM ports
    /// and enables accessing them.
    ///
    /// The PortSettingsDialog dialog box displays the system's ports and updates 
    /// as needed to display the currently attached ports.
    ///
    /// If there are no COM ports, the application searches for new ports and selects
    /// one when attached.
    ///
    /// User preferences are stored in a .settings file and retrieved when the application runs.
    ///
    /// To connect two RS-232 ports on the same PC or different PCs, 
    /// use a null-modem cable. (Cross-connect RXD to TXD, RTS to CTS, DTR to DSR.)
    ///
    /// Each COM port can be controlled by an instance of this application, or one of the ports 
    /// can be controlled by Windows Hyperterminal or another application.
    ///
    /// Known issues:
    ///
    /// 1. Users should avoid removing virtual COM ports that are in use.
    /// Physically removing a USB virtual COM port with an open handle 
    /// can terminate the application with the following error:
    ///
    /// System.ObjectDisposedException was unhandled
    /// Message="Safe handle has been closed"
    /// at Microsoft.Win32.UnsafeNativeMethods.WaitCommEvent.
    ///
    /// Application.ThreadException doesn't catch this exception.
    /// AppDomain.CurrentDomain.UnhandledException can detect the exception but terminates the application. 
    ///
    /// 2. The ToolStripStatusLabel at the bottom of the form
    /// occasionally truncates to a few characters wide or less and you need to
    /// restart the application to restore it. Advice welcome on this issue.
    ///
    /// Send any comments or trouble reports to me at jan@Lvr.com 
    /// </remarks>

    public partial class MainForm  
    { 
        public MainForm() 
        { 
            InitializeComponent();if (transDefaultFormMainForm == null)	transDefaultFormMainForm = this;
           
            btnOpenOrClosePort.Click += new System.EventHandler( btnOpenOrClosePort_Click );             
            btnPort.Click += new System.EventHandler( btnPort_Click );                            
            Load += new System.EventHandler(Form1_Load);                                     
            rtbMonitor.TextChanged += new System.EventHandler( rtbMonitor_TextChanged );                     
            tmrLookForPortChanges.Tick += new System.EventHandler( tmrLookForPortChanges_Tick ); 
        }             
       
        private const string ButtonTextOpenPort = "Open COM Port"; 
        private const string ButtonTextClosePort = "Close COM Port"; 
        private const string ModuleName = "COM Port Terminal"; 
        
        internal MainForm MyMainForm; 
        internal PortSettingsDialog MyPortSettingsDialog; 
        internal ComPorts UserPort1;
       
        private delegate void AccessFormMarshalDelegate( string action, string textToAdd, Color textColor );
            
        private Color colorReceive = Color.Green;
        private Color colorTransmit = Color.Red;
        private int maximumTextBoxLength;
        private string receiveBuffer;
        private bool savedOpenPortOnStartup;
        private int userInputIndex;

        /// <summary> 
        /// Perform functions on the application's form.
        /// Used to access the form from a different thread.
        /// See AccessFormMarshal().
        /// </summary>
        /// 
        /// <param name="action"> a string that names the action to perform on the form </param>  
        /// <param name="formText"> text that the form displays </param> 
        /// <param name="textColor"> a system color for displaying text </param>

        private void AccessForm( string action, string formText, Color textColor ) 
        {                                
            switch ( action ) 
            {
                case "AppendToMonitorTextBox":
                    
                    //  Append text to the rtbMonitor textbox using the color for received data.
                    
                    rtbMonitor.SelectionColor = colorReceive; 
                    rtbMonitor.AppendText( formText ); 
                    
                    // Return to the default color.
                    
                    rtbMonitor.SelectionColor = colorTransmit; 
                    
                    //  Trim the textbox's contents if needed.
                    
                    if ( rtbMonitor.TextLength > maximumTextBoxLength ) 
                    {                         
                        TrimTextBoxContents();                         
                    }                    
                    break;

                case "DisplayStatus":
                    
                    //  Add text to the rtbStatus textbox using the specified color.
                    
                    DisplayStatus( formText, textColor ); 
                    
                    break;

                case "DisplayCurrentSettings":
                    
                    //  Display the current port settings in the ToolStripStatusLabel.
                    
                    DisplayCurrentSettings(); 
                    
                    break;
                case "DisplayHeartbeat":
                    txtHeartBeat.Text = formText;

                    break;

                case "DisplayReadEE":
                    txtReadValue.Text   = formText;

                    break;

                case "DisplayReadAllEE":
                    txtEEData.Text = formText;

                    break;


                case "DisplayWriteEE":
                    txtWriteValue.Text = formText;

                    break;

                case "DisplayFirmware":
                    txtFirmware.Text = formText;

                    break;


                case "DisplaySN":
                    txtSerialNumber.Text = formText;

                    break;

                case "DisplayInput":
                        // need to update the bit
                    //extract the bit information
                    int value = Convert.ToInt32(formText, 16);
                    int bit0, bit1, bit2, bit3;

                    bit0 =  (value & 1);
                    bit1 = (value & 2) >> 1;
                    bit2 = (value & 4) >> 2;
                    bit3 = (value & 8) >> 3;

                    chkInput0.Checked = Convert.ToBoolean(bit0);
                    chkInput1.Checked = Convert.ToBoolean(bit1);
                    chkInput2.Checked = Convert.ToBoolean(bit2);
                    chkInput3.Checked = Convert.ToBoolean(bit3);

                    //txtSerialNumber.Text = formText;

                    break;

                default:
                    
                    break;
            }                      
        } 
     
        /// <summary>
        /// Enables accessing the form from another thread.
        /// The parameters match those of AccessForm() 
        /// </summary>
        /// 
        /// <param name="action"> a string that names the action to perform on the form </param>  
        /// <param name="formText"> text that the form displays </param> 
        /// <param name="textColor"> a system color for displaying text </param>

        private void AccessFormMarshal( string action, string textToDisplay, Color textColor ) 
        {          
            AccessFormMarshalDelegate AccessFormMarshalDelegate1; 

            AccessFormMarshalDelegate1 = new AccessFormMarshalDelegate( AccessForm ); 

            object[] args = { action, textToDisplay, textColor }; 
            
            //  Call AccessForm, passing the parameters in args.
            
            base.Invoke( AccessFormMarshalDelegate1, args );             
        }       
               
        /// <summary>
        /// Display the current port parameters on the form.
        /// </summary>

        private void DisplayCurrentSettings() 
        {               
            string selectedPortState = ""; 
            
            if ( ComPorts.comPortExists ) 
            {                 
                if ( ( !( ( UserPort1.SelectedPort == null ) ) ) ) 
                {                     
                    if ( UserPort1.SelectedPort.IsOpen ) 
                    { 
                        selectedPortState = "OPEN"; 
                        btnOpenOrClosePort.Text = ButtonTextClosePort; 
                    } 
                    else 
                    { 
                        selectedPortState = "CLOSED"; 
                        btnOpenOrClosePort.Text = ButtonTextOpenPort; 
                    } 
                } 
                
                UpdateStatusLabel( System.Convert.ToString( MyPortSettingsDialog.cmbPort.SelectedItem ) + "   " + System.Convert.ToString( MyPortSettingsDialog.cmbBitRate.SelectedItem ) + "   N 8 1   Handshake: " + MyPortSettingsDialog.cmbHandshaking.SelectedItem.ToString() + "   " + selectedPortState );                 
            } 
            else 
            { 
                DisplayStatus( ComPorts.noComPortsMessage, Color.Red ); 
                UpdateStatusLabel( "" );                 
            } 
        }        
                
        /// <summary>
        /// Provide a central mechanism for displaying exception information.
        /// Display a message that describes the exception.
        /// </summary>
        /// 
        /// <param name="moduleName"> the module where the exception occurred.</param>
        /// <param name="ex"> the exception </param>

        private void DisplayException( string moduleName, Exception ex ) 
        {    
            string errorMessage = null; 
            
            errorMessage = "Exception: " + ex.Message + " Module: " + moduleName + ". Method: " + ex.TargetSite.Name; 
            
            DisplayStatus( errorMessage, Color.Red ); 
            
            //  To display errors in a message box, uncomment this line:
            // MessageBox.Show(errorMessage)            
        }        
 
        /// <summary>
        /// Displays text in a richtextbox.
        /// </summary>
        /// 
        /// <param name="status"> the text to display.</param>
        /// <param name="textColor"> the text color. </param>
       
        private void DisplayStatus( string status, Color textColor ) 
        {             
            rtbStatus.ForeColor = textColor; 
            rtbStatus.Text = status;            
        } 

        /// <summary>
        /// Get user preferences for the COM port and parameters.
        /// See SetPreferences for more information.
        /// </summary>
       
        private void GetPreferences() 
        {      
            UserPort1.SavedPortName = Settings.Default.ComPort;
            UserPort1.SavedBitRate = Settings.Default.BitRate;
            UserPort1.SavedHandshake = Settings.Default.Handshaking;
            savedOpenPortOnStartup = Settings.Default.OpenComPortOnStartup;         
        } 
         
        /// <summary>
        /// Initialize elements on the main form.
        /// </summary>

        private void InitializeDisplayElements() 
        {        
            //  The TrimTextboxContents routine trims a richtextbox with more data than this:
            
            maximumTextBoxLength = 10000; 
            rtbMonitor.SelectionColor = colorTransmit;             
        }

        /// <summary>
        ///  Determine if the textbox's TextChanged event occurred due to new user input.
        /// If yes, get the input and write it to the COM port.
        /// </summary>

        private void ProcessTextboxInput()
        {        
            IAsyncResult ar = null;
            string msg = null;
            int textLength = 0;
            string userInput = null;
        
            //  Find out if the textbox contains new user input.
            //  If the new data is data received on the COM port or if no COM port exists, do nothing.

            if (((rtbMonitor.Text.Length > userInputIndex + UserPort1.ReceivedDataLength) & ComPorts.comPortExists))
            {
                //  Retrieve the contents of the textbox.

                userInput = rtbMonitor.Text;

                //  Get the length of the new text.

                textLength = userInput.Length - userInputIndex;

                //  Extract the unread input.

                userInput = rtbMonitor.Text.Substring(userInputIndex, textLength);

                //  Create a message to pass to the Write operation (optional). 
                //  The callback routine can retrieve the message when the write completes.

                msg = DateTime.Now.ToString();

                //  Send the input to the COM port.
                //  Use a different thread so the main application doesn't have to wait
                //  for the write operation to complete.                

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(userInput, new AsyncCallback(UserPort1.WriteCompleted), msg);

                //  To use the same thread for writes to the port,
                //  comment out the statement above and uncomment the statement below.
                // UserPort1.WriteToComPort(userInput)

                AccessForm("UpdateStatusLabel", "", Color.Black);
            }
            else
            {
                //  Received bytes displayed in the text box are ignored,
                //  but we need to reset the value that indicates
                //  the number of received but not processed bytes.

                UserPort1.ReceivedDataLength = 0;
            }

            if (rtbMonitor.TextLength > maximumTextBoxLength)
            {
                TrimTextBoxContents();
            }

            //  Update the value that indicates the last character processed.

            userInputIndex = rtbMonitor.Text.Length;  
        }
                
        /// <summary> 
        /// Save user preferences for the COM port and parameters.
        /// </summary>

        private void SavePreferences() 
        {  
            // To define additional settings, in the Visual Studio IDE go to
            // Solution Explorer > right click on project name > Properties > Settings.

            if (MyPortSettingsDialog.cmbPort.SelectedIndex > -1) 
            {
                // The system has at least one COM port.

                Settings.Default.ComPort = MyPortSettingsDialog.cmbPort.SelectedItem.ToString();
                Settings.Default.BitRate = (int)MyPortSettingsDialog.cmbBitRate.SelectedItem;
                Settings.Default.Handshaking = (Handshake) MyPortSettingsDialog.cmbHandshaking.SelectedItem;
                Settings.Default.OpenComPortOnStartup = MyPortSettingsDialog.chkOpenComPortOnStartup.Checked;

                Settings.Default.Save();    
            }
        }
        
        /// <summary>
        /// Use stored preferences or defaults to set the initial port parameters.
        /// </summary>

        private void SetInitialPortParameters() 
        {         
            GetPreferences(); 
            
            if ( ComPorts.comPortExists ) 
            {                 
                //  Select a COM port and bit rate using stored preferences if available.
                
                UsePreferencesToSelectParameters(); 
                
                //  Save the selected indexes of the combo boxes.
                
                MyPortSettingsDialog.SavePortParameters();                 
            } 
            else 
            {                 
                //  No COM ports have been detected. Watch for one to be attached.
                
                tmrLookForPortChanges.Start(); 
                DisplayStatus( ComPorts.noComPortsMessage, Color.Red );                 
            }             
            UserPort1.ParameterChanged = false;             
        }         
       
        /// <summary>
        /// Saves the passed port parameters.
        /// Called when the user clicks OK on PortSettingsDialog.
        /// </summary>

        private void SetPortParameters( string userPort, int userBitRate, Handshake userHandshake ) 
        {          
            try 
            {                 
                //  Don't do anything if the system has no COM ports.
                
                if ( ComPorts.comPortExists ) 
                {                     
                    if ( MyPortSettingsDialog.ParameterChanged() ) 
                    {                         
                        //  One or more port parameters has changed.
                        
                        if ( ( string.Compare( MyPortSettingsDialog.oldPortName, userPort, true ) != 0 ) ) 
                        {                             
                            //  The port has changed.
                            //  Close the previously selected port.
                            
                            UserPort1.PreviousPort = UserPort1.SelectedPort; 
                            UserPort1.CloseComPort( UserPort1.SelectedPort ); 
                            
                            //  Set SelectedPort to the current port.
                            
                            UserPort1.SelectedPort.PortName = userPort; 
                            UserPort1.PortChanged = true;                            
                        } 
                        
                        //  Set other port parameters.
                        
                        UserPort1.SelectedPort.BaudRate = userBitRate; 
                        UserPort1.SelectedPort.Handshake = userHandshake; 
                        
                        MyPortSettingsDialog.SavePortParameters(); 
                        
                        UserPort1.ParameterChanged = true;                         
                    } 
                    else 
                    { 
                        UserPort1.ParameterChanged = false;                         
                    } 
                }
            } 
            catch ( InvalidOperationException ex ) 
            {                 
                UserPort1.ParameterChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
            catch ( UnauthorizedAccessException ex ) 
            {                 
                UserPort1.ParameterChanged = true; 
                DisplayException( ModuleName, ex ); 
                
                //  This exception can occur if the port was removed. 
                //  If the port was open, close it.
                
                UserPort1.CloseComPort( UserPort1.SelectedPort );                 
            } 
            catch ( System.IO.IOException ex ) 
            {                 
                UserPort1.ParameterChanged = true; 
                DisplayException( ModuleName, ex );                 
            } 
        }        
    
        /// <summary>
        /// Trim a richtextbox by removing the oldest contents.
        /// </summary>
        /// 
        /// <remarks >
        /// To trim the box while retaining any formatting applied to the retained contents,
        /// create a temporary richtextbox, copy the contents to be preserved to the 
        /// temporary richtextbox,and copy the temporary richtextbox back to the original richtextbox.
        /// </remarks>

        private void TrimTextBoxContents() 
        {        
            RichTextBox rtbTemp = new RichTextBox(); 
            int textboxTrimSize = 0;           
                        
            //  When the contents are too large, remove half.
            
            textboxTrimSize = maximumTextBoxLength / 2; 
            
            rtbMonitor.Select( rtbMonitor.TextLength - textboxTrimSize + 1, textboxTrimSize ); 
            rtbTemp.Rtf = rtbMonitor.SelectedRtf; 
            rtbMonitor.Clear(); 
            rtbMonitor.Rtf = rtbTemp.Rtf; 
            rtbTemp = null; 
            rtbMonitor.SelectionStart = rtbMonitor.TextLength;             
        } 

        /// <summary>
        /// Set the text in the ToolStripStatusLabel.
        /// </summary>
        /// 
        /// <param name="status"> the text to display </param>

        private void UpdateStatusLabel( string status ) 
        {        
            ToolStripStatusLabel1.Text = status; 
            StatusStrip1.Update();             
        } 

        /// <summary>
        /// Set the user preferences or default values in the combo boxes and ports array
        /// using stored preferences or default values.
        /// </summary>
      
        private void UsePreferencesToSelectParameters() 
        {         
            int myPortIndex = 0;

            myPortIndex = MyPortSettingsDialog.SelectComPort(UserPort1.SavedPortName);
                
            MyPortSettingsDialog.SelectBitRate(UserPort1.SavedBitRate);

            UserPort1.SelectedPort.BaudRate = (int)MyPortSettingsDialog.cmbBitRate.SelectedItem;
                
            MyPortSettingsDialog.SelectHandshaking(UserPort1.SavedHandshake);

            UserPort1.SelectedPort.Handshake = (Handshake)MyPortSettingsDialog.cmbHandshaking.SelectedItem;

            MyPortSettingsDialog.chkOpenComPortOnStartup.Checked = savedOpenPortOnStartup;           
        }
        
        /// <summary>
        /// Depending on the text displayed on the button, open or close the selected port
        /// and change the button text to the opposite action.
        /// </summary>

        private void btnOpenOrClosePort_Click( object sender, System.EventArgs e ) 
        {         
            if ( ( btnOpenOrClosePort.Text == ButtonTextOpenPort ) ) 
            { 
                UserPort1.OpenComPort(); 
                if ( UserPort1.SelectedPort.IsOpen ) 
                { 
                    btnOpenOrClosePort.Text = ButtonTextClosePort; 
                }                 
            } 
            else 
            { 
                UserPort1.CloseComPort( UserPort1.SelectedPort ); 
                
                if ( !( UserPort1.SelectedPort.IsOpen ) ) 
                { 
                    btnOpenOrClosePort.Text = ButtonTextOpenPort; 
                }                 
            }             
        } 

        /// <summary>
        /// Look for COM ports and display them in the combo box.
        /// </summary>

        private void btnPort_Click( object sender, System.EventArgs e ) 
        {          
            ComPorts.FindComPorts(); 
            
            MyPortSettingsDialog.DisplayComPorts(); 
            MyPortSettingsDialog.SelectComPort( UserPort1.SelectedPort.PortName ); 
            MyPortSettingsDialog.SelectBitRate( UserPort1.SelectedPort.BaudRate ); 
            MyPortSettingsDialog.SelectHandshaking( UserPort1.SelectedPort.Handshake ); 
            
            UserPort1.ParameterChanged = false; 
            
            //  Display the combo boxes for setting port parameters.
            
            MyPortSettingsDialog.ShowDialog(); 
        } 

        /// <summary>
        /// Create an instance of the ComPorts class.
        /// Initialize port settings and other parameters. 
        /// specify behavior on events.
        /// </summary>
       
        private void Form1_Load( object sender, System.EventArgs e ) 
        {
                Show();                        

                UserPort1 = new ComPorts();

                MyPortSettingsDialog = new PortSettingsDialog();

                tmrLookForPortChanges.Interval = 1000;
                tmrLookForPortChanges.Stop();

                InitializeDisplayElements();

                SetInitialPortParameters();

                if (ComPorts.comPortExists)
                {
                    UserPort1.SelectedPort.PortName = ComPorts.myPortNames[MyPortSettingsDialog.cmbPort.SelectedIndex];

                    //  A check box enables requesting to open the selected COM port on start up.
                    //  Otherwise the application opens the port when the user clicks the Open Port
                    //  button or types text to send. 

                    if (MyPortSettingsDialog.chkOpenComPortOnStartup.Checked)
                    {
                        UserPort1.PortOpen = UserPort1.OpenComPort();
                        AccessForm("DisplayCurrentSettings", "", Color.Black);
                        AccessForm("DisplayStatus", "", Color.Black);
                    }
                    else
                    {
                        DisplayCurrentSettings();
                    }
                }

                //  Specify the routines that execute on events in other modules.
                //  The routines can receive data from other modules. 

                ComPorts.UserInterfaceData += new ComPorts.UserInterfaceDataEventHandler(AccessFormMarshal);
                PortSettingsDialog.UserInterfaceData += new PortSettingsDialog.UserInterfaceDataEventHandler(AccessFormMarshal);
                PortSettingsDialog.UserInterfacePortSettings += new PortSettingsDialog.UserInterfacePortSettingsEventHandler(SetPortParameters);
                       }         
        
        /// <summary>
        /// Close the port if needed and save preferences.
        /// </summary>
        
        private void Form1_FormClosing( object sender, System.Windows.Forms.FormClosingEventArgs e ) 
        {             
            UserPort1.CloseComPort( UserPort1.SelectedPort ); 
            SavePreferences(); 
        } 

        /// <summary>
        /// Do whatever is needed with new characters in the textbox.
        /// </summary>
     
        private void rtbMonitor_TextChanged( System.Object sender, System.EventArgs e ) 
        {           
            ProcessTextboxInput();             
        } 
               
        /// <summary>
        /// Look for ports. If at least one is found, stop the timer and
        /// select the saved port if possible or the first port.
        /// This timer is enabled only when no COM ports are present.
        /// </summary>

        private void tmrLookForPortChanges_Tick( object sender, System.EventArgs e ) 
        {         
            ComPorts.FindComPorts(); 
            
            if ( ComPorts.comPortExists ) 
            {                 
                tmrLookForPortChanges.Stop(); 
                DisplayStatus( "COM port(s) found.", Color.Black ); 
                
                MyPortSettingsDialog.DisplayComPorts(); 
                MyPortSettingsDialog.SelectComPort( UserPort1.SavedPortName ); 
                MyPortSettingsDialog.SelectBitRate(UserPort1.SavedBitRate); 
                MyPortSettingsDialog.SelectHandshaking( ( ( Handshake )( UserPort1.SavedHandshake ) ) ); 
                
                //  Set selectedPort.
                
                SetPortParameters( UserPort1.SavedPortName, UserPort1.SavedBitRate, ( ( Handshake )( UserPort1.SavedHandshake ) ) ); 
                
                DisplayCurrentSettings(); 
                UserPort1.ParameterChanged = true; 
            } 
        } 
                
        // Default instance for Form

        private static MainForm transDefaultFormMainForm = null;
        public static MainForm TransDefaultFormMainForm
        { 
        	get
        	{ 
        		if (transDefaultFormMainForm == null)
        		{
        			transDefaultFormMainForm = new MainForm();
        		}
        		return transDefaultFormMainForm;
        	} 
        }

        private void rtbMonitor_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnSent_Click(object sender, EventArgs e)
        {
            byte data;
            data = 0x13;

            string mystring;


            IAsyncResult ar = null;
            string msg = null;

            StringBuilder sb = new StringBuilder();
            StringBuilder cpkey = new StringBuilder();
            StringBuilder exit = new StringBuilder();


            cpkey.Append("cpkey");
            cpkey.Append("\r");

            exit.Append("quit");
            exit.Append("\r");


            sb.Append(txtSent.Text );
            sb.Append("\r");
            //sb.Append("Second line in default");

            mystring = sb.ToString();


            UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);


            mystring = cpkey.ToString();
            ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(mystring, new AsyncCallback(UserPort1.WriteCompleted), msg);
            mystring = sb.ToString();
            ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(mystring, new AsyncCallback(UserPort1.WriteCompleted), msg);
            mystring = exit.ToString();
            ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(mystring , new AsyncCallback(UserPort1.WriteCompleted), msg);
            //ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(data, new AsyncCallback(UserPort1.WriteCompleted), msg);

        }

        /*
        private void nudConstant_ValueChanged(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int  value;
            string strvalue;

            value = (int)nudConstant.Value;
            try
            {
                strvalue = value.ToString("X");

                // pad with Zero infront since we expect 2 bytes
                if (strvalue.Length == 1)
                    strvalue = "0" + strvalue;

                //strvalue = String.Format("{0:X2}", value);
                strCommand = "@SI" + cboChannel.SelectedIndex.ToString()   + strvalue+"*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }


        }
        */

        private void tbConstant_Scroll(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;

            value = (int)tbConstant.Value;
            try
            {
                strvalue = value.ToString("X");

                // pad with Zero infront since we expect 2 bytes
                //if (strvalue.Length == 1)
                //  strvalue = "0" + strvalue;

                strvalue = String.Format("{0:X4}", value);
                strCommand = "@SI" + cboChannel.SelectedIndex.ToString() + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void tbConstant_MouseUp(object sender, MouseEventArgs e)
        {

            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;

            value = (int)tbConstant.Value;
            try
            {
                strvalue = value.ToString("X");

                // pad with Zero infront since we expect 2 bytes
                //if (strvalue.Length == 1)
                  //  strvalue = "0" + strvalue;

                strvalue = String.Format("{0:X2}", value);
                strCommand = "@SI" + cboChannel.SelectedIndex.ToString() + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }


        }

        private void tbStrobeIntensity_MouseUp(object sender, MouseEventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;

            value = (int)tbStrobeIntensity.Value;
            try
            {


                strvalue = value.ToString("X");

                // pad with Zero infront since we expect 2 bytes
                //if (strvalue.Length == 1)
                //  strvalue = "0" + strvalue;

                strvalue = String.Format("{0:X4}", value);
                strCommand = "@SS" + cboChannel.SelectedIndex.ToString() + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }


        }

        private void tbStrobeDuration_MouseUp(object sender, MouseEventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;

            value = (int)tbStrobeDuration.Value;
            try
            {
                strvalue = value.ToString("X");

                // pad with Zero infront since we expect 2 bytes
                if (strvalue.Length == 1)
                    strvalue = "0" + strvalue;

                //strvalue = String.Format("{0:X2}", value);
                strCommand = "@SD" + cboChannel.SelectedIndex.ToString() + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void cmdStrobe_Click(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;

            
            try
            {
            
                strCommand = "@ST" + cboChannel.SelectedIndex.ToString()  + "1*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void cmdLock_Click(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;


            try
            {

                strCommand = "@SL1*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void cmdUnlock_Click(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;


            try
            {

                strCommand = "@SL0*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;


            try
            {

                strCommand = "@ST01*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
                Thread.Sleep(50);
                strCommand = "@ST11*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
                Thread.Sleep(50);
                strCommand = "@ST21*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
                Thread.Sleep(50);
                strCommand = "@ST31*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);

                Thread.Sleep(50);

            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void btnStopTimer_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            UserPort1.GetST = false;

        }

        private void btnStartTimer_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = true;

            txtEEData.Text = "";

            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;


            UserPort1.GetST = true;

            value = 0;

            strvalue = String.Format("{0:X}", value);

            try
            {

                strCommand = "@ST" + strvalue + "1*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }


        }

        private void btnGetHeartBeat_Click(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;


            try
            {

                strCommand = "@GH*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            int value;
            try
            {
                value = Convert.ToInt32(txtAddress.Text);

                lblAddress.Text = "0x" + String.Format("{0:X2}", value);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void btnReadEEData_Click(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            string strvalue;

            value = Convert.ToInt32(txtAddress.Text );



                
            strvalue = String.Format("{0:X2}", value);
            

            try
            {

                strCommand = "@GE" +strvalue+ "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void btnWriteEEData_Click(object sender, EventArgs e)
        {
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;

            try
            {
            value = Convert.ToInt32(txtAddress.Text);
            wvalue = Convert.ToInt32(txtWriteValue.Text);



            strvalue = String.Format("{0:X2}", value);
            strwvalue = String.Format("{0:X2}", wvalue);

         

                strCommand = "@SE" + strvalue +strwvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void btnReadAll_Click(object sender, EventArgs e)
        {
            txtEEData.Text  = "";

            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;


            UserPort1.GetAllEEData = true;

            value = 0;
           
            strvalue = String.Format("{0:X2}", value);
            
            try
            {

                strCommand = "@GE" + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }


        }

        private void txtReadValue_TextChanged(object sender, EventArgs e)
        {
            int value;
            try
            {
                value = Convert.ToInt32(txtReadValue.Text);

                lblReadValue.Text = "0x" + String.Format("{0:X2}", value);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void txtWriteValue_TextChanged(object sender, EventArgs e)
        {
            int value;
            try
            {
                value = Convert.ToInt32(txtWriteValue.Text);

                lblWriteValue.Text = "0x" + String.Format("{0:X2}", value);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void btnZeroUserEEData_Click(object sender, EventArgs e)
        {
            txtEEData.Text = "";

            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;


            UserPort1.ZeroAllEEData = true;

            value = 0;

            strvalue = String.Format("{0:X2}", value);

            try
            {

                strCommand = "@SE" + strvalue + "00*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void btnGetDeviceSN_Click(object sender, EventArgs e)
        {
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;


            

            value = 0;

            strvalue = String.Format("{0:X2}", value);

            try
            {

                strCommand = "@GR*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void cboOutputNormal_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check the index value
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;




            value = cboOutputNormal.SelectedIndex;

            strvalue = value.ToString("X") ;

            try
            {

                strCommand = "@SN"+strvalue +"*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void cboOutputInverted_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check the index value
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;




            value = cboOutputInverted.SelectedIndex;

            strvalue = value.ToString("X");

            try
            {

                strCommand = "@SV" + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void cboSerialReply_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check the index value
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;




            value = cboSerialReply.SelectedIndex;

            strvalue = value.ToString("X");

            try
            {

                strCommand = "@SR" + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void cboButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check the index value
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;




            value = cboButton.SelectedIndex;

            strvalue = value.ToString("X");

            try
            {

                strCommand = "@SB" + strvalue + "*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void btnGetFirmware_Click(object sender, EventArgs e)
        {
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;




            value = 0;

            strvalue = String.Format("{0:X2}", value);

            try
            {

                strCommand = "@GF*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }

        }

        private void btnGetInput_Click(object sender, EventArgs e)
        {
            //GR
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;




            value = 0;

            strvalue = String.Format("{0:X2}", value);

            try
            {

                strCommand = "@GO*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }


        }

        private void chkOutput0_CheckedChanged_1(object sender, EventArgs e)
        {
            //@SOX*
            IAsyncResult ar = null;
            string msg = null;
            string strCommand;
            int value;
            int wvalue;
            string strvalue;
            string strwvalue;

            int bit0;
            int bit1;
            int bit2;
            int bit3;
            int bit4;
            int bit5;
            int bit6;
            int bit7;


            bit0 = Convert.ToInt16(chkOutput0.Checked);
            bit1 = Convert.ToInt16(chkOutput1.Checked);
            bit2 = Convert.ToInt16(chkOutput2.Checked);
            bit3 = Convert.ToInt16(chkOutput3.Checked);
            bit4 = Convert.ToInt16(chkOutput4.Checked);
            bit5 = Convert.ToInt16(chkOutput5.Checked);
            bit6 = Convert.ToInt16(chkOutput6.Checked);
            bit7 = Convert.ToInt16(chkOutput7.Checked);



            value = bit0 + (bit1 << 1) + (bit2 << 2) + (bit3 << 3)+ (bit4 << 4) + (bit5 << 5) + (bit6 << 6) + (bit7 << 7);

            strvalue = String.Format("{0:X2}", value);

            try
            {

                strCommand = "@SO"+ strvalue +"*";

                UserPort1.WriteToComPortDelegate1 = new ComPorts.WriteToComPortDelegate(UserPort1.WriteToComPort);

                ar = UserPort1.WriteToComPortDelegate1.BeginInvoke(strCommand, new AsyncCallback(UserPort1.WriteCompleted), msg);
            }
            catch (Exception ec)
            {
                Console.WriteLine("{0} Exception caught.", ec);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tbStrobeDuration_Scroll(object sender, EventArgs e)
        {

        }

        private void tbStrobeIntensity_Scroll(object sender, EventArgs e)
        {

        }

        private void btnOpenOrClosePort_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPort_Click_1(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            btnGetInput_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }
    }   
} 
