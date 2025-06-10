using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Colourflies
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public float Xv = 0;
        public float Yv = 0;
        public float TargetFPS = 60;
        public MainWindow()
        {
            InitializeComponent();
            String[] colors = {
                "red",
                "blue",
                "green",
                "yellow",
                "cyan",
                "magenta",
            };
            Random rand = new Random();
            BrushConverter converter = new BrushConverter();
            Brush colour = (Brush)converter.ConvertFrom(colors[rand.Next(0, colors.Length)]);
            silly.Fill = colour;
            silly.Stroke = colour;

            this.Top = rand.Next(0, (int)SystemParameters.VirtualScreenHeight);
            this.Left = rand.Next(0, (int)SystemParameters.VirtualScreenWidth);
           

            bounce();
            jerimitosis();

            New();


        }

        public async void bounce()
        {
            Xv /= 1.1f;
            Yv /= 1.1f;
            Random rand = new Random();
            this.Topmost = true;
            await Task.Delay((int)(1000/TargetFPS));
            silly.Width += 0.01;
            silly.Height += 0.01;
            Xv += rand.Next(-1, 2);
            Yv += rand.Next(-1, 2);
            this.Left +=  + Xv;
            this.Top +=  + Yv;
            
            this.Topmost = true;
            bounce();
        }
        public async void jerimitosis()
        {


            Random rand = new Random();
            //await Task.Delay(rand.Next(15, 120) * 1000);
            await Task.Delay(rand.Next(5, 20) * 1000);
           // await Task.Delay(5000);
            //await Task.Delay(1000); //debug
            //await Task.Delay(1000); //debug
            silly.Width /= 1.1;
            silly.Height /= 1.1;
            MainWindow window = new MainWindow();
            int mutate = rand.Next(-1, 1);
            if(mutate == 1)
            {
                window.silly.Width = silly.Width * 8;
                window.silly.Height = silly.Height * 8;
            }
            else
            {
                window.silly.Width = silly.Width;
                window.silly.Height = silly.Height;
            }
            window.Left = Left;
            window.Top = Top;
            Xv = rand.Next(-25, 25);
            Yv = rand.Next(-25, 25);
            window.Xv = -Xv;
            window.Yv = -Yv;

            window.Show();
            jerimitosis();


        }

        public async void New()
        {
            Random rand = new Random();

            await Task.Delay(rand.Next(5, 20) * 1000);

            MainWindow window = new MainWindow();
            window.Show();
            New();
        }

    }
}