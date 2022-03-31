using AID.Entites;
using Microsoft.AspNetCore.Mvc;
using AID;
using AID.Data;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class DataSetController
    {
        private readonly ApplicationDbContext _context;

        public DataSetController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ResponseModel<DataSet>> CreateData([FromBody]DataSet newDataSet)
        {

            DataSet dataSet = newDataSet;
            _context.Add(dataSet);
            _context.SaveChanges();
            return new ResponseModel<DataSet>(true, newDataSet, "");
        }
    }
}
