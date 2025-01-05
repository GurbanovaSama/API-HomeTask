namespace FinalApiTask.BL.DTOs.AppUserDtos
{
    public record AppUserLoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
