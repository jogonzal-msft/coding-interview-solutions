using System;
using System.Collections.Generic;

namespace CodingInterviewSolutions.Named
{
	public static class CountRegionsInBoolArray
	{
		/// <summary>
		/// Given a bidimensional array of booleans, find the number of regions that are contained in that array
		/// A region is defined by adjacent values of "true"
		/// </summary>
		public static int FindCountRegionsWithTrue(bool[,] matrix)
		{
			if (matrix == null)
			{
				throw new ArgumentNullException("matrix");
			}

			int rowCount = matrix.GetLength(0);
			int columnCount = matrix.GetLength(1);

			if (!(rowCount > 0 && columnCount > 0))
			{
				throw new ArgumentException("Array must have at least one element!");
			}

			int totalNumberOfRegions = 0;
			// At this point, we have a rectangular matrix of rowCount x columnCount
			// Create a new matrix for tracking, all initialized to false
			bool[,] myBooleanMatrixForTracking = new bool[rowCount,columnCount];

			for (int r = 0; r < rowCount; r++)
			{
				for (int c = 0; c < columnCount; c++)
				{
					if (myBooleanMatrixForTracking[r, c])
					{
						// If we've already visited this cell, continue
						continue;
					}

					// We haven't visited this cell. If it's true, increment the number of count in the
					// total regions and explore all adjacent "true" regions
					// NOTE: There is a recursive solution here, but we're opting for an iterative solution, since that
					// is more efficient, uses less memory and is in general more performant
					if (matrix[r, c])
					{
						totalNumberOfRegions++;
						Stack<Tuple<int, int>> pendingCoordinatesToExplore = new Stack<Tuple<int, int>>();
						AddAdjacentValues(pendingCoordinatesToExplore, r, c, rowCount, columnCount);
						myBooleanMatrixForTracking[r, c] = true;

						while (pendingCoordinatesToExplore.Count != 0)
						{
							// Pop from the stack
							Tuple<int, int> coordinatesToExplore = pendingCoordinatesToExplore.Pop();

							// If explored already, skip
							if (myBooleanMatrixForTracking[coordinatesToExplore.Item1, coordinatesToExplore.Item2])
							{
								// If we've already visited this cell, continue
								continue;
							}

							// Mark as explored
							myBooleanMatrixForTracking[coordinatesToExplore.Item1, coordinatesToExplore.Item2] = true;

							// If it is true, add adjacent coordinates to the stack
							if (matrix[coordinatesToExplore.Item1, coordinatesToExplore.Item2])
							{	
								AddAdjacentValues(pendingCoordinatesToExplore, coordinatesToExplore.Item1, coordinatesToExplore.Item2, rowCount, columnCount);
							}
						}
					}
				}
			}

			return totalNumberOfRegions;
		}

		private static void AddAdjacentValues(Stack<Tuple<int, int>> stack, int r, int c, int rowCount, int columnCount)
		{
			// Add upper
			AddIfValid(stack, r - 1, c, rowCount, columnCount);
			// Add lower
			AddIfValid(stack, r + 1, c, rowCount, columnCount);
			// Add left
			AddIfValid(stack, r, c - 1, rowCount, columnCount);
			// Add right
			AddIfValid(stack, r, c + 1, rowCount, columnCount);
		}

		private static void AddIfValid(Stack<Tuple<int, int>> stack, int r, int c, int rowCount, int columnCount)
		{
			if (IsCoordinateValid(r, c, rowCount, columnCount))
			{
				stack.Push(new Tuple<int, int>(r, c));
			}
		}

		private static bool IsCoordinateValid(int r, int c, int rowCount, int columnCount)
		{
			return (r >= 0 && r < rowCount && c >= 0 && c < columnCount);
		}
	}
}
