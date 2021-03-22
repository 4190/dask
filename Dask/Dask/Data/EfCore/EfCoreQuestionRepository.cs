using Dask.Data.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dask.Models;
using Dask.Data;

namespace Dask.Data.EfCore
{
    public class EfCoreQuestionRepository : EfCoreRepository<Question, ApplicationDbContext>
    {
        public EfCoreQuestionRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
