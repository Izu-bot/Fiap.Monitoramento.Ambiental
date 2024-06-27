namespace Fiap.Monitoramento.Ambiental.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Role { get; set; }
        public string? PasswordHash {  get; set; }
    }
}
