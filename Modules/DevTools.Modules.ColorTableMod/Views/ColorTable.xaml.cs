using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace DevTools.Modules.ColorTableMod.Views
{
    /// <summary>
    /// Interaction logic for ColorTable
    /// </summary>
    public partial class ColorTable : UserControl
    {
        public ColorTable()
        {
            InitializeComponent();
            _tasks = new ObservableCollection<ListBoxItemCustom>() { };

            DataContext = _tasks;
            Isradio6 = true;
            radio6.IsChecked = true;
            var color_query =
                from PropertyInfo property in typeof(Colors).GetProperties()
                orderby property.Name
                select (Color)property.GetValue(null, null);

            //foreach (var s in color_query)
            //{
            //   var colorItem = new ColorItem(s,s,s);
            //   WrapPanel.Children.Add(colorItem);
            //}
            var arrayColors = color_query.ToArray();
            for (int i = 0; i < arrayColors.Count(); i += 3)
            {
                Color c1 = arrayColors[i];
                Color c2 = new Color();
                Color c3 = new Color();

                if (i + 1 < arrayColors.Length)
                {
                    c2 = arrayColors[i + 1];
                }

                if (i + 2 < arrayColors.Length)
                {
                    c3 = arrayColors[i + 2];
                }
            }
            LoadData();
        }

        ObservableCollection<ListBoxItemCustom> _tasks = null;
        private bool isRadio6;

        public bool Isradio6
        {
            get { return isRadio6; }
            set { isRadio6 = value; }
        }

        public Root CurrentData { get; private set; }
        private void LoadData()
        {
            string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(baseDirectory, "ColorGroups.json");
            if (!File.Exists(path))
            {
                return;
            }

            var jsonString = File.ReadAllText(path);
            CurrentData = jsonString.ToObject<Root>();
            if (CurrentData != null)
            {
                foreach (ColorGroup colorGroup in CurrentData.ColorGroups)
                {
                    _tasks.Add(new ListBoxItemCustom() { Name = colorGroup.GroupName });
                }
            }
        }

        private void UIElement_OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var item = ItemsControl.ContainerFromElement(listBox, e.OriginalSource as DependencyObject) as ListBoxItem;
            if (item != null)
            {
                // ListBox item clicked - do some cool things here
                var content = item.Content;
                if (content is ListBoxItemCustom)
                {
                    DrawColor(((ListBoxItemCustom)content).Name);
                }
            }
        }

        private void DrawColor(string colorTypeName)
        {
            this.WrapPanel.Children.Clear();
            if (CurrentData != null)
            {
                foreach (ColorGroup colorGroup in CurrentData.ColorGroups)
                {
                    if (colorTypeName == colorGroup.GroupName)
                    {
                        GroupDes.Text = colorGroup.Description;

                        var arrayColors = colorGroup.ColorSubItems.ToArray();
                        for (int i = 0; i < arrayColors.Length; i += 3)
                        {
                            string c1 = arrayColors[i].Color;
                            string c2 = arrayColors[i].Color;
                            string c3 = arrayColors[i].Color;

                            if (i + 1 < arrayColors.Length)
                            {
                                c2 = arrayColors[i + 1].Color;
                            }
                            if (i + 2 < arrayColors.Length)
                            {
                                c3 = arrayColors[i + 2].Color;
                            }


                            var colorItem = new ColorItem(
                                c1,
                                c2,
                                c3);
                            WrapPanel.Children.Add(colorItem);

                        }
                        foreach (ColorSubItem colorSubItem in colorGroup.ColorSubItems)
                        {

                        }
                    }
                }
            }
            //foreach (ColorType colorType in ColorTypes.ColorTypes2)
            //{
            //    if (colorType.TypeName == colorTypeName)
            //    {
            //        foreach (ColorGroup colorGroup in colorType.ColorGroups)
            //        {
            //            var colorItem = new ColorItem(
            //                colorGroup.ThreeColors[0],
            //                colorGroup.ThreeColors[1], 
            //                colorGroup.ThreeColors[2]);
            //            WrapPanel.Children.Add(colorItem);
            //        }
            //    }
            //}
        }

    }

    public class ListBoxItemCustom
    {
        public string Name { get; set; }
    }
}
