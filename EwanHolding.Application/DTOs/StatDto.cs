namespace EwanHolding.Application.DTOs
{
    public class CreateStatDto
    {
        public string Label_Ar { get; set; }
        public string Label_En { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class UpdateStatDto
    {
        public int Id { get; set; }
        public string Label_Ar { get; set; }
        public string Label_En { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
    }
    public class StatResponseDto
    {
        public int Id { get; set; }
        public string Label_Ar { get; set; }
        public string Label_En { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; }
    }
}
