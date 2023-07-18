using SimpleInventoryManagement.Model;
using SQLite;

namespace SimpleInventoryManagement.Services
{
    public class ItemService
    {
        private SQLiteAsyncConnection conn;
        public string StatusMessage { get; private set; }

        public ItemService()
        {
        }

        private async Task Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            await conn.CreateTableAsync<Item>();
        }

        public async Task AddNewItem(string name, string photo)
        {
            try
            {
                int result;
                await Init();

                //Todo: name validation
                if (string.IsNullOrEmpty(name))
                    throw new Exception($"Valid {nameof(name)} required");
                if (string.IsNullOrEmpty(photo))
                    throw new Exception($"Valid {nameof(photo)} required");

                result = await conn.InsertAsync(new Item { Name = name, Photo = photo });
                StatusMessage = $"{result} record(s) added (Name: {name})";
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to add {name}. Error: {e.Message}";
            }
        }

        public async Task<List<Item>> GetAllItems()
        {
            try
            {
                await Init();
                return await conn.Table<Item>().ToListAsync();
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to retrieve data. {e.Message}";
            }

            return new List<Item>();
        }
    }
}
