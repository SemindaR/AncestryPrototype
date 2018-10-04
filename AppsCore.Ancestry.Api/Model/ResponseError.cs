namespace AppsCore.Ancestry.Api.Model
{
    public class ResponseError
    {
        public ResponseError(string code, string msg)
        {
            Code = code;
            Message = msg;
        }

        public string Code { get; set; }
        public string Message { get; set; }
    }
}
