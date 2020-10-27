using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.IO;
using Microsoft.Win32;
using System.Windows.Threading;

namespace Kontokollen_2._0
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

        private void Browse_btn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
                File_path.Text = openFileDialog.FileName; //File.ReadAllText(openFileDialog.FileName);
        }

        private void Run_btn_Click(object sender, RoutedEventArgs e)
        {
            // Run R script in command line
            
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";

           

            if (mycheckBox.IsChecked == true)
            {
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.Arguments = "/C rscript " + File_path.Text + " " + cat_value.Text + " " + from_date.SelectedDate.ToString() + " " + to_date.SelectedDate.ToString() + " " + File_path.Text;
            }
            else
            {
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.Arguments = "/K rscript " + File_path.Text + " " + cat_value.Text + " " + from_date.SelectedDate.ToString() + " " + to_date.SelectedDate.ToString() + " " + File_path.Text;
            }

            process.StartInfo = startInfo;
            process.Start();

            Delay();

        }

        private void Delay()
        {

            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(10) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                timer.Stop();
                MessageBox.Show("/K rscript " + File_path.Text + " " + cat_value.Text + " " + from_date.SelectedDate + " " + to_date.SelectedDate + " " + File_path.Text);

            };
        }
    }
}
