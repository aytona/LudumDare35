using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Aytona.Editor.UI
{
    public class UITextChanger : EditorWindow
    {
        // A class that stores the object that has text coupled with a bool
        public class UITextElement
        {
            public Text LabelObj { get; set; }
            public bool changeWanted { get; set; }
        }

        private Font newFont;                                               // The new font that will be changed to
        private List<UITextElement> textList = new List<UITextElement>();   // A list that stores certain data
        private Vector2 scrollPos;                                          // Scroll bar vector2

        [MenuItem("Tools/Custom/UI Text Changer", false, 1)]
        public static void OpenLevelEditorWindow()
        {
            GetWindow<UITextChanger>(true, "UI Text Changer");
        }

        private void OnGUI()
        {
            // Scrollbar
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, false, true);

            // Only finds active objects that contains text
            Text[] sceneTexts = FindObjectsOfType(typeof(Text)) as Text[];

            // Goes through array to add to list
            if (GUILayout.Button("Find all label objects"))
            {
                textList = new List<UITextElement>();
                foreach (Text textScript in sceneTexts)
                {
                    textList.Add(new UITextElement() { LabelObj = textScript, changeWanted = false });
                }
            }

            // New font row
            EditorGUILayout.BeginHorizontal(GUILayout.MaxWidth(300));
            GUILayout.Label("New font", GUILayout.ExpandWidth(false));
            newFont = EditorGUILayout.ObjectField(newFont, typeof(Font), false) as Font;

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("Title", GUILayout.MinWidth(115));
            GUILayout.Label("Text", GUILayout.MinWidth(115));
            GUILayout.Label("Font change", GUILayout.MaxWidth(100));
            GUILayout.Label("Color", GUILayout.MaxWidth(115));
            EditorGUILayout.EndHorizontal();

            foreach (UITextElement textObjects in textList)
            {
                EditorGUILayout.BeginHorizontal();
                textObjects.LabelObj.name = EditorGUILayout.TextField(textObjects.LabelObj.name, GUILayout.MinWidth(100));
                textObjects.LabelObj.text = EditorGUILayout.TextField(textObjects.LabelObj.text, GUILayout.MinWidth(100));
                textObjects.changeWanted = EditorGUILayout.Toggle(textObjects.changeWanted);
                textObjects.LabelObj.color = EditorGUILayout.ColorField(textObjects.LabelObj.color, GUILayout.MinWidth(30));
                EditorGUILayout.EndHorizontal();
            }

            // Button prompt to change fonts
            if (GUILayout.Button("Change Fonts"))
            {
                if (textList == null || textList.Count <= 0)
                {
                    ShowNotification(new GUIContent("No fonts to change"));
                    return;
                }
                if (newFont == null)
                {
                    ShowNotification(new GUIContent("Need new font"));
                    return;
                }

                ChangeLabels();
            }
            EditorGUILayout.EndScrollView();
        }

        private void ChangeLabels()
        {
            // A loop that just goes through the list of texts and changes the fonts of them
            for (int index = 0; index < textList.Count; index++)
            {
                if (textList[index].changeWanted)
                {
                    textList[index].LabelObj.font = newFont;
                }
            }
            ShowNotification(new GUIContent("Labels changed!"));
        }
    }
}