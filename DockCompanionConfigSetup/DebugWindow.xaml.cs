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
using Microsoft.Win32;
using System.IO;

namespace DockCompanionConfigSetup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        //RetrieveWindowHandles retrieveWindowHandles;
        public DebugWindow()
        {
            InitializeComponent();
        }
        private void GetWindows_Click(object sender, RoutedEventArgs e)
        {
            RetrieveWindowHandles.GetWindowHandles();
            WindowTitles.ItemsSource = RetrieveWindowHandles.WindowList;
        }
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                inputFilePath.Text = openFileDialog.FileName;
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string inputStringValue = inputString.Text.Replace("System.Windows.Controls.TextBox: ", "");
            string inputFilePathValue = inputFilePath.Text.Replace("System.Windows.Controls.TextBox: ", "");
            string filePath = "Config.txt";

            if (string.IsNullOrWhiteSpace(inputStringValue) || string.IsNullOrWhiteSpace(inputFilePathValue))
            {
                MessageBox.Show("One or more of the required fields above is empty. Please double check both fields and try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Create the file if it doesn't exist
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Dispose();
            }

            // Write the strings to the file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine(inputStringValue);
                writer.WriteLine(inputFilePathValue);
            }
          //  MessageBox.Show("Config.txt file setup complete. This application will now close.", "Config Setup", MessageBoxButton.OK);
            MessageBoxResult result = MessageBox.Show("Config.txt file setup complete. You can now exit the Config Setup application.", "Config Setup", MessageBoxButton.OK);
            if (result == MessageBoxResult.OK)
            {
                Application.Current.Shutdown();
            }
        }
        private void WindowTitles_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the selected item
            var selectedItem = WindowTitles.SelectedItem as string;

            // Extract the string after the last "|"
            var lastPipeIndex = selectedItem.LastIndexOf("|");
            var targetString = selectedItem.Substring(lastPipeIndex + 1);

            // Set the text of the inputString TextBox
            inputString.Text = targetString;
        }
    }
}
