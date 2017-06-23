namespace Jojo.Wpf.UI.Views
{
    /// <summary>
    /// Interface de représentation d'une page de l'application.
    /// </summary>
    public interface IPageViewModel
    {
        /// <summary>
        /// Obtient le titre de la page.
        /// </summary>
        string Title { get; }
    }
}
