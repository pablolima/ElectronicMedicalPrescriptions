using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALReceituario
{
    interface IDAL<T>
    {
         List<T> SelectAll();
         bool Insert(T t);
         bool Update(T t);
         bool Delete(T t);
    }
}
