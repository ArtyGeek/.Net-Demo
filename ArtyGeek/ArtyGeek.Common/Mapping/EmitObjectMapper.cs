using EmitMapper;
using EmitMapper.MappingConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Common.Mapping
{
    public class EmitObjectMapper : IObjectMapper
    {
        private static readonly DefaultMapConfig _config;

        static EmitObjectMapper()
        {
            _config = ConfigureMapper();
        }

        public TDst Map<TSrc, TDst>(TSrc obj)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TSrc, TDst>(_config);
            return mapper.Map(obj);
        }

        public IEnumerable<TDst> MapCollection<TSrc, TDst>(IEnumerable<TSrc> obj)
        {
            var mapper = ObjectMapperManager.DefaultInstance.GetMapper<TSrc, TDst>(_config);
            return mapper.MapEnum(obj);
        }

        private static DefaultMapConfig ConfigureMapper()
        {
            return new DefaultMapConfig()
                .ConvertUsing<short, int>(i => i); // mapping functions here
        }
    }
}
