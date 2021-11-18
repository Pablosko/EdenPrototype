using UnityEngine;
public static class FileManager
{
    public static string LoadJSONFile(string filePath)
    {
        TextAsset dataFile = Resources.Load<TextAsset>(Constants.DATADIRECTORY + filePath);
        return dataFile.text; 
    }
}
