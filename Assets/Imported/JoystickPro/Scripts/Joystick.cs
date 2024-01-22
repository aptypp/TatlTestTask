using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FormatGames.VirtualJoystick.Pro
{
    [AddComponentMenu("UI/Joystick")]
    public class Joystick : MonoBehaviour
    {
        #region VARIABLES

        #region PUBLIC

        [Serializable]
        public class OnTouch : UnityEvent
        {
        }

        [HideInInspector]
        public OnTouch onTouch = new OnTouch();

        [Serializable]
        public class OnRealase : UnityEvent
        {
        }

        [HideInInspector]
        public OnRealase onRealase = new OnRealase();


        [Serializable]
        public enum AxisType
        {
            Angle,
            Cross
        };

        [HideInInspector]
        public AxisType axisType;

        [Serializable]
        public enum JoystickType
        {
            Default,
            Custom
        };

        [HideInInspector]
        public JoystickType joystickType;

        [Serializable]
        public enum TransitionType
        {
            Default,
            ShowOnTouch,
            HighlightOnTouch
        };

        [HideInInspector]
        public TransitionType transitionType;

        [SerializeField, HideInInspector]
        public float JoystickSize = 180f;

        [SerializeField, HideInInspector]
        public float HandleShadowSize = 100f;

        [SerializeField, HideInInspector]
        public float HandleSize = 80f;

        [SerializeField, HideInInspector]
        public float BackgroundAlpha = 17f;

        [SerializeField, HideInInspector]
        public float HandleShadowAlpha = 100f;

        [SerializeField, HideInInspector]
        public float HandleAlpha = 100f;

        [SerializeField, HideInInspector]
        public float Ratio = 100f;

        [SerializeField, HideInInspector]
        public float DeadZone = 90f;

        [SerializeField, HideInInspector]
        public float ResetHandleSpeed = 90f;

        [SerializeField, HideInInspector]
        public float MinimumHighlight = 50;

        [SerializeField, HideInInspector]
        public float MaximumHighlight = 100;

        [SerializeField, HideInInspector]
        public bool ShowOnTouch;

        [SerializeField, HideInInspector]
        public bool HighLightOnTouch;

        [SerializeField, HideInInspector]
        public bool OnReleaseAxis;

        [SerializeField, HideInInspector]
        public bool RunOnDesktop;

        [SerializeField, HideInInspector]
        public bool ShowCursor;

        [SerializeField, HideInInspector]
        public bool AnimatedMode;

        [SerializeField, HideInInspector]
        public bool RotateBackground;

        [SerializeField, HideInInspector]
        public bool RotateHandle;

        #endregion

        #region READONLY

        public enum Direction
        {
            None,
            Up,
            Down,
            Right,
            Left
        }

        [HideInInspector]
        public Direction DIRECTION;

        private int FINGERID = -1;
        public bool IS_USING;
        public bool IS_OUT_OF_DEADZONE;
        private bool IS_UPDATE = false;
        private bool IS_LATEUPDATE = false;
        private bool TOUCH_DETECTED;


        // ------------------- DEFAULT VAIRABLES ----------------//

        private float DEADZONE_ON_START;
        private float RATIO_ON_START;
        private float HANDLE_SIZE_ON_START;
        private float HANDLESHADOW_SIZE_ON_START;
        private float BACKGROUND_SIZE_ON_START;
        private float HANDLE_ALPHA_ON_STAR;
        private float BACKGROUND_ALPHA_ON_START;

        private Sprite HANDLE_SPRITE_ON_START;
        private Sprite HANDLESHADOW_SPRITE_ON_START;
        private Sprite BACKGROUND_SPRITE_ON_START;

        private Color HANDLE_COLOR_ON_START;
        private Color HANDLESHADOW_COLOR_ON_START;
        private Color BACKGROUND_COLOR_ON_START;

        private Vector2 JOYSTICK_DEFAULT_POSITION;
        private Vector2 TOUCH_POSITION;

        [HideInInspector]
        public Vector2 AXIS;

        [HideInInspector]
        public Vector2 ONREALESE_AXIS;

        [HideInInspector]
        public float ANGLE;

        #endregion


        #region REFERENCES

        [SerializeField, HideInInspector]
        public Joystick virtualJoystick;

        [SerializeField, HideInInspector]
        public CanvasGroup JoystickCanvas;

        [SerializeField, HideInInspector]
        public RectTransform MainParent;

        [SerializeField, HideInInspector]
        public RectTransform Body;

        [SerializeField, HideInInspector]
        public RectTransform TouchArea;

        [SerializeField, HideInInspector]
        public Image BackGround;

        [SerializeField, HideInInspector]
        public Image HandleShadow;

        [SerializeField, HideInInspector]
        public Image Handle;

        [SerializeField, HideInInspector]
        public Arrow arrow;

        [SerializeField, HideInInspector]
        public Cross cross;

        [SerializeField, HideInInspector]
        public Tail tail;

        [SerializeField, HideInInspector]
        public float calls;

        [SerializeField, HideInInspector]
        public Text Debbuger;

        #endregion

        #region CUSTOM EDITOR

        [HideInInspector]
        public bool Unfold;

        [HideInInspector]
        public bool Enable;

        [SerializeField, HideInInspector]
        public bool ShowInspector;

        #endregion

        #endregion


        #region FUNCTIONS

        void Awake()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                RunOnDesktop = false;

                return;
            }

            RunOnDesktop = true;
        }

        void Reset()
        {
#if UNITY_EDITOR
            if (gameObject.GetComponent<Joystick>() != this)
            {
                GameObject.DestroyImmediate(this);
                return;
            }

            if (gameObject.transform.childCount > 0)
            {
                foreach (Transform go in transform)
                {
                    if (go.name == "Body")
                    {
                        GameObject.DestroyImmediate(go.gameObject);

                        HierarchyManager hierarchy = new HierarchyManager();
                        hierarchy.CreateHierarrchy(this.transform, this);
                        UpdateConfig();
                    }
                }
            }

            else
            {
                HierarchyManager hierarchy = new HierarchyManager();
                hierarchy.CreateHierarrchy(this.transform, this);
                UpdateConfig();
            }
#endif
        }

        void Start()
        {
            Ratio = Ratio / 2;
            RATIO_ON_START = Ratio;
            DEADZONE_ON_START = Ratio * DeadZone / 100;

            HANDLE_SIZE_ON_START = HandleSize;
            BACKGROUND_SIZE_ON_START = JoystickSize;
            BACKGROUND_ALPHA_ON_START = BackgroundAlpha;
            HANDLE_ALPHA_ON_STAR = HandleAlpha;

            HANDLE_SPRITE_ON_START = Handle.sprite;
            BACKGROUND_SPRITE_ON_START = BackGround.sprite;

            HANDLE_COLOR_ON_START = Handle.color;
            BACKGROUND_COLOR_ON_START = BackGround.color;

            JOYSTICK_DEFAULT_POSITION = MainParent.anchoredPosition;


            Handle.rectTransform.localPosition = Vector3.zero;

            SetTransition(false);

            OnStart();
        }

        private void Update()
        {
            if (Debbuger)
            {
                Debbuger.text = AXIS.ToString();
            }


            InputTouch();

            if (IS_USING)
            {
                if (cross.gameObject.activeSelf) cross.Ontouch();
            }
            else
            {
                if (AnimatedMode && !IS_USING)
                {
                    Handle.rectTransform.localPosition = Vector2.Lerp(Handle.rectTransform.localPosition, Vector2.zero,
                        Time.deltaTime * ResetHandleSpeed);
                }

                if (IS_UPDATE)
                {
                    IS_UPDATE = false;

                    if (!AnimatedMode)
                    {
                        Handle.rectTransform.localPosition = Vector3.zero;
                    }

                    if (cross.gameObject.activeSelf) cross.OnEndTouch();
                }
            }
        }

        private void LateUpdate()
        {
            if (IS_USING)
            {
                if (arrow.gameObject.activeSelf) arrow.Ontouch();
                if (tail.gameObject.activeSelf) tail.Ontouch();
            }
            else
            {
                if (IS_LATEUPDATE)
                {
                    IS_LATEUPDATE = false;


                    if (arrow.gameObject.activeSelf) arrow.OnEndTouch();

                    if (tail.gameObject.activeSelf) tail.OnEndTouch();
                }
            }
        }

        public void UpdateConfig()
        {
            virtualJoystick = this;

            Body.GetComponent<RectTransform>().sizeDelta = new Vector2(JoystickSize, JoystickSize);
            HandleShadow.rectTransform.sizeDelta = new Vector2(HandleShadowSize, HandleShadowSize);
            Handle.rectTransform.sizeDelta = new Vector2(HandleSize, HandleSize);


            BackGround.color = new Color(BackGround.color.r, BackGround.color.g, BackGround.color.b,
                BackgroundAlpha * 0.01f);
            HandleShadow.color = new Color(HandleShadow.color.r, HandleShadow.color.g, HandleShadow.color.b,
                HandleShadowAlpha * 0.01f);
            Handle.color = new Color(Handle.color.r, Handle.color.g, Handle.color.b, HandleAlpha * 0.01f);
        }


        private void InputTouch()
        {
            if (RunOnDesktop)
            {
                DesktopInput();
            }
            else
            {
                MobileInput();
            }
        }

        private void DesktopInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                AXIS = Vector2.zero;

                if (!IS_USING)
                {
                    if (TouchArea)
                    {
                        if (!TouchArea.gameObject.activeSelf)
                        {
                            if (inBounds(Input.mousePosition, MainParent))
                            {
                                SetTransition(true);

                                Down(Input.mousePosition);

                                TOUCH_DETECTED = true;
                            }
                            else
                            {
                                TOUCH_DETECTED = false;
                            }

                            return;
                        }


                        if (inBounds(Input.mousePosition, TouchArea))
                        {
                            //------------------------ CHECK IF TOUCH COLLIDED WITH A UI ELEMENT -------------------------//

                            if (!inBounds(Input.mousePosition, MainParent) &&
                                EventSystem.current.IsPointerOverGameObject())
                            {
                                TOUCH_DETECTED = false;

                                return;
                            }

                            //---------------------------------- OTHERWISE CONTINUE -------------------------------------//

                            SetTransition(true);

                            MainParent.position = Input.mousePosition;

                            TOUCH_POSITION = Input.mousePosition;

                            TOUCH_DETECTED = true;
                        }
                        else
                        {
                            TOUCH_DETECTED = false;
                        }
                    }
                    else
                    {
                        if (inBounds(Input.mousePosition, MainParent))
                        {
                            SetTransition(true);

                            Down(Input.mousePosition);
                            TOUCH_DETECTED = true;
                        }
                        else
                        {
                            TOUCH_DETECTED = false;
                        }
                    }
                }
            }

            if (Input.GetMouseButton(0))
            {
                Drag(Input.mousePosition);
            }

            if (Input.GetMouseButtonUp(0))
            {
                Drop();
            }
        }

        private void MobileInput()
        {
            if (Input.touchCount <= 0)
            {
                return;
            }

            // Iterate through all the detected touches

            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);

                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        AXIS = Vector2.zero;

                        if (!IS_USING)
                        {
                            if (TouchArea)
                            {
                                if (!TouchArea.gameObject.activeSelf)
                                {
                                    if (inBounds(touch.position, MainParent) && FINGERID == -1)
                                    {
                                        SetTransition(true);

                                        Down(touch.position);
                                        FINGERID = touch.fingerId;
                                        TOUCH_DETECTED = true;
                                    }
                                    else
                                    {
                                        TOUCH_DETECTED = false;
                                    }

                                    return;
                                }


                                if (inBounds(touch.position, TouchArea))
                                {
                                    //------------------------ CHECK IF TOUCH COLLIDED WITH A UI ELEMENT -------------------------//

                                    if (!inBounds(touch.position, MainParent) &&
                                        EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                                    {
                                        TOUCH_DETECTED = false;

                                        return;
                                    }


                                    //---------------------------------- OTHERWISE CONTINUE -------------------------------------//

                                    SetTransition(true);

                                    MainParent.position = touch.position;

                                    if (FINGERID == -1)
                                    {
                                        FINGERID = touch.fingerId;
                                        TOUCH_POSITION = touch.position;
                                        TOUCH_DETECTED = true;
                                    }
                                }
                                else
                                {
                                    TOUCH_DETECTED = false;
                                }
                            }
                            else if (!TouchArea)
                            {
                                if (inBounds(touch.position, MainParent) && FINGERID == -1)
                                {
                                    SetTransition(true);

                                    Down(touch.position);
                                    FINGERID = touch.fingerId;
                                    TOUCH_DETECTED = true;
                                }
                                else
                                {
                                    TOUCH_DETECTED = false;
                                }
                            }
                        }

                        break;

                    case TouchPhase.Moved:

                        if (touch.fingerId == FINGERID)
                        {
                            Drag(touch.position);
                        }

                        break;

                    case TouchPhase.Ended:

                        if (touch.fingerId == FINGERID)
                        {
                            FINGERID = -1;
                            Drop();
                        }

                        break;
                }
            }
        }


        private void Down(Vector3 touch)
        {
            TOUCH_POSITION = touch;

            if (joystickType == JoystickType.Custom) onTouch.Invoke();
        }

        private void Drag(Vector3 touch)
        {
            if (!TOUCH_DETECTED) return;

            IS_USING = true;
            IS_UPDATE = true;
            IS_LATEUPDATE = true;

            //////////////////////////////////////////////////////////// Handle Follow Touch position /////////////////////////////////////////////////////////

            if (Body.sizeDelta.x != BACKGROUND_SIZE_ON_START ||
                Handle.rectTransform.sizeDelta.x != HANDLE_SIZE_ON_START)
            {
                float FixedRatio = ((Body.sizeDelta.x / 2) - (BACKGROUND_SIZE_ON_START / 2)) -
                                   ((Handle.rectTransform.sizeDelta.x / 2) - (HANDLE_SIZE_ON_START / 2));

                Ratio = RATIO_ON_START + FixedRatio;
            }

            Handle.rectTransform.position = touch;
            Handle.rectTransform.anchoredPosition = Vector3.ClampMagnitude(Handle.rectTransform.localPosition, Ratio);


            if (AnimatedMode)
            {
                Vector3 AngleRotation = new Vector3(0, 0, ANGLE);

                if (RotateBackground)
                {
                    BackGround.rectTransform.eulerAngles = AngleRotation;
                }

                if (RotateHandle)
                {
                    Handle.rectTransform.eulerAngles = new Vector3(0, 0, ANGLE);
                }
            }


            /////////////////////////////////////////////////////////////////// RETURN AXIS ////////////////////////////////////////////////////////////////////


            if (Vector2.Distance(Vector2.zero, Handle.rectTransform.localPosition) >= DEADZONE_ON_START)
            {
                IS_OUT_OF_DEADZONE = true;

                if (!OnReleaseAxis)
                {
                    AXIS = GetAxis();
                }
                else
                {
                    ONREALESE_AXIS = GetAxis();
                }
            }
            else
            {
                IS_OUT_OF_DEADZONE = false;
                AXIS = Vector2.zero;
                ONREALESE_AXIS = Vector2.zero;
            }

            GetDirection();
        }

        private void Drop()
        {
            if (!TOUCH_DETECTED) return;

            SetTransition(false);

            BackGround.rectTransform.eulerAngles = new Vector3(0, 0, 0);
            Handle.rectTransform.eulerAngles = new Vector3(0, 0, 0);

            MainParent.anchoredPosition = JOYSTICK_DEFAULT_POSITION;

            AXIS = OnReleaseAxis == false ? Vector2.zero : ONREALESE_AXIS;

            DIRECTION = Direction.None;
            IS_USING = false;
            IS_OUT_OF_DEADZONE = false;

            if (joystickType == JoystickType.Custom) onRealase.Invoke();
        }


        public float GetDistanceFromCenter()
        {
            return Mathf.Clamp01(Vector2.Distance(Vector2.zero, Handle.rectTransform.localPosition) * 2 /
                                 (JoystickSize - HandleSize));
        }


        public void SetTransition(bool startTransition)
        {
            if (transitionType == TransitionType.Default)
            {
                JoystickCanvas.enabled = false;
            }

            else
            {
                JoystickCanvas.enabled = true;

                if (startTransition)
                {
                    switch (transitionType)
                    {
                        case TransitionType.ShowOnTouch:

                            JoystickCanvas.alpha = 1;

                            break;

                        case TransitionType.HighlightOnTouch:

                            JoystickCanvas.alpha = MaximumHighlight * 0.01f;

                            break;
                    }

                    return;
                }


                switch (transitionType)
                {
                    case TransitionType.ShowOnTouch:

                        JoystickCanvas.alpha = 0;

                        break;

                    case TransitionType.HighlightOnTouch:

                        JoystickCanvas.alpha = MinimumHighlight * 0.01f;

                        break;
                }
            }
        }

        private Vector2 GetAxis()
        {
            Vector2 axis = new Vector2();

            switch (axisType)
            {
                case AxisType.Angle:

                    axis = ((Vector2)Handle.rectTransform.position - TOUCH_POSITION).normalized;

                    break;

                case AxisType.Cross:

                    switch (DIRECTION)
                    {
                        case Direction.Up:

                            axis = new Vector2(0, 1);

                            break;

                        case Direction.Down:

                            axis = new Vector2(0, -1);

                            break;

                        case Direction.Right:

                            axis = new Vector2(1, 0);

                            break;

                        case Direction.Left:

                            axis = new Vector2(-1, 0);

                            break;
                    }

                    break;
            }

            return axis;
        }

        private void GetDirection()
        {
            //--------------------------- DIRECTION -----------------------------//

            Vector2 Axis = ((Vector2)Handle.rectTransform.position - TOUCH_POSITION).normalized;

            if (Axis != new Vector2(0, 0))
            {
                float Vertical = Mathf.Abs(Axis.y);
                float Horizontal = Mathf.Abs(Axis.x);

                if (Vertical > Horizontal)
                {
                    if (TOUCH_POSITION.y - Handle.rectTransform.position.y < 0)
                    {
                        DIRECTION = Direction.Up;
                    }
                    else if (TOUCH_POSITION.y - Handle.rectTransform.position.y > 0)
                    {
                        DIRECTION = Direction.Down;
                    }
                }
                else if (Horizontal > Vertical)
                {
                    if (TOUCH_POSITION.x - Handle.rectTransform.position.x < 0)
                    {
                        DIRECTION = Direction.Right;
                    }
                    else if (TOUCH_POSITION.x - Handle.rectTransform.position.x > 0)
                    {
                        DIRECTION = Direction.Left;
                    }
                }
            }

            //--------------------------- ANGLE -----------------------------//

            GetAngle(Axis);

            //--------------------------- Handle Distance -----------------------------//


            //HandleDistance = Vector2.Distance(Handle.rectTransform.anchoredPosition, Vector2.zero);
        }

        public void GetAngle(Vector2 Axis)
        {
            //ANGLE = Mathf.Atan2(Axis.y, Axis.x) * Mathf.Rad2Deg;

            Vector2 screenPointA = RectTransformUtility.WorldToScreenPoint(null, BackGround.transform.position);
            Vector2 screenPointB = RectTransformUtility.WorldToScreenPoint(null, Handle.transform.position);
            Vector2 direction = screenPointB - screenPointA;

            ANGLE = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        private bool inBounds(Vector3 touch, RectTransform rect)
        {
            bool inside = false;

            Vector2 touchpos = rect.InverseTransformPoint(touch);

            if (rect.rect.Contains(touchpos))
            {
                return true;
            }

            return inside;
        }

        #endregion


        // OnStart is called before the first frame update

        private void OnStart()
        {
        }

        // MAKES THE HANDLE BIGGER WHEN THE JOYSTICK IS BEING USED.
        public void OnStartTouch()
        {
            Handle.rectTransform.sizeDelta = new Vector2(HANDLE_SIZE_ON_START + 25, HANDLE_SIZE_ON_START + 25);
        }

        // MAKES THE HANDLE SMALLER WHEN THE JOYSTICK IS NOT BEING USED.
        public void OnEndTouch()
        {
            Handle.rectTransform.sizeDelta = new Vector2(HANDLE_SIZE_ON_START, HANDLE_SIZE_ON_START);
        }
    }
}