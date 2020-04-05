﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AI_FOV))]
public class AI_FOVEditor : Editor
{
    void OnSceneGUI()
    {
        AI_FOV fow = (AI_FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);

        Vector3 viewAngleA = fow.DirFromAngle(-fow.viewAngle / 2, false);
        Vector3 viewAngleB = fow.DirFromAngle(fow.viewAngle / 2, false);

        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleA * fow.viewRadius);
        Handles.DrawLine(fow.transform.position, fow.transform.position + viewAngleB * fow.viewRadius);


        //foreach (Transform visibleTarget in fow.visibleTargets) {
        //    Handles.color = Color.red;
        //    Handles.DrawLine(fow.transform.position,visibleTarget.position);
        //}
    }
}
