using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace HUBMetallisation.Helpers.Converters
{
    /// <summary>
    /// Comparason de 2 valeurs.
    /// </summary>
    public class IsLessThanMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// Indique si la première valeur et inférieure à la seconde.
        /// </summary>
        /// <param name="values">Un tableau contenant 2 valeurs.</param>
        /// <param name="targetType">Le type.</param>
        /// <param name="parameter">Les paramètres.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>True si la première valeur est inférieure à la seconde, false sinon.</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Résultat par défaut false
            bool result = false;

            if (values.Length == 2)
            {
                IConvertible convertA = values[0] as IConvertible;
                IConvertible convertB = values[1] as IConvertible;
                if (convertA != null && convertB != null)
                {
                    double valA = System.Convert.ToDouble(convertA);
                    double valB = System.Convert.ToDouble(convertB);

                    result = valA <= valB;
                }
            }

            return result;
        }

        /// <summary>
        /// Conversion inverse. Attention méthode non utilisée et donc non implémentée.
        /// </summary>
        /// <param name="value">La valeur.</param>
        /// <param name="targetType">Le type d'objet.</param>
        /// <param name="parameter">Le paramètre passé au convertisseur.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Un booléen.</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
