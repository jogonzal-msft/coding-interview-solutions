using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterviewSolutions.Named
{
	/// <summary>
	/// 
	/// </summary>
	public class HangmanStrategy
	{
		public class HangmanGame
		{
			public static IReadOnlyList<string> PoolOfWords = new List<string>()
			{
				"jorge",
				"boat",
				"mauri",
				"interview",
				"question",
				"coat",
				"dog",
				"cat",
				"serial",
				"lake",
				"tree",
				"doggy",
				"pluto",
				"jupiter",
				"saturn",
				"neptune",
				"play",
				"playing",
				"blue",
				"red",
				"brown",
				"white",
				"black",
				"gray"
			};

			private char[] _word;

			private HashSet<char> _guessedChars;
			private bool[] _guessed;

			public bool[] GuessedCharacters()
			{
				return (bool[])_guessed.Clone();
			}

			private int _mistakes;

			public HangmanGame MakeRandomGame()
			{
				Random r = new Random();
				int rand = r.Next(0, PoolOfWords.Count - 1);
				string word = PoolOfWords[rand];
				return new HangmanGame(word);
			}

			public HangmanGame(string word)
			{
				_word = word.ToCharArray();
				_guessed = new bool[_word.Length];
				_guessedChars = new HashSet<char>();
				_mistakes = 0;
			}

			public int WordLength()
			{
				return _word.Length;
			}

			public enum GuessResult
			{
				No,
				Yes,
				Won,
				Lost
			}

			public GuessResult Guess(char guessedCharacter)
			{
				if (!_guessedChars.Add(guessedCharacter))
				{
					throw new InvalidOperationException("Guessed same character twice!");
				}

				bool guessedCorrectly = false;
				for (int index = 0; index < _word.Length; index++)
				{
					var character = _word[index];
					if (character == guessedCharacter)
					{
						_guessed[index] = true;
						guessedCorrectly = true;
					}
				}

				if (!guessedCorrectly)
				{
					_mistakes++;
					if (_mistakes > MaxAttempts)
					{
						return GuessResult.Lost;
					}

					return GuessResult.No;
				}
				if (_guessed.All(n => n))
				{
					return GuessResult.Won;
				}
				return GuessResult.Yes;
			}

			public int GetMistakes()
			{
				return _mistakes;
			}

			public const int MaxAttempts = 3;
		}

		public static string SolveHangman(HangmanGame game)
		{
			// Hangman chose a word from pool of words
			// Find all the words of that length and put them on a list
			List<string> listOfPossibleWords = HangmanGame.PoolOfWords.Where(w => w.Length == game.WordLength()).ToList();

			HashSet<char> guessedCharacters = new HashSet<char>();
			char[] word = new char[game.WordLength()];

			// On the first iteration, all characters are possible. Afterwards, some positions will be restricted
			while (true)
			{
				bool[] before = game.GuessedCharacters();
				char characterToGuess = GetMaxChar(listOfPossibleWords, before, guessedCharacters);
				guessedCharacters.Add(characterToGuess);
				var guessResult = game.Guess(characterToGuess);
				bool[] after = game.GuessedCharacters();
				switch (guessResult)
				{
					case HangmanGame.GuessResult.No:
						RemoveWordsWithCharacter(listOfPossibleWords, characterToGuess);
						break;
					case HangmanGame.GuessResult.Yes:
						bool[] diff = GetDiff(after, before);
						WriteToWord(word, diff, characterToGuess);
						KeepOnlyWordsWithCharacterAtPosition(listOfPossibleWords, characterToGuess, diff);
						break;
					case HangmanGame.GuessResult.Won:
						WriteToWord(word, GetDiff(after, before), characterToGuess);
						return new string(word);
					case HangmanGame.GuessResult.Lost:
						throw new InvalidOperationException("Cannot lose!");
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private static void WriteToWord(char[] word, bool[] diff, char guessedCharacter)
		{
			for (int i = 0; i < diff.Length; i++)
			{
				if (diff[i])
				{
					word[i] = guessedCharacter;
				}
			}
		}

		private static void KeepOnlyWordsWithCharacterAtPosition(List<string> listOfPossibleWords, char characterToGuess, bool[] diff)
		{
			listOfPossibleWords.RemoveAll((possibleWord) =>
			{
				bool containsCharacterAtPositon = false;
				for (int i = 0; i < diff.Length; i++)
				{
					if (diff[i] && possibleWord[i] == characterToGuess)
					{
						containsCharacterAtPositon = true;
					}
				}
				return !containsCharacterAtPositon;
			});
		}

		private static bool[] GetDiff(bool[] after, bool[] before)
		{
			var result = new bool[after.Length];
			for (int i = 0; i < after.Length; i++)
			{
				if (after[i] && !before[i])
				{
					result[i] = true;
				}
			}
			return result;
		}

		private static char GetMaxChar(List<string> possibleWords, bool[] guessed, HashSet<char> guessedCharacters)
		{
			Dictionary<char, int> charCounts = new Dictionary<char, int>();
			foreach (var possibleWord in possibleWords)
			{
				for (int index = 0; index < possibleWord.Length; index++)
				{
					var character = possibleWord[index];
					if (guessedCharacters.Contains(character))
					{
						continue;
					}

					if (guessed[index])
					{
						continue;
					}

					int count;
					if (!charCounts.TryGetValue(character, out count))
					{
						charCounts[character] = 1;
					}
					charCounts[character] = count + 1;
				}
			}

			KeyValuePair<char, int>? kvpMax = null;
			foreach (var i in charCounts)
			{
				if (kvpMax == null || kvpMax.Value.Value < i.Value)
				{
					kvpMax = i;
				}
			}
			return kvpMax.Value.Key;
		}

		private static void RemoveWordsWithCharacter(List<string> listOfPossibleWords, char character)
		{
			listOfPossibleWords.RemoveAll(word =>
			{
				return word.Contains(character);
			});
		}
	}
}
