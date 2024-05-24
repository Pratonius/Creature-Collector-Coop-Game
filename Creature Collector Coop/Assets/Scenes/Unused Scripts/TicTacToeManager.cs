using System.Drawing;
using UnityEngine;

public enum Player {
    EMPTY,
    X,
    O
}

public class TicTacToeManager : MonoBehaviour {
    public readonly static int SIZE = 3;
    // Game grid represented as a 2D array
    private Player[,] grid = new Player[SIZE, SIZE];

    private Player currentPlayer = Player.X;

    // Start is called before the first frame update
    void Start() {
        InitializeGrid();
    }

    // Initialize the grid with default values
    void InitializeGrid() {
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                grid[i, j] = Player.EMPTY;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        // Game logic can be added here
    }

    public bool PlayerMove(int row, int column) {
        if (enabled) {
            if (grid[row, column] == Player.EMPTY) {
                grid[row, column] = currentPlayer;
                return true;
            } else {
                return false;
            }
        } else {
            return false;
        }
    }

    public bool IsGameOver() {
        return GameHasBeenWon() || IsDraw();
    }

    public bool GameHasBeenWon() {
        return HasWon(Player.X) || HasWon(Player.O);
    }

    public bool HasWon(Player player) {
        // Check rows
        for (int i = 0; i < SIZE; i++) {
            if (grid[i,0] == player && grid[i,1] == player && grid[i,2] == player) {
                return true;
            }
        }
        // Check columns
        for (int j = 0; j < SIZE; j++) {
            if (grid[0,j] == player && grid[1,j] == player && grid[2,j] == player) {
                return true;
            }
        }
        // Check diagonals
        if ((grid[0,0] == player && grid[1,1] == player && grid[2,2] == player) ||
                (grid[0,2] == player && grid[1,1] == player && grid[2,0] == player)) {
            return true;
        }
        return false;
    }

    public bool IsDraw() {
        for (int i = 0; i < SIZE; i++) {
            for (int j = 0; j < SIZE; j++) {
                if (grid[i,j] == Player.EMPTY) {
                    return false;
                }
            }
        }
        return true;
    }

    public Player GetCurrentPlayer() {
        return currentPlayer;
    }

    public void SwitchPlayer() {
        if (!IsGameOver()) {
            currentPlayer = (currentPlayer == Player.X) ? Player.O : Player.X;
        }
    }

    public int GetSize(){
        return SIZE;
    }

    public Player[,] GetGrid() {
        return grid;
    }
}
