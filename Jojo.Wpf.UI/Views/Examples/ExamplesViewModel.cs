using Jojo.Wpf.UI.Helpers.MVVM;
using Jojo.Wpf.UI.Resources.Internationalization;

namespace Jojo.Wpf.UI.Views
{
    /// <summary>
    /// Vue modèle de la page exemples.
    /// </summary>
    public class ExamplesViewModel : ViewModelBase, IPageViewModel
    {
        /// <summary>
        /// Obtient le titre de la page exemples.
        /// </summary>
        public string Title
        {
            get { return ExamplesMsg.Title; }
        }
    }
}
