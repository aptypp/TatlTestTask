using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FormatGames.VirtualJoystick.Pro
{
    public class Cross : MonoBehaviour
    {

        [HideInInspector] public float Size = 0.22f;
        [HideInInspector] public float Position = 130f;
        [HideInInspector] public float Alpha = 60f;
        [HideInInspector] public Color Selected = Color.white;
        [HideInInspector] public Color Disabled = Color.white;
        [HideInInspector] public bool PreserveAspect;
        [HideInInspector] public bool Unfold;
        [HideInInspector] public bool Enable;


        [HideInInspector] public Joystick joystick;
        [HideInInspector] public Image Up;
        [HideInInspector] public Image Down;
        [HideInInspector] public Image Left;
        [HideInInspector] public Image Right;


        void Reset()
        {
            if (Up && Down && Right && Left)
            {
                UpdateConfig();
            }
        }

        public void UpdateConfig()
        {
            if (Up && Down && Right && Left)
            {

                Disabled = new Color(Disabled.r, Disabled.g, Disabled.g, Alpha * 0.01f);

                Up.color = Disabled;
                Down.color = Disabled;
                Right.color = Disabled;
                Left.color = Disabled;

                Up.color = new Color(Up.color.r, Up.color.g, Up.color.b, Alpha * 0.01f);
                Down.color = new Color(Down.color.r, Down.color.g, Down.color.b, Alpha * 0.01f);
                Right.color = new Color(Right.color.r, Right.color.g, Right.color.b, Alpha * 0.01f);
                Left.color = new Color(Left.color.r, Left.color.g, Left.color.b, Alpha * 0.01f);


                Up.rectTransform.anchoredPosition = new Vector2(0, Position);
                Up.transform.localScale = new Vector2(Size, Size);

                Down.rectTransform.anchoredPosition = new Vector2(0, -Position);
                Down.transform.localScale = new Vector2(Size, Size);

                Right.rectTransform.anchoredPosition = new Vector2(Position, 0);
                Right.transform.localScale = new Vector2(Size, Size);

                Left.rectTransform.anchoredPosition = new Vector2(-Position, 0);
                Left.transform.localScale = new Vector2(Size, Size);

                Up.preserveAspect = PreserveAspect;
                Down.preserveAspect = PreserveAspect;
                Left.preserveAspect = PreserveAspect;
                Right.preserveAspect = PreserveAspect;
            }
            else
            {
                Debug.LogError("You need to fill all the image fields");
            }
        }

        public void Ontouch()
        {

            if (!joystick || !joystick.IS_USING)
            {
                Up.color = Disabled;
                Down.color = Disabled;
                Right.color = Disabled;
                Left.color = Disabled;
                return;
            }

            switch (joystick.DIRECTION)
            {
                case Joystick.Direction.Up:

                    Up.color = Selected;
                    Down.color = Disabled;
                    Right.color = Disabled;
                    Left.color = Disabled;

                    break;

                case Joystick.Direction.Down:

                    Up.color = Disabled;
                    Down.color = Selected;
                    Right.color = Disabled;
                    Left.color = Disabled;

                    break;

                case Joystick.Direction.Right:

                    Up.color = Disabled;
                    Down.color = Disabled;
                    Right.color = Selected;
                    Left.color = Disabled;

                    break;

                case Joystick.Direction.Left:

                    Up.color = Disabled;
                    Down.color = Disabled;
                    Right.color = Disabled;
                    Left.color = Selected;

                    break;
            }
        }

        public void OnEndTouch()
        {
            Up.color = Disabled;
            Down.color = Disabled;
            Right.color = Disabled;
            Left.color = Disabled;
        }
    }
}
