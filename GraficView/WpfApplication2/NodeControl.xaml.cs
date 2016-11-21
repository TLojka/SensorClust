using System;
using System.Collections.Generic;
using System.Text;
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
	/// <summary>
	/// Interaction logic for NodeControl.xaml
	/// </summary>
	public partial class NodeControl : UserControl
	{
        public int ID;
        public event MenuDelegat HandlerMenuCreat;
		public NodeControl(Gateway_Version1.DeviceManager.DeviceDataTemplate device)
		{
			this.InitializeComponent();
            this.Resources["NameA"] = device.DeviceName;
           
            this.ID = device.ID;

            TooltipName.PlacementTarget = ellipse;
            TooltipName.IsOpen = true;

            input = new List<Gateway_Version1.DeviceManager.DeviceDataTemplate>();

            input.Add(device);
          //  m = new ControlMenu();
          //  m.closeWindow +=HidecontextMenu;

            switch (device.ClusterID)
            {
                case 0: ellipse.Fill = Brushes.Azure; break;
                case 1: ellipse.Fill = Brushes.DarkMagenta; break;
                case 2: ellipse.Fill = Brushes.Chartreuse; break;
                default: break;
            }

            ellipse.SetValue(Canvas.TopProperty, device.position.X);
            ellipse.SetValue(Canvas.LeftProperty, device.position.Y);
		}

        public void Update(Gateway_Version1.DeviceManager.DeviceDataTemplate device)
        {
            input[0].ClusterID = device.ClusterID;
            switch (device.ClusterID)
            {
                case 0: ellipse.Fill = ChangeColor(Colors.White, Colors.Orange, Colors.OliveDrab); break;
                case 1: ellipse.Fill = ChangeColor(Colors.White, Colors.Blue, Colors.Brown); break;
                case 2: ellipse.Fill = ChangeColor(Colors.White, Colors.Cyan, Colors.DarkCyan); break;
                default: break;
            }

        }

        RadialGradientBrush ChangeColor(Color a, Color b, Color c)
        {
            RadialGradientBrush myBrush = new RadialGradientBrush();
            myBrush.GradientOrigin = new Point(0.75, 0.25);
            myBrush.GradientStops.Add(new GradientStop(a, 0.0));
            myBrush.GradientStops.Add(new GradientStop(b, 0.5));
            myBrush.GradientStops.Add(new GradientStop(c, 1.0));
            return myBrush;
        }

        /// <summary>
        /// presunie Node na inú pozíciu
        /// </summary>
        /// <param name="_x">nová x-sová pozícia</param>
        /// <param name="_y">nová y-silonová pozícia</param>
        public void Move(double _x, double _y)
        {
            x_start = x_final;
            y_start = y_final;

            x_final = _x;
            y_final = _y;

            Storyboard sb = this.FindResource("Moving") as Storyboard;
            Storyboard.SetTarget(sb, ellipse);
            sb.Begin();

            MoveTo(_x,_y);

        }

    public  void MoveTo(double _x, double _y)
    {
      
      TranslateTransform trans = new TranslateTransform();
      ellipse.RenderTransform = trans;
      DoubleAnimation anim1 = new DoubleAnimation(0,_x, TimeSpan.FromSeconds(4));
      DoubleAnimation anim2 = new DoubleAnimation(0, _y, TimeSpan.FromSeconds(4));
      trans.BeginAnimation(TranslateTransform.XProperty, anim1);
      trans.BeginAnimation(TranslateTransform.YProperty, anim2);
        DataTransferEventArgs e = null;
      ellipse_TargetUpdated(new Object(), e );

    }

        private double x_start
        {
            set
            {
                this.Resources["x_start"] = value;
            }
            get
            {
                object value = this.Resources["x_start"];
                return System.Convert.ToDouble(value);
            }
        }

        private double y_start
        {
            set
            {
                this.Resources["y_start"] = value;
            }
            get
            {
                object value = this.Resources["x_start"];
                return System.Convert.ToDouble(value);
            }
            
        }

        private double x_final
        {
            set
            {
                this.Resources["x_final"] = value;
            }

            get
            {
                object value = this.Resources["x_final"];
                return System.Convert.ToDouble(value);
            }
        }

        private double y_final
        {
            set
            {
                this.Resources["y_final"] = value;
            }
            get
            {
                object value = this.Resources["y_final"];
                return System.Convert.ToDouble(value);
            }
        }

        private void ellipse_TargetUpdated(object sender, DataTransferEventArgs e)
        {
           
            
        }

        private void DoubleAnimationUsingKeyFrames_Changed(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            try
            {
                if (ellipse != null)
                { 
                tooltip = (ToolTip)ellipse.ToolTip;
               /* tooltip.HorizontalOffset =  x_final;
                tooltip.VerticalOffset =  y_final;*/
                tooltip.IsOpen = false;
                tooltip.IsOpen = true;

                ellipse.ToolTip = tooltip;
                }
            }
            finally 
            { 
            
            }
        }

        private void DoubleAnimationUsingKeyFrames_Completed(object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip = (ToolTip)ellipse.ToolTip;
            tooltip.IsOpen = false;
            tooltip.IsOpen = true;
            ellipse.ToolTip = tooltip;
        }

        static ControlMenu m;
        List<Gateway_Version1.DeviceManager.DeviceDataTemplate> input;
        private void Itemdetails_event(object sender, RoutedEventArgs e)
        {
           /* ContextMenu cnmenu = this.FindResource("EllipseContex_menu") as ContextMenu;
            cnmenu.PlacementTarget = sender as Ellipse;
            cnmenu.HasDropShadow= true;
            
            //cnmenu.Background = Brushes.;
          //  cnmenu.Background =   

            cnmenu.IsOpen = true;*/
                        
           /* m.insertInput(input);
            m.Opacity = 30;


          
            try
            {
              LayoutRoot.Children.Add(m);
            }
            finally
            { }*/

            HandlerMenuCreat(input);

        }

        
        public void HidecontextMenu()
        {
            
        //    LayoutRoot.Children.Remove(m);
        }



	}
}