#if UNITY_EDITOR
using System.IO;
using System.Linq;
using UnityEditor;

public class DTDAndroidWindow : EditorWindow
{
    private static string PluginSource => Path.Combine("Packages", "com.devtodev.sdk.analytics.huawei", "Editor",
        "Analytics", PLUGIN_FOLDER_NAME);

    private static string PluginDestination => Path.Combine("Assets", "Plugins", "Android", PLUGIN_FOLDER_NAME);
    private const string PLUGIN_FOLDER_NAME = "devtodev.plugin";

    [MenuItem("Window/devtodev/Create Android plugin folder")]
    public static void CreateAndroidPluginFolder()
    {
        if (!Directory.Exists(PluginDestination))
        {
            Directory.CreateDirectory(PluginDestination);
        }

        var files = Directory.GetFiles(PluginSource).Where(f => !f.EndsWith(".meta"));
        foreach (var file in files)
        {
            var fileName = Path.GetFileName(file);
            var destinationFileName = Path.Combine(PluginDestination, fileName);
            if (File.Exists(destinationFileName)) continue;
            File.Copy(file, Path.Combine(PluginDestination, fileName));
        }

        AssetDatabase.Refresh();
    }
}
#endif