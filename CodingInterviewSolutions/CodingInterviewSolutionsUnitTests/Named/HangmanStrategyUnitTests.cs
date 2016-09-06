using System;

using CodingInterviewSolutions.Named;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingInterviewSolutionsUnitTests.Named
{
	[TestClass]
	public class HangmanStrategyUnitTests
	{
		[TestMethod]
		public void PlayHangman()
		{
			var hangmanOptions = HangmanStrategy.HangmanGame.PoolOfWords;
			foreach (var hangmanOption in hangmanOptions)
			{
				HangmanStrategy.HangmanGame game = new HangmanStrategy.HangmanGame(hangmanOption);

				string word = HangmanStrategy.SolveHangman(game);
				word.Should().Be(hangmanOption);
				Console.WriteLine("Guessed {0} with {1} mistakes.", word, game.GetMistakes());
			}
		}
	}
}
