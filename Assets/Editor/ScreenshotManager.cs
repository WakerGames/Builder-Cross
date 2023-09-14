using UnityEditor;

public class ScreenshotManager
{
    
    [MenuItem("Screenshot/Take")]
    private static void TakeScreenshotCallbackDef()
    {
        var obj = UnityEngine.GameObject.FindObjectOfType<Screenshothelper>();
        if (obj != null)
        {
            obj.TakeScreenshotCallback();
        }
    }

}
