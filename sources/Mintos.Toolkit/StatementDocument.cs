using System.Collections.ObjectModel;
using DustInTheWind.Mintos.Toolkit.Csv;

namespace DustInTheWind.Mintos.Toolkit;

/// <summary>
/// Represents a Mintos statement document.
/// </summary>
/// <remarks>
/// The structure of the csv file is the one that is exported from the Mintos app (2026).
/// </remarks>
public class StatementDocument : Collection<TransactionRecord>
{
	public static async Task<StatementDocument> LoadFromFileAsync(string filePath)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

		try
		{
			using StreamReader streamReader = File.OpenText(filePath);
			return await LoadInternalAsync(streamReader);
		}
		catch (DocumentLoadException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new DocumentLoadException(ex);
		}
	}

	public static async Task<StatementDocument> LoadAsync(string csv)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(csv);

		try
		{
			using StringReader stringReader = new(csv);
			return await LoadInternalAsync(stringReader);
		}
		catch (DocumentLoadException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new DocumentLoadException(ex);
		}
	}

	public static async Task<StatementDocument> LoadAsync(Stream stream)
	{
		ArgumentNullException.ThrowIfNull(stream);

		try
		{
			using StreamReader streamReader = new(stream);
			return await LoadInternalAsync(streamReader);
		}
		catch (DocumentLoadException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new DocumentLoadException(ex);
		}
	}

	public static async Task<StatementDocument> LoadAsync(FileInfo fileInfo)
	{
		ArgumentNullException.ThrowIfNull(fileInfo);

		try
		{
			using StreamReader streamReader = fileInfo.OpenText();
			return await LoadInternalAsync(streamReader);
		}
		catch (DocumentLoadException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new DocumentLoadException(ex);
		}
	}

	public static Task<StatementDocument> LoadAsync(StreamReader streamReader)
	{
		ArgumentNullException.ThrowIfNull(streamReader);

		return LoadInternalAsync(streamReader);
	}

	public static Task<StatementDocument> LoadAsync(TextReader textReader)
	{
		ArgumentNullException.ThrowIfNull(textReader);

		return LoadInternalAsync(textReader);
	}

	private static async Task<StatementDocument> LoadInternalAsync(TextReader textReader)
	{
		try
		{
			CsvStatementDocument csvStatementDocument = new(textReader);
			StatementDocument statementDocument = [];

			await foreach (TransactionRecord transactionRecord in csvStatementDocument.ReadTransactions())
				statementDocument.Add(transactionRecord);

			return statementDocument;
		}
		catch (DocumentLoadException)
		{
			throw;
		}
		catch (Exception ex)
		{
			throw new DocumentLoadException(ex);
		}
	}
}