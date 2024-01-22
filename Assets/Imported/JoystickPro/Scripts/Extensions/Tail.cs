using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace FormatGames.VirtualJoystick.Pro
{
    public class Tail : MonoBehaviour
    {

        [HideInInspector] public float Size = 5f;
        [HideInInspector] public float Alpha = 100f;
        [HideInInspector] public Color color = Color.white;
        [HideInInspector] public bool ShowOnEdit;
        [HideInInspector] public bool Unfold;
        [HideInInspector] public bool Enable;

        [HideInInspector] public Joystick joystick;
        [HideInInspector] public Image Render;
        [HideInInspector] public RectTransform Center;
        [HideInInspector] public RectTransform Handle;
        [HideInInspector] public RectTransform rectTransform;


        public void UpdateConfig()
        {
            Center = joystick.Body;
            Handle = joystick.Handle.rectTransform;
            rectTransform = GetComponent<RectTransform>();

            Render.enabled = ShowOnEdit;
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, Size);
            Render.color = color;
            Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, Alpha * 0.01f);

            Render.raycastTarget = false;
        }

        void Start()
        {
            Render.enabled = false;

            RectTransform aux;

            if (Center.localPosition.x > Handle.localPosition.x)
            {
                aux = Center;
                Center = Handle;
                Handle = aux;
            }
        }

        public void Ontouch()
        {
            if (joystick.IS_USING)
            {
                if ((Handle.anchoredPosition.x < 0 && Handle.anchoredPosition.y > 0) || (Handle.anchoredPosition.x < 0 && Handle.anchoredPosition.y < 0))
                {
                    Render.rectTransform.localEulerAngles = new Vector3(0, 0, 180);
                }
                else
                {
                    Render.rectTransform.localEulerAngles = new Vector3(0, 0, 0);
                }

                rectTransform.localPosition = (Center.localPosition + Handle.localPosition) / 2;
                Vector3 dif = Handle.localPosition - Center.localPosition;
                rectTransform.sizeDelta = new Vector3(dif.magnitude, Size);

                // Check if dif.x is not zero to avoid division by zero
                float angle = dif.x != 0 ? Mathf.Atan(dif.y / dif.x) : 0;

                // Round the angle to apply a tolerance
                angle = Mathf.Round(angle * Mathf.Rad2Deg);

                // Ensure the angle is within -180 to 180 range
                angle = Mathf.Clamp(angle, -180, 180);

                rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

                Render.enabled = true;
            }
        }

        public void OnEndTouch()
        {
            Render.enabled = false;
        }
    }
}
