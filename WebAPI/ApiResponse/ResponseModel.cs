using WebAPI.Enum;

namespace WebAPI.ApiResponse
{
    public class ResponseModel
    {
        public StatusRespone StatusRespone { get; set; }
        public dynamic? Output { get; set; }

        public ResponseModel(StatusRespone statusRespone, dynamic output)
        {
            StatusRespone = statusRespone;
            Output = output;
        }

        public static ResponseModel ResponseTemplate(StatusRespone statusRespone, dynamic output)
        {
            return new ResponseModel(statusRespone, output);
        }
    }
}
