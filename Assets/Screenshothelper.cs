using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class Screenshothelper : MonoBehaviour
{
    private static bool _isTakingScreenshot = false;

    private static string SCREENSHOT_NAME = "screenshot.jpg";
    private IEnumerator TakeScreenshotCo()
    {
        yield return new WaitForEndOfFrame();

        int factor = Mathf.CeilToInt(1080f / Screen.height);

        Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture(factor > 0 ? factor : 1);

        yield return new WaitForEndOfFrame();

        _isTakingScreenshot = false;

        var tempnumber = UnityEngine.Random.Range(0, 100);
        string screenshotPath = Application.persistentDataPath + "/" + tempnumber + SCREENSHOT_NAME;
        File.WriteAllBytes(screenshotPath, tex.EncodeToJPG());
        Debug.Log(screenshotPath);
        //HubEvents.ScreenshotTaken?.Invoke(tex);
    }

#if UNITY_EDITOR
    [MenuItem("Screenshot/Take")]
#endif
    private static void TakeScreenshotCallbackDef()
    {
        var obj =FindObjectOfType<Screenshothelper>();
        if (obj != null)
        {
            obj.TakeScreenshotCallback();
        }
    }

    public void TakeScreenshotCallback()
    {
        if (_isTakingScreenshot) return;

        _isTakingScreenshot = true;
        StartCoroutine(TakeScreenshotCo());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Break();
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
