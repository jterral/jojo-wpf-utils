using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace HUBMetallisation.Helpers.Converters
{
    /// <summary>
    /// MultiConversion d'objet Null ou chaine vide vers un booléen.
    /// </summary>
    public class NullToFalseMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// Indique si un des éléments est nul.
        /// </summary>
        /// <param name="values">Les valeurs à transformer.</param>
        /// <param name="targetType">Le type.</param>
        /// <param name="parameter">Les paramètres si besoin.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>False si au moins un des éléments du tableau est null, true sinon.</returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Résultat
            bool result = true;

            // Si un objet de la liste est null ou vide on s'arrête et on renvoie false
            for (int i = 0; i < values.Length && result; i++)
            {
                // Test sur l'objet
                object value = values[i];
                if (value == null)
                {
                    // S'il est null on s'arrête
                    result = false;
                }
                else
                {
                    // Test si l'objet est de format "String"
                    if (value is string && string.IsNullOrEmpty(value as string))
                    {
                        // Si il est vide, on s'arrête
                        result = false;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Conversion inverse. Non Utilisée.
        /// </summary>
        /// <param name="value">La valeur.</param>
        /// <param name="targetTypes">Les types.</param>
        /// <param name="parameter">Les paramètres si besoin.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Un tableau de string.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] splitValues = ((string)value).Split(' ');
            return splitValues;
        }
    }
}
