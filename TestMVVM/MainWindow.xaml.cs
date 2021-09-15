using System.Threading.Tasks;
using System.Windows;
using TestMVVM.ViewModels;

namespace TestMVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow()
        {
            DataContext = _viewModel = new MainWindowViewModel();
            InitializeComponent();
        }

        private async void BtnGo_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => _viewModel.Go()); // implement as a Command
        }
    }
}
