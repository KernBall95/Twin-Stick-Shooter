using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyMoveToPlayer))]
public class EnemyMoveToPlayerEditor : Editor {

    override public void OnInspectorGUI()
    {
        EnemyMoveToPlayer enemyMoveToPlayer = target as EnemyMoveToPlayer;

        enemyMoveToPlayer.variableSpeedEnabled = GUILayout.Toggle(enemyMoveToPlayer.variableSpeedEnabled, "Variable Speed");

        if(enemyMoveToPlayer.variableSpeedEnabled)
        {
            enemyMoveToPlayer.minSpeed = EditorGUILayout.FloatField("Minimum speed", enemyMoveToPlayer.minSpeed);
            enemyMoveToPlayer.maxSpeed = EditorGUILayout.FloatField("Maximum Speed", enemyMoveToPlayer.maxSpeed);
        }
    }
}
