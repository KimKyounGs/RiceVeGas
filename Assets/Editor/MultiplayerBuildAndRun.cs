using UnityEditor;
using UnityEngine;

public class MultiplayerBuildAndRun
{
    // 유니티 메뉴에 2개의 클라이언트를 실행하는 메뉴 추가
    [MenuItem("Tools/Run Multiplayer/2 Players Android")]
    static void PerformAndroidBuild2()
    {
        PerformAndroidBuild(2);
    }

    // 유니티 메뉴에 3개의 클라이언트를 실행하는 메뉴 추가
    [MenuItem("Tools/Run Multiplayer/3 Players Android")]
    static void PerformAndroidBuild3()
    {
        PerformAndroidBuild(3);
    }

    // 유니티 메뉴에 4개의 클라이언트를 실행하는 메뉴 추가
    [MenuItem("Tools/Run Multiplayer/4 Players Android")]
    static void PerformAndroidBuild4()
    {
        PerformAndroidBuild(4);
    }

    // 안드로이드 빌드 수행
    static void PerformAndroidBuild(int playerCount)
    {
        // 안드로이드 빌드 타겟으로 전환
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        for (int i = 1; i <= playerCount; i++)
        {
            // 빌드 경로와 파일 이름 설정
            string buildPath = "Builds/Android/" + GetProjectName() + i.ToString() + "/";
            string buildFileName = GetProjectName() + i.ToString() + ".apk";

            // 빌드 옵션 설정
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = GetScenePaths(),
                locationPathName = buildPath + buildFileName,
                target = BuildTarget.Android,
                options = BuildOptions.None // 안드로이드는 AutoRunPlayer 옵션을 지원하지 않습니다.
            };

            // 빌드 실행
            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
    }

    // 프로젝트 이름 가져오는 함수
    static string GetProjectName()
    {
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }

    // 모든 씬(Scene)에 대한 경로 가져오는 함수
    static string[] GetScenePaths()
    {
        string[] scenes = new string[EditorBuildSettings.scenes.Length];

        for (int i = 0; i < scenes.Length; i++)
        {
            scenes[i] = EditorBuildSettings.scenes[i].path;
        }

        return scenes;
    }
}
