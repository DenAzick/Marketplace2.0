using Marketplace.Organizations.Blazor.Entities;

namespace Marketplace.Organizations.Blazor.Models.OrganizationModels
{
    public class OrganizationUserModel
    {
        public Guid UserId { get; set; }
        public OrganizationUserRole UserRole { get; set; }
    }
}
