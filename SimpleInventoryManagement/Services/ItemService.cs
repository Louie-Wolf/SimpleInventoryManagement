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

        /// <summary>
        /// Adds a new Item to the local database.
        /// </summary>
        /// <param name="name"> specifies the name of the item, must not be null or empty</param>
        /// <param name="photo"> specifies the path of the photo of the item, must not be null or empty</param>
        /// <exception cref="ArgumentException"> if one of the parameters is invalid </exception>
        public async Task AddNewItem(string name, string photo)
        {
            try
            {
                int result;
                await Init();

                //Todo: name validation
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException($"Valid {nameof(name)} required");
                if (string.IsNullOrEmpty(photo))
                    throw new ArgumentException($"Valid {nameof(photo)} required");

                result = await conn.InsertAsync(new Item { Name = name, Photo = photo });
                StatusMessage = $"{result} record(s) added (Name: {name})";
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to add {name}. Error: {e.Message}";
            }
        }

        /// <summary>
        /// Removes an item from the list if it exists.
        /// </summary>
        /// <param name="name"> specifies the name of the item, must not be null or empty</param>
        /// <exception cref="ArgumentException">if the parameter invalid</exception>
        public async Task RemoveItem(string name)
        {
            try
            {
                int result;
                await Init();
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException($"Valid {nameof(name)} required");

                //dont need the photo here because it only needs the primary key?
                result = await conn.DeleteAsync(new Item() { Name = name });
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to remove {name}: Error: {e.Message}";
            }
        }

        /// <summary>
        /// Returns a specific item from the database.
        /// </summary>
        /// <param name="name">specifies the name of the item, must not be null or empty</param>
        /// <returns>The specific item if it exists.</returns>
        public async Task<Item> GetItem(string name)
        {
            try
            {
                await Init();
                if (string.IsNullOrEmpty(name))
                    throw new ArgumentException($"Valid {nameof(name)} required.");
                return await conn.GetAsync<Item>(new Item { Name = name });
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to retrieve data. {e.Message}";
            }
            return null;
        }

        /// <summary>
        /// Returns every item in the database.
        /// </summary>
        /// <returns>Every item in the database.</returns>
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
            //empty list wanted if the database is actually empty
            return new List<Item>();
        }
    }
}
