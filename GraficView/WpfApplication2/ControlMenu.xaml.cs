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

namespace GraficUI
{
    public delegate void CloseUserControl();
    /// <summary>
    /// Interaction logic for ControlMenu.xaml
    /// </summary>
    public partial class ControlMenu : UserControl
    {
        
        public event CloseUserControl closeWindow;
        public ControlMenu()
        {
            InitializeComponent();   
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
           
            ((Panel)this.Parent).Children.Remove(this);
        }

        public void insertInput(List<Gateway_Version1.DeviceManager.DeviceDataTemplate> input)
        {
            ItemListView.ItemsSource = input;
        }

        private void CloseMenu(object sender, MouseButtonEventArgs e)
        {
            closeWindow();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // closeWindow();
            ((Panel)this.Parent).Children.Remove(this);
        }

    }

    public class testingObject
    {
        public string name {get;set;}
        public string value {get;set;}
    }
}
