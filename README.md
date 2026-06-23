# Mintos Toolkit

[![GitHub Repo](https://img.shields.io/badge/github-repo-blue?logo=github)](https://github.com/lastunicorn/mintos-toolkit) [![GitHub Build](https://img.shields.io/github/actions/workflow/status/lastunicorn/mintos-toolkit/build-master.yml?logo=github)](https://github.com/lastunicorn/mintos-toolkit/actions/workflows/build-master.yml) [![NuGet Version](https://img.shields.io/nuget/v/DustInTheWind.Mintos.Toolkit?logo=nuget)](https://www.nuget.org/packages/DustInTheWind.Mintos.Toolkit) [![NuGet Downloads](https://img.shields.io/nuget/dt/DustInTheWind.Mintos.Toolkit?logo=nuget)](https://www.nuget.org/packages/DustInTheWind.Mintos.Toolkit)

`Mintos Toolkit` is a .NET library that helps working with files exported from Mintos.

Mintos is a loan investment platform.

- https://www.mintos.com

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

## Features

- **Parse Mintos Statement Documents** - Load and parse CSV files exported directly from the Mintos platform

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

StatementDocument statementDocument = await StatementDocument.LoadFromFileAsync("statement.csv");

foreach (TransactionRecord transaction in statementDocument)
{
	...
}
```

## CSV Statement Document

Each row is mapped to a `TransactionRecord` with the following columns:

| CSV Column      | Type     | TransactionRecord Property | Description                                         |
|-----------------|----------|--------------------------|-----------------------------------------------------|
| `Date`          | `DateTime` | `Date`                   | The date when the transaction occurred.             |
| `Transaction ID:`| `string` | `TransactionId`         | A unique identifier for the transaction.            |
| `Details`       | `string` | `Details`                | Additional details or description of the transaction.|
| `Turnover`      | `decimal` | `Turnover`               | The transaction amount.                             |
| `Balance`       | `decimal` | `Balance`                | The account balance after the transaction.         |
| `Currency`      | `string` | `Currency`               | The currency code (e.g., EUR, USD).                |
| `Payment Type`  | `string` | `PaymentType`            | The type of payment (e.g., Deposit, Withdrawal, Interest).|

## Demo Project

The repository includes a sample CLI project in `sources/Mintos.Toolkit.Demo` that demonstrates:

- reading `statement.csv`
- printing parsed data.

You can use this project as a reference implementation for your own importer/exporter tools.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
