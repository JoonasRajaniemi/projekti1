using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyHybridApp.Models
{
    internal class itemsDatabase
    {
        
      public async static Task<IEnumerable<Item>> GetItems()
      {
            string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

            try
            {
                if (!File.Exists(filePath))
                {
                    var defaultItems = new List<Item>();

                    JsonSerializerOptions writeOptions = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };

                    string defaultJson = JsonSerializer.Serialize(defaultItems, writeOptions);

                    await File.WriteAllTextAsync(filePath, defaultJson);
                    return [];
                }
                else
                {
                    using FileStream stream = File.OpenRead(filePath);

                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    IEnumerable<Item>? result = await JsonSerializer.DeserializeAsync<IEnumerable<Item>>(stream, options);
                    Console.WriteLine(filePath + ": File read successfully");

                    return result ?? Enumerable.Empty<Item>();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A read error occurred: {ex.Message}");
                return [];
            }
        } 

        public async static Task WriteItems(ObservableCollection<ViewModels.ItemViewModel> items)
        {
            JsonSerializerOptions options = new()
            {
                WriteIndented = true,
            };

            string json = System.Text.Json.JsonSerializer.Serialize(items, options);

            string filePath = Path.Combine(FileSystem.AppDataDirectory, "data.json");

            try
            {
                using StreamWriter writer = new StreamWriter(filePath);
                await writer.WriteAsync(json);
            }
            catch (IOException IoEx)
            {
                Console.WriteLine($"I/O error occurred: {IoEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine($"Permission erros: {uaEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
