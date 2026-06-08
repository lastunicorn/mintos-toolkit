namespace DustInTheWind.Mintos.Toolkit.Csv;

internal enum CsvDocumentReadState
{
	HeaderRow = 0,
	DataRow,
	Ended
}