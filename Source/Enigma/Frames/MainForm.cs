using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Enigma.Components;
using Enigma.Graphics;
using Enigma.Logistics;

namespace Enigma.Frames
{
    public partial class MainForm : Form
    {
        private Random randomGenerator;

        private EnigmaMachine enigmaMachine;
        private Enigma_GR enigma_GR;
        private Theme theme;
        private readonly ConfigurationHolder configHolder = ConfigurationHolder.GetInstance();
        private int distanceBetweenRotors,enigmaX,enigmaY;
        private String inputString, outputString;
        
        private HowToForm howToForm = new HowToForm();




        public MainForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeEnigmaMachine(3);

        }

        private void InitializeCustomComponents()
        {
            randomGenerator = new Random();

            distanceBetweenRotors = Int32.Parse(configHolder.Settings["distance_between_rotors"]);
            enigmaX = Int32.Parse(configHolder.Settings["enigma_x"]);
            enigmaY = Int32.Parse(configHolder.Settings["enigma_y"]);

            inputString = "";
            outputString = "";

            theme = new Theme
                        {
                            ContactBlob = Brushes.LightGray,
                            ContactBlobStep = Brushes.Black,
                            ContactBlobOutline = Pens.Black,
                            ContactBlobLR = Brushes.Red,
                            ContactBlobRL = Brushes.Blue,
                            ContactBlobReflected = Brushes.Fuchsia,
                            ContactBody = Pens.DarkGray,
                            ContactBodyLR = new Pen(Brushes.Red, 3),
                            ContactBodyRL = new Pen(Brushes.Blue, 3),
                            ContactBodyReflected = new Pen(Brushes.Fuchsia, 3),
                            SmallLabel = new Font(FontFamily.GenericSansSerif, 8),
                            SmallBoldLabel = new Font(FontFamily.GenericSansSerif,8,FontStyle.Bold),
                            Text = Brushes.Black,
                            BigLabel = new Font(FontFamily.GenericSansSerif, 16)
                        };

            
        }

        private void InitializeEnigmaMachine(int numberOfRotorsParam)
        {
            if (enigmaMachine!=null)
            {
                for (int i=0; i<enigmaMachine.NumberOfRotors; i++)
                {
                    this.Controls.Remove(this.Controls.Find("riu"+i , true).First());
                    this.Controls.Remove(this.Controls.Find("rid" + i, true).First());
                    this.Controls.Remove(this.Controls.Find("rau" + i, true).First());
                    this.Controls.Remove(this.Controls.Find("rad" + i, true).First());
                    this.Controls.Remove(this.Controls.Find("itr" + i, true).First());
                }
            }

            enigmaMachine = new EnigmaMachine(numberOfRotorsParam);

            for (int i = 0; i < enigmaMachine.NumberOfRotors; i++)
            {
                AddRotorControlls(i);
            }

            enigma_GR = new Enigma_GR(enigmaMachine,theme);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGray, 12, enigmaY + 422, enigmaX + enigmaMachine.NumberOfRotors * distanceBetweenRotors + 25, 40);
            e.Graphics.DrawString("Rotor : ",theme.SmallLabel,Brushes.Black,72,enigmaY+425);
            e.Graphics.DrawString("Alphabet : ", theme.SmallLabel, Brushes.Black, 55, enigmaY+445);
            enigma_GR.DrawEnigma(e.Graphics,enigmaX,enigmaY);    
        }

        private void UpdateRotorInputAreas()
        {
            for (int i=0; i<enigmaMachine.NumberOfRotors; i++)
            {
                Controls["itr" + i].Text =
                    Convert.ToChar(enigmaMachine.Rotors["rotor_" + i].CurrentIndex + 65).ToString();
            }
        }


        private void GenericTurnRotorMethod(object sender, EventArgs e)
        {
            Button button = (Button) sender;
            int rotorNumber = Int32.Parse(button.Name.Substring(3, 1));
            Rotor designatedRotor = enigmaMachine.Rotors["rotor_" + rotorNumber];
            String operation = button.Name.Substring(1, 2);

            switch (operation)
            {
                case "iu":
                    designatedRotor.TurnUp();
                    break;
                case "id":
                    designatedRotor.TurnDown();
                    break;
                case "au":
                    designatedRotor.AdvanceAlphabet();
                    break;
                case "ad":
                    designatedRotor.WithdrawAlphabet();
                    break;
            }

            enigmaMachine.ResetContactMarkings();

            Controls.Find("itr" + rotorNumber, false).First().Text =
                Convert.ToChar(designatedRotor.CurrentIndex + 65).ToString();

            ResetInputOutputFields();

            Invalidate();
        }

        private void ResetEverything()
        {
            InitializeEnigmaMachine(enigmaMachine.NumberOfRotors);
            ResetInputOutputFields();
            
            Invalidate();
        }

        private void GenericKeyDownRotorMethod(Object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            int rotorNumber = Int32.Parse(textBox.Name.Substring(3, 1));
            String rotorName = "rotor_" + rotorNumber;

            Rotor designatedRotor = enigmaMachine.Rotors[rotorName];

            int currentIndex = designatedRotor.CurrentIndex;
            int desiredIndex = e.KeyValue <= 90 ? (e.KeyValue - 65) : (e.KeyValue - 97);

            if (desiredIndex != -57)
            {
                if (desiredIndex<0)
                {
                    MessageBox.Show(
                        "The key you pressed is not present on an Enigma machine's rotor (only letters are allowed).");
                }
                else
                {
                    int stepCounter = desiredIndex - currentIndex;
                    if (stepCounter<0)
                    {
                        designatedRotor.TurnDown(0-stepCounter);
                    }
                    else
                    {
                        designatedRotor.TurnUp(stepCounter);
                    }
                }
                enigmaMachine.ResetContactMarkings();
                ResetInputOutputFields();
                UpdateRotorInputAreas();
                Invalidate();
            }
        }

        private void AddRotorControlls(int rotorNumber)
        {
            Button upButton= new Button();
            Button downButton = new Button();
            Button alphaUpButton = new Button();
            Button alphaDownButton = new Button();
            TextBox inputBox = new TextBox();

            upButton.Name = "riu" + rotorNumber;
            upButton.Top = enigmaY + 422;
            upButton.Left = enigmaX + 76 + rotorNumber*distanceBetweenRotors;
            upButton.Width = 30;
            upButton.Height = 20;
            upButton.Text = @"+";
            upButton.Click += new EventHandler(GenericTurnRotorMethod);

            downButton.Name = "rid" + rotorNumber;
            downButton.Top = enigmaY + 422;
            downButton.Left = enigmaX + 106 + rotorNumber * distanceBetweenRotors;
            downButton.Width = 30;
            downButton.Height = 20;
            downButton.Text = @"-";
            downButton.Click += new EventHandler(GenericTurnRotorMethod);

            alphaUpButton.Name = "rau" + rotorNumber;
            alphaUpButton.Top = enigmaY + 442;
            alphaUpButton.Left = enigmaX + 76 + rotorNumber * distanceBetweenRotors;
            alphaUpButton.Width = 30;
            alphaUpButton.Height = 20;
            alphaUpButton.Text = @"+";
            alphaUpButton.Click += new EventHandler(GenericTurnRotorMethod);

            alphaDownButton.Name = "rad" + rotorNumber;
            alphaDownButton.Top = enigmaY + 442;
            alphaDownButton.Left = enigmaX + 106 + rotorNumber * distanceBetweenRotors;
            alphaDownButton.Width = 30;
            alphaDownButton.Height = 20;
            alphaDownButton.Text = @"-";
            alphaDownButton.Click += new EventHandler(GenericTurnRotorMethod);

            inputBox.Name = "itr" + rotorNumber;
            inputBox.Top = enigmaY;
            inputBox.Left = enigmaX + 76 + rotorNumber * distanceBetweenRotors;
            inputBox.Width = 60;
            inputBox.Height = 20;
            inputBox.Font = new Font(FontFamily.GenericSansSerif, 12);
            inputBox.Text = "A";
            inputBox.TextAlign = HorizontalAlignment.Center;
            inputBox.KeyDown += new KeyEventHandler(GenericKeyDownRotorMethod);
            inputBox.ReadOnly = true;
            inputBox.BackColor = Color.White;

            Controls.Add(upButton);
            Controls.Add(downButton);
            Controls.Add(alphaUpButton);
            Controls.Add(alphaDownButton);
            Controls.Add(inputBox);
        }

        private void ResetInputOutputFields()
        {
            inputString = "";
            outputString = "";

            UpdateInputOutputFields();
        }

        private void UpdateInputOutputFields()
        {
            inputTextArea.Text = inputString;
            outputTextArea.Text = outputString;
        }

        private void inputTextArea_KeyDown(object sender, KeyEventArgs e)
        {

            var keyValue = e.KeyValue <= 90 ? (e.KeyValue - 65) : (e.KeyValue - 97);

            if (keyValue == -57)
            {
                if (inputString.Length>0)
                {
                    inputString = inputString.Substring(0, inputString.Length - 1);
                    outputString = outputString.Substring(0, outputString.Length - 1);

                    enigmaMachine.ResetContactMarkings();

                    enigmaMachine.WithdrawRotors();
                }
            }
            else
            {

                if (keyValue < 0 || keyValue > 25)
                {
                    MessageBox.Show(
                        "The key you pressed is not supported by an Enigma machine (only letters are allowed).");
                }
                else
                {
                    inputString = String.Concat(inputString, Convert.ToChar(keyValue + 65).ToString());
                    enigmaMachine.ResetContactMarkings();
                    enigmaMachine.AdvanceRotors();

                    int encryptedValue = enigmaMachine.GetEncrytedKeyValue(keyValue);

                    outputString = String.Concat(outputString, Convert.ToChar(encryptedValue + 65).ToString());


                }
            }

            inputTextArea.Text = inputString;
            outputTextArea.Text = outputString;

            UpdateRotorInputAreas();

            Invalidate();

            

        }

        private void GenericRotorsNumberClick(Object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem) sender;
            String name = toolStripMenuItem.Name;
            int numberOfRotors = Int32.Parse(name.Substring(12, name.Length - 12));

            InitializeEnigmaMachine(numberOfRotors);

            for (int i = 1; i <= 10; i++ )
            {
                var item = (ToolStripMenuItem) topMenuBar.Items.Find("rotorsNumber" + i, true).First();
                item.Checked = false;
            }

            toolStripMenuItem.Checked = true;

            ResetInputOutputFields();
            UpdateRotorInputAreas();

            Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < inputString.Length; i++ )
            {
                enigmaMachine.WithdrawRotors();
            }
            enigmaMachine.ResetContactMarkings();

            ResetInputOutputFields();
            UpdateRotorInputAreas();

            Invalidate();

        }

        private void pasteTextToInputToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IDataObject clipboardContent = Clipboard.GetDataObject();


            if (!clipboardContent.GetDataPresent(DataFormats.Text))
            {
                MessageBox.Show("Unable to find any message to encrypt in the clipboard.");
                return;
            }

            String message = clipboardContent.GetData(DataFormats.Text).ToString();
            String encryptedMessage = enigmaMachine.GetEncryptedString(message);

            if (encryptedMessage == null)
            {
                MessageBox.Show(
                    "The given message contains one or more illegal characters (space, tab, digit, etc). Please use letters only !");
            }
            else
            {
                inputString = message;
                outputString = encryptedMessage;


                UpdateInputOutputFields();
                UpdateRotorInputAreas();
                enigmaMachine.ResetContactMarkings();
                Invalidate();
            }

        }

        private void copyTextFromInputAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(inputString);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(outputString);
        }


        private void resetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ResetEverything();
        }


        private void configureTheMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "In order to setup The Enigma Machine you have to follow these steps : \r\n\r\n";
            message +=
                " STEP 1 : select the numbers of rotors\r\n";
            message +=
                " STEP 2 : for each rotor select the proper alphabet offset\r\n";
            message +=
                " STEP 3 : for each rotor select the coresponding letter";

            howToForm.appear("How to setup", message);

        }

        private void encryptAMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "After you configure the machine (see \"Setup the machine\") all you have to do is type your message in the \"Input\" field and the encrypted message will be generated in the \"Output\" field.";
            message +=
                "\r\n\r\nMake sure you don't forget to write down the machine configurations (number of rotors, alphabet offset, rotor configuration).";
            message +=
                "\r\n\r\n\r\nTo speed things up, you could use the \"Clipboard\" functions to perform any data transfer";

            howToForm.appear("How to encrypt", message);
        }

        private void decryptAMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "The decryption phase is identical to the encryption phase. You type the encrypted message in the \"Input\" field, and if you configured the machine properly, you should have the original message in the \"Output\" field.";
            message +=
                "\r\n\r\n\r\nTo speed things up, you could use the \"Clipboard\" functions to perform any data transfers";

            howToForm.appear("How to decrypt", message);
        }

        private void whatIsThisAndHowItWorksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "This is a simulator for the famous Enigma encryption machine. Even though the mechanism is simple, the complexity of the encryption and the difficulty in breaking it are remarcable.\r\n";
            message +=
                "\r\n\r\nThe machine has a keyboard with 26 keys (the \"Input\" field) and a board with 26 lightbulbs each representing a letter (the \"Output\" field).";
            message+="Between them we have a plugboard, the rotors and a reflector.\n\r\n\r The plugboard allows you to switch letters in order to improve the encryption (this feature is not supported by this simulator).";
            message += "The rotors are cylindrical components that have 26 contacts on one side and 26 contacts on the other side. Inside we have wires that randomly connect the contacts. The reflector is just a component that sends the electric current back to the rotors";
            message += "When a key is pressed, an electric flow is sent on the corresponding contact on the plugboard. From here the current travels through the rotors to the reflector and back again to the plugboard and finally it lights a lightbulb indicating the encrypted letter. ";
            message += "\r\n\r\nEvery time a key is pressed, the rotor is turned one notch, generating a totally different rotor configuration.";
            message += "\r\n\r\nIt is essential to configure the machine properly before decrypting a message.";

            howToForm.appear("What is this ?", message);
        }

        private void whatTheSimulatorDoesAndDoesntToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "The simulator implements the principle of the machine. It allows the use of any number of rotors between 1 and 10 (the machine usually had 3 rotors). Also full configuration of the rotor position and alphabet offset is allowed.";
            message +=
                "\r\n\r\nThe simulator offers no plugboard functionality (switching 2 letters up to a maximum of 13 switches), key management and inter-rotor switches(instead of the default 012345... configuration, you could use 1503482..., etc.).";
           

            howToForm.appear("What it does and wat it doesn't",message);
        }


    }
}
