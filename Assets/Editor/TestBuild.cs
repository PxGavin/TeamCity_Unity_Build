using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class TestBuild
{
    public static void BuildApk()
    {
        var outdir = "C:/bin/win/TeamCity_CI_Build/";
        var outputPath = Path.Combine(outdir, "TeamCity.exe");

        if (!Directory.Exists(outdir)) Directory.CreateDirectory(outdir);
        if (File.Exists(outputPath)) File.Delete(outputPath);

        string[] scenes = new string[] { "Assets/Scemes/SampleScene.unity" };
        BuildPipeline.BuildPlayer(scenes, outputPath, BuildTarget.StandaloneWindows, BuildOptions.None);

        if(File.Exists(outputPath))
        {
            Debug.Log("Build Success :" + outputPath);
        }
        else
        {
            Debug.LogException(new Exception("Build Fail! Please Check the log! "));
        }
    }
}
