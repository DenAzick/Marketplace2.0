namespace Marketplace.Services.Identity.Models
{
    public class UpdateUserModel
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
    }
}
