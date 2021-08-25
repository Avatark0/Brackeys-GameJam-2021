using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Asset retirado do projeto PicturePuzzle (ainda não adaptado para este projeto)
public class SaveFileScript : MonoBehaviour
{
    [HideInInspector] public bool[] levelsUnlocked;
    [HideInInspector] public bool hasSaveFile;
    
    void Awake(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("saveManager");

        if (objs.Length > 1){
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        Debug.Log("SaveFileScript: Files saved at "+Application.persistentDataPath);
        Load();
    }

    public void InitializeLevelsUnlocked(bool[] levelsUnlockedInitialization){
        levelsUnlocked=levelsUnlockedInitialization;
    }

    //É acessado por MainButtonScript em Exit(), e por PieceScript em PuzzleCompleted()
    public void Save(){
        BinaryFormatter bf=new BinaryFormatter();
        FileStream file=File.Create(Application.persistentDataPath+"/levelSaveFile.dat");
    
        SaveFile data=new SaveFile();
        data.levelsUnlocked=levelsUnlocked;

        bf.Serialize(file,data);
        file.Close();

        hasSaveFile=true;
    }

    public void Load(){
        if(File.Exists(Application.persistentDataPath+"/levelSaveFile.dat")){
            hasSaveFile=true;

            BinaryFormatter bf=new BinaryFormatter();
            FileStream file=File.Open(Application.persistentDataPath+"/levelSaveFile.dat",FileMode.Open);
            
            SaveFile data=(SaveFile)bf.Deserialize(file);
            file.Close();

            levelsUnlocked=data.levelsUnlocked;
        }
        else hasSaveFile=false;
    }
}

[Serializable]
class SaveFile
{
    public bool[] levelsUnlocked;
}
