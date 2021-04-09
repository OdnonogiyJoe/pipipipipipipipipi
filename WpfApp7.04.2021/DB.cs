using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp7._04._2021
{
    class DB
    {
        static Entities студентыEntities;
        public static Entities GetDB()
        {
            if (студентыEntities == null)
                студентыEntities = new Entities();
            return студентыEntities;//промежуточное хранилище
        }
    }
}
