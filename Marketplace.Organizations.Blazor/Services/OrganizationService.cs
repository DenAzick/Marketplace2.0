using Marketplace.Organizations.Blazor.Models;
using System.Net.Http.Json;

namespace Marketplace.Organizations.Blazor.Services
{
    public class OrganizationService
    {
        private readonly HttpClient httpClient;

        public OrganizationService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<OrganizationModel>> GetOrganizations()
        {
            return await httpClient.GetFromJsonAsync<List<OrganizationModel>>("/api/organizations");
        }
    }
}
