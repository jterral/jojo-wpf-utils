using System.Windows.Data;

namespace Jojo.Wpf.UI.Helpers.Bindings
{
    /// <summary>
    /// Liaison <c>OneWay</c> avec actualisation à la modification de la propriété.
    /// </summary>
    public class TwoWayBinding : Binding
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TwoWayBinding"/>.
        /// </summary>
        public TwoWayBinding()
            : base()
        {
            this.Mode = BindingMode.TwoWay;
            this.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="TwoWayBinding"/>.
        /// </summary>
        /// <param name="path">Le chemin d'accès initial pour la liaison.</param>
        public TwoWayBinding(string path)
            : base(path)
        {
            this.Mode = BindingMode.TwoWay;
            this.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
    }
}
