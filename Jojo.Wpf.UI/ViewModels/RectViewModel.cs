using Jojo.Wpf.UI.Helpers.MVVM;

namespace Jojo.Wpf.UI.ViewModels
{
    /// <summary>
    /// Représentation d'un carré.
    /// </summary>
    public class RectViewModel : ViewModelBase
    {
        /// <summary>
        /// Obtient ou définit le nom du rectangle.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Obtient ou définit la coordonnée x du coin supérieur gauche du rectangle.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Obtient ou définit la coordonnée y du coin supérieur gauche du rectangle.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Obtient ou définit la largeur du rectangle.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Obtient ou définit la hauteur du rectangle.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Initialise une nouvelle instance d'un rectangle.
        /// </summary>
        /// <param name="name">Le nom du rectangle.</param>
        /// <param name="x">La coordonnée x du coin supérieur gauche du rectangle.</param>
        /// <param name="y">La coordonnée y du coin supérieur gauche du rectangle.</param>
        /// <param name="width">La largeur du rectangle.</param>
        /// <param name="height">La hauteur du rectangle.</param>
        public RectViewModel(string name, double x, double y, double width, double height)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }
}
