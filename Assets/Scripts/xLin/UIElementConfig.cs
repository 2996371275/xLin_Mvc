using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace xLin
{
    [System.Serializable]
    public class UIElementConfig
    {
        public string name;
        public string type;
        public string path;
        public string fontColor = "FFFFFF";
        public string texturePath;
        public string spritePath;
        public int fontSize = 18;
        public Transform transform;

        public void SetElement(GameObject parent)
        {
            transform = parent.transform.Find(path);
            switch (type)
            {
                case "Image":
                    if (!string.IsNullOrEmpty(spritePath))
                    {
                        ResourcesManager.Instance.Load(PathDef.sprite, path, (image) => {
                            transform.GetComponent<Image>().sprite = image as Sprite;
                        });
                    }
                    break;
                case "RawImage":
                    if (!string.IsNullOrEmpty(texturePath))
                    {
                        ResourcesManager.Instance.Load(PathDef.texture, path, (tex) => {
                            transform.GetComponent<RawImage>().texture = tex as Texture;
                        });
                    }
                    break;
                case "Text":
                    TMPro.TMP_Text text = transform.GetComponent<TMPro.TMP_Text>();
                    text.fontSize = fontSize;
                    Color c;
                    ColorUtility.TryParseHtmlString("#"+ fontColor, out c);
                    text.color = c;
                    break;

            }
        }
        public void GetElement<T>()
        {
            switch (type)
            {
                case "Image":
                    break;
                case "RawImage":
                    break;
                case "Text":
                    break;

            }
        }
    }

}