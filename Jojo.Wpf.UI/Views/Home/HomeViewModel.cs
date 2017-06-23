using Jojo.Wpf.UI.Helpers.MVVM;
using Jojo.Wpf.UI.Resources.Internationalization;

namespace Jojo.Wpf.UI.Views
{
    /// <summary>
    /// Vue modèle de la page principale.
    /// </summary>
    public class HomeViewModel : ViewModelBase, IPageViewModel
    {
        /// <summary>
        /// Obtient le titre de la page principale.
        /// </summary>
        public string Title
        {
            get { return HomeMsg.Title; }
        }
    }
}
