using System.Text.Json;

namespace Aurora.Dados.Json
{
	public static class JsonDataBase<T> where T : class
	{
		private const int LimiteTamanhoArquivo = 1024; // 1 KB

		public static async Task SalvarTAsync(T objeto, string name)
		{
			var pastaArquivos = $"Arquivos do tipo {typeof(T).FullName}";

			if (!Directory.Exists(pastaArquivos))
			{
				Directory.CreateDirectory(pastaArquivos);
			}

			var json = JsonSerializer.Serialize(objeto);
			var filePath = $"{pastaArquivos}/{name}_{Guid.NewGuid()}.json";

			if (File.Exists(filePath))
			{
				var fileInfo = new FileInfo(filePath);
				if (fileInfo.Length >= LimiteTamanhoArquivo)
				{
					filePath = $"{pastaArquivos}/{name}_{Guid.NewGuid()}.json";
				}
			}

			await File.WriteAllTextAsync(filePath, json);
		}

		public static async Task<List<T>> RecuperarTsAsync(string name)
		{
			var pastaArquivos = $"Arquivos do tipo {typeof(T).FullName} - {name}";
			var objetos = new List<T>();

			if (Directory.Exists(pastaArquivos))
			{
				var files = Directory.GetFiles(pastaArquivos, "*.json");
				foreach (var file in files)
				{
					var json = await File.ReadAllTextAsync(file);
					var objeto = JsonSerializer.Deserialize<T>(json);
					objetos.Add(objeto);
				}
			}

			return objetos;
		}
	}

}