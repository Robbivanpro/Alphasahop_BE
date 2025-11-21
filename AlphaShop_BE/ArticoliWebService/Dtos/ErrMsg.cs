namespace ArticoliWebService.Dtos
{
    public class ErrMsg
    {
        public ErrMsg(string message, int errCode)
        {
            this.message = message;
            this.errCode = errCode;
        }

        public string message { get; set; }
        public int errCode { get; set; }
    }
}