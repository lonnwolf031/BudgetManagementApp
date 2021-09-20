using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetManagementApp.Models;

namespace BudgetManagementApp
{
	public class BudgetItemManager
	{
		IDocumentDBService documentDBService;

		public BudgetItemManager(IDocumentDBService service)
		{
			documentDBService = service;
		}

		public Task CreateDatabase(string databaseName)
		{
			return documentDBService.CreateDatabase(databaseName);
		}

		public Task CreateDocumentCollection(string databaseName, string collectionName)
		{
			return documentDBService.CreateDocumentCollection(databaseName, collectionName);
		}

		public Task<List<BudgetItem>> GetBudgetItemsAsync()
		{
			return documentDBService.GetBudgetItemsAsync();
		}

		public Task SaveBudgetItemAsync(BudgetItem item, bool isNewItem = false)
		{
			return documentDBService.SaveBudgetItemAsync(item, isNewItem);
		}

		public Task DeleteBudgetItemAsync(BudgetItem item)
		{
			return documentDBService.DeleteBudgetItemAsync(item.Id);
		}
	}
}
