using System.Runtime.InteropServices;

class Program
{
    [DllImport("hovellas_engine.dll")]
    private static extern void InitializeEngine();

    [DllImport("hovellas_engine.dll")]
    private static extern void RenderScene(string sceneName);

    [DllImport("hovellas_engine.dll")]
    private static extern void ShutdownEngine();

    static void Main(string[] args)
    {
        InitializeEngine();
        RenderScene("MainMenu");
        // Game loop here
        ShutdownEngine();
    }
}