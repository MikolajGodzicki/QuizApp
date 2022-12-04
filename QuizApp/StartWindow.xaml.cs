using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuizApp {
    public partial class StartWindow : Window {
        private string FilePath = "";
        public StartWindow() {
            InitializeComponent();
        }

        private void openQuizFileBtn_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".json";
            openFileDialog.Filter = "Quiz file (.json)|*.json";
            
            bool? result = openFileDialog.ShowDialog(this);

            if (result == true) {
                string filePath = openFileDialog.FileName;

                fileName.Text = filePath.Split('\\').Last();

                FilePath = filePath;
            }
        }

        private void startQuizBtn_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(FilePath)) {
                MessageBox.Show("Plik nie istnieje.");
                return;
            }

            MainWindow main = new MainWindow(FilePath);
            if (!main.IsValidFile) {
                MessageBox.Show("Wybrano pusty/nieprawidłowy plik");
                return;
            }
            main.Show();
            this.Close();
        }
    }
}
