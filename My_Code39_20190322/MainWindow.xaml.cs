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

namespace My_Code39_20190322
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public Dictionary<char, string> codeMap = new Dictionary<char, string>();
        public MainWindow()
        {
            InitializeComponent();
            initCodeMap();
        }

        public void initCodeMap()
        {
            codeMap['0'] = "101001101101";
            codeMap['1'] = "110100101011";
            codeMap['2'] = "101100101011";
            codeMap['3'] = "110110010101";
            codeMap['4'] = "101001101011";
            codeMap['5'] = "110100110101";
            codeMap['6'] = "101100110101";
            codeMap['7'] = "101001011011";
            codeMap['8'] = "110100101101";
            codeMap['9'] = "101100101101";

            codeMap['+'] = "100101001001";
            codeMap['-'] = "100101011011";
            codeMap['*'] = "100101101101";
            codeMap['/'] = "100100101001";
            codeMap['%'] = "101001001001";
            codeMap['$'] = "100100100101";
            codeMap['.'] = "110010101101";
            codeMap[' '] = "100110101101";

            codeMap['A'] = "110101001011";
            codeMap['B'] = "101101001011";
            codeMap['C'] = "110110100101";
            codeMap['D'] = "101011001011";
            codeMap['E'] = "110101100101";
            codeMap['F'] = "101101100101";
            codeMap['G'] = "101010011011";
            codeMap['H'] = "110101001101";
            codeMap['I'] = "101101001101";
            codeMap['J'] = "101011001101";
            codeMap['K'] = "110101010011";
            codeMap['L'] = "101101010011";
            codeMap['M'] = "110110101001";
            codeMap['N'] = "101011010011";
            codeMap['O'] = "110101101001";
            codeMap['P'] = "101101101001";
            codeMap['Q'] = "101010110011";
            codeMap['R'] = "110101011001";
            codeMap['S'] = "101101011001";
            codeMap['T'] = "101011011001";
            codeMap['U'] = "110010101011";
            codeMap['V'] = "100110101011";
            codeMap['W'] = "110011010101";
            codeMap['X'] = "100101101011";
            codeMap['Y'] = "110010110101";
            codeMap['Z'] = "100110110101";

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string txt = $"*{textBox.Text.Trim()}*";
            count = 0;
            //gd.Children.Count;
            foreach (var s in txt)
            {
                Console.WriteLine("{0} {1}", s, codeMap[s]);
                foreach (var item in codeMap[s])
                {
                    add(item == '1');
                }
                add(false);
            }
            Console.WriteLine("" + gd.Children.Count);
            //gd.Children.Clear();
            //gd.ColumnDefinitions.Clear();

            save(@"C:\Users\wuye\Desktop\1.png");
        }

        private void save(string v)
        {
            var rtb = new RenderTargetBitmap(500, 56, 96, 96, PixelFormats.Default);
            rtb.Render(gd);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            using(Stream fs = File.Create(v))
            {
                png.Save(fs);
            }
        }

        int count;
        private void add(bool black)
        {
            ColumnDefinition r1 = new ColumnDefinition();
            r1.Width = new GridLength(3);
            gd.ColumnDefinitions.Add(r1);

            TextBlock tb = new TextBlock();
            tb.Background = new SolidColorBrush(black ? Colors.Black : Colors.White);
            gd.Children.Add(tb);
            Grid.SetColumn(tb, count++);
        }
    }
}
