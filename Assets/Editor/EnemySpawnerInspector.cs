// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Base;
// using UnityEditor;
// using UnityEngine;
//
// namespace Editor
// {
//     [CustomEditor(typeof(EnemySpawner))]
//     public class EnemySpawnerInspector : UnityEditor.Editor
//     {
//         private readonly List<String> _choices = Values.ShootableColors.Keys.ToList();
//         private int _choiceIndex = 0;
//         private EnemySpawner _enemySpawner;
//
//         public void OnEnable()
//         {
//             _enemySpawner = target as EnemySpawner;
//
//             _choiceIndex = _enemySpawner.color != null ? _choices.IndexOf(_enemySpawner.color.ToString()) : 0;
//         }
//             
//         public override void OnInspectorGUI()
//         {
//             DrawDefaultInspector();
//             _choiceIndex = EditorGUILayout.Popup(_choiceIndex, _choices.ToArray());
//             _enemySpawner.color = Values.ShootableColors [_choices[_choiceIndex]];
//         }
//     }
// }