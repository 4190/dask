using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dask.Models;

namespace Dask.Data.EfCore
{
    public class EfCoreSurveysRepositary : EfCoreRepository<Survey, ApplicationDbContext>
    {
        public EfCoreAdvertRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
