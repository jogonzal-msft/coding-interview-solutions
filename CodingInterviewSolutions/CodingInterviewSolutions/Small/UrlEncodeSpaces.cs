namespace CodingInterviewSolutions.Small
{
	/// <summary>
	/// Given a string (as an array of characters) replace all spaces with "%20"
	/// </summary>
	public static class UrlEncodeSpaces
	{
		public static char[] EncodeSpaces(char[] input)
		{
			if (input == null || input.Length == 0)
			{
				// Nothing to do here
				return input;
			}

			// Count the spaces
			int numberOfSpaces = 0;
			for (int i = 0; i < input.Length; i++)
			{
				if (input[i] == ' ')
				{
					numberOfSpaces++;
				}
			}

			if (numberOfSpaces == 0)
			{
				return input;
			}

			char[] output = new char[input.Length + numberOfSpaces * 2];
			int outputOffset = 0;
			for (int inputOffset = 0; inputOffset < input.Length; inputOffset++)
			{
				if (input[inputOffset] == ' ')
				{
					output[outputOffset++] = '%';
					output[outputOffset++] = '2';
					output[outputOffset++] = '0';
				}
				else
				{
					output[outputOffset++] = input[inputOffset];
				}
			}

			return output;
		}
	}
}
