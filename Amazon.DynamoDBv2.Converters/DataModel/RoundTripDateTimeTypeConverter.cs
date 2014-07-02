using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Amazon.DynamoDBv2.DocumentModel;

namespace Amazon.DynamoDBv2.DataModel
{
    /// <summary>
    /// The <see cref="IPropertyConverter"/> to properly support round-trip serialization of <see cref="DateTime"/>.
    /// </summary>
    public class RoundTripDateTimeTypeConverter : IPropertyConverter
    {
        /// <summary>
        /// Converts the <c>value</c> to a <see cref="Primitive"/>.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The primitive of the <c>value</c>.</returns>
        public DynamoDBEntry ToEntry(object value)
        {
            return new Primitive
            {
                Value = ((DateTime)value).ToString("o", CultureInfo.InvariantCulture)
            };
        }

        /// <summary>
        /// Converts the <c>entry</c> to <see cref="DateTime"/>.
        /// </summary>
        /// <param name="entry">The entry to convert.</param>
        /// <returns>The date time of the entry.</returns>
        public object FromEntry(DynamoDBEntry entry)
        {
            return DateTime.ParseExact(entry.AsString(), "o", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
        }
    }
}
