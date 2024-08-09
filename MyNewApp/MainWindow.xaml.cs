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
            try
            {
                

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await manage.UpdateApp();
            MessageBox.Show("Updated Successfully");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                manage = await UpdateManager.GitHubUpdateManager(@"https://github.com/AhmedAbduo625/MyNewApp");
                CheckBtn.IsEnabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
