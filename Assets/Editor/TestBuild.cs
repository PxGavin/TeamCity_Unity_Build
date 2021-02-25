using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TestBuild
{
    public static string buildPath = Application.dataPath + "/../../bin/";

    public static void BuildApk()
    {
        var outdir = $"{buildPath}win/TeamCity_CI_Build";
        var targetPath = $"{buildPath}win/TeamCity_CI_Build/TeamCity.exe";

        if (!Directory.Exists(outdir)) Directory.CreateDirectory(outdir);
        if (File.Exists(targetPath)) File.Delete(targetPath);

        string[] scenes = new string[] { "Assets/Scenes/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scenes, targetPath, BuildTarget.StandaloneWindows, BuildOptions.None);

        if(File.Exists(targetPath))
        {
            Debug.Log("Build Success :" + targetPath);
        }
        else
        {
            Debug.LogException(new Exception("Build Fail! Please Check the log! "));
        }
    }
}
