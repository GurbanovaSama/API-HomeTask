namespace FinalApiTask.BL.DTOs.AppUserDtos
{
    public record AppUserEditDto
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
