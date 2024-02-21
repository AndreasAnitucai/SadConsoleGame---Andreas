using SadConsole.Configuration;
using SadConsoleGame;

Settings.WindowTitle = "Adv.Programmering Uppgift - AA";

Builder configuration = new Builder()
    .SetScreenSize(120, 38)
    .SetStartingScreen<RootScreen>()
    .IsStartingScreenFocused(true)
    ;

Game.Create(configuration);
Game.Instance.Run();
Game.Instance.Dispose();

static void Startup(object? sender, GameHost host)
{
    ScreenObject container = new ScreenObject();
    Game.Instance.Screen = container;

    // First console
    Console console1 = new(60, 14);
    console1.Position = (3, 2);
    console1.Surface.DefaultBackground = Color.AnsiCyan;
    console1.Clear();
    console1.Print(1, 1, "Type on me!");
    console1.Cursor.Position = (1, 2);
    console1.Cursor.IsEnabled = true;
    console1.Cursor.IsVisible = true;
    console1.Cursor.MouseClickReposition = true;
    console1.IsFocused = true;


    // Add a child surface
    ScreenSurface surfaceObject = new(5, 3);
    surfaceObject.Surface.FillWithRandomGarbage(surfaceObject.Font);
    surfaceObject.Position = console1.Surface.Area.Center - (surfaceObject.Surface.Area.Size / 2);
    surfaceObject.UseMouse = false;

    console1.Children.Add(surfaceObject);

    // Second console
    Console console2 = new Console(58, 12);
    console2.Position = new Point(19, 11);
    console2.Surface.DefaultBackground = Color.AnsiRed;
    console2.Clear();
    console2.Print(1, 1, "Type on me!");
    console2.Cursor.Position = new Point(1, 2);
    console2.Cursor.IsEnabled = true;
    console2.Cursor.IsVisible = true;
    console2.FocusOnMouseClick = true;
    console2.MoveToFrontOnMouseClick = true;

    container.Children.MoveToBottom(console2);

    container.Children.Add(console2);
    container.Children.Add(console1);
}