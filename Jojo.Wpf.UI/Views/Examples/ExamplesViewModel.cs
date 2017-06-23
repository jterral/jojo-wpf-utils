using Jojo.Wpf.UI.Helpers.MVVM;
using Jojo.Wpf.UI.Resources.Internationalization;
using Jojo.Wpf.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

        /// <summary>
        /// Indique si le chargement de la page est en cours.
        /// </summary>
        private bool _isLoading;

        /// <summary>
        /// Obtient une valeur indiquant si le chargement de la page est en cours.
        /// </summary>
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            private set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        /// <summary>
        /// Obtient la liste des rectangles affichés dans la page.
        /// </summary>
        public ObservableCollection<RectViewModel> RectItems { get; private set; }

        /// <summary>
        /// Chargement du rectangle dans la page.
        /// </summary>
        /// <param name="squareViewModel">Le rectangle à charger.</param>
        public async Task Load(RectViewModel rectViewModel)
        {
            this.IsLoading = true;

            // TODO : Implémentation de la logique
            await Task.Delay(TimeSpan.FromSeconds(3));

            RectItems = new ObservableCollection<RectViewModel>();
            RectItems.Add(rectViewModel);
            OnPropertyChanged("RectItems");

            this.IsLoading = false;
        }
    }
}
