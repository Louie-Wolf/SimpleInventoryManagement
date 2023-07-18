using System.Threading.Tasks;
using SimpleInventoryManagement.Model;

namespace SimpleInventoryManagement.Services
{
    public class ItemService
    {
        List<Item> itemList = new ();

        public ItemService()
        {

        }

        //Todo: Implement sql database calls
        public async Task<List<Item>> GetItems()
        {
            if (itemList?.Count > 0)
                return itemList;
        
            return itemList;
        }
    }
}
