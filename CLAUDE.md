# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Overview

`Mintos Toolkit` is a .NET 8 library (`DustInTheWind.Mintos.Toolkit`) that parses CSV statement files exported from the [Mintos](https://www.mintos.com) loan investment platform. It is published as a NuGet package.

## Commands

```bash
# Build the solution
dotnet build ./Mintos.Toolkit.slnx

# Build in Release mode (also produces the .nupkg)
dotnet build ./Mintos.Toolkit.slnx -c Release

# Restore dependencies (uses nuget.config)
dotnet restore ./Mintos.Toolkit.slnx --configfile ./nuget.config

# Run the demo project
dotnet run --project sources/Mintos.Toolkit.Demo
```

There are no automated tests in this repository.

## Architecture

The solution (`Mintos.Toolkit.slnx`) contains two projects under `sources/`:

- **`Mintos.Toolkit`** — the library (NuGet package). Target: `net8.0`. Assembly name: `DustInTheWind.Mintos.Toolkit`.
- **`Mintos.Toolkit.Demo`** — a CLI demo that reads `statement.csv` and prints parsed rows.

### Library internals

`StatementDocument` (extends `Collection<TransactionRecord>`) is the public entry point. It exposes several `LoadAsync` overloads accepting a file path, `string`, `Stream`, `FileInfo`, `StreamReader`, or `TextReader`. All overloads funnel into `LoadInternalAsync`, which delegates to the internal `CsvStatementDocument`.

`CsvStatementDocument` (internal, `Csv/` subfolder) wraps CsvHelper and drives parsing as an `IAsyncEnumerable<TransactionRecord>`. It tracks a state machine (`CsvDocumentReadState`: `HeaderRow → DataRow → Ended`). CSV exceptions from CsvHelper are translated into the library's own exception hierarchy.

**Exception hierarchy** (all public):
- `DocumentLoadException` — base; wraps unexpected failures
- `HeaderLoadException` — CSV header missing or invalid
- `DataLoadException` — row data parsing failure
- `HeaderAlreadyLoadedException` — headers read twice

**CSV mapping** lives in `Csv/TransactionRecordMap.cs` (CsvHelper `ClassMap`), with custom type converters `CurrencyConverter` and `PaymentTypeConverter` for the `Currency` and `PaymentType` enums.

### Versioning and packaging

Shared metadata (version, company, license, README) is in `Directory.Build.props`. The library csproj sets `GeneratePackageOnBuild=true`, so a `.nupkg` is produced on every build.

## Code Conventions

From `.github/copilot-instructions.md`:

- Do not use `var`; use the explicit type.
- Use `new()` (target-typed) when instantiating objects.
- In LINQ lambdas, name the item parameter `x`.
- Multi-property object initializers: one property per line.
- Omit curly braces for single-line `if`, `for`, and `using` bodies.
- XML doc comments only on public types/members that are part of the NuGet API; omit for internal/solution-only types.

## NuGet Publishing

Publishing is handled by the GitHub Actions workflow `.github/workflows/publish-nuget.yml` (triggered manually or on tag). The package id is `DustInTheWind.Mintos.Toolkit`.
