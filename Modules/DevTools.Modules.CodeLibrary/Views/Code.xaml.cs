using System;
using System.Windows.Controls;
using System.Windows.Threading;
using DevTools.Modules.CodeLibrary.ViewModels;

namespace DevTools.Modules.CodeLibrary.Views
{
    /// <summary>
    /// Interaction logic for Code
    /// </summary>
    public partial class Code : UserControl
    {
        private CodeViewModel model = null;

        public Code()
        {
            InitializeComponent();
            model = this.DataContext as CodeViewModel;

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += timer_Tick;
            LiveTime.Start();

        }
        void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = "当前时间: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.GetDocumentCount();
        }
    }
}
