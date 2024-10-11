using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

using static System.IO.Path;
using static UnityEditor.AssetDatabase;

public class ProjectSetUp : MonoBehaviour
{
    [MenuItem("Tools/Setup/Import Custom Assets")]
    public static void ImportCustomAssets()
    {
        //Import from a custom folder
        Assets.ImportCustomAsset("EditorShortcuts.unitypackage", "C:/Users/aaron/OneDrive/Documents/GitHub/UnityPackages/Custom");
        Assets.ImportCustomAsset("OptionalStruct.unitypackage", "C:/Users/aaron/OneDrive/Documents/GitHub/UnityPackages/Custom");
        Assets.ImportCustomAsset("VariableReferences.unitypackage", "C:/Users/aaron/OneDrive/Documents/GitHub/UnityPackages/Custom");
    }

    [MenuItem("Tools/Setup/Import Essential Assets")]
    public static void ImportEssentialAssets()
    {
        Assets.ImportEssentialAsset("Selection History.unitypackage", "Staggart Creations/Editor ExtensionsUtilities");
        Assets.ImportEssentialAsset("Better Hierarchy.unitypackage", "Toaster Head/Editor ExtensionsUtilities");
        Assets.ImportEssentialAsset("Odin Inspector and Serializer.unitypackage", "Sirenix/Editor ExtensionsSystem");
    }

    [MenuItem("Tools/Setup/Install Essential Packages")]
    public static void InstallPackages()
    {
        Packages.InstallPackages(new[] {
            "git+https://gitlab.hotreload.net/root/hot-reload-releases.git#1.12.12",
            "git+https://github.com/starikcetin/Eflatun.SceneReference.git#4.1.1",
            "git+https://github.com/YarnSpinnerTool/YarnSpinner-Unity.git#current",
            "git+https://github.com/KyleBanks/scene-ref-attribute",
            "git+https://github.com/uvivagabond/unity-bulk-rename",
            "com.unity.inputsystem"
        });
    }

    [MenuItem("Tools/Setup/Create Folders")]
    public static void CreateFolders()
    {
        Folders.Create("_Project", "Animations", "Art", "Audio", "Materials", "Prefabs", "Scripts", "Resources");
        Refresh();
        Folders.Move("_Project", "Scenes");
        Folders.Move("_Project", "Settings");
        Folders.Delete("TutorialInfo");
        Refresh();

        MoveAsset("Assets/InputSystem_Actions.inputactions", "Assets/_Project/Settings/InputSystem_Actions.inputactions");
        DeleteAsset("Assets/Readme.asset");
        Refresh();
    }

    static class Assets
    {
        public static void ImportEssentialAsset(string asset, string folder)
        {
            var basePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var assetsFolder = Combine(basePath, "Unity/Asset Store-5.x");
            ImportPackage(Combine(assetsFolder, folder, asset), false);
        }

        public static void ImportCustomAsset(string folder, string asset)
        {
            var assetPath = Combine(folder, asset);
            ImportPackage(assetPath, false);
        }
    }

    static class Packages
    {
        static AddRequest request;
        static Queue<string> packagesToInstall = new Queue<string>();

        public static void InstallPackages(string[] packages)
        {
            foreach (var package in packages)
            {
                packagesToInstall.Enqueue(package);
            }

            if (packagesToInstall.Count > 0)
            {
                StartNextPackageInstallation();
            }
        }

        static async void StartNextPackageInstallation()
        {
            request = Client.Add(packagesToInstall.Dequeue());

            while (!request.IsCompleted) await Task.Delay(10);

            if (request.Status == StatusCode.Success) Debug.Log("Installed: " + request.Result.packageId);
            else if (request.Status >= StatusCode.Failure) Debug.LogError(request.Error.message);

            if (packagesToInstall.Count > 0)
            {
                await Task.Delay(1000);
                StartNextPackageInstallation();
            }
        }
    }

    static class Folders
    {
        public static void Create(string root, params string[] folders)
        {
            var fullpath = Combine(Application.dataPath, root);
            if (!Directory.Exists(fullpath))
            {
                Directory.CreateDirectory(fullpath);
            }

            foreach (var folder in folders)
            {
                CreateSubFolders(fullpath, folder);
            }
        }

        static void CreateSubFolders(string rootPath, string folderHierarchy)
        {
            var folders = folderHierarchy.Split('/');
            var currentPath = rootPath;

            foreach (var folder in folders)
            {
                currentPath = Combine(currentPath, folder);
                if (!Directory.Exists(currentPath))
                {
                    Directory.CreateDirectory(currentPath);
                }
            }
        }

        public static void Move(string newParent, string folderName)
        {
            var sourcePath = $"Assets/{folderName}";
            if (IsValidFolder(sourcePath))
            {
                var destinationPath = $"Assets/{newParent}/{folderName}";
                var error = MoveAsset(sourcePath, destinationPath);

                if (!string.IsNullOrEmpty(error))
                {
                    Debug.LogError($"Failed to move {folderName}: {error}");
                }
            }
        }

        public static void Delete(string folderName)
        {
            var pathToDelete = $"Assets/{folderName}";

            if (IsValidFolder(pathToDelete))
            {
                DeleteAsset(pathToDelete);
            }
        }
    }
}
