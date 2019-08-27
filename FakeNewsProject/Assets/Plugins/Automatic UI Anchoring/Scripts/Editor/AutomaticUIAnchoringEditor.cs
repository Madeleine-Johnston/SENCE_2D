using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class AutomaticUIAnchoringEditor : Editor
{
    private static void Anchor(RectTransform rectTransform)
    {
        Slider slider = null;
        if (rectTransform.GetComponentsInParent<Slider>(true).Length != 0)
            slider = rectTransform.GetComponentsInParent<Slider>(true)[0];
        Scrollbar scrollbar = null;
        if (rectTransform.GetComponentsInParent<Scrollbar>(true).Length != 0)
            scrollbar = rectTransform.GetComponentsInParent<Scrollbar>(true)[0];
        Dropdown dropdown = null;
        if (rectTransform.GetComponentsInParent<Dropdown>(true).Length != 0)
            dropdown = rectTransform.GetComponentsInParent<Dropdown>(true)[0];
        InputField inputField = null;
        if (rectTransform.GetComponentsInParent<InputField>(true).Length != 0)
            inputField = rectTransform.GetComponentsInParent<InputField>(true)[0];
        ScrollRect scrollRect = null;
        if (rectTransform.GetComponentsInParent<ScrollRect>(true).Length != 0)
            scrollRect = rectTransform.GetComponentsInParent<ScrollRect>(true)[0];

        RectTransform parentRectTransform = null;
        if (rectTransform.transform.parent)
            parentRectTransform = rectTransform.transform.parent.GetComponent<RectTransform>();

        if (!parentRectTransform)
            return;
        else
        {
            if (rectTransform.GetComponent<ContentSizeFitter>() || rectTransform.transform.parent.GetComponent<LayoutGroup>())
                return;
            else if (slider && (rectTransform.transform == slider.handleRect.parent || rectTransform == slider.handleRect || rectTransform.transform == slider.fillRect.parent || rectTransform == slider.fillRect))
                return;
            else if (scrollbar && (rectTransform.transform == scrollbar.handleRect.parent || rectTransform == scrollbar.handleRect))
                return;
            else if (dropdown && (rectTransform == dropdown.template || rectTransform == dropdown.captionText.rectTransform))
                return;
            else if (inputField && (rectTransform == inputField.textComponent.rectTransform || rectTransform == inputField.placeholder.rectTransform || rectTransform.gameObject.name.Equals("InputField Input Caret")))
                return;
            else if (scrollRect && (rectTransform == scrollRect.viewport || rectTransform == scrollRect.content || (scrollRect.horizontalScrollbar && rectTransform.gameObject == scrollRect.horizontalScrollbar.gameObject) || (scrollRect.verticalScrollbar && rectTransform.gameObject == scrollRect.verticalScrollbar.gameObject)))
                return;
        }

        Undo.RecordObject(rectTransform, "Anchor UI Object");
        Rect parentRect = parentRectTransform.rect;
        rectTransform.anchorMin = new Vector2(rectTransform.anchorMin.x + (rectTransform.offsetMin.x / parentRect.width), rectTransform.anchorMin.y + (rectTransform.offsetMin.y / parentRect.height));
        rectTransform.anchorMax = new Vector2(rectTransform.anchorMax.x + (rectTransform.offsetMax.x / parentRect.width), rectTransform.anchorMax.y + (rectTransform.offsetMax.y / parentRect.height));
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
    }

    [MenuItem("Tools/Automatic UI Anchoring/Anchor All UI Objects")]
    private static void AnchorAllUIObjects()
    {
        Dictionary<GameObject, string> tmp = new Dictionary<GameObject, string>();
        RectTransform[] rectTransforms = Resources.FindObjectsOfTypeAll(typeof(RectTransform)) as RectTransform[];
        for (int i = 0; i < rectTransforms.Length; i++)
        {
            if (rectTransforms[i])
            {
                GameObject prefab = null;
                prefab = PrefabUtility.GetOutermostPrefabInstanceRoot(rectTransforms[i].gameObject);
                if (prefab)
                {
                    string prefabPath = AssetDatabase.GetAssetPath(PrefabUtility.GetCorrespondingObjectFromSource(rectTransforms[i].gameObject));
                    
                    PrefabUtility.UnpackPrefabInstance(prefab, PrefabUnpackMode.Completely, InteractionMode.UserAction);

                    Anchor(rectTransforms[i]);

                    PrefabUtility.SaveAsPrefabAssetAndConnect(prefab, prefabPath, InteractionMode.UserAction);
                }
                else
                    Anchor(rectTransforms[i]);
            }
        }
    }

    [MenuItem("Tools/Automatic UI Anchoring/Anchor Selected UI Objects")]
    private static void AnchorSelectedUIObjects()
    {
        for (int i = 0; i < Selection.gameObjects.Length; i++)
        {
            RectTransform rectTransform = Selection.gameObjects[i].GetComponent<RectTransform>();
            if (rectTransform)
                Anchor(rectTransform);
        }
    }

    [MenuItem("Tools/Automatic UI Anchoring/About")]
    private static void About()
    {
        string text = "Thank you for using the Automatic UI Anchoring extension for Unity created by AndrewCodes200!"
            + System.Environment.NewLine + System.Environment.NewLine +
            "I hope you found this tool useful and it saved you some time!"
            + System.Environment.NewLine + System.Environment.NewLine +
            "If it did and you would like to check out my other awesome side projects and stay up to date with any changes made to this plugin you can follow me on social media at:"
            + System.Environment.NewLine +
            "https://connect.unity.com/u/AndrewCodes200"
            + System.Environment.NewLine +
            "https://www.github.com/AndrewCodes200"
            + System.Environment.NewLine +
            "https://www.youtube.com/channel/UCpUT_Ek4tlp9cZvtH7g5j-g"
            + System.Environment.NewLine +
            "https://www.twitter.com/AndrewCodes200"
            + System.Environment.NewLine +
            "https://www.instagram.com/AndrewCodes200"
            + System.Environment.NewLine + System.Environment.NewLine +
            "Contact:"
             + System.Environment.NewLine +
            "Email: AndrewCodes200@pm.me";

        EditorUtility.DisplayDialog("About Automatic UI Anchoring", text, "Ok", string.Empty);
    }
}
