# WebParser
Web app for parsing data and save it to database.

The database is created automatically, if this has not happened to do the following steps:
1. Run the Add-Migration InitialCreate command in Package Manager Console. This creates a migration to create the existing schema.
2. Run the Update-Database command in Package Manager Console.

The test data file is located at the root of the project "TextFile.txt".
