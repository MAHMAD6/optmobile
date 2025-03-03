namespace OptMobile.Retailer.Models
{
    public class PartyMaster
    {
        public int party_id { get; set; }
        public int party_type { get; set; }
        public string party_code { get; set; }
        public string party_name { get; set; }
        public string address_one { get; set; }
        public string address_two { get; set; }
        public string address_three { get; set; }
        public string other_address { get; set; }
        public int pin { get; set; }
        public string area { get; set; }
        public string city { get; set; }
        public string mobile { get; set; }
        public string whatsapp_mobile { get; set; }
        public string email { get; set; }
        public bool isactive { get; set; }
        public string unq_code { get; set; }
    }
}
