using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int Count { get; set; } = default;
        public MainWindow()
        {
            InitializeComponent(); 
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Txt Files (*.txt)|*.txt";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                TxtBlckFirst.Text = dlg.FileName;
                TxtBxData.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(TxtBlckFirst.Text))
            {
                File.WriteAllText(TxtBlckFirst.Text, TxtBxData.Text);
                TxtBxData.Text = default;
                TxtBlckFirst.Text = default;
                MessageBox.Show("Save successfully.");
            }
        }

        //private void Btn_Click(object sender, RoutedEventArgs e)
        //{
        //    ++Count;
        //    Btn.Content = Count.ToString();
        //    MessageBox.Show(TxtBx.Text);
        //    Frame.Source = new Uri($"https://www.google.com/search?q={TxtBx.Text}");
        //}

        //private void BtnRepeat_Click(object sender, RoutedEventArgs e)
        //{
        //    ++Count;
        //    BtnRepeat.Content = Count.ToString();
        //}

        //private void BtnToggle_Click(object sender, RoutedEventArgs e)
        //{
        //    MessageBox.Show("Test");
        //}
    }
}
