# vscode-compoundlaunch

An example of how to use compound launch configurations in VS Code.

## How do I run this?

Clone the repository.

```sh
git clone https://github.com/oliverroer/vscode-compoundlaunch.git
```

Open the root folder in VS Code.

On the sidebar, click on the debug icon to open the debug tab.

Click the top drop-down.

You will see multiple options, including:

- `.NET Core Launch (Client)`: This will debug just the client.
- `.NET Core Launch (Server)`: This will debug just the server.
- `.NET Core Launch (Server/Client)`: This will debug the server and the client, at the same time!

Choose `.NET Core Launch (Server/Client)` from the dropdown.

Click the green play-button next to the dropdown, or press `F5` to start debugging.

You are now debugging the client and the server at the same time.

Try setting a breakpoint in the for-loop in `Client/Program.cs` and the `Get()` method of `Server/Controllerse/ValuesController`.

Run the debugger again.

You should be able to see how the debugger seamlessly jumps back and forth between the server and client, depending on which breakpoint is hit next.

## How did you configure this?

Quite easily, actually. They've added a feature to VS Code called [compound launch configurations](https://code.visualstudio.com/Docs/editor/debugging#_multitarget-debugging) which allows you to compose multiple launch configurations into a new launch configuration, which will run all declared configurations simultaneously.

This is all configured in the `.vscode/launch.json` file.

Under configurations, you'll find the definitions for regular launch configurations.

Here's the one for debugging the client:

```json
{
    "name": ".NET Core Launch (Client)",
    "type": "coreclr",
    "request": "launch",
    "preLaunchTask": "build",
    // If you have changed target frameworks, make sure to update the program path.
    "program": "${workspaceFolder}/Client/bin/Debug/netcoreapp2.1/Client.dll",
    "args": [],
    "cwd": "${workspaceFolder}/Client",
    // For more information about the 'console' field, see https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md#console-terminal-window
    "console": "internalConsole",
    "stopAtEntry": false,
    "internalConsoleOptions": "openOnSessionStart"
}
```

Here's the one of debugging the server:

```json
{
    "name": ".NET Core Launch (Server)",
    "type": "coreclr",
    "request": "launch",
    "preLaunchTask": "build",
    // If you have changed target frameworks, make sure to update the program path.
    "program": "${workspaceFolder}/Server/bin/Debug/netcoreapp2.1/Server.dll",
    "args": [],
    "cwd": "${workspaceFolder}/Server",
    // For more information about the 'console' field, see https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger-launchjson.md#console-terminal-window
    "console": "internalConsole",
    "stopAtEntry": false,
    "internalConsoleOptions": "openOnSessionStart"
}
```

Note the names here; `.NET Core Launch (Client)` and `.NET Core Launch (Server)`.

Further down, you'll find a `compounds` property, containing an array of named compounds.

Here's I've declared one compound, named `.NET Core Launch (Server/Client)` which combines `.NET Core Launch (Client)` and `.NET Core Launch (Server)`:

```json
{
    "name": ".NET Core Launch (Server/Client)",
    "configurations": [
        ".NET Core Launch (Server)",
        ".NET Core Launch (Client)"
    ]
}
```

This is what makes `.NET Core Launch (Server/Client)` appear in the debug dropdown, and triggers a debug session wherein you can debug both the client and the server.
