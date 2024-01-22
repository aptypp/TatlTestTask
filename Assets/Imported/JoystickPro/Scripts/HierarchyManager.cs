using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
namespace FormatGames.VirtualJoystick.Pro
{


    public class HierarchyManager
    {

#if UNITY_EDITOR

        public void CreateHierarrchy(Transform parent, Joystick joystick)
        {

            //------------------------------------- INSTANTIATE -----------------------------------------//

            GameObject Object_ = new GameObject();

            GameObject BodyInstance = GameObject.Instantiate(Object_, parent);
            GameObject BackGroundInstance = GameObject.Instantiate(Object_, BodyInstance.transform);
            GameObject HandleShadowInstance = GameObject.Instantiate(Object_, BodyInstance.transform);
            GameObject ComplementsInstance = GameObject.Instantiate(Object_, BodyInstance.transform);
            GameObject HandleInstance = GameObject.Instantiate(Object_, BodyInstance.transform);

            RectTransform BodyRect = BodyInstance.AddComponent<RectTransform>();
            RectTransform ComplementsRect = ComplementsInstance.AddComponent<RectTransform>();
            RectTransform BackGroundRect = BackGroundInstance.AddComponent<RectTransform>();
            RectTransform HandleShadowRect = HandleShadowInstance.AddComponent<RectTransform>();
            RectTransform HandleRect = HandleInstance.AddComponent<RectTransform>();

            Image BackGroundIMG = BackGroundInstance.AddComponent<Image>();
            Image HandleShadowIMG = HandleShadowInstance.AddComponent<Image>();
            Image HandleIMG = HandleInstance.AddComponent<Image>();

            BodyInstance.AddComponent<CanvasGroup>();


            BackGroundIMG.color = Color.white;
            BackGroundIMG.raycastTarget = false;

            HandleShadowIMG.color = Color.black;
            HandleShadowIMG.raycastTarget = false;

            HandleIMG.color = Color.white;
            HandleIMG.raycastTarget = false;


            BodyRect.gameObject.name = "Body";
            ComplementsRect.gameObject.name = "Complements";
            BackGroundRect.gameObject.name = "BackGround";
            HandleShadowRect.gameObject.name = "HandleShadow";
            HandleRect.gameObject.name = "Handle";

            joystick.JoystickCanvas = BodyInstance.GetComponent<CanvasGroup>();
            joystick.MainParent = parent.GetComponent<RectTransform>();
            joystick.Body = BodyRect;
            joystick.BackGround = BackGroundIMG;
            joystick.HandleShadow = HandleShadowIMG;
            joystick.Handle = HandleIMG;


            GameObject.DestroyImmediate(Object_);


            //------------------------------------- RESIZE -----------------------------------------//

            float JoystickSize = 400f;
            float HandleSize = 150f;
            float HandleShadowSize = 150f;

            /*Joystick*/

            BodyRect.sizeDelta = new Vector2(JoystickSize, JoystickSize);

            /*Complements*/

            ComplementsRect.offsetMin = new Vector2(0, 0);
            ComplementsRect.offsetMax = new Vector2(0, 0);
            ComplementsRect.anchorMin = new Vector2(0, 0);
            ComplementsRect.anchorMax = new Vector2(1, 1);

            /*BackGround*/

            BackGroundRect.offsetMin = new Vector2(0, 0);
            BackGroundRect.offsetMax = new Vector2(0, 0);
            BackGroundRect.anchorMin = new Vector2(0, 0);
            BackGroundRect.anchorMax = new Vector2(1, 1);

            /*Handle*/

            HandleShadowRect.sizeDelta = new Vector2(HandleShadowSize, HandleShadowSize);
            HandleRect.sizeDelta = new Vector2(HandleSize, HandleSize);


            foreach (var obj in AssetDatabase.LoadAllAssetsAtPath("Assets/JoystickPro/Sprites/DefaultBackground.png"))
            {
                if (obj is Sprite sprite)
                {
                    BackGroundIMG.sprite = obj as Sprite;
                }
            }

            foreach (var obj in AssetDatabase.LoadAllAssetsAtPath("Assets/JoystickPro/Sprites/DefaultHandle.png"))
            {
                if (obj is Sprite sprite)
                {
                    HandleShadowIMG.sprite = obj as Sprite;
                }
            }

            foreach (var obj in AssetDatabase.LoadAllAssetsAtPath("Assets/JoystickPro/Sprites/DefaultHandle.png"))
            {
                if (obj is Sprite sprite)
                {
                    HandleIMG.sprite = obj as Sprite;
                }
            }

            BodyInstance.hideFlags = HideFlags.HideInHierarchy;

            CreateArrow(ComplementsInstance, joystick);
        }

        public void CreateArrow(GameObject Complements, Joystick joystick)
        {
            GameObject Object_ = new GameObject();

            GameObject ArrowInstance = GameObject.Instantiate(Object_, Complements.transform);
            GameObject GraphicInstance = GameObject.Instantiate(Object_, ArrowInstance.transform);

            RectTransform ArrowRect = ArrowInstance.AddComponent<RectTransform>();
            RectTransform GraphicRect = GraphicInstance.AddComponent<RectTransform>();

            Image ArrowIMG = GraphicInstance.AddComponent<Image>();

            Arrow ArrowScript = ArrowInstance.AddComponent<Arrow>();

            foreach (var obj in AssetDatabase.LoadAllAssetsAtPath("Assets/JoystickPro/Sprites/Arrow.psd"))
            {
                if (obj is Sprite sprite)
                {
                    Sprite sp = obj as Sprite;
                    ArrowIMG.sprite = sp;
                    ArrowIMG.raycastTarget = false;
                }
            }

            ArrowRect.gameObject.name = "Arrow";
            GraphicRect.gameObject.name = "Render";

            ArrowRect.offsetMin = new Vector2(0, 0);
            ArrowRect.offsetMax = new Vector2(0, 0);
            ArrowRect.anchorMin = new Vector2(0, 0);
            ArrowRect.anchorMax = new Vector2(1, 1);

            GraphicRect.offsetMin = new Vector2(0, 0);
            GraphicRect.offsetMax = new Vector2(160, 0);
            GraphicRect.anchorMin = new Vector2(1, 0);
            GraphicRect.anchorMax = new Vector2(1, 1);


            joystick.arrow = ArrowScript;

            ArrowScript.joystick = joystick;
            ArrowScript.Render = ArrowIMG;

            GameObject.DestroyImmediate(Object_);

            CreateCross(Complements, joystick);
        }

        public void CreateCross(GameObject Complements, Joystick joystick)
        {
            GameObject Object_ = new GameObject();

            GameObject CrossInstance = GameObject.Instantiate(Object_, Complements.transform);

            GameObject Cross_UpInstance = GameObject.Instantiate(Object_, CrossInstance.transform);
            GameObject Cross_DownInstance = GameObject.Instantiate(Object_, CrossInstance.transform);
            GameObject Cross_LeftInstance = GameObject.Instantiate(Object_, CrossInstance.transform);
            GameObject Cross_RightInstance = GameObject.Instantiate(Object_, CrossInstance.transform);

            RectTransform CrossRect = CrossInstance.AddComponent<RectTransform>();
            RectTransform Cross_UpRect = Cross_UpInstance.AddComponent<RectTransform>();
            RectTransform Cross_DownRect = Cross_DownInstance.AddComponent<RectTransform>();
            RectTransform Cross_LeftRect = Cross_LeftInstance.AddComponent<RectTransform>();
            RectTransform Cross_RightRect = Cross_RightInstance.AddComponent<RectTransform>();

            Image Cross_UpIMG = Cross_UpInstance.AddComponent<Image>();
            Image Cross_DownIMG = Cross_DownInstance.AddComponent<Image>();
            Image Cross_LeftIMG = Cross_LeftInstance.AddComponent<Image>();
            Image Cross_RightIMG = Cross_RightInstance.AddComponent<Image>();

            Cross CrossScript = CrossInstance.AddComponent<Cross>();
            CrossScript.joystick = joystick;


            Cross_UpIMG.raycastTarget = false;
            Cross_DownIMG.raycastTarget = false;
            Cross_LeftIMG.raycastTarget = false;
            Cross_RightIMG.raycastTarget = false;

            CrossScript.Up = Cross_UpIMG;
            CrossScript.Down = Cross_DownIMG;
            CrossScript.Left = Cross_LeftIMG;
            CrossScript.Right = Cross_RightIMG;

            CrossRect.gameObject.name = "Cross";
            Cross_UpRect.gameObject.name = "Up";
            Cross_DownRect.gameObject.name = "Down";
            Cross_LeftRect.gameObject.name = "Left";
            Cross_RightRect.gameObject.name = "Right";

            CrossRect.offsetMin = new Vector2(0, 0);
            CrossRect.offsetMax = new Vector2(0, 0);
            CrossRect.anchorMin = new Vector2(0, 0);
            CrossRect.anchorMax = new Vector2(1, 1);

            joystick.cross = CrossScript;

            CrossInstance.gameObject.SetActive(false);

            GameObject.DestroyImmediate(Object_);

            CreateTail(Complements, joystick);
        }

        public void CreateTail(GameObject Complements, Joystick joystick)
        {
            GameObject Object_ = new GameObject();

            GameObject TrailInstance = GameObject.Instantiate(Object_, Complements.transform);
            GameObject TrailInside = GameObject.Instantiate(Object_, TrailInstance.transform);

            RectTransform TrailRect = TrailInstance.AddComponent<RectTransform>();
            RectTransform TrailInsideRect = TrailInside.AddComponent<RectTransform>();


            Image TrailInsideRectIMG = TrailInside.AddComponent<Image>();

            Tail TrailScript = TrailInstance.AddComponent<Tail>();

            TrailInsideRect.offsetMin = new Vector2(0, 0);
            TrailInsideRect.offsetMax = new Vector2(0, 0);
            TrailInsideRect.anchorMin = new Vector2(0, 0);
            TrailInsideRect.anchorMax = new Vector2(1, 1);

            TrailScript.joystick = joystick;
            TrailScript.Render = TrailInsideRectIMG;


            TrailRect.gameObject.name = "Tail";
            TrailInsideRect.gameObject.name = "Render";

            joystick.tail = TrailScript;

            TrailInstance.gameObject.SetActive(false);

            GameObject.DestroyImmediate(Object_);

        }

#endif

        public float LocalOffsetToWorldPosition(RectTransform target, string Axis, string factor,float offset)
        {
            float Handle_Offset_x;
            Vector3 Handle_Offset = new Vector3(0,0,0);

            switch (Axis)
            {
                case "x":
                

                    if (factor == "-")
                    {
                        Handle_Offset_x = target.localPosition.x - offset;
                    }
                    else
                    {
                        Handle_Offset_x = target.localPosition.x + offset;
                    }

                    Handle_Offset = new Vector3(Handle_Offset_x, 0, 0);

                    break;

                case "y":

                    if (factor == "-")
                    {
                        Handle_Offset_x = target.localPosition.y - offset;
                    }
                    else
                    {
                        Handle_Offset_x = target.localPosition.y + offset;
                    }

                    Handle_Offset = new Vector3(0, Handle_Offset_x, 0);

                    break;

                case "z":

                    if (factor == "-")
                    {
                        Handle_Offset_x = target.localPosition.z - offset;
                    }
                    else
                    {
                        Handle_Offset_x = target.localPosition.z + offset;
                    }

                    Handle_Offset = new Vector3(0, 0, Handle_Offset_x);

                    break;
            }

            Vector3 Handle_Offset_World = target.transform.TransformPoint(Handle_Offset);


            return Vector3.Distance(target.transform.position, Handle_Offset_World);

            
        }
    }

}
