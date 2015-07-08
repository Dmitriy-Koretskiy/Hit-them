using System.Windows;

namespace Hit_them
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu
    {
        public string Player;
        public static int Delta = 3;
    
        public Menu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var w1 = new ResultTable();
            w1.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Gameplay.Username = UserNameTextBox.Text.Trim();
            if (Gameplay.Username.Length == 0 && Gameplay.Username.Length < 20)
            {
                MessageBox.Show("Enter your name!", "Wrong name");
                return;
            }
            if (EasyRadio.IsChecked == true)
            {
                Gameplay.Level = LevelType.Easy;
            }
            else
            {
                if (NormalRadio.IsChecked == true)
                {
                    Gameplay.Level = LevelType.Normal;
                }
                else
                {
                    Gameplay.Level = LevelType.Hard;
                    Delta = 2;
                }
            }
            var w1 = new Beaverland();
            w1.Show();
            Close();
        }
    }
}
