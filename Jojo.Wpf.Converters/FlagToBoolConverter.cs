using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TSV.CIC65.UI.Helpers.Converters
{
    /// <summary>
    /// Conversion d'un <see cref="Enum"/> flag en <see cref="bool"/>.
    /// </summary>
    public class FlagToBoolConverter : IValueConverter
    {
        /// <summary>
        /// La valeur de la cible.
        /// </summary>
        private ulong _target;

        /// <summary>
        /// Conversion d'une énumération en booléen.
        /// </summary>
        /// <param name="value">La valeur de l'énumération.</param>
        /// <param name="targetType">Le type de l'énumération.</param>
        /// <param name="parameter">Le paramètre avec lequel comparer.</param>
        /// <param name="culture">Une implémentation de l'interface <see cref="IFormatProvider"/> qui supporte l'information de culture.</param>
        /// <returns>Retourne <c>true</c> si le flag est inclus, <c>false</c> sinon.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter is Enum && value is Enum)
            {
                var mask = (ulong)parameter;
                this._target = (ulong)value;

                return (mask & this._target) != 0;
            }

            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// Conversion inverse d'un booléen en flag.
        /// </summary>
        /// <param name="value">La valeur du booléen.</param>
        /// <param name="targetType">Le type de l'énumération.</param>
        /// <param name="parameter">Le paramètre à comparer.</param>
        /// <param name="culture">Une implémentation de l'interface <see cref="IFormatProvider"/> qui supporte l'information de culture.</param>
        /// <returns>Retourne la valeur du flag.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && parameter is Enum)
            {
                var mask = System.Convert.ToUInt64(parameter);
                if ((bool)value)
                {
                    _target |= mask;
                }
                else
                {
                    _target &= ~mask;
                }

                return Enum.ToObject(targetType, _target);
            }

            return DependencyProperty.UnsetValue;
        }
    }
}
