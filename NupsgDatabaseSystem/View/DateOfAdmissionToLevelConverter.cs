using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NupsgDatabaseSystem.View
{
    public class DateOfAdmissionToLevelConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int level = 0;
            DateTime DOA =(DateTime)value;
            try
            {
                DateTime adminDate = DOA;
                int adminYear = adminDate.Year;
                level = DateTime.Now.Year - adminYear;
                if (DateTime.Now.Month > 6)
                {
                    level++;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message+"\n Please Contact John @www.Kleitech.com, 0200262423 ");
            }
            level *= 100;
            return level.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
