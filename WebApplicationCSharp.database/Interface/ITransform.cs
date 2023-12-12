using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationCSharp.database.Interface
{    public interface ITransform<out T>
    {
        T Transform();
    }
}
