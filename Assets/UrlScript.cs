using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlScript : MonoBehaviour
{
    private string googleplayUrl = "https://play.google.com/store/apps/dev?id=8942875264357629235&hl=tr&gl=US";
    private string appstoreUrl = "https://apps.apple.com/in/developer/waker-games/id1596083334";
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
    public void MoreGameURL()
    {
#if UNITY_ANDROID
        Application.OpenURL(googleplayUrl);

#else
        Application.OpenURL(appstoreUrl);



#endif
    }
}
