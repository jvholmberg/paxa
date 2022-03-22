# Paxa

## Prerequisites
* [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)
* [PostgreSQL](https://www.postgresql.org/)

## Setup
The recomended setup is the following. Feel free to make other choices however coding conventions must be followed.

* [pgAdmin (Database tool)](https://www.pgadmin.org/) - A very potent tool for working with PostgreSQL.
* [.NET Core Cli Entity Framework](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) - Used for creating migrations and updating database.
* [Visual Studio Code](https://code.visualstudio.com/) - In my opinion the best text editor by far.
* [Editorconfig (Plugin for Visual Studio Code)](https://marketplace.visualstudio.com/items?itemName=EditorConfig.EditorConfig) - A plugin for making sure editor config stays the same even if different editors are used.
* [TSLint (Plugin for Visual Studio Code)](https://marketplace.visualstudio.com/items?itemName=ms-vscode.vscode-typescript-tslint-plugin) - Lints the code to make sure rules are followed.
* [C# (Plugin for Visual Studio Code)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) - You will need this to build the project from visual studio code.

## Way of working
* For managing migrations there are scripts in the project root. These are recomended to use as they simplify this process.
* We use [Automapper](https://automapper.org/) for mapping dtos to entities and the other way around. It's recomended that you have basic knowledge of this lib before attempting to do anything backend-related.
* [Tailwindcss](https://tailwindcss.com/)


## Code scaffolding

Navigate to ClientApp and run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.
