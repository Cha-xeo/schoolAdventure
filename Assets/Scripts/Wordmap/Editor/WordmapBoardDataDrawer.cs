using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(WordmapBoardData), false)]
[CanEditMultipleObjects]
[System.Serializable]
public class WordmapBoardDataDrawer : Editor
{
    private WordmapBoardData GameDataInstance => target as WordmapBoardData;
    private ReorderableList _dataList;

    private void OnEnable()
    {
        InitializedReorderableList(ref _dataList, "SearchWords", "Find Words");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GameDataInstance.timeInSeconds = EditorGUILayout.FloatField("Max Game Time in Secondes", GameDataInstance.timeInSeconds);

        DrawColumnsRows();
        EditorGUILayout.Space();
        ConvertToUpperButton();

        if (GameDataInstance.Board != null && GameDataInstance.Columns > 0 && GameDataInstance.Rows > 0) {
            DrawBoardTable();
        }

        GUILayout.BeginHorizontal();
        ClearBoardButton();
        RandomLettersButton();
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();
        _dataList.DoLayoutList();
        

        serializedObject.ApplyModifiedProperties();
        if (GUI.changed) {
            EditorUtility.SetDirty(GameDataInstance);
        }
    }

    private void DrawColumnsRows()
    {
        var columnsTemp = GameDataInstance.Columns;
        var rowsTemp = GameDataInstance.Rows;

        GameDataInstance.Columns = EditorGUILayout.IntField("Columns", GameDataInstance.Columns);
        GameDataInstance.Rows = EditorGUILayout.IntField("Rows", GameDataInstance.Rows);

        if ((GameDataInstance.Columns != columnsTemp || GameDataInstance.Rows != rowsTemp) && GameDataInstance.Columns > 0 && GameDataInstance.Rows > 0) {
            GameDataInstance.CreateNewBoard();
        }
    }

    private void DrawBoardTable()
    {
        var tableStyle = new GUIStyle("box");
        var headerColumnStyle = new GUIStyle();
        var columnsStyle = new GUIStyle();
        var rowsStyle = new GUIStyle();

        tableStyle.padding = new RectOffset(10, 10, 10, 10);
        tableStyle.margin.left = 32;
        headerColumnStyle.fixedWidth = 35;
        columnsStyle.fixedWidth = 50;
        rowsStyle.fixedHeight = 25;
        rowsStyle.fixedWidth = 40;
        rowsStyle.alignment = TextAnchor.MiddleCenter;

        var textFieldsStyle = new GUIStyle();

        textFieldsStyle.normal.background = Texture2D.grayTexture;
        textFieldsStyle.normal.textColor = Color.white;
        textFieldsStyle.fontStyle = FontStyle.Bold;
        textFieldsStyle.alignment = TextAnchor.MiddleCenter;

        EditorGUILayout.BeginHorizontal(tableStyle);
        for (var x = 0; x < GameDataInstance.Columns; x++) {
            EditorGUILayout.BeginVertical(x == -1 ? headerColumnStyle : columnsStyle);
            for (var y = 0; y < GameDataInstance.Rows; y++) {
                if (x >= 0 && y >= 0) {
                    EditorGUILayout.BeginHorizontal(rowsStyle);
                    var character = (string) EditorGUILayout.TextArea(GameDataInstance.Board[x].Row[y], textFieldsStyle);
                    if (GameDataInstance.Board[x].Row[y].Length > 1) {
                        character = GameDataInstance.Board[x].Row[y].Substring(0, 1);
                    }
                    GameDataInstance.Board[x].Row[y] = character;
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void InitializedReorderableList(ref ReorderableList list, string propertyName, string listLabel)
    {
        list = new ReorderableList(serializedObject, serializedObject.FindProperty(propertyName), true, true, true, true);
        list.drawHeaderCallback = (Rect rect) => 
        {
            EditorGUI.LabelField(rect, listLabel);
        };
        
        var l = list;

        list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused ) =>
        {
            var element = l.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2;

            EditorGUI.PropertyField(new Rect(rect.x, rect.y, EditorGUIUtility.labelWidth, EditorGUIUtility.singleLineHeight), element.FindPropertyRelative("Word"), GUIContent.none);
        };
    }

    private void ConvertToUpperButton()
    {
        if (GUILayout.Button("To Upper")) {
            for (var i = 0; i < GameDataInstance.Columns; i++) {
                for (var j = 0; j < GameDataInstance.Rows; j++) {
                    var errorCounter = Regex.Matches(GameDataInstance.Board[i].Row[j], @"[a-z]").Count;

                    if (errorCounter > 0) {
                        GameDataInstance.Board[i].Row[j] = GameDataInstance.Board[i].Row[j].ToUpper();
                    }
                }
            }

            foreach (var searchWord in GameDataInstance.SearchWords) {
                var errorCounter = Regex.Matches(searchWord.Word, @"[a-z]").Count;

                if (errorCounter > 0) {
                    searchWord.Word = searchWord.Word.ToUpper();
                }
            }
        }
    }

    private void ClearBoardButton()
    {
        if (GUILayout.Button("Clear Board")) {
            for (int i = 0; i < GameDataInstance.Columns; i++) {
                for (int j = 0; j < GameDataInstance.Rows; j++) {
                    GameDataInstance.Board[i].Row[j] = " ";
                }
            }
        }
    }
    
    private void RandomLettersButton()
    {
        string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (GUILayout.Button("Fill up random letters")) {
            for (int i = 0; i < GameDataInstance.Columns; i++) {
                for (int j = 0; j < GameDataInstance.Rows; j++) {
                    int errorCounter = Regex.Matches(GameDataInstance.Board[i].Row[j], @"[a-zA-Z]").Count;
                    int index = UnityEngine.Random.Range(0, letters.Length);
                    if (errorCounter == 0) {
                        GameDataInstance.Board[i].Row[j] = letters[index].ToString();
                    }
                }
            } 
        }
    }
}
