using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DevTools.Modules.ColorTableMod
{
    /// <summary>
    /// Interaction logic for ColorItem.xaml
    /// </summary>
    public partial class ColorItem : UserControl
    {
        public ColorItem()
        {
            InitializeComponent();
        }

        public ColorItem(Color c1, Color c2, Color c3)
        {
            InitializeComponent();
            R1.Background = new SolidColorBrush(c1);
            R2.Background = new SolidColorBrush(c2);
            R3.Background = new SolidColorBrush(c3);
            T1.Text = c1.ToHtmlHexadecimal6();
            T2.Text = c2.ToHtmlHexadecimal6();
            T3.Text = c3.ToHtmlHexadecimal6();
        }

        public ColorItem(string s1, string s2, string s3)
        {
            InitializeComponent();
            Color color1 = (Color)ColorConverter.ConvertFromString(s1);
            Color color2 = (Color)ColorConverter.ConvertFromString(s2);
            Color color3 = (Color)ColorConverter.ConvertFromString(s3);
            R1.Background = new SolidColorBrush(color1);
            R2.Background = new SolidColorBrush(color2);
            R3.Background = new SolidColorBrush(color3);
            T1.Text = color1.ToHtmlHexadecimal6();
            T2.Text = color2.ToHtmlHexadecimal6();
            T3.Text = color3.ToHtmlHexadecimal6();
        }
        private void R1_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var br = sender as Border;
            if (br != null)
            {
                var bc = br.Background;
                Color color = ((SolidColorBrush)bc).Color;
                var colorStr = color.ToHtmlHexadecimal6();
                ClipboardCopy(colorStr);
            }
        }

        private void R2_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var br = sender as Border;
            if (br != null)
            {
                var bc = br.Background;
                Color color = ((SolidColorBrush)bc).Color;
                var colorStr = color.ToHtmlHexadecimal6();
                ClipboardCopy(colorStr);
            }
        }
        private void R3_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var br = sender as Border;
            if (br != null)
            {
                var bc = br.Background;
                Color color = ((SolidColorBrush)bc).Color;
                var colorStr = color.ToHtmlHexadecimal6();
                ClipboardCopy(colorStr);
            }
        }

        private static void ClipboardCopy(string data)

        {

            if (string.IsNullOrEmpty(data))

                return;

            try

            {

                Clipboard.SetDataObject(data, true);

            }

            catch { }

        }

    }
}
