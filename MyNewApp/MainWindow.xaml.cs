using Squirrel;
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

namespace MyNewApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UpdateManager manage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            manage = await UpdateManager.GitHubUpdateManager(@"https://github.com/AhmedAbduo625/MyNewApp");

            var updateInfo = await manage.CheckForUpdate();

            if (updateInfo.ReleasesToApply.Count > 0)
            {
                MessageBox.Show("New Release is available");
                UpdateBtn.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("No Release available");
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await manage.UpdateApp();
            MessageBox.Show("Updated Successfully");
        }

    }
}
