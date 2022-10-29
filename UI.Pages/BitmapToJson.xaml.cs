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
using Microsoft.Win32;
using Tools;
using Path = System.IO.Path;

namespace UI.Pages
{
    /// <summary>
    /// BitmapToJson.xaml etkileşim mantığı
    /// </summary>
    public partial class BitmapToJson : UserControl
    {
        private string? _path;
        private string? _saveLocation;
        public BitmapToJson()
        {
            InitializeComponent();
        }

        private void SelectFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                DefaultExt = ".bmp",
                Filter = "Bitmap Files (*.bmp)|*.bmp"
            };

            bool? result = dialog.ShowDialog();

            if (result != true) return;
            _path = dialog.FileName;
            SelectedFileLabel.Content = Path.GetFileName(dialog.FileName);
        }

        private void SelectSaveLocationButton_OnClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                FileName = "bmp2json",
                DefaultExt = ".json",
                Filter = "Json File (.json)|*.json"
            };

            bool? result = dialog.ShowDialog();

            if (result != true) return;
            _saveLocation = dialog.FileName;
            SaveDirectionLabel.Content = Path.GetFileName(dialog.FileName);
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (_path == null)
                MessageLabel.Content = "Select A File";
            else if (_saveLocation == null)
                MessageLabel.Content = "Select A Save Location";
            else
            {
                BitmapReader reader = new BitmapReader();
                string json = reader.GetPixelsAsJson(_path);

                File.WriteAllText(_saveLocation, json);

                MessageLabel.Content = $"Saved {Path.GetFileName(_path)} as {Path.GetFileName(_saveLocation)}";
                SelectedFileLabel.Content = "Select A File...";
                SaveDirectionLabel.Content = "Select A Location...";

                _path = null;
                _saveLocation = null;
            }
        }
    }
}
