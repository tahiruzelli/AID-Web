using AID.Entites;
using Microsoft.AspNetCore.Mvc;
using AID;
using AID.Data;
using Microsoft.EntityFrameworkCore;

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


            User user = await _context.Users.Where(x => x.id == newDataSet.userId).FirstOrDefaultAsync();
            if (user is null)
            {
                return new ResponseModel<DataSet>(false, null, "Bu id'ye ait bir user yok!");
            }
            else
            {
                DataSet dataSet = newDataSet;
                _context.Add(dataSet);
                
                user.totalGain += 0.01;
                user.totalVideoEditetTime += 0.01;
                user.balance += 0.01;
                _context.Update(user);

                _context.SaveChanges();

                return new ResponseModel<DataSet>(true, newDataSet, "");
            }

    
        }
    }
}
