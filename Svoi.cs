using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

   public partial class Информация_о_косметике
    {
        public string sv1
        {
            get
            {
                return "Дата изготовление: " + Дата_изготовления;

            }
        }

        public string sv2
        {
            get
            {
                return "Бренд : " + Бренд1.Имя_бренда;

            }
        }

    }
}
