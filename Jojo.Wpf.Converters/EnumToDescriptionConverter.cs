using Jojo.Wpf.Utils.Extensions;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace TSV.CIC65.UI.Helpers.Converters
{
    /// <summary>
    /// Conversion d'un <see cref="Enum"/> en chaine de caractère.
    /// </summary>
    public class EnumToDescriptionConverter : IValueConverter
    {
        /// <summary>
        /// Conversion d'une énumération en sa description.
        /// </summary>
        /// <param name="value">La valeur de l'énumération.</param>
        /// <param name="targetType">Ignoré, le type est toujours <see cref="Enum"/>.</param>
        /// <param name="parameter">Ignoré, aucun paramètre récupéré.</param>
        /// <param name="culture">Une implémentation de l'interface <see cref="IFormatProvider"/> qui supporte l'information de culture.</param>
        /// <returns>Retourne la description de de l'énumération.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return DependencyProperty.UnsetValue;
            }

            return ((Enum)value).GetDescription();
        }

        /// <summary>
        /// Conversion d'une chaine de caractère en énumération.
        /// </summary>
        /// <param name="value">La valeur de la chaine de caractère.</param>
        /// <param name="targetType">Ignoré, le type est toujours <see cref="string"/>.</param>
        /// <param name="parameter">Ignoré, aucun paramètre récupéré.</param>
        /// <param name="culture">Une implémentation de l'interface <see cref="IFormatProvider"/> qui supporte l'information de culture.</param>
        /// <returns>Retourne l'énumération.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Enum.ToObject(targetType, value);
        }
    }
}
