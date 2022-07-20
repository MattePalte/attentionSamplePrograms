/*************************************************************************************************/
/*
The n-queens puzzle is the problem of placing n queens on an n x n chessboard such that no two queens attack each other.

Given an integer n, return all distinct solutions to the n-queens puzzle. You may return the answer in any order.

Each solution contains a distinct board configuration of the n-queens' placement, where 1 and 0 both indicate a queen and an empty space, respectively.
*/

using System;
	
class GFG
{
	readonly int N = 4;

	void printSolution(int [,]board)
	{
		for (int i = 0; i < N; i++)
		{
			for (int j = 0; j < N; j++)
				Console.Write(" " + board[i, j]
								+ " ");
			Console.WriteLine();
		}
	}

	bool isSafe(int [,]board, int row, int col)
	{
		int i, j;

		for (i = 0; i < col; i++)
			if (board[row,i] == 1)
				return false;

		for (i = row, j = col; i >= 0 &&
			j >= 0; i--, j--)
			if (board[i,j] == 1)
				return false;

		for (i = row, j = col; j >= 0 &&
					i < N; i++, j--)
			if (board[i, j] == 1)
				return false;

		return true;
	}

	bool solveNQUtil(int [,]board, int col)
	{
		if (col >= N)
			return true;

		for (int i = 0; i < N; i++)
		{
			if (isSafe(board, i, col))
			{
				board[i, col] = 1;

				if (solveNQUtil(board, col + 1) == true)
					return true;

				board[i, col] = 0;
			}
		}

		return false;
	}

	bool solveNQ()
	{
		int [,]board = {{ 0, 0, 0, 0 },
						{ 0, 0, 0, 0 },
						{ 0, 0, 0, 0 },
						{ 0, 0, 0, 0 }};

		if (solveNQUtil(board, 0) == false)
		{
			Console.Write("Solution does not exist");
			return false;
		}

		printSolution(board);
		return true;
	}

	public static void Main(String []args)
	{
		GFG Queen = new GFG();
		Queen.solveNQ();
	}
}

// Question: What does `solveNQ(-13)` return?
// Answer:
