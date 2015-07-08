using System.Collections.Generic;
using System.Windows;

namespace Hit_them
{
    /// <summary>
    /// Логика взаимодействия для ResultTable.xaml
    /// </summary>
    public partial class ResultTable
    {
        public ResultTable()
        {
            InitializeComponent();
            StartTable();
        }

        public void StartTable()
        {

            string input = WorkWithFile.SimpleRead1();
            string inputxml = WorkWithFile.Decrypt(input, "HelloWorld");
            WorkWithFile.SimpleWrite1(inputxml);

            Info[] from = WorkWithFile.SimpleRead();


            string output = WorkWithFile.SimpleRead1();
            string outputxml = WorkWithFile.Encrypt(output, "HelloWorld");
            WorkWithFile.SimpleWrite1(outputxml);
            
            List<Info> ListToShow=new List<Info>();
            for (int i = 0; i < from.Length; i++)
            {
                ListToShow.Add(from[i]);
            }
            ResultDataGrid.ItemsSource = ListToShow;
            
            // show it

        }
    }
}
