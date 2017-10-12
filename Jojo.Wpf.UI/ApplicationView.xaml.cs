using Jojo.Wpf.UI.Helpers;
using Jojo.Wpf.UI.ViewModels;
using Jojo.Wpf.UI.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Jojo.Wpf.UI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class ApplicationView : Window, INotifyPropertyChanged
    {
        /// <summary>
        /// Titre de la fenêtre.
        /// </summary>
        private string customWindowTitle = string.Empty;

        /// <summary>
        /// Obtient le titre de la fenêtre.
        /// </summary>
        public string CustomWindowTitle
        {
            get
            {
                return customWindowTitle;
            }

            private set
            {
                customWindowTitle = value;
                OnPropertyChanged("CustomWindowTitle");
            }
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="ApplicationView"/>.
        /// </summary>
        public ApplicationView()
        {
            // Initialisation des composants.
            InitializeComponent();

            // Binding du contexte
            DataContext = this;

            // Chargement de la page d'accueil par défaut
            LoadHomePage();
        }

        #region Implémentation du INotifyPropertyChanged
        /// <summary>
        /// Evènement levé à la modification.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Appelé lors d'une modification.
        /// </summary>
        /// <param name="propertyName">La propriété qui a été modifiée.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Gestions des pages affichées dans la fenêtre
        /// <summary>
        /// Liste des vues à afficher.
        /// </summary>
        private List<IPageViewModel> _pageViewModels = null;

        /// <summary>
        /// Obtient la liste des vues à afficher.
        /// </summary>
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                {
                    _pageViewModels = new List<IPageViewModel>();
                }

                return _pageViewModels;
            }
        }

        /// <summary>
        /// Vue affichée.
        /// </summary>
        private IPageViewModel _currentPageViewModel = null;

        /// <summary>
        /// Obtient ou définit la vue affichée.
        /// </summary>
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }

            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }
        #endregion

        /// <summary>
        /// Changement de fenêtre.
        /// </summary>
        /// <param name="viewModel">La vue à afficher.</param>
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!this.PageViewModels.Contains(viewModel))
            {
                // Si la vue n'existe pas encore dans la liste, on l'ajoute
                this.PageViewModels.Add(viewModel);
            }

            // Changement de fenêtre si valide
            this.CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
            if (this.CurrentPageViewModel != null)
            {
                // Actualisation du titre
                this.CustomWindowTitle = CurrentPageViewModel.Title;
            }
        }

        /// <summary>
        /// Chargement de la page d'accueil.
        /// </summary>
        private void LoadHomePage()
        {
            HomeViewModel viewModel = PageViewModels.FirstOrDefault(vm => vm.GetType() == typeof(HomeViewModel)) as HomeViewModel;
            if (viewModel == null)
            {
                // Création d'une nouvelle vue
                viewModel = new HomeViewModel();
                viewModel.NavigateToExample += OnNavigateToExample;
            }

            ChangeViewModel((IPageViewModel)viewModel);
        }

        /// <summary>
        /// Se produit lors de la demande d'affichage de la page exemple.
        /// </summary>
        /// <param name="sender">L'objet à l'origine de l'évènement.</param>
        /// <param name="e">Les paramètres de l'évènement.</param>
        private void OnNavigateToExample(object sender, EventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));

            if (e == null)
                throw new ArgumentNullException(nameof(e));

            PageOneViewModel viewModel = PageViewModels.FirstOrDefault(vm => vm.GetType() == typeof(PageOneViewModel)) as PageOneViewModel;
            if (viewModel == null)
            {
                viewModel = new PageOneViewModel();
            }

            if (e is EventArgs<RectViewModel> args)
            {
                Task.Run(() => viewModel.Load(args.Value));
            }

            ChangeViewModel((IPageViewModel)viewModel);
        }
    }
}
