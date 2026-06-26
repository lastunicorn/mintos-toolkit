using System.Collections;

namespace DustInTheWind.Mintos.Toolkit;

/// <summary>
/// Helper class to easily load multiple CSV statement documents from a directory.
/// </summary>
public class StatementDocuments : IEnumerable<StatementDocument>
{
	private readonly List<StatementDocument> documents = [];

	/// <summary>
	/// Loads the CSV files from the provided path.
	/// If the path is a file, it loads the specified file.
	/// If the path is a directory it searches for all CSV files in that directory and loads them.
	/// </summary>
	/// <param name="path">The path of a CSV file or a directory containing CSV files.</param>
	/// <param name="options">Allows controlling the list of files to be loaded.</param>
	public async Task LoadAsync(string path, StatementLoadOptions options = null)
	{
		IEnumerable<string> filePaths = GetFilePaths(path, options);

		Predicate<string> filePathFilter = options?.FilePathFilter;

		if (filePathFilter != null)
			filePaths = filePaths.Where(x => filePathFilter(x));

		Task<StatementDocument>[] tasks = filePaths
			.Select(x =>
			{
				Console.WriteLine($"- Load file: {x}");
				return StatementDocument.LoadFromFileAsync(x);
			})
			.ToArray();

		IEnumerable<StatementDocument> newDocuments = await Task.WhenAll(tasks);
		documents.AddRange(newDocuments);
	}

	private static IEnumerable<string> GetFilePaths(string path, StatementLoadOptions options)
	{
		if (File.Exists(path))
		{
			return
			[
				path
			];
		}

		if (Directory.Exists(path))
		{
			string filePattern = options?.FilePattern ?? "*.csv";

			SearchOption searchOption = options?.Recursive == true
				? SearchOption.AllDirectories
				: SearchOption.TopDirectoryOnly;

			return Directory.EnumerateFiles(path, filePattern, searchOption);
		}

		throw new FileNotFoundException(path);
	}

	/// <summary>
	/// Returns an enumeration with all records from all loaded documents.
	/// </summary>
	public IEnumerable<TransactionRecord> GetAllRecords()
	{
		return documents
			.SelectMany(x => x);
	}

	public IEnumerator<StatementDocument> GetEnumerator()
	{
		return documents.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}
}