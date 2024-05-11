using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SalonMebeli.Models
{
    public partial class Product
    {
        public string GetPhoto
        {
            get
            {
                if (Photo is null)
                    return Directory.GetCurrentDirectory() + @"\Images\";
                return Directory.GetCurrentDirectory() + @"\Images\" + Photo.Trim();
            }

        }
        public string GetColor
        {
            get
            {
                if (ProductDiscountAmount > 15)
                    return "#7fff00";
                else
                    return "#fff";
            }
        }
        public double GetPriceWithDiscount
        {
            get
            {
                double p = Convert.ToDouble(Price);
                byte d = Convert.ToByte(ProductDiscountAmount);
                return p * (100 - d) / 100;
            }
        }
        public string GetTextDecoration
        {
            get
            {
                if (ProductDiscountAmount > 0)
                    return "Strikethrough";
                return null;
            }
        }
        public string GetVisibility
        {
            get
            {
                if (ProductDiscountAmount > 0)
                    return "Visible";
                return "Collapsed";
            }
        }

    }
}
