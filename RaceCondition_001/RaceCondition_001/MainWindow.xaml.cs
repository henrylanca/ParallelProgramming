using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RaceCondition_001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            Task<string> getTime = Task.Factory.StartNew<string>(()=>
            {
                return DisplayTime();
            });


            Task updateUI = getTime.ContinueWith((antecedent) =>
                {
                    string cutTime = antecedent.Result;

                    this.txtInfo.Text = cutTime;
                },
                TaskScheduler.FromCurrentSynchronizationContext());

            //MessageBox.Show("OK");
        }

        private string DisplayTime()
        {
            int sum=0;
            object myLock = new object();

            List<Task<int>> tasks = new List<Task<int>>();

            for (int i = 1; i <= 50; i++)
            {
                Task<int> t = Task.Factory.StartNew<int>((count) =>
                    {
                        int tmpi = (int)count;

                        Thread.Sleep(i * 10);

                        return tmpi;
                    },i);

                tasks.Add(t);
            }

            sum = WaitAllOneByOne(tasks);

            return sum.ToString(); ;

        }

        private int WaitAllOneByOne(List<Task<int>> tasks)
        {
            int sum = 0;
            while (tasks.Count > 0)
            {
                int i = Task.WaitAny(tasks.ToArray());
                sum += tasks[i].Result;
                tasks.RemoveAt(i);
            }

            return sum;
        }
    }
}
