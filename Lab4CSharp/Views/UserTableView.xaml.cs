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
using Lab4CSharp.ViewModels;

namespace Lab4CSharp.Views
{
    /// <summary>
    /// Interaction logic for UserTableView.xaml
    /// </summary>
    public partial class UserTableView : UserControl
    {
        public UserTableView()
        {
            InitializeComponent();
            DataContext = new UserTableViewModel();
        }
    }
}
