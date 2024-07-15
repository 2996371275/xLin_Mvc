using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace xLin
{
    public class Common
    {

    }


    public class StringDropdownAttribute : PropertyAttribute
    {
        public string[] options;

        public StringDropdownAttribute(params string[] options)
        {
            this.options = options;
        }
    }
    [CustomPropertyDrawer(typeof(StringDropdownAttribute))]
    public class StringDropdownDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            StringDropdownAttribute dropdownAttribute = (StringDropdownAttribute)attribute;
            string[] options = dropdownAttribute.options;
            int index = Mathf.Max(0, System.Array.IndexOf(options, property.stringValue));

            index = EditorGUI.Popup(position, label.text, index, options);
            property.stringValue = options[index];
        }
    }
}