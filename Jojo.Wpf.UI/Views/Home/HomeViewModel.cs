using Jojo.Wpf.UI.Helpers;
using Jojo.Wpf.UI.Helpers.MVVM;
using Jojo.Wpf.UI.Resources.Internationalization;
using Jojo.Wpf.UI.ViewModels;
using System;
using System.Windows.Input;

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

        /// <summary>
        /// Nom du rectangle.
        /// </summary>
        private string _name;

        /// <summary>
        /// Obtient ou définit le nom du rectangle.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        #region COMMANDS
        /// <summary>
        /// Commande exemple.
        /// </summary>
        private ICommand _exampleCmd = null;

        /// <summary>
        /// Obtient la commande exemple.
        /// </summary>
        public ICommand ExampleCmd
        {
            get
            {
                if (_exampleCmd == null)
                {
                    _exampleCmd = new RelayCommand(
                        param => NavigateToExampleView(),
                        param => true);
                }

                return _exampleCmd;
            }
        }

        /// <summary>
        /// Commande affectant un nom aléatoire.
        /// </summary>
        private ICommand _randomNameCmd = null;

        /// <summary>
        /// Obtient la commande affectant un nom aléatoire.
        /// </summary>
        public ICommand RandomNameCmd
        {
            get
            {
                if (_randomNameCmd == null)
                {
                    _randomNameCmd = new RelayCommand(
                        param => SetRandomName(),
                        param => true);
                }

                return _randomNameCmd;
            }
        }
        #endregion

        #region EVENTS
        /// <summary>
        /// L'évènement exemple.
        /// </summary>
        public event EventHandler NavigateToExample;
        #endregion

        /// <summary>
        /// Se produit lors de la demande au passsage à la page exemple.
        /// </summary>
        private void NavigateToExampleView()
        {
            if (NavigateToExample != null)
            {
                NavigateToExample(this, new EventArgs<RectViewModel>(new RectViewModel("My Name", 50, 80, 400, 400)));
            }
        }

        /// <summary>
        /// Se produit lors de la demande d'affectation d'un nom aléatoire.
        /// </summary>
        private void SetRandomName()
        {
            this.Name = Guid.NewGuid().ToString();
        }
    }
}
