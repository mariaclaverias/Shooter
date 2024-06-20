using UnityEngine;
using TMPro;

public class ConsoleCheck : MonoBehaviour
{
    public TextMeshProUGUI pcText;
    public TextMeshProUGUI xboxText;

    void Start()
    {
        pcText.gameObject.SetActive(false);
        xboxText.gameObject.SetActive(false);
        CheckConsoleType();
    }

    void CheckConsoleType()
    {
#if UNITY_EDITOR
        UnityEditor.BuildTarget buildTarget = UnityEditor.EditorUserBuildSettings.activeBuildTarget;
        Debug.Log("Running in Unity Editor with build target: " + buildTarget);

        if (buildTarget == UnityEditor.BuildTarget.StandaloneWindows ||
            buildTarget == UnityEditor.BuildTarget.StandaloneWindows64)
        {
            Debug.Log("Detected build target as Standalone Windows.");
            pcText.gameObject.SetActive(true);
        }
        else if (buildTarget == UnityEditor.BuildTarget.XboxOne ||
                 buildTarget == UnityEditor.BuildTarget.WSAPlayer)
        {
            Debug.Log("Detected build target as Xbox or UWP.");
            xboxText.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Detected build target as something else.");
        }
#else
        Debug.Log("Running outside of Unity Editor on platform: " + Application.platform);

        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            Debug.Log("Detected runtime platform as Windows.");
            pcText.gameObject.SetActive(true);
        }
        else if (Application.platform == RuntimePlatform.XboxOne ||
                 Application.platform == RuntimePlatform.WSAPlayerX86 ||
                 Application.platform == RuntimePlatform.WSAPlayerX64 ||
                 Application.platform == RuntimePlatform.WSAPlayerARM)
        {
            Debug.Log("Detected runtime platform as Xbox or UWP.");
            xboxText.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Detected runtime platform as something else.");
        }
#endif
    }
}
