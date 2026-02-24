using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_SGTORNEO_ADOLFO.Converters
{
    public class ByteArray2ImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (value is byte[] bytes && bytes.Length > 0)
                {
                    return ImageSource.FromStream(() => new MemoryStream(bytes));
                }
            }
            catch
            {
                //si falla, devolvemos null
            }

            return null;

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
