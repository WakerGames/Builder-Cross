//C# Example
using UnityEditor;
using UnityEngine;


[ExecuteInEditMode]
public class Screenshot : EditorWindow
{
	//string mystr="1536x2048";
	string resolution0= "2048x2732";
	string resolution1= "1242x2208";
	string resolution2= "1242x2688";
	string resolution3="800x450";
	string resolution4="960x640"; 
	string myname="screen";
	int resWidth = 0; 
	int resHeight = 0;

	public Camera myCamera;
	int scale = 1;

	string path = "";
	bool showPreview = true;
	RenderTexture renderTexture;

	bool isTransparent = false;

	// Add menu item named "My Window" to the Window menu
	[MenuItem("Tools/m nasir/Instant High-Res Screenshot")]
	public static void ShowWindow()
	{
		//Show existing window instance. If one doesn't exist, make one.
		EditorWindow editorWindow = EditorWindow.GetWindow(typeof(Screenshot));
		editorWindow.autoRepaintOnSceneChange = true;
		editorWindow.Show();
		editorWindow.title = "n_Screenshot";
	}

	float lastTime;


	void OnGUI()
	{

		EditorGUILayout.LabelField ("Resolution", EditorStyles.boldLabel);


		 EditorGUILayout.IntField ("Width", resWidth);
		 EditorGUILayout.IntField ("Height", resHeight);

		EditorGUILayout.Space();

	

		
		EditorGUILayout.Space();
		
		
		GUILayout.Label ("Save Path", EditorStyles.boldLabel);

		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.TextField(path,GUILayout.ExpandWidth(false));
		if(GUILayout.Button("Browse",GUILayout.ExpandWidth(false)))
			path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);

		EditorGUILayout.EndHorizontal();

		EditorGUILayout.HelpBox("Choose the folder in which to save the screenshots ",MessageType.None);
		EditorGUILayout.Space();



	



		GUILayout.Label ("Select Camera", EditorStyles.boldLabel);


		myCamera = EditorGUILayout.ObjectField(myCamera, typeof(Camera), true,null) as Camera;


		if(myCamera == null)
		{
			myCamera =Camera.main;
		}

		isTransparent = EditorGUILayout.Toggle("Transparent Background", isTransparent);


		EditorGUILayout.HelpBox("Choose the camera of which to capture the render. You can make the background transparent using the transparency option.",MessageType.None);

		EditorGUILayout.Space();
		EditorGUILayout.BeginVertical();
		EditorGUILayout.LabelField ("Default Options", EditorStyles.boldLabel);




		EditorGUILayout.EndVertical();

		EditorGUILayout.Space();
		EditorGUILayout.LabelField ("If any Last screenshot was taken at " + resWidth*scale + " x " + resHeight*scale + " px", EditorStyles.boldLabel);

	
		if(GUILayout.Button("Ipad "+resolution0,GUILayout.MinHeight(60)))
		{

			resWidth= int.Parse( resolution0.Split('x')[0].Trim().ToString());
			resHeight=int.Parse( resolution0.Split('x')[1].Trim().ToString());
		
			myname="Ipad";
			if(path == "")
			{
				
				path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);
				Debug.Log("Path Set");
				TakeHiResShot();
			}
			else
			{
				TakeHiResShot();
			}
		}
		
		

		if(GUILayout.Button("5.5 "+resolution1,GUILayout.MinHeight(60)))
		{
			
			resWidth= int.Parse( resolution1.Split('x')[0].Trim().ToString());
			resHeight=int.Parse( resolution1.Split('x')[1].Trim().ToString());
		
			
			myname="5.5";
			if(path == "")
			{
				
				path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);
				Debug.Log("Path Set");
				TakeHiResShot();
			}
			else
			{
				TakeHiResShot();
			}
		}
		if(GUILayout.Button("4.5 "+resolution2,GUILayout.MinHeight(60)))
		{
			
			resWidth= int.Parse( resolution2.Split('x')[0].Trim().ToString());
			resHeight=int.Parse( resolution2.Split('x')[1].Trim().ToString());
		
			
			myname="4.5";
			if(path == "")
			{
				
				path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);
				Debug.Log("Path Set");
				TakeHiResShot();
			}
			else
			{
				TakeHiResShot();
			}
		}
		if(GUILayout.Button("4 "+resolution3,GUILayout.MinHeight(60)))
		{
			
			resWidth= int.Parse( resolution3.Split('x')[0].Trim().ToString());
			resHeight=int.Parse( resolution3.Split('x')[1].Trim().ToString());
		
			
			myname="4";
			if(path == "")
			{
				
				path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);
				Debug.Log("Path Set");
				TakeHiResShot();
			}
			else
			{
				TakeHiResShot();
			}
		}
		if(GUILayout.Button("3.5 "+resolution4,GUILayout.MinHeight(60)))
		{
			
			resWidth= int.Parse( resolution4.Split('x')[0].Trim().ToString());
			resHeight=int.Parse( resolution4.Split('x')[1].Trim().ToString());

			myname="3.5";
			if(path == "")
			{
				
				path = EditorUtility.SaveFolderPanel("Path to Save Images",path,Application.dataPath);
				Debug.Log("Path Set");
				TakeHiResShot();
			}
			else
			{
				TakeHiResShot();
			}
		}


		

		EditorGUILayout.Space();
		EditorGUILayout.BeginHorizontal();

		if(GUILayout.Button("Open Last Screenshot",GUILayout.MaxWidth(160),GUILayout.MinHeight(40)))
		{
			if(lastScreenshot != "")
			{
				Application.OpenURL("file://" + lastScreenshot);
				Debug.Log("Opening File " + lastScreenshot);
			}
		}

		if(GUILayout.Button("Open Folder",GUILayout.MaxWidth(100),GUILayout.MinHeight(40)))
		{
			Application.OpenURL("file://" + path);
		}



		EditorGUILayout.EndHorizontal();


		
		if (takeHiResShot) 
		{
			int resWidthN = resWidth*scale;
			int resHeightN = resHeight*scale;
			RenderTexture rt = new RenderTexture(resWidthN, resHeightN, 24);
			myCamera.targetTexture = rt;
			
			TextureFormat tFormat;
			if(isTransparent)
				tFormat = TextureFormat.ARGB32;
			else
				tFormat = TextureFormat.RGB24;
			
			
			Texture2D screenShot = new Texture2D(resWidthN, resHeightN, tFormat,false);
			myCamera.Render();
			RenderTexture.active = rt;
			screenShot.ReadPixels(new Rect(0, 0, resWidthN, resHeightN), 0, 0);
			myCamera.targetTexture = null;
			RenderTexture.active = null; 
			byte[] bytes = screenShot.EncodeToPNG();
			string filename = ScreenShotName(resWidthN, resHeightN);
			
			System.IO.File.WriteAllBytes(filename, bytes);
			Debug.Log(string.Format("Took screenshot to: {0}", filename));
			//Application.OpenURL(filename);
			takeHiResShot = false;
		}

		EditorGUILayout.HelpBox("In case of any error, make sure you have Unity Pro as the plugin requires Unity Pro to work.",MessageType.Info);


	}


	
	private bool takeHiResShot = false;
	public string lastScreenshot = "";
	
		
	public string ScreenShotName(int width, int height) {

		string strPath="";

		strPath = string.Format("{0}/"+myname+"_{1}x{2}_{3}.png", 
		                     path, 
		                     width, height, 
		                               System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
		lastScreenshot = strPath;
	
		return strPath;
	}



	public void TakeHiResShot() {
		Debug.Log("Taking Screenshot");
		takeHiResShot = true;
	}
	public static EditorWindow GetMainGameView()
	{
		System.Type T = System.Type.GetType("UnityEditor.GameView,UnityEditor");
		System.Reflection.MethodInfo GetMainGameView = T.GetMethod("GetMainGameView",System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
		System.Object Res = GetMainGameView.Invoke(null,null);
		return (EditorWindow)Res;
	}

}

