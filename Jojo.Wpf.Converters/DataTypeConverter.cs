using System;
using System.Globalization;
using System.Windows.Data;

namespace TSV.CIC65.UI.Helpers.Converters
{
    /// <summary>
    /// Conversion d'un objet en son type.
    /// <example>
    /// </example>
    /// <![CDATA[
    /// ...
    /// <converter:DataTypeConverter x:Key="DataTypeConverter"/>
    /// ...
    /// Binding="{Binding Path=MyObject, Converter={StaticResource DataTypeConverter}, ConverterParameter={x:Static local:MyObjectClass}}"
    /// ...
    /// ]]>
    /// </summary>
    public class DataTypeConverter : IValueConverter
    {
        /// <summary>
        /// Conversion d'un objet en son type.
        /// </summary>
        /// <param name="value">L'objet à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Retourne le type de l'objet.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.GetType();
        }

        /// <summary>
        /// Conversion inverse non implémentée.
        /// </summary>
        /// <param name="value">L'objet à convertir.</param>
        /// <param name="targetType">Le type de l'objet.</param>
        /// <param name="parameter">Le paramètre.</param>
        /// <param name="culture">La culture.</param>
        /// <returns>Lève une exception de non implémentation.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
