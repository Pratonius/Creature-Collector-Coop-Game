using System;
using UnityEngine;

public class AIManager : MonoBehaviour {

    private readonly int[,] fieldValues = {{3,2,3}, {2,4,2}, {3,2,3}};

    public TicTacToeManager ticTacToeManager;

    readonly Player aiPlayer = Player.O;
    readonly Player player = Player.X;
    readonly Player noPlayer = Player.EMPTY;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        AiMove();
    }

    Player[,] GetGrid() {
        return ticTacToeManager.GetGrid();
    }

    bool IsValidMove(int row, int col) {
        return row >= 0 && row < ticTacToeManager.GetSize() && col >= 0 && col < ticTacToeManager.GetSize() && GetGrid()[row, col] == Player.EMPTY;
    }

    bool MakeMove(int row, int col, Player player) {
        if (IsValidMove(row, col)) {
            GetGrid()[row, col] = player;
            UpdateHighlightOnHover(row, col, player);
            ticTacToeManager.IsGameOver();
            return true;
        }
        return false;
    }

    void UpdateHighlightOnHover(int row, int col, Player player) {
        HighlightOnHover[] highlights = FindObjectsOfType<HighlightOnHover>();
        foreach (HighlightOnHover highlight in highlights) {
            if (highlight.row == row && highlight.column == col) {
                if (player == this.player) {
                    highlight.SetSprite(highlight.xSprite);
                } else if (player == aiPlayer) {
                    highlight.SetSprite(highlight.oSprite);
                }
                break;
            }
        }
    }

    public void AiMove() {
        if (ticTacToeManager.GetCurrentPlayer() == aiPlayer && !ticTacToeManager.IsGameOver()) {
            int[] bestMove = MinimaxAlphaBeta(GetGrid(), 0, int.MinValue, int.MaxValue, true);
            Debug.Log("best AI move score: " + bestMove[0]);
            Debug.Log("best AI move: (" + bestMove[1] + ", " + bestMove[2] + ")");
            bool canMakeMove = MakeMove(bestMove[1], bestMove[2], aiPlayer);
            if (canMakeMove) {
                ticTacToeManager.SwitchPlayer();
            } else {
                AiMove();
            }
        }
    }

    int[] MinimaxAlphaBeta(Player[,] board, int depth, int alpha, int beta, bool maximizingPlayer) {
        //Node is leaf
        if (depth >= 5 || ticTacToeManager.IsGameOver()) {
            return new int[] {Evaluate(board)};
        }

        int bestScore;
        int[] bestMove = new int[] {-1, -1};

        //node is max
         if (maximizingPlayer) {
            bestScore = int.MinValue;
            for (int i = 0; i < ticTacToeManager.GetSize(); i++) {
                for (int j = 0; j < ticTacToeManager.GetSize(); j++) {
                    if (board[i,j] == noPlayer) {
                        board[i,j] = aiPlayer;
                        if (ticTacToeManager.HasWon(aiPlayer)) {
                            bestScore = int.MaxValue;
                            bestMove[0] = i;
                            bestMove[1] = j;
                            board[i,j] = noPlayer;
                            break;
                        } else {
                            int[] score;
                            if (depth != 0) {
                                score = MinimaxAlphaBeta(board, depth - 1, alpha, beta, false);
                            }
                            score = MinimaxAlphaBeta(board, depth + 1, alpha, beta, false);
                            if (!AiMoveLeadsToLoss(board, i, j)) {
                                score[0] += 24;
                            }
                            if (score[0] > bestScore) {
                                bestScore = score[0];
                                bestMove[0] = i;
                                bestMove[1] = j;
                            }
                            alpha = Math.Max(alpha, bestScore);
                            if (beta <= alpha) {
                                board[i,j] = noPlayer;
                                break;
                            }
                            board[i,j] = noPlayer;
                        }
                        board[i,j] = noPlayer;
                    }
                }
            }
        //node is min
        } else {
            bestScore = int.MaxValue;
            for (int i = 0; i < ticTacToeManager.GetSize(); i++) {
                for (int j = 0; j < ticTacToeManager.GetSize(); j++) {
                    if (board[i,j] == noPlayer) {
                        board[i,j] = player;
                        int[] score = MinimaxAlphaBeta(board, depth + 1, alpha, beta, true);
                        board[i,j] = noPlayer;
                        if (score[0] < bestScore) {
                            bestScore = score[0];
                            bestMove[0] = i;
                            bestMove[1] = j;
                        }
                        beta = Math.Min(beta, bestScore);
                        if (beta <= alpha) {
                            break;
                        }
                    }
                }
            }
        }
        return new int[] {bestScore, bestMove[0], bestMove[1]};
    }

    int Evaluate(Player[,] board) {
        int aiScore = 0;
        int opponentScore = 0;
        for (int i = 0; i < ticTacToeManager.GetSize(); i++) {
            for (int j = 0; j < ticTacToeManager.GetSize(); j++) {
                if (board[i,j] == aiPlayer) {
                    aiScore += fieldValues[i,j];
                } else if (board[i,j] == player) {
                    opponentScore += fieldValues[i,j];
                }
            }
        }
        return aiScore - opponentScore;
    }

    bool AiMoveLeadsToLoss(Player[,] board, int row, int col) {
        for (int i = 0; i < ticTacToeManager.GetSize(); i++) {
            for (int j = 0; j < ticTacToeManager.GetSize(); j++) {
                if (board[i,j] == noPlayer) {
                    board[i,j] = player;
                    if (ticTacToeManager.HasWon(player)) {
                        board[i,j] = noPlayer;
                        return true;
                    }
                    board[i,j] = noPlayer;
                }
            }
        }
        return false;
    }
}
