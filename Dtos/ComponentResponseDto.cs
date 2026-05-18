namespace APBD_TASK7.Dtos
{
    public class PcComponentResponseDto
    {
        public string ComponentCode { get; set; } = null!;
        public string ComponentName { get; set; } = null!;
        public string Description { get; set; }
        public string ComponentType { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int Amount { get; set; }
    }
}
