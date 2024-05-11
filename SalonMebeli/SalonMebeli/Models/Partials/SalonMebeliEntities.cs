using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SalonMebeli.Models
{
    public partial class SalonMebeliEntities : DbContext
    {
        private static SalonMebeliEntities _context;
        /// <summary>
        /// Метод возвращающий контекст подключения
        /// </summary>
        /// <returns></returns>
        public static SalonMebeliEntities GetContext()
        {
            if (_context == null)
            {
                _context = new SalonMebeliEntities();
            }
            return _context;
        }
    }
}
