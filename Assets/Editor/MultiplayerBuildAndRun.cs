using UnityEditor;
using UnityEngine;

public class MultiplayerBuildAndRun
{
    // ����Ƽ �޴��� 2���� Ŭ���̾�Ʈ�� �����ϴ� �޴� �߰�
    [MenuItem("Tools/Run Multiplayer/2 Players Android")]
    static void PerformAndroidBuild2()
    {
        PerformAndroidBuild(2);
    }

    // ����Ƽ �޴��� 3���� Ŭ���̾�Ʈ�� �����ϴ� �޴� �߰�
    [MenuItem("Tools/Run Multiplayer/3 Players Android")]
    static void PerformAndroidBuild3()
    {
        PerformAndroidBuild(3);
    }

    // ����Ƽ �޴��� 4���� Ŭ���̾�Ʈ�� �����ϴ� �޴� �߰�
    [MenuItem("Tools/Run Multiplayer/4 Players Android")]
    static void PerformAndroidBuild4()
    {
        PerformAndroidBuild(4);
    }

    // �ȵ���̵� ���� ����
    static void PerformAndroidBuild(int playerCount)
    {
        // �ȵ���̵� ���� Ÿ������ ��ȯ
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        for (int i = 1; i <= playerCount; i++)
        {
            // ���� ��ο� ���� �̸� ����
            string buildPath = "Builds/Android/" + GetProjectName() + i.ToString() + "/";
            string buildFileName = GetProjectName() + i.ToString() + ".apk";

            // ���� �ɼ� ����
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = GetScenePaths(),
                locationPathName = buildPath + buildFileName,
                target = BuildTarget.Android,
                options = BuildOptions.None // �ȵ���̵�� AutoRunPlayer �ɼ��� �������� �ʽ��ϴ�.
            };

            // ���� ����
            BuildPipeline.BuildPlayer(buildPlayerOptions);
        }
    }

    // ������Ʈ �̸� �������� �Լ�
    static string GetProjectName()
    {
        string[] s = Application.dataPath.Split('/');
        return s[s.Length - 2];
    }

    // ��� ��(Scene)�� ���� ��� �������� �Լ�
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
