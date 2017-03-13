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
using System.Windows.Shapes;

namespace ActivAID
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Button ClickedButton;
        public MainWindow windowtho;
        public Settings()
        {
            InitializeComponent();
            settingswindow.Buttonsch1.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
            settingswindow.Buttonsch1.BorderThickness = new Thickness(2);
            MouseDown += delegate { DragMove(); };
            settingswindow.Buttonsch1.Focus();
            settingswindow.Buttonsch1.IsDefault=true;
            ClickedButton = settingswindow.Buttonsch1;
        }

        private void SaveButton_OnClose(object sender, RoutedEventArgs e)
        {
            this.Hide();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    if (ClickedButton.Name == "Buttonsch1")
                    {
                        (window as MainWindow).grid1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF284167"));
                        (window as MainWindow).close.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF5383AD"));
                        (window as MainWindow).firstBOT.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4A4B53"));
                        (window as MainWindow).ColorBOT = "#FF4A4B53";
                        (window as MainWindow).ColorUser = "#FF5383AD";
                        foreach (Label block in (window as MainWindow).OutputBox.Items)
                        {
                            if (block.Name == "botmsg" || block.Name == "botmsgGold")
                            {
                                block.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4A4B53"));
                            }
                            else if (block.Name == "usermsg")
                            {
                                block.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF5383AD"));
                            }
                            block.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                            block.FontSize = Convert.ToInt32(textBoxfont.Text);
                        }
                    }
                    else if (ClickedButton.Name == "Buttonsch2")
                    {
                        (window as MainWindow).grid1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4A4B53"));
                        (window as MainWindow).close.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF000000"));
                        (window as MainWindow).close.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                        (window as MainWindow).firstBOT.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        (window as MainWindow).ColorBOT = "#000000";
                        (window as MainWindow).ColorUser = "#FF284167";
                        foreach (Label block in (window as MainWindow).OutputBox.Items)
                        {
                            if (block.Name == "botmsg" || block.Name == "botmsgGold")
                            {
                                block.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                            }
                            else if (block.Name == "usermsg")
                            {
                                block.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF284167"));
                            }
                            block.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                            block.FontSize = Convert.ToInt32(textBoxfont.Text);
                        }
                    }
                    else if (ClickedButton.Name == "Buttonsch3")
                    {

                        (window as MainWindow).grid1.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#C39428"));
                        (window as MainWindow).close.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        (window as MainWindow).firstBOT.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                        (window as MainWindow).ColorBOT = "#000000";
                        (window as MainWindow).ColorUser = "#FF284167";
                        (window as MainWindow).GoldBOT = "botmsgGold";
                        foreach (Label block in (window as MainWindow).OutputBox.Items)
                        {
                            if (block.Name == "botmsg" || block.Name == "botmsgGold")
                            {
                                block.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                            }
                            else if (block.Name == "usermsg")
                            {
                                block.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF284167"));
                            }                           
                            block.FontSize = Convert.ToInt32(textBoxfont.Text);
                        }
                    }

                    (window as MainWindow).fontSize = Convert.ToInt32(textBoxfont.Text);
                }
               
            }

        }
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            settingswindow.Hide();
        }
        private void colorsch_OnClick(object sender, RoutedEventArgs e)
        {
            ClickedButton.IsDefault = false;
            ClickedButton = (sender as Button);
            (sender as Button).IsDefault = true;
        }
    }
}
