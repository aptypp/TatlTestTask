using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

namespace FormatGames.VirtualJoystick.Pro
{
    public class Arrow : MonoBehaviour
    {

        [HideInInspector] public float Width = 190f;
        [HideInInspector] public float Height = 110f;
        [HideInInspector] public float Spacing = 20;

        [HideInInspector] public float Alpha = 100f;
        [HideInInspector] public Color color = Color.white;


        [HideInInspector] public bool preserveAspect;
        [HideInInspector] public bool Unfold;
        [HideInInspector] public bool Enable;

        [HideInInspector] public Joystick joystick;
        [HideInInspector] public Image Render;
        [HideInInspector] public RectTransform rectTransform;

        void Start()
        {
            Render.enabled = false;
        }

        // Start is called before the first frame update
        void Reset()
        {
            gameObject.SetActive(false);
            rectTransform = gameObject.GetComponent<RectTransform>();
        }

        public void UpdateConfig()
        {
            Render.preserveAspect = preserveAspect;
            Render.color = color;
            Render.color = new Color(Render.color.r, Render.color.g, Render.color.b, Alpha * 0.01f);

            Render.rectTransform.anchoredPosition = new Vector2(Spacing, 0);
            Render.rectTransform.sizeDelta = new Vector2(Width, Height);

        }

        public void Ontouch()
        {

            if (joystick.IS_OUT_OF_DEADZONE)
            {
                Render.enabled = true;
                rectTransform.eulerAngles = new Vector3(0, 0, joystick.ANGLE);
            }
            else
            {
                Render.enabled = false;
            }
        }

        public void OnEndTouch()
        {
            Render.enabled = false;
        }
    }
}

