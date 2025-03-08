using static MagicVilla_Utility.DS;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
    }
}
