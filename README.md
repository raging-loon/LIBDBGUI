# LIBDBGUI

This is Windows Forms-based C# application I wrote for my Database final.

## Build

If you are using Visual Studio, you can install all required packages via: 
\<Project Name\> -> Manage NuGet Package -> Restore

Or by installing the `MySQL.Data` package.

## Features
- Connection Caching - so you don't have to retype IP addresses/user names every time 
- Client Management
- Regex Searching
- Input Sanitization to help prevent SQL Injection Attacks
- Field Editing for most tables
    - Exluding fields that would potentially disrupt the validity of database, e.g. primary keys
- Book Check Out/Return
