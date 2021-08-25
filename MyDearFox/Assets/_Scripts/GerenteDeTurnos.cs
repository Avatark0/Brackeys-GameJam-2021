using System.Collections.Generic;
using UnityEngine;

public class GerenteDeTurnos : MonoBehaviour
{
//OrdemDeExecução atualizada para +100 em projectSettings

    [SerializeField] private GameObject spawnerCriaturas=default;
    [SerializeField] private Criatura[] criaturasSpawnadas;

    [SerializeField] public List<CriaturasAtivas> criaturasAtivas;

    private int maxIndexCriaturas;
    private int vezNoTurno=0;

    private void Start()
    {
        maxIndexCriaturas=spawnerCriaturas.transform.childCount;
        criaturasSpawnadas=new Criatura[maxIndexCriaturas];
        for(int i=0; i<maxIndexCriaturas; i++)
        {
            criaturasSpawnadas[i]=spawnerCriaturas.transform.GetChild(i).gameObject.GetComponent<Criatura>();

            CriaturasAtivas novaCriatura = new CriaturasAtivas();

            novaCriatura.criatura=criaturasSpawnadas[i];
            novaCriatura.iniciativa=criaturasSpawnadas[i].iniciativa;

            criaturasAtivas.Add(novaCriatura);
        }

        criaturasAtivas.Sort((maior,menor)=>menor.iniciativa.CompareTo(maior.iniciativa));
    }

    private void Update()
    {
        ControleDeTurno();
    }

    private void ControleDeTurno()
    {
        for(int i=0; i<maxIndexCriaturas; i++){
            if(vezNoTurno==i){
                
                if(!criaturasAtivas[i].criatura.MeuTurno())
                {
                    criaturasAtivas[i].turnoAtual=false;
                    vezNoTurno++;
                }
                else
                {
                    criaturasAtivas[i].turnoAtual=true;
                }
                    
                if(vezNoTurno>=maxIndexCriaturas)
                    vezNoTurno=0;
            }
        }
    }
}

[System.Serializable]
public class CriaturasAtivas
{
    public Criatura criatura;
    public bool turnoAtual;
    public int iniciativa;
}

/*
        var gameOver = false;
     
    function Start () {
        while (!gameOver) {
            yield PlayerTurn();
            yield EnemyTurns();
        }
    }
    */
