using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetManagementApp.Models;

namespace BudgetManagementApp
{
	public interface IDocumentDBService
	{
		Task CreateDatabase(string databaseName);

		Task CreateDocumentCollection(string databaseName, string collectionName);

		Task<List<BudgetItem>> GetBudgetItemsAsync();

		Task SaveBudgetItemAsync(BudgetItem item, bool isNewItem);

		Task DeleteBudgetItemAsync(string id);
	}
}
