using Marketplace.Blazor.Models.Account;
using Marketplace.Organizations.Blazor.Entities;
using Marketplace.Organizations.Blazor.Models.OrganizationModels;

namespace Marketplace.Organizations.Blazor.Managers;

public class OrganizationsManager
{
	private readonly RequestManager _requestManager;

	public OrganizationsManager(RequestManager requestManager)
	{
		_requestManager = requestManager;
	}

	public async Task<List<Organization>?> GetOrganizations()
	{
		return await _requestManager.Get<List<Organization>>("api/organizations");
	}

	public async Task AddOrganization(OrganizationModel model)
	{
		await _requestManager.Post<string>("api/organizations", model);
	}
}