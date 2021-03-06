﻿using System.Windows.Data;

namespace Jojo.Wpf.UI.Helpers.Bindings
{
    /// <summary>
    /// Liaison <c>OneWay</c> avec actualisation à la modification de la propriété.
    /// </summary>
    public class OneWayBinding : Binding
    {
        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OneWayBinding"/>.
        /// </summary>
        public OneWayBinding()
            : base()
        {
            this.Mode = BindingMode.OneWay;
            this.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }

        /// <summary>
        /// Initialise une nouvelle instance de la classe <see cref="OneWayBinding"/>.
        /// </summary>
        /// <param name="path">Le chemin d'accès initial pour la liaison.</param>
        public OneWayBinding(string path)
            : base(path)
        {
            this.Mode = BindingMode.OneWay;
            this.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
        }
    }
}
