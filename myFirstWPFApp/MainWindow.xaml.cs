using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace myFirstWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public static Label source;
        public static Image imsource;
        public static Image first, second;
        public static int h, w;

        private void Canvas_Initialized(object sender, EventArgs e)
        {
            h = Convert.ToInt32(Im1.Height);
            w = Convert.ToInt32(Im1.Width);

        }
        //нажатие на одну из картинок, первая картинка запоминается, вторая меняется изображениям с первой, если одна из них "серая" и они "соседние"
        private void Im_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (first == null||first==(Image)sender)
            {
                first = (Image)sender;
                first.Opacity = 0.5;
            }
            else
            {
                    second = (Image)sender;
                if (second.Source.ToString() == "file:///C:/Users/rmatv/source/repos/myFirstWPFApp/gray.jpg"||first.Source.ToString() == "file:///C:/Users/rmatv/source/repos/myFirstWPFApp/gray.jpg")
                {
                    int td = (int)Canvas.GetTop(first);
                    int tl = (int)Canvas.GetLeft(first);

                    int sd = (int)Canvas.GetTop(second);
                    int sl = (int)Canvas.GetLeft(second);

                    if (((Math.Abs(td - sd) < 2 * h) && (tl == sl)) || ((Math.Abs(tl - sl) < 2 * w) && (td == sd)))
                    {

                        second.Opacity = 0.5;
                        string fsource, ssource;
                        fsource = first.Source.ToString();
                        ssource = second.Source.ToString();
                        second.Source = BitmapFrame.Create(new Uri(fsource));
                        first.Source = BitmapFrame.Create(new Uri(ssource));
                    }
                }
                    first.Opacity = 1;
                    second.Opacity= 1;
                    second = null;
                    first = null;
            }
        }
        //нажатие на кнопку старта перемешивает картинки
        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int[] x = new int[8];
            Random rnd = new Random();
            int i = 0, n;
            while (i < 8)
            {
                n = rnd.Next() % 8;
                if (x[n] == 0)
                {
                    x[n] = i + 1;
                    i++;
                }
            }
            Im1.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[0].ToString()+".jpg"));
            Im2.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[1].ToString() + ".jpg"));
            Im3.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[2].ToString() + ".jpg"));
            Im4.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[3].ToString() + ".jpg"));
            Im5.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[4].ToString() + ".jpg"));
            Im6.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[5].ToString() + ".jpg"));
            Im7.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[6].ToString() + ".jpg"));
            Im8.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\kitty" + x[7].ToString() + ".jpg"));
            Im9.Source = BitmapFrame.Create(new Uri(@"C:\Users\rmatv\source\repos\myFirstWPFApp\gray.jpg"));
        }
    }
}
