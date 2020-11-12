using Libird.Data.Context;

namespace Libird.Data.Generic
{
    public class GenericContext
    {
        protected readonly ApplicationContext _context;
        public GenericContext(ApplicationContext context)
        {
            _context = context;
        }
    }
}
