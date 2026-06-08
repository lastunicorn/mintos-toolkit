# Mintos Toolkit

`Mintos Toolkit` is a .NET library that helps working with files exported from Mintos.

Mintos is a loan investment platform.

- https://www.mintos.com

The package is published as `DustInTheWind.Mintos.Toolkit`.

## Installation

Package Manager:

```powershell
Install-Package DustInTheWind.Mintos.Toolkit
```

.NET CLI:

```bash
dotnet add package DustInTheWind.Mintos.Toolkit
```

## Runtime Requirements

- Library target framework: `.NET 8.0` (`net8.0`)

## Quick Start

### a) Export the Transactions CSV File

In Mintos web application:

1. Log in.
2. Click on profile image (top-right) and open **Transactions**.
3. Select the date interval you need.
4. Click "Search" button to apply the filters
5. Click the **Download Selected List (*.csv)** link to download the file.

You will get a CSV containing transaction rows that can be parsed with this toolkit.

### b) Parse the Exported Document

```csharp
using DustInTheWind.Mintos.Toolkit;

TransactionsDocument document = TransactionsDocument.LoadFromFile("transactions.csv");

foreach (TransactionRecord transaction in document.Transactions)
{
	...
}
```

## `Transaction` Record

Each row is mapped to:

- TBD

## Demo Project

The repository includes a sample CLI project in `sources/Mintos.Toolkit.Demo` that demonstrates:

- reading `transactions.csv`
- printing parsed data.

You can use this project as a reference implementation for your own importer/exporter tools.
