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
using CXFtoCSV;

namespace CXFtoCSV.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush lightGreen;
        SolidColorBrush lightRed;
        SolidColorBrush lightBlue;
        SolidColorBrush lightGray;
        String messagePrompt = "Drag and drop the.CXF files here";
        String messageDrop = "Drop the.CXF files here";
        String messageError = "You can only drag files here";
        String messageWorking = "Processing...";
        String messageDone = "Done!";
        bool busy = false;

        public MainWindow()
        {
            lightGreen = new SolidColorBrush(Colors.LightGreen);
            lightGreen.Freeze();
            lightRed = new SolidColorBrush(Colors.LightPink);
            lightRed.Freeze();
            lightBlue = new SolidColorBrush(Colors.LightCyan);
            lightBlue.Freeze();
            lightGray = new SolidColorBrush(Colors.LightGray);
            lightGray.Freeze();

            InitializeComponent();
            this.Background = lightGray;
            Status.Text = messagePrompt;
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            if (busy)
            {
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                this.Background = lightGreen;
                Status.Text = messageDrop;
            }
            else
            {
                this.Background = lightRed;
                Status.Text = messageError;
            }
        }

        private void Window_DragLeave(object sender, DragEventArgs e)
        {
            if (busy)
            {
                return;
            }
            this.Background = lightGray;
            Status.Text = messagePrompt;
        }

        private async void Window_Drop(object sender, DragEventArgs e)
        {
            if (busy)
            {
                return;
            }
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.All(n => n.ToLower().EndsWith(".cxf")))
                {
                    busy = true;
                    this.Background = lightBlue;
                    Status.Text = messageWorking;

                    await Task.Run(() => DataConverter.ProcessFiles(files));

                    busy = false;
                    this.Background = lightGray;
                    Status.Text = messageDone;
                }
            }
        }
    }
}

