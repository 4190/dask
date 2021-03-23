    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dask.Data.EFCore;

using Dask.Models;

namespace Dask.Data.EfCore
{
    public class EfCoreSurveysRepository : EfCoreRepository<Survey, ApplicationDbContext>
    {
        public EfCoreSurveysRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
