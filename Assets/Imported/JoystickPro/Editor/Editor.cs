using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Events;

namespace FormatGames.VirtualJoystick.Pro
{

#if UNITY_EDITOR

    [CustomEditor(typeof(Joystick))]
    public class Editor : UnityEditor.Editor
    {
        #region VARIABLES

        public GUIStyle FoldoutStyle;

        #endregion

        #region TOOLBARS

        public void JoystickBar(Joystick virtualJoystick, string label, bool Bottom)
        {
            Color Background = new Color32(48, 48, 48, 200);
            Color Line = new Color32(0, 0, 0, 100);
            float ElemtnsSpace = 0;
            float BackGroundSize = 30;
            float DefaultTopSpace = 6;

            //-------------------- BACKGROUND ---------------------//

            Rect LineRect_top = EditorGUILayout.GetControlRect(false, 0);
            EditorGUI.DrawRect(new Rect(0, LineRect_top.y - 5, EditorGUIUtility.currentViewWidth, 0.5f), Line); // line

            Rect BackgroundRect = EditorGUILayout.GetControlRect(false, 1);
            EditorGUI.DrawRect(new Rect(0, BackgroundRect.y - DefaultTopSpace, EditorGUIUtility.currentViewWidth, BackGroundSize), Background); // Background



            GUILayout.Space(-8 + (BackGroundSize / DefaultTopSpace)); EditorGUILayout.BeginHorizontal(GUILayout.Width(20)); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace + 2);



            //-------------------- FOULD OUT ---------------------//


            virtualJoystick.Unfold = EditorGUILayout.BeginFoldoutHeaderGroup(virtualJoystick.Unfold, GUIContent.none, FoldoutStyle);
            EditorGUILayout.EndFoldoutHeaderGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace);



            //-------------------- TOGGLE ---------------------//

            virtualJoystick.Enable = EditorGUILayout.BeginToggleGroup("  " + label, virtualJoystick.Enable);
            EditorGUILayout.EndToggleGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.EndHorizontal();

            if (Bottom)
            {
                GUILayout.Space(-2);
            }
            else
            {
                GUILayout.Space(8);
            }
        }

        public void Arrow(Joystick virtualJoystick, string label, bool Bottom)
        {
            Color Background = new Color32(62, 62, 62, 255);
            Color Line = new Color32(0, 0, 0, 100);
            float ElemtnsSpace = 0;
            float BackGroundSize = 30;
            float DefaultTopSpace = 6;

            //-------------------- BACKGROUND ---------------------//

            Rect LineRect_top = EditorGUILayout.GetControlRect(false, 0);
            EditorGUI.DrawRect(new Rect(0, LineRect_top.y - 5, EditorGUIUtility.currentViewWidth, 0.5f), Line); // line

            Rect BackgroundRect = EditorGUILayout.GetControlRect(false, 1);
            EditorGUI.DrawRect(new Rect(0, BackgroundRect.y - DefaultTopSpace, EditorGUIUtility.currentViewWidth, BackGroundSize), Background); // Background



            GUILayout.Space(-8 + (BackGroundSize / DefaultTopSpace)); EditorGUILayout.BeginHorizontal(GUILayout.Width(20)); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace + 2);



            //-------------------- FOULD OUT ---------------------//


            virtualJoystick.arrow.Unfold = EditorGUILayout.BeginFoldoutHeaderGroup(virtualJoystick.arrow.Unfold, GUIContent.none, FoldoutStyle);
            EditorGUILayout.EndFoldoutHeaderGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace);



            //-------------------- TOGGLE ---------------------//

            virtualJoystick.arrow.Enable = EditorGUILayout.BeginToggleGroup("  " + label, virtualJoystick.arrow.Enable);
            EditorGUILayout.EndToggleGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.EndHorizontal();

            if (Bottom)
            {
                GUILayout.Space(-2);
            }
            else
            {
                GUILayout.Space(8);
            }
        }

        public void Cross(Joystick virtualJoystick, string label, bool Bottom)
        {

            Color Background = new Color32(62, 62, 62, 255);
            Color Line = new Color32(0, 0, 0, 100);
            float ElemtnsSpace = 0;
            float BackGroundSize = 30;
            float DefaultTopSpace = 6;

            //-------------------- BACKGROUND ---------------------//

            Rect LineRect_top = EditorGUILayout.GetControlRect(false, 0);
            EditorGUI.DrawRect(new Rect(0, LineRect_top.y - 5, EditorGUIUtility.currentViewWidth, 0.5f), Line); // line

            Rect BackgroundRect = EditorGUILayout.GetControlRect(false, 1);
            EditorGUI.DrawRect(new Rect(0, BackgroundRect.y - DefaultTopSpace, EditorGUIUtility.currentViewWidth, BackGroundSize), Background); // Background



            GUILayout.Space(-8 + (BackGroundSize / DefaultTopSpace)); EditorGUILayout.BeginHorizontal(GUILayout.Width(20)); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace + 2);



            //-------------------- FOULD OUT ---------------------//


            virtualJoystick.cross.Unfold = EditorGUILayout.BeginFoldoutHeaderGroup(virtualJoystick.cross.Unfold, GUIContent.none, FoldoutStyle);
            EditorGUILayout.EndFoldoutHeaderGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace);



            //-------------------- TOGGLE ---------------------//

            virtualJoystick.cross.Enable = EditorGUILayout.BeginToggleGroup("  " + label, virtualJoystick.cross.Enable);
            EditorGUILayout.EndToggleGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.EndHorizontal();

            if (Bottom)
            {
                GUILayout.Space(-2);
            }
            else
            {
                GUILayout.Space(8);
            }
        }

        public void Trail(Joystick virtualJoystick, string label, bool Bottom)
        {

            Color Background = new Color32(62, 62, 62, 255);
            Color Line = new Color32(0, 0, 0, 100);
            float ElemtnsSpace = 0;
            float BackGroundSize = 30;
            float DefaultTopSpace = 6;

            //-------------------- BACKGROUND ---------------------//

            Rect LineRect_top = EditorGUILayout.GetControlRect(false, 0);
            EditorGUI.DrawRect(new Rect(0, LineRect_top.y - 5, EditorGUIUtility.currentViewWidth, 0.5f), Line); // line

            Rect BackgroundRect = EditorGUILayout.GetControlRect(false, 1);
            EditorGUI.DrawRect(new Rect(0, BackgroundRect.y - DefaultTopSpace, EditorGUIUtility.currentViewWidth, BackGroundSize), Background); // Background



            GUILayout.Space(-8 + (BackGroundSize / DefaultTopSpace)); EditorGUILayout.BeginHorizontal(GUILayout.Width(20)); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace + 2);



            //-------------------- FOULD OUT ---------------------//


            virtualJoystick.tail.Unfold = EditorGUILayout.BeginFoldoutHeaderGroup(virtualJoystick.tail.Unfold, GUIContent.none, FoldoutStyle);
            EditorGUILayout.EndFoldoutHeaderGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.BeginVertical(); GUILayout.Space(ElemtnsSpace);



            //-------------------- TOGGLE ---------------------//

            virtualJoystick.tail.Enable = EditorGUILayout.BeginToggleGroup("  " + label, virtualJoystick.tail.Enable);
            EditorGUILayout.EndToggleGroup();



            EditorGUILayout.EndVertical(); EditorGUILayout.EndHorizontal();

            if (Bottom)
            {
                GUILayout.Space(-2);
            }
            else
            {
                GUILayout.Space(8);
            }
        }

        #endregion

        #region OTHERS
        void OnDestroy()
        {

#if UNITY_EDITOR

            Joystick virtualJoystick = (target) as Joystick;

            if (!UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                if (Time.frameCount != 0 && Time.renderedFrameCount != 0)//not loading scene
                {
                    if (!virtualJoystick)
                    {
                        DestroyImmediate(virtualJoystick.Body.gameObject);
                    }
                }
            }          
 #endif
        }

        void OnEnable()
        {
            if (FoldoutStyle == null)
            {
                FoldoutStyle = new GUIStyle(EditorStyles.foldout);

                FoldoutStyle.fixedHeight = 0;
                FoldoutStyle.fixedWidth = 1;
            }
        }

        #endregion

        void OnSceneGUI()
        {
            if(Application.isPlaying) { return; }


            Joystick virtualJoystick = (target) as Joystick;

            HierarchyManager hierarchy = new HierarchyManager();

            float Handle_Ratio = hierarchy.LocalOffsetToWorldPosition(virtualJoystick.Handle.rectTransform,"x", "-", (virtualJoystick.Ratio / 2));
            float Handle_Size_Clamp = hierarchy.LocalOffsetToWorldPosition(virtualJoystick.Handle.rectTransform,"x", "-", (virtualJoystick.Handle.rectTransform.sizeDelta.x / 2));


            // indicates the handle position will be clamped in the middle of red circle line
            Handles.color = Color.red;
            //Handles.DrawWireDisc(virtualJoystick.Body.transform.position, Vector3.forward, virtualJoystick.Ratio);

            Handles.DrawWireDisc(virtualJoystick.Body.transform.position, Vector3.forward, Handle_Ratio);

            // indicates the handle position will beclamped inside white circle bounds
            Handles.color = Color.white;
            Handles.DrawWireDisc(virtualJoystick.Body.transform.position, Vector3.forward, Handle_Ratio + Handle_Size_Clamp);


            // DEAD ZONE : indicates joystick will return the axis once the handle position overpass the blue circle
            Handles.color = Color.blue;
            Handles.DrawWireDisc(virtualJoystick.Body.transform.position, Vector3.forward, Handle_Ratio * virtualJoystick.DeadZone / 100);
        }

        public override void OnInspectorGUI()
        {
            Joystick virtualJoystick = (target) as Joystick;

            if (virtualJoystick.ShowInspector)
            {
                GUILayout.Space(14);
                DrawDefaultInspector();
                GUILayout.Space(14);
            }
  
            JoystickBar(virtualJoystick, "Joystick", false);

            if (virtualJoystick.Unfold)
            {
                GUILayout.Space(8);
                EditorGUILayout.LabelField("Types");
                GUILayout.Space(8);

                EditorGUILayout.PropertyField(serializedObject.FindProperty("axisType"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("joystickType"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("transitionType"));


                // CONFIGURATION


                GUILayout.Space(8);EditorGUILayout.LabelField("Configuration", EditorStyles.boldLabel);GUILayout.Space(8);

                virtualJoystick.Ratio = (float)EditorGUILayout.Slider("Ratio", virtualJoystick.Ratio, 0, virtualJoystick.JoystickSize * 2);
                virtualJoystick.DeadZone = (float)EditorGUILayout.Slider("DeadZone", virtualJoystick.DeadZone, 1, 100);
               
                virtualJoystick.JoystickSize = (float)EditorGUILayout.Slider("Joystick Size", virtualJoystick.JoystickSize, 10, 900);
                virtualJoystick.BackgroundAlpha = (float)EditorGUILayout.Slider("Background Alpha", virtualJoystick.BackgroundAlpha, 0, 100);
                virtualJoystick.HandleShadowSize = (float)EditorGUILayout.Slider("Handle Shadow Size", virtualJoystick.HandleShadowSize, 10, 400);
                virtualJoystick.HandleShadowAlpha = (float)EditorGUILayout.Slider("Handle Shadow Alpha", virtualJoystick.HandleShadowAlpha, 0, 100);
                virtualJoystick.HandleSize = (float)EditorGUILayout.Slider("Handle Size", virtualJoystick.HandleSize, 10, 400);
                virtualJoystick.HandleAlpha = (float)EditorGUILayout.Slider("Handle Alpha", virtualJoystick.HandleAlpha, 0, 100);

                GUILayout.Space(8);


                // CONDITIONS

                GUILayout.Space(8); EditorGUILayout.LabelField("Conditions", EditorStyles.boldLabel); GUILayout.Space(8);

                EditorGUILayout.PropertyField(serializedObject.FindProperty("AnimatedMode"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("ShowInspector"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("OnReleaseAxis"));

                if (virtualJoystick.AnimatedMode)
                {
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("RotateBackground"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("RotateHandle"));
                }


                // ADVANZED


                if(virtualJoystick.transitionType != Joystick.TransitionType.Default || virtualJoystick.AnimatedMode)
                {   
                    GUILayout.Space(8);EditorGUILayout.LabelField("Advanzed", EditorStyles.boldLabel);GUILayout.Space(8);
                }
                if (virtualJoystick.transitionType != Joystick.TransitionType.Default)
                {
                    virtualJoystick.MinimumHighlight = (float)EditorGUILayout.Slider("Minimum Highlight", virtualJoystick.MinimumHighlight, 1, 100);
                    virtualJoystick.MaximumHighlight = (float)EditorGUILayout.Slider("Maximum Highlight", virtualJoystick.MaximumHighlight, 1, 100);
                }
                if (virtualJoystick.AnimatedMode)
                {
                    virtualJoystick.ResetHandleSpeed = (float)EditorGUILayout.Slider("Reset Handle Speed", virtualJoystick.ResetHandleSpeed, 1, 20);
                }


                // REFRENCES


                GUILayout.Space(8);EditorGUILayout.LabelField("References", EditorStyles.boldLabel); GUILayout.Space(8);


                EditorGUILayout.PropertyField(serializedObject.FindProperty("TouchArea"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("Debbuger"));


                // APPEARANCE

                GUILayout.Space(8);EditorGUILayout.LabelField("Appearance", EditorStyles.boldLabel);GUILayout.Space(8);

                virtualJoystick.BackGround.sprite = (Sprite)EditorGUILayout.ObjectField("BackGround", virtualJoystick.BackGround.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                virtualJoystick.HandleShadow.sprite = (Sprite)EditorGUILayout.ObjectField("Handle Shadow", virtualJoystick.HandleShadow.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                virtualJoystick.Handle.sprite = (Sprite)EditorGUILayout.ObjectField("Handle", virtualJoystick.Handle.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));

                virtualJoystick.BackGround.color = EditorGUILayout.ColorField("BackGround", virtualJoystick.BackGround.color);
                virtualJoystick.HandleShadow.color = EditorGUILayout.ColorField("Handle Shadow", virtualJoystick.HandleShadow.color);
                virtualJoystick.Handle.color = EditorGUILayout.ColorField("Handle", virtualJoystick.Handle.color);


                // CUSTOM EVENTS

                if (virtualJoystick.joystickType == Joystick.JoystickType.Custom)
                {
                    GUILayout.Space(8);
                    EditorGUILayout.LabelField("Events", EditorStyles.boldLabel);
                    GUILayout.Space(8);

                    EditorGUILayout.PropertyField(serializedObject.FindProperty("onTouch"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("onRealase"));
                }

                GUILayout.Space(14);
            }

            Arrow(virtualJoystick, "Arrow", false);

            if (virtualJoystick.arrow.Unfold)
            {
                GUILayout.Space(7);

                virtualJoystick.arrow.Width = (float)EditorGUILayout.Slider("Width", virtualJoystick.arrow.Width, 0, 500);
                virtualJoystick.arrow.Height = (float)EditorGUILayout.Slider("Height", virtualJoystick.arrow.Height, 0, 500);
                virtualJoystick.arrow.Spacing = (float)EditorGUILayout.Slider("Arrow Spacing", virtualJoystick.arrow.Spacing, -virtualJoystick.JoystickSize / 2, virtualJoystick.JoystickSize / 2);

                virtualJoystick.arrow.Alpha = (float)EditorGUILayout.Slider("Alpha", virtualJoystick.arrow.Alpha, 0, 100);
                virtualJoystick.arrow.color = EditorGUILayout.ColorField("Color", virtualJoystick.arrow.color);
                virtualJoystick.arrow.Render.sprite = (Sprite)EditorGUILayout.ObjectField("Sprite", virtualJoystick.arrow.Render.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));

                GUILayout.Space(7);

                virtualJoystick.arrow.preserveAspect = EditorGUILayout.Toggle("Preserv Aspect", virtualJoystick.arrow.preserveAspect);

                GUILayout.Space(14);

            }

            Cross(virtualJoystick, "Cross", false);

            if (virtualJoystick.cross.Unfold)
            {
                GUILayout.Space(14);

                virtualJoystick.cross.Size = (float)EditorGUILayout.Slider("Size", virtualJoystick.cross.Size, 0, 5);
                virtualJoystick.cross.Position = (float)EditorGUILayout.Slider("Space", virtualJoystick.cross.Position, 10, virtualJoystick.JoystickSize);
                virtualJoystick.cross.Alpha = (float)EditorGUILayout.Slider("Alpha", virtualJoystick.cross.Alpha, 0, 100);

                GUILayout.Space(7);

                virtualJoystick.cross.Up.sprite = (Sprite)EditorGUILayout.ObjectField("Up", virtualJoystick.cross.Up.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                virtualJoystick.cross.Down.sprite = (Sprite)EditorGUILayout.ObjectField("Down", virtualJoystick.cross.Down.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                virtualJoystick.cross.Left.sprite = (Sprite)EditorGUILayout.ObjectField("Left", virtualJoystick.cross.Left.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));
                virtualJoystick.cross.Right.sprite = (Sprite)EditorGUILayout.ObjectField("Right", virtualJoystick.cross.Right.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));

                GUILayout.Space(7);

                virtualJoystick.cross.Disabled = EditorGUILayout.ColorField("Disabled", virtualJoystick.cross.Disabled);
                virtualJoystick.cross.Selected = EditorGUILayout.ColorField("Selected", virtualJoystick.cross.Selected);

                GUILayout.Space(7);

                virtualJoystick.cross.PreserveAspect = EditorGUILayout.Toggle("Preserve Aspect", virtualJoystick.cross.PreserveAspect);

                GUILayout.Space(14);

            }

            Trail(virtualJoystick, "Tail", true);

            if (virtualJoystick.tail.Unfold)
            {
                GUILayout.Space(14);

                virtualJoystick.tail.Size = (float)EditorGUILayout.Slider("Size", virtualJoystick.tail.Size, 5, 400);
                virtualJoystick.tail.Alpha = (float)EditorGUILayout.Slider("Alpha", virtualJoystick.tail.Alpha, 0, 100);
                virtualJoystick.tail.color = EditorGUILayout.ColorField("Color", virtualJoystick.tail.color);
                virtualJoystick.tail.Render.sprite = (Sprite)EditorGUILayout.ObjectField("Render", virtualJoystick.tail.Render.sprite, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight));

                GUILayout.Space(7);

                virtualJoystick.tail.ShowOnEdit = EditorGUILayout.Toggle("Show On Edit", virtualJoystick.tail.ShowOnEdit);

                GUILayout.Space(7);

            }

            if (GUI.changed)
            {
                if (virtualJoystick.Enable)
                {
                    virtualJoystick.Body.hideFlags = HideFlags.None;
                }
                else
                {
                    virtualJoystick.Body.hideFlags = HideFlags.HideInHierarchy;
                }

                if (virtualJoystick.arrow.Enable)
                {
                    virtualJoystick.arrow.gameObject.SetActive(true);
                }
                else
                {
                    virtualJoystick.arrow.gameObject.SetActive(false);
                }

                if (virtualJoystick.cross.Enable)
                {
                    virtualJoystick.cross.gameObject.SetActive(true);
                }
                else
                {
                    virtualJoystick.cross.gameObject.SetActive(false);
                }

                if (virtualJoystick.tail.Enable)
                {
                    virtualJoystick.tail.gameObject.SetActive(true);
                }
                else
                {
                    virtualJoystick.tail.gameObject.SetActive(false);
                }

                virtualJoystick.UpdateConfig();
                virtualJoystick.arrow.UpdateConfig();
                virtualJoystick.cross.UpdateConfig();
                virtualJoystick.tail.UpdateConfig();

                EditorUtility.SetDirty(virtualJoystick);
                serializedObject.ApplyModifiedProperties();
            }
        }

    }
   
#endif
}
