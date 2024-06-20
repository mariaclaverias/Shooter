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
        if (buildTarget == UnityEditor.BuildTarget.StandaloneWindows ||
            buildTarget == UnityEditor.BuildTarget.StandaloneWindows64)
        {
            pcText.gameObject.SetActive(true);
        }
        else
        {
            xboxText.gameObject.SetActive(true);
        }
#else
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor)
        {
            pcText.gameObject.SetActive(true);
        }
        else if (Application.platform == RuntimePlatform.XboxOne ||
                 Application.platform == RuntimePlatform.XboxSeriesX)
        {
            xboxText.gameObject.SetActive(true);
        }
#endif
    }
}
