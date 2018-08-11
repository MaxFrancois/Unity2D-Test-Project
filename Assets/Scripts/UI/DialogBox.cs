using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour {

    static DialogBox Instance;
    private Image dialogFrame;
    private TMP_Text dialogText;

    private void Awake()
    {
        Instance = this;
        dialogFrame = GetComponent<Image>();
        dialogText = GetComponentInChildren<TMP_Text>();
    }

    public static bool IsVisible()
    {
        return Instance.dialogFrame.enabled;
    }

    public static void Show(string text)
    {
        Instance.DoShow(text);
    }

    void DoShow(string text)
    {
        dialogFrame.enabled = true;
        dialogText.enabled = true;
        dialogText.text = text;
    }

    public static void Hide()
    {
        Instance.DoHide();
    }

    void DoHide()
    {
        dialogFrame.enabled = false;
        dialogText.enabled = false;
    }
}
