using System.Windows.Controls;

namespace Jojo.Wpf.UI.Views.Examples
{
    /// <summary>
    /// Interaction logic for the <c>AsyncPropertiesView.xaml</c>.
    /// </summary>
    public partial class AsyncPropertiesView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncPropertiesView"/> class.
        /// </summary>
        public AsyncPropertiesView()
        {
            InitializeComponent();

            this.DataContext = new AsyncPropertiesViewModel();
        }
    }
}
