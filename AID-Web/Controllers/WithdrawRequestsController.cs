using AID;
using AID.Model;
using Microsoft.AspNetCore.Mvc;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class WithdrawRequestsController : ControllerBase
    {
        private List<WithdrawRequest> _withdrawRequests = FakeData.getWithdrawRequests(10);
        [HttpGet("GetMyRequests/{id}")]
        public ResponseModel<List<WithdrawRequest>> getMyRequests(int id)
        {
            return new ResponseModel<List<WithdrawRequest>>(true, _withdrawRequests, "");
        }

        [HttpPost("CreateRequest")]
        public ResponseModel<WithdrawRequest> createRequest([FromBody]WithdrawRequest withdrawRequest)
        {
            WithdrawRequest newWithdrawRequest = new WithdrawRequest();
            newWithdrawRequest.userId = withdrawRequest.userId;
            newWithdrawRequest.cvv = withdrawRequest.cvv;
            newWithdrawRequest.cardHolder = withdrawRequest.cardHolder;
            newWithdrawRequest.expDate = withdrawRequest.expDate;
            newWithdrawRequest.balance = withdrawRequest.balance;
            newWithdrawRequest.cardNo = withdrawRequest.cardNo;
            newWithdrawRequest.isApproved = false;
            withdrawRequest.createTime = DateTime.Now;

            _withdrawRequests.Add(newWithdrawRequest);
            
            return new ResponseModel<WithdrawRequest>(true, newWithdrawRequest, "");
        }

        private bool approveWithDrawRequest(int id)
        {
            
            WithdrawRequest withdrawRequest = _withdrawRequests.FirstOrDefault(x => x.id == id);
            if (depositMoney(withdrawRequest.userId,withdrawRequest.balance) == true) {

                withdrawRequest.isApproved = true;
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private bool depositMoney(int userId, double balance)
        {
            List<User> _user = FakeData.getUsers(200);
            User user = _user.FirstOrDefault(x => x.id == userId);
            if(user == null)
            {
                return false;
            }
            else if((user.balance - balance) < 0)
            {
                return false;
            }
            else
            {
                return true;
                user.balance -= balance;
            }
            
          
        }
    }
}
