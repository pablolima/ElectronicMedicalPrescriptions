using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLReceituario
{
    public interface IBLLCrud<T>
    {
        List<T> SelectALL();
        bool Update(T t);
        bool Insert(T t);
        bool Delete(T t);
    }
}
