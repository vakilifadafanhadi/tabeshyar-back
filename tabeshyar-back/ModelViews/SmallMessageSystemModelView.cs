namespace tabeshyar_back.ModelViews
{
    public class SmallMessageSystemModelView: SmallMessageSystemUserModelView
    {
        public string? Message { get; set; }
        public string? From { get; set; }
        public string Op { get; set; } = default!;
        public List<string>? To { get; set; }
    }
    public class SmallMessageSystemUserModelView
    {
        public string Uname { get; set; } = default!;
        public string Pass { get; set; } = default!;
    }
    public class SmallMessageSystemResponce
    {
        public int Status { get; set; }
        public string Data { get; set; } = default!;
    }
}
