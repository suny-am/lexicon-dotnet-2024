using SuperConsole;

IO singleton = IO.Instance;

// Check if the value has been created
singleton.Write($"{IO.InstanceCreated}", newline: true);