using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Common.Mapping
{
    public interface IObjectMapper
    {
        TDst Map<TSrc, TDst>(TSrc obj);

        IEnumerable<TDst> MapCollection<TSrc, TDst>(IEnumerable<TSrc> obj);
    }
}
