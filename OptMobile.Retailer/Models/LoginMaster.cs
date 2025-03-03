namespace OptMobile.Retailer.Models;

public class LoginMaster
{
    public string login_name { get; set; }
    public string login_password { get; set; }
}

public class SignUpMaster
{
    public string? mobile { get; set; }
    public string? email { get; set; }
    public bool ismobile { get; set; }
}

public class SignUpResponse
{
    public int otp { get; set; }
    public int user_type_id { get; set; }
    public string user_type { get; set; }
    public string user_code { get; set; }
}

public class OtpMaster
{
    public string user_code { get; set; }
    public int otp { get; set; }
    public string fcm_token { get; set; }
}

public class LoginResponse
{
    public string token { get; set; }
    //[JsonPropertyName("refresh_token")]
    public string refreshToken { get; set; }
    //[JsonPropertyName("user_code")]
    public string userCode { get; set; }
    public string tenant { get; set; }
    public string root { get; set; }
}
