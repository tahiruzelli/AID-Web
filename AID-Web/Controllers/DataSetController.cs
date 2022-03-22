using AID.Model;
using Microsoft.AspNetCore.Mvc;
using AID;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class DataSetController
    {
        private List<DataSet> _dataSets = FakeData.getDataSets(10);
        [HttpPost]
        public ResponseModel<DataSet> createData([FromBody]DataSet dataSet)
        {

            DataSet newDataSet = new DataSet();
            newDataSet.id = 0;
            newDataSet.createTime = DateTime.Now;
            newDataSet.photoUrl = dataSet.photoUrl;
            newDataSet.userId = dataSet.userId;
            newDataSet.tagId = dataSet.tagId;

            _dataSets.Add(newDataSet);

            return new ResponseModel<DataSet>(true, newDataSet, "");
        }
    }
}
