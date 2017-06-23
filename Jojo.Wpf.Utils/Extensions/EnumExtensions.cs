using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Jojo.Wpf.Utils.Extensions
{
    /// <summary>
    /// Extensions du type <see cref="System.Enum" />.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Obtient la description de l'énumération.
        /// </summary>
        /// <typeparam name="T">Le type de l'énumération.</typeparam>
        /// <param name="enumValue">L'énumération pour laquelle récupérer sa description.</param>
        /// <returns>Retourne la description de l'énumération si celle-ci existe, sinon l'énumération sous forme de <see cref="string" />.</returns>
        public static string GetDescription(this Enum enumValue)
        {
            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? enumValue.ToString() : attribute.Description;
        }

        /// <summary>
        /// Obtient l'attribut personnalisé d'une énumération.
        /// </summary>
        /// <typeparam name="TAttribute">Le type de l'attribut à récupérer.</typeparam>
        /// <param name="enumValue">L'énumération pour laquelle récupérer l'attribut.</param>
        /// <returns>Retourne l'attribut retrouvé sur l'énumération.</returns>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue) where TAttribute : Attribute
        {
            return enumValue.GetType().GetMember(enumValue.ToString()).First().GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Conversion d'une chaine de caractère en énumération.
        /// </summary>
        /// <typeparam name="T">Le type de l'énumération.</typeparam>
        /// <param name="value">La chaine de caractère à convertir.</param>
        /// <param name="defaultValue">La valeur par défaut à positionner.</param>
        /// <returns>Retourne l'énumération convertie.</returns>
        public static T ToEnum<T>(this string value, T defaultValue) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }

            T result;
            return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        }
    }
}
