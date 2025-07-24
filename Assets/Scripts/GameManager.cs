using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System;

public class GameManager : MonoBehaviour
{
    public enum Choice { None, Rock, Paper, Scissors }

    public TMP_Text playerChoiceText;
    public TMP_Text computerChoiceText;
    public TMP_Text resultText;



    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button shootButton;
    public Button replayButton;

    private Choice playerChoice = Choice.None;
    private Choice computerChoice = Choice.None;
    private bool gamePlayed = false;

    void Start()
    {
        ResetGame();
    }

    public void SelectRock() { if (!gamePlayed) playerChoice = Choice.Rock; }
    public void SelectPaper() { if (!gamePlayed) playerChoice = Choice.Paper; }
    public void SelectScissors() { if (!gamePlayed) playerChoice = Choice.Scissors; }

    public void OnShoot()
    {
        if (playerChoice == Choice.None || gamePlayed) return;

        computerChoice = (Choice)UnityEngine.Random.Range(1, 4);

        playerChoiceText.text = "Player: " + playerChoice.ToString();
        computerChoiceText.text = "Computer: " + computerChoice.ToString();
        resultText.text = "Result: " + DetermineWinner(playerChoice, computerChoice);

        gamePlayed = true;
        replayButton.gameObject.SetActive(true);
    }

    public void OnReplay()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        playerChoice = Choice.None;
        computerChoice = Choice.None;
        playerChoiceText.text = "Player: ";
        computerChoiceText.text = "Computer: ";
        resultText.text = "Result: ";
        gamePlayed = false;
        replayButton.gameObject.SetActive(false);
    }

    private string DetermineWinner(Choice player, Choice computer)
    {
        if (player == computer) return "It's a Tie!";
        if ((player == Choice.Rock && computer == Choice.Scissors) ||
            (player == Choice.Paper && computer == Choice.Rock) ||
            (player == Choice.Scissors && computer == Choice.Paper))
        {
            return "You Win!";
        }
        else
        {
            return "Computer Wins!";
        }
    }
}
