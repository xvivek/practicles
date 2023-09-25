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

namespace Geometry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //https://stackoverflow.com/questions/4437189/convert-a-geometry-to-a-path-in-wpf-with-blend
            //

            var geom = new EllipseGeometry(new Point(5, 4), 4, 4);
            var pathGeometry = PathGeometry.CreateFromGeometry(geom);           

            string pathText = pathGeometry.ToString();

            var streamGeometry = StreamGeometry.Parse(pathText);

            var p = new Path { Data = streamGeometry };
        }
    }
}
