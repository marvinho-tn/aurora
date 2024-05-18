using System.Text.Json;

namespace Aurora.Data.Json
{
	public static class JsonDataBase<T> where T : class
	{
		private const int FileLengthLimit = 1024; // 1 KB

		public static async Task SaveAsync(T objeto, string name)
		{
			var folderName = $"Arquivos do tipo {typeof(T).FullName}";

			if (!Directory.Exists(folderName))
			{
				Directory.CreateDirectory(folderName);
			}

			var json = JsonSerializer.Serialize(objeto);
			var filePath = $"{folderName}/{name}_{Guid.NewGuid()}.json";

			if (File.Exists(filePath))
			{
				var fileInfo = new FileInfo(filePath);
				if (fileInfo.Length >= FileLengthLimit)
				{
					filePath = $"{folderName}/{name}_{Guid.NewGuid()}.json";
				}
			}

			await File.WriteAllTextAsync(filePath, json);
		}

		public static async Task<List<T>> FetchAsync(string name)
		{
			var folderName = $"Arquivos do tipo {typeof(T).FullName} - {name}";
			var objects = new List<T>();

			if (Directory.Exists(folderName))
			{
				var files = Directory.GetFiles(folderName, "*.json");

				foreach (var file in files)
				{
					var json = await File.ReadAllTextAsync(file);
					var obj = JsonSerializer.Deserialize<T>(json);
					objects.Add(obj);
				}
			}

			return objects;
		}
	}

}