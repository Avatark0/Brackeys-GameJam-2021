using UnityEngine;
using UnityEditor;

public class CriarAssetDeSO : MonoBehaviour
{
    //Essa função cria assets de scriptable objects durante a execução (funciona apenas no editor)
    public void AssetDeSO(ScriptableObject scriptableObject){
        ScriptableObject meuSO = scriptableObject;
        
        AssetDatabase.CreateAsset(meuSO, "MinhaPastaDeSo/" + meuSO.name + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = meuSO;
    }
}
