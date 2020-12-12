using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Media;

namespace TestGame
{
    public partial class Form1 : Form
    {
        int timeLeft = 60;
        int doDisplay = 0;
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // int countThis = 0;
            // string mainWord = "ELEPHANT!";
            //"ELEPHANT".substring(0, 7);
            bool FirstTimeRan = true;
            FormLoadProcess(FirstTimeRan);

            int returnNum = RandomQuestion();

        }

        private void FormLoadProcess(bool FirstTimeRan)
        {


            int controlCount = 8;

            for (int i = 0; i < controlCount; i++)
            {
                var myButton = new Button();
                var myLabel = new Label();
                myLabel.Visible = false;
                myButton.Click += ButtonClickHandler;
                myButton.Height = 90;
                myButton.Width = 90;


                // mainWord.Substring(0, i);


            

                //  myLabel.Text = mainWord.Substring(countThis, i).ToString();
                // countThis = countThis++; 
                
                myLabel.Text = i.ToString();

                if (FirstTimeRan == true)
                {
                    switch (i)
                    {
                        case 0:
                            myButton.BackColor = Color.Blue;
                            myButton.ForeColor = Color.White;
                            break;
                        default:
                            myButton.BackColor = Color.Blue;
                            myButton.ForeColor = Color.White;
                            break;
                    }
                    myButton.Text = i.ToString();
                    this.flowLayoutPanel1.Controls.Add(myButton);
                    this.flowLayoutPanel1.Controls.Add(myLabel);
                }
                else
                {

                    myButton.Text = "*";
                    
                }
            }
        }



        private int RandomQuestion()
        {
            int min = 0;
            int max = 8;

            Random random = new Random();
            int number = random.Next(min, max);
            lblHidden.Text = number.ToString();

            switch (number)
            {

                case 0:
                    lblQuestion.Text = "System.out.print(a[0])";
                    break;
                case 1:
                    lblQuestion.Text = "System.out.print(a[1])";
                    break;
                case 2:
                    lblQuestion.Text = "System.out.print(a[2])";
                    break;
                case 3:
                    lblQuestion.Text = "System.out.print(a[3])";
                    break;
                case 4:
                    lblQuestion.Text = "System.out.print(a[4])";
                    break;
                case 5:
                    lblQuestion.Text = "System.out.print(a[5])";
                    break;
                case 6:
                    lblQuestion.Text = "System.out.print(a[6])";
                    break;
                case 7:
                    lblQuestion.Text = "System.out.print(a[7])";
                    break;
                case 8:
                    lblQuestion.Text = "System.out.print(a[8])";
                    break;
                case 9:
                    lblQuestion.Text = "System.out.print(a[9])";
                    break;
            }

            return number;
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            //var buttonThatWasClicked = sender as Button;
            var buttonThatWasClicked = (Button)sender;
            // var labelThatWasCLicked = (Label)sender; 

            var intValue = int.Parse(buttonThatWasClicked.Text);
            //  var intValue2 = buttonThatWasClicked; 
            // MessageBox.Show(buttonThatWasClicked.Text);
            var totalVal = 0;
            var compareVal = int.Parse(lblHidden.Text);
            if (compareVal == intValue)
            {
                totalVal = 0;
            }
            else
            {
                totalVal = 1;
            }
            int totalScore;

            switch (totalVal)
            {
                case 0:
                    buttonThatWasClicked.BackColor = Color.Green;
                    buttonThatWasClicked.ForeColor = Color.White;

                    totalScore = int.Parse(lblScore.Text) + 1;
                    lblScore.Text = totalScore.ToString();

                    break;
                case 1:
                    buttonThatWasClicked.BackColor = Color.Red;
                    buttonThatWasClicked.ForeColor = Color.White;
                    if (int.Parse(lblScore.Text) > 0)
                    {
                        totalScore = int.Parse(lblScore.Text) - 1;
                        lblScore.Text = totalScore.ToString();

                    }

                    break;
                default:
                    buttonThatWasClicked.BackColor = Color.Blue;
                    buttonThatWasClicked.ForeColor = Color.White;
                    break;
            }

            if (buttonThatWasClicked.BackColor == Color.Green)
            {
                RandomQuestion();
                MessageBox.Show("You Scored");
                buttonThatWasClicked.BackColor = Color.Blue;
                if (chkSound.Checked == true)
                {
                    SystemSounds.Beep.Play();
                }
            }

            if (buttonThatWasClicked.BackColor == Color.Red)
            {
                RandomQuestion();
                MessageBox.Show("You Were wrong");
                buttonThatWasClicked.BackColor = Color.Blue;
                if (chkSound.Checked == true)
                {
                    SystemSounds.Exclamation.Play();
                }
            }



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimer.Checked == true)
            {

                lblTimer.Visible = true;
                timer1.Enabled = true;
                countTimer.Enabled = true;
                countTimer.Tick += new System.EventHandler(OnTimerCountEvent);
                timer1.Tick += new System.EventHandler(OnTimerEvent);
            }
            else
            {
                timer1.Enabled = false;
                countTimer.Enabled = false;
                lblTimer.Visible = false;
            }
        }
        private void OnTimerEvent(object sender, EventArgs e)
        {
            //  MessageBox.Show("You Lose");
            //SystemSounds.Exclamation.Play();
        }
        private void OnTimerCountEvent(object sender, EventArgs e)
        {

            //lblTimer.Text
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
           

            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                // Display time remaining as mm:ss
                var timespan = TimeSpan.FromSeconds(timeLeft);
                lblTimer.Text = timespan.ToString(@"ss");

                // Alternate method
                //int secondsLeft = timeLeft % 60;
                //int minutesLeft = timeLeft / 60;
            }
            else
            {
                timer2.Stop();
                if (chkSound.Checked == true)
                {
                    SystemSounds.Exclamation.Play();
                }
               
                timer1.Enabled = false;
                timer2.Enabled = false;
                countTimer.Enabled = false;

                if (doDisplay == 0)
                {
                   
                    MessageBox.Show("Time's up!", "Time has elapsed", MessageBoxButtons.OK);
                    doDisplay = 1;
                    if (int.Parse(lblScore.Text) > 0)
                    {
                        int totalScore; 
                        totalScore = int.Parse(lblScore.Text) - 1;
                        lblScore.Text = totalScore.ToString();

                    }
                    RandomQuestion();
                    chkTimer.Checked = false; 
                }
                
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RandomQuestion();
        }

        private void chkLabels_CheckedChanged(object sender, EventArgs e)
        {
            FormLoadProcess(false);
        }
    }
}
