namespace AID_Web.Models
{
    public class CreateWithdrawRequestModel
    {
        public double balance { get; set; }
        public string cardNo { get; set; }
        public int cvv { get; set; }
        public string expDate { get; set; }
        public string cardHolder { get; set; }
        public int userId { get; set; }
        public bool isApproved { get; set; } = false;
    }
}
