using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Hit_them
{
    /// <summary>
    /// Логика взаимодействия для Beaverland.xaml
    /// </summary>
    public partial class Beaverland
    {
        public Beaverland()
        {
            InitializeComponent();
            TimerStart();
            FigureTimer();
            Sw.Start();
        }

        public Gameplay Gameplay
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        private static readonly Stopwatch Sw = new Stopwatch();
        private DispatcherTimer _timer;
        private DispatcherTimer _timer1;
        public long Lasttime=0;
        /// <summary>
        /// Timer to visualization stopwatch
        /// </summary>
        private void TimerStart()
        {
            _timer = new DispatcherTimer();
            // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            _timer.Tick += new EventHandler(TimerTick);
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            _timer.Start();
        }
        /// <summary>
        /// Visualization of stopwatch
        /// </summary>
        /// <param name="sender">System.Windows.Threading.DispatcherTimer</param>
        /// <param name="e">System.EventArgs</param>
        private void TimerTick(object sender, EventArgs e)
        {
            Lasttime=59 - Sw.ElapsedMilliseconds / 1000;
            //Lasttime -= 59; // for testing
            TimeTextBlock.Text =  Lasttime.ToString();
            ScoreTextBlock.Text = Gameplay.UserScore.ToString();
            if (Lasttime == 0)
            {
                _timer.Stop();
                _timer1.Stop();
                EndGame();
            }

            Visualisation();
        }

        /// <summary>
        /// Timer for calling generation method
        /// </summary>
        private void FigureTimer()
        {
            _timer1 = new DispatcherTimer();
            // если надо, то в скобках указываем приоритет, например DispatcherPriority.Render
            _timer1.Tick += new EventHandler(FigureGen);
            _timer1.Interval = new TimeSpan(0, 0, 0,0, Menu.Delta*300);
            _timer1.Start();
        }

        /// <summary>
        /// Method for generation new shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FigureGen(object sender, EventArgs e)
        {
            Gameplay.Generation();
        }


        /// <summary>
        /// Binding pictures to buttons
        /// </summary>
        /// <param name="path">Path to picture</param>
        /// <param name="i"></param>
        public void ShowPic(string path, int i)
        {
            Image img = new Image();
            BitmapImage btimg = new BitmapImage();
            Uri u = new Uri(path);
            btimg.BeginInit();
            btimg.UriSource = u;
            btimg.EndInit();
            img.Source = btimg;
            switch (i)
            {
                case 0:
                    Hole1Button.Content = img;
                    break;
                case 1:
                    Hole2Button.Content = img;
                    break;
                case 2:
                    Hole3Button.Content = img;
                    break;
                case 3:
                    Hole4Button.Content = img;
                    break;
                case 4:
                    Hole5Button.Content = img;
                    break;
                case 5:
                    Hole6Button.Content = img;
                    break;
                case 6:
                    Hole7Button.Content = img;
                    break;
                case 7:
                    Hole8Button.Content = img;
                    break;
                default:
                    Hole9Button.Content = img;
                    break;
            }
        }
        

        /// <summary>
        /// Showing bev/heg/empty
        /// </summary>
        private void Visualisation()
        {
            for (int i = 0; i < 9; i++)
            {
                if (Gameplay.Place[i] != Conditions.Empty)
                {
                    if (Gameplay.Place[i] == Conditions.Bev)
                    {
                        ShowPic("F:/лабы/решенные/3 курс/ООП/Hit them/Hit them/images/bever.jpg", i);
                    }
                    else
                    {
                        ShowPic("F:/лабы/решенные/3 курс/ООП/Hit them/Hit them/images/heg.jpg", i);
                    }
                }
                else
                {
                    ShowPic("F:/лабы/решенные/3 курс/ООП/Hit them/Hit them/images/white.jpg", i);
                }
            }
        }

        private void EndGame()
        {

            string now = DateTime.Now.ToString("dd/MM/yy H:mm:ss");
            Info person = new Info(Gameplay.Username,Gameplay.UserScore,Gameplay.Level,now);

            if (File.Exists("persons.xml"))
            {
                string input = WorkWithFile.SimpleRead1();
                string inputxml = WorkWithFile.Decrypt(input, "HelloWorld");
                WorkWithFile.SimpleWrite1(inputxml);
            }

            Info[] from = WorkWithFile.SimpleRead();
            Info[] persons={person};
            if (from[0] != null)
            {
                persons = new Info[from.Length + 1];
                for (int i = 0; i < persons.Length - 1; i++)
                {
                    persons[i] = from[i];
                }
                persons[persons.Length - 1] = person;
            }
            
            WorkWithFile.SimpleWrite(persons);
            string output = WorkWithFile.SimpleRead1();
            string outputxml = WorkWithFile.Encrypt(output, "HelloWorld");
            WorkWithFile.SimpleWrite1(outputxml);
            
            var w1 = new ResultTable();
            w1.Show();
            Close();
        }



        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = GetWindow(this);
            if (window != null) window.KeyDown += HandleKeyPress;
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.NumPad1:
                case Key.D1: Hole1Button_Click(Hole1Button, null); break;
                case Key.NumPad2:
                case Key.D2: Hole2Button_Click(Hole2Button, null); break;
                case Key.NumPad3:
                case Key.D3: Hole3Button_Click(Hole3Button, null); break;
                case Key.NumPad4:
                case Key.D4: Hole4Button_Click(Hole4Button, null); break;
                case Key.NumPad5:
                case Key.D5: Hole5Button_Click(Hole5Button, null); break;
                case Key.NumPad6:
                case Key.D6: Hole6Button_Click(Hole6Button, null); break;
                case Key.NumPad7:
                case Key.D7: Hole7Button_Click(Hole7Button, null); break;
                case Key.NumPad8:
                case Key.D8: Hole8Button_Click(Hole8Button, null); break;
                case Key.NumPad9:
                case Key.D9: Hole9Button_Click(Hole9Button, null); break;
            }
        }




        /// <summary>
        /// Checking if there anybody
        /// </summary>
        /// <param name="i">index of hole</param>
        public void ChechHole(int i)
        {
            if (Gameplay.Place[i] != Conditions.Empty)    // place enable
            {
                // who sits in this place?
                if (Gameplay.Place[i] == Conditions.Bev) // in this place beaver or not
                {
                    Gameplay.UserScore += 100;
                }
                else
                {
                    Gameplay.UserScore -= 200;
                }
                Gameplay.Place[i] = Conditions.Empty;
            }
            else
            {
                Gameplay.UserScore -= 50;
            }

        }

        private void Hole1Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(0);
        }

        private void Hole2Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(1);
        }

        private void Hole3Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(2);
        }

        private void Hole4Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(3);
        }

        private void Hole5Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(4);
        }

        private void Hole6Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(5);
        }

        private void Hole7Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(6);
        }

        private void Hole8Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(7);
        }

        private void Hole9Button_Click(object sender, RoutedEventArgs e)
        {
            ChechHole(8);
        }
    }
}
