/*************************************************************************************************/
/*
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.
Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.
Each solution contains a distinct board configuration of the n-queens' placement, where 1 and 0 both indicate a queen and an empty space, respectively.
*/

#include <bits/stdc++.h>
#define N 4
using namespace std;

void printSolution(int board[N][N])
{
	for (int i = 0; i < N; i++)
	{
		for (int j = 0; j < N; j++)
			cout << " " << board[i][j] << " ";
		printf("\n");
	}
}

bool isSafe(int board[N][N], int row, int col)
{
	int i, j;

	for (i = 0; i < col; i++)
		if (board[row][i])
			return false;

	for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
		if (board[i][j])
			return false;

	for (i = row, j = col; j >= 0 && i < N; i++, j--)
		if (board[i][j])
			return false;

	return true;
}

bool solveNQUtil(int board[N][N], int col)
{
	if (col >= N)
		return true;

	for (int i = 0; i < N; i++)
	{
		if (isSafe(board, i, col))
		{
			board[i][col] = 1;

			if (solveNQUtil(board, col + 1))
				return true;

			board[i][col] = 0;
		}
	}

	return false;
}

bool solveNQ()
{
	int board[N][N] = {{0, 0, 0, 0},
					   {0, 0, 0, 0},
					   {0, 0, 0, 0},
					   {0, 0, 0, 0}};

	if (solveNQUtil(board, 0) == false)
	{
		cout << "Solution does not exist";
		return false;
	}

	printSolution(board);
	return true;
}

int main()
{
	solveNQ();
	return 0;
}
