using Unity.Logging;
using Unity.Logging.Sinks;
using UnityEngine;
using Logger = Unity.Logging.Logger;

public class CustomLogger : MonoBehaviour
{
    private void Awake()
    {
        Log.Logger = new Logger(new LoggerConfig()
            .MinimumLevel.Debug()
            .OutputTemplate("{Timestamp} - {Level} - {Message}")
            .RedirectUnityLogs()
            .WriteTo.StdOut(outputTemplate: "{Level} || {Timestamp} || {Message}")
            .WriteTo.UnityEditorConsole());
    }
}
