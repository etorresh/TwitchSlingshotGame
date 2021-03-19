using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersHandler : MonoBehaviour
{
    private List<string> playerList;
    private string player1;
    private string player2;
    public void JoinGame(string playerId)
    {
        if(!playerList.Contains(playerId))
        {
            playerList.Add(playerId);
        }
    }
    public void Shoot(string shootArgs)
    {
        // Filtrar fuerza y angulo
        // Agregar disparo a una lista de espera si no es su turno
    }
    public void StartGame()
    {
        if(playerList.Count > 1)
        {
            player1 = playerList[0];
            player2 = playerList[1];
            playerList.RemoveRange(0, 2);
        }
        Debug.Log("Hay menos de 2 jugadores en la lista");
    }
}
