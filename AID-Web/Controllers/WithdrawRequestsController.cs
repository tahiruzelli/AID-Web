using AID;
using AID.Data;
using AID.Entites;
using AID_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AID_Web.Controllers
{
    [Route("api/v1/[controller]")]
    public class WithdrawRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WithdrawRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetMyRequests/{id}")]
        public async Task<ResponseModel<List<WithdrawRequest>>> GetMyRequests(int id)
        {
            List<WithdrawRequest> withdrawRequest = await _context.WithdrawRequests.Where(x => x.userId == id).ToListAsync();
            if (withdrawRequest is null)
                return new ResponseModel<List<WithdrawRequest>>(false, null, "Çekim isteği bulunmamaktadır.");
            return new ResponseModel<List<WithdrawRequest>>(true, withdrawRequest, "");
        }

        [HttpPost("CreateRequest")]
        public ResponseModel<WithdrawRequest> CreateRequest([FromBody]CreateWithdrawRequestModel withdrawRequest)
        {
            WithdrawRequest newWithdrawRequest = new WithdrawRequest();
            newWithdrawRequest.expDate = withdrawRequest.expDate;
            newWithdrawRequest.userId = withdrawRequest.userId;
            newWithdrawRequest.balance = withdrawRequest.balance;
            newWithdrawRequest.cardNo = withdrawRequest.cardNo;
            newWithdrawRequest.cardHolder = withdrawRequest.cardHolder;
            newWithdrawRequest.cvv = withdrawRequest.cvv;
            newWithdrawRequest.createTime = DateTime.UtcNow;
            newWithdrawRequest.isApproved = false;

            _context.Add(newWithdrawRequest);
            _context.SaveChanges();
            
            return new ResponseModel<WithdrawRequest>(true, newWithdrawRequest, "");
        }

        private async Task<bool> ApproveWithDrawRequest(int id)
        {
            WithdrawRequest withdrawRequest = await _context.WithdrawRequests.FirstOrDefaultAsync(x => x.id == id);
            if(withdrawRequest is null)
            {
                return false;
            }
            else if (await depositMoney(withdrawRequest.userId,withdrawRequest.balance) == true) {

                withdrawRequest.isApproved = true;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        private async Task<bool> DepositMoney(int userId, double balance)
        {
            User user = await _context.Users.FirstOrDefaultAsync(x => x.id == userId);
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
                user.balance -= balance;
                return true;
            }
            
          
        }
    }
}
