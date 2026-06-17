using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Made by Julien Cagnoncle

public class ProjectSetup
{
	// Set the path for the window on the menu
    [MenuItem("Tools/Project Setup")]
	private static void SetupFiles()
    {
		AssetDatabase.CreateFolder("Assets", "_" + GetProjectNameFromPath());
		AssetDatabase.CreateFolder("Assets", "_Common");

		SetupSubFile("_" + GetProjectNameFromPath());
		SetupSubFile("_Common");
	}

	private static void SetupSubFile(string parentFolder)
    {
		string path = "Assets/"+parentFolder;
		path = GeneratePathAndGetNewPath(path, "Audio");
		AssetDatabase.CreateFolder(path, "SFX");
		AssetDatabase.CreateFolder(path, "Musics");

		path = "Assets/" + parentFolder;
		path = GeneratePathAndGetNewPath(path, "Script");
		AssetDatabase.CreateFolder(path, "Editor");
		path = "Assets/" + parentFolder;
		AssetDatabase.CreateFolder(path, "Prefabs");
		AssetDatabase.CreateFolder(path, "Meshes");
		AssetDatabase.CreateFolder(path, "Materials");
		path = GeneratePathAndGetNewPath(path, "Texture");
		AssetDatabase.CreateFolder(path, "Sprite");
		AssetDatabase.CreateFolder(path, "2DTexture");
		path = "Assets/" + parentFolder;
		path = GeneratePathAndGetNewPath(path, "Animation");
		AssetDatabase.CreateFolder(path, "Animator");
		AssetDatabase.CreateFolder(path, "AnimationFile");
		path = "Assets/" + parentFolder;
		AssetDatabase.CreateFolder(path, "Shaders");
	}

	private static string GeneratePathAndGetNewPath(string path, string newFolderName)
    {
		AssetDatabase.CreateFolder(path,newFolderName);

		return path + "/" + newFolderName;
    }

	private static string GetProjectNameFromPath()
	{
		// Find the index of the last directory separator before "Assets"
		string path = Application.dataPath;
		int assetsIndex = path.LastIndexOf("/Assets");
		if (assetsIndex == -1)
		{
			assetsIndex = path.LastIndexOf("\\Assets");
		}

		if (assetsIndex == -1)
		{
			Debug.LogError("Assets directory not found in path");
			return string.Empty;
		}

		// Get the path up to the directory containing "Assets"
		string projectPath = path.Substring(0, assetsIndex);

		// Find the last directory separator in the project path
		int lastSeparatorIndex = projectPath.LastIndexOf('/');
		if (lastSeparatorIndex == -1)
		{
			lastSeparatorIndex = projectPath.LastIndexOf('\\');
		}

		if (lastSeparatorIndex == -1)
		{
			Debug.LogError("Invalid project path");
			return string.Empty;
		}

		// Extract the project name
		string projectName = projectPath.Substring(lastSeparatorIndex + 1);

		return projectName;
	}
}
