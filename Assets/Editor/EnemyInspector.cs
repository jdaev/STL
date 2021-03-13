using System;
using System.Collections.Generic;
using System.Linq;
using Base;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : UnityEditor.Editor
    {
        private readonly List<String> _choices = Values.ShootableColors.Keys.ToList();
        private int _choiceIndex = 0;
        private Enemy _enemy;

        public void OnEnable()
        {
            _enemy = target as Enemy;

            _choiceIndex = _choices.IndexOf(_enemy.color.color.ToString());
        }

        public override void OnInspectorGUI()
        {
            _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.ToArray());
            _enemy.color = Values.ShootableColors [_choices[_choiceIndex]];
        }
    }
}