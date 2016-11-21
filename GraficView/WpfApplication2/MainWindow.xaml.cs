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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraficUI
{
    public delegate void MenuDelegat (List<Gateway_Version1.DeviceManager.DeviceDataTemplate> input);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Storyboard sbNew;


        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        Gateway_Version1.Gateway Gateway_Version1;
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Gateway_Version1 = new Gateway_Version1.Gateway();

            Gateway_Version1._deviceManager.DeviceFoundEvent += _deviceManager_DeviceFoundEvent;
            Gateway_Version1._deviceManager.ClusterIDChange += UpdataNode;
            Gateway_Version1.RunTesting();
        }

        void _deviceManager_DeviceFoundEvent(Gateway_Version1.DeviceManager.DeviceDataTemplate device)
        {
            NewNode(new object(), new RoutedEventArgs(), device);
        }


        NodeControl control;
        private void NewNode(object sender, RoutedEventArgs e, Gateway_Version1.DeviceManager.DeviceDataTemplate device)
        {
            /* sbNew = this.FindResource("new") as Storyboard;
             Storyboard.SetTarget(sbNew, ellipse);
             sbNew.Begin();*/
            control = new NodeControl(device);
            control.HandlerMenuCreat += control_HandlerMenuCreat;
            GridMain.Children.Add(control);

            //    control.Move(device.position.X, device.position.Y);
        }



        private void UpdataNode(Gateway_Version1.DeviceManager.DeviceDataTemplate device)
        {
            int ind = FindControlByName(device.ID);
            if (ind != 99999)
            {
                NodeControl nodec = (NodeControl)GridMain.Children[ind];
                nodec.Update(device);
            }
        }

        private int FindControlByName(int _ID)
        {
            for (int i = 0; i < GridMain.Children.Count; i++)
            {
                if (GridMain.Children[i] is NodeControl)
                {
                    NodeControl c = (NodeControl)GridMain.Children[i];
                    if (c.ID == _ID)
                        return i;
                }
            }
            return 99999;
        }

        private void NodePosition(object sender, RoutedEventArgs e)
        {
            Gateway_Version1._deviceManager.MaunlKmenatStart();
        }

        private void btnAddMore_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button newBtn = new Button();
            newBtn.Height = 10;
            newBtn.Content = "A New Button";
            GridMain.Children.Add(newBtn);
        }

        private void ChangePposition(object sender, RoutedEventArgs e)
        {
            control.Move(120, 120);
        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {



        }

        ////UserControl Menu
        static ControlMenu m;
        List<Gateway_Version1.DeviceManager.DeviceDataTemplate> input;
        void control_HandlerMenuCreat(List<Gateway_Version1.DeviceManager.DeviceDataTemplate> input)
        {
            if (m != null)
                if (GridMain.Children.Contains(m))
                    HidecontextMenu();

            m = new ControlMenu();
            m.closeWindow += HidecontextMenu;

            m.insertInput(input);
            m.Opacity = 30;

            try
            {
                GridMain.Children.Add(m);
            }
            finally
            { }
        }

        public void HidecontextMenu()
        {

            GridMain.Children.Remove(m);
        }

    }
}
