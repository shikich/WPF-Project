namespace OrdersWPF.Services
{
    public class Tag
    {
        public string _tag { get; set; }
        public bool _check { get; set; }
        public Tag(string tag, bool check)
        {
            _tag = tag;
            _check = check;
        }
    }
}
