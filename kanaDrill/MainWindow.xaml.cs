using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;

namespace kanaDrill
{
    public partial class MainWindow : Window
    {
        
        ushort      maxPoints       = levelEngine.levelPoints[levelEngine.levelPoints.Length - 1];
        int         timeleft        = 0;
        bool        started         = false;
        bool        submitLock      = false;
        bool        brushLock       = false;
        byte        currMode        = 1;
        string      currField1;
        string      currField2;
        string      currField3;
        string      currQuestion;
        string      currAnswer;
        Timer       quizTimer       = new Timer();
        Kana        getQuiz         = new Kana();

        public MainWindow()
        {
            InitializeComponent();
            InitMessage();
            quizTimer.Tick += QuizTimer_Tick;
            quizTimer.Interval = 100;
        }
        public void pullQuiz()
        {
            getQuiz.pullKana(ref currField1, ref currField2, ref currField3);
            switch (currMode)
            {
                case 1:
                    currQuestion = currField1;
                    currAnswer = currField3;
                    break;

                case 2:
                    if (currField2 == null)
                        getQuiz.pullKana(ref currField1, ref currField2, ref currField3);
                    currQuestion = currField2;
                    currAnswer = currField3;
                    break;
            }
            timeleft = levelEngine.levelTimer[levelEngine.levelIndex];
            questionBox.Text = currQuestion;
            quizTimer.Start();
        }
        private async void answerInput_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
                if (!started)
                {
                    switchStart(ref started);
                    initMessage.Text = string.Empty;
                    pullQuiz();
                    updateTable();
                }
                if (started && !submitLock && answerInput.Text != "")
                {
                    if (answerInput.Text.Equals(currAnswer, StringComparison.OrdinalIgnoreCase))
                    {
                        quizTimer.Stop();

                        questionBox.Foreground = brush("blue");
                        await Task.Delay(150);
                        questionBox.Foreground = brush("black");

                        levelEngine.add100(ref levelEngine.currPoints);
                        levelEngine.levelChange(ref levelEngine.levelIndex);

                        updateTable();
                        answerInput.Text = string.Empty;

                        pullQuiz();
                    }
                    else
                    {
                        questionBox.Foreground = brush("red");
                        await Task.Delay(300);
                        if (!brushLock)
                            questionBox.Foreground = brush("black");

                        levelEngine.deductWrong(ref levelEngine.currPoints);
                        levelEngine.levelChange(ref levelEngine.levelIndex);

                        updateTable();
                        answerInput.Text = string.Empty;
                    }
                }
            }
        }
        public async void QuizTimer_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
                timeleft = timeleft - 1;
                displayTimeLeft.Text = "Time left: \n" + timeleft.ToString();
            }
            else
            {
                quizTimer.Stop();
                questionBox.Text = currAnswer;

                asyncLocks(ref submitLock, ref brushLock);
                questionBox.Foreground = brush("red");
                await Task.Delay(2000);
                questionBox.Foreground = brush("black");
                asyncLocks(ref submitLock, ref brushLock);

                levelEngine.deductTimeout(ref levelEngine.currPoints);
                levelEngine.levelChange(ref levelEngine.levelIndex);

                updateTable();
                answerInput.Text = string.Empty;

                pullQuiz();
            }
        }
        private void switchStart(ref bool started)
        {
            started = !started;
        }
        private void asyncLocks(ref bool submitLock, ref bool brushLock)
        {
            submitLock = !submitLock;
            brushLock = !brushLock;
        }
        private Brush brush(string color)
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString(color);
            return brush;
        }
        private void updateTable()
        {
            displayTimeLeft.Text = "Time left: \n" + timeleft.ToString();
            pointsBlock.Text = "Points: " + levelEngine.currPoints.ToString();
            if (levelEngine.currPoints > maxPoints)
            {
                levelBlock.Foreground = brush("blue");
                pointsBlock.Foreground = brush("blue");
                levelBlock.Text = "MAX";
            }
            else
            {
                levelBlock.Foreground = brush("black");
                pointsBlock.Foreground = brush("black");
                levelBlock.Text = "Level: " + (levelEngine.levelIndex + 1).ToString();
            }
        }
        private void InitMessage()
        {
            string currentMode = null;
            switch (currMode)
            {
                case 1:
                    currentMode = "ひらがな";
                    break;

                case 2:
                    currentMode = "カタカナ";
                    break;                    
            }
            string currentLevel = "Level: " + (levelEngine.levelIndex + 1).ToString();
            string initialMessage = "To start, press Space";

            initMessage.Text = currentMode + "\n" + currentLevel + "\n" + initialMessage;
        }
        private void modeSwitch(ref byte currMode)
        {
            if (currMode < 2)
                currMode++;
            else if (currMode == 2)
                currMode = 1;
        }
        private void buttons_Common()
        {
            quizTimer.Stop();

            levelBlock.Text = string.Empty;
            pointsBlock.Text = string.Empty;
            displayTimeLeft.Text = string.Empty;
            questionBox.Text = string.Empty;
            answerInput.Text = string.Empty;
            InitMessage();
            if (started)
                switchStart(ref started);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (!submitLock)
            {
                levelEngine.clearLevel(ref levelEngine.levelIndex, ref levelEngine.currPoints);
                buttons_Common();
            }
        }
        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            if (!submitLock)
            {
                modeSwitch(ref currMode);
                buttons_Common();
            }
        }
        private void levelPlus_Click(object sender, RoutedEventArgs e)
        {
            if (!submitLock)
            {
                levelEngine.addLevel(ref levelEngine.levelIndex, ref levelEngine.currPoints);
                buttons_Common();
            }
        }
        private void levelMinus_Click(object sender, RoutedEventArgs e)
        {
            if (!submitLock)
            {
                levelEngine.subtLevel(ref levelEngine.levelIndex, ref levelEngine.currPoints);
                buttons_Common();
            }
        }
    }
}
