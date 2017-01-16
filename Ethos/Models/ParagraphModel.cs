using System;
using System.Linq;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ethos
{
	//class that stores the paragraph entered via input and performs the required functions.
	public class ParagraphModel
	{
		//property that stores the paragraph
		[Required]
		[Display(Name="Please enter your paragraph:")]
		public string Paragraph { get; set; }

		//we first split the paragraph string into an array of words.
		//we then reverse the array of words.
		//finally, we join the array back into a string.
		public string ReverseWordOrder(string paragraph)
		{
			string[] words = paragraph.Split(' ');
			Array.Reverse(words);
			return String.Join(" ", words);
		}

		//we first split the paragraph string into an array of words.
		//we then split every single word into an array of characters.
		//we then reverse every single of the character arrays.
		//finally, we join the arrays back into a string.
		public string ReverseCharacters(string paragraph)
		{
			return string.Join(" ",paragraph.Split(' ').Select(x => new String(x.Reverse().ToArray())));
		}

		//we first split the paragraph string into an array of words.
		//we then sort the array of words.
		//finally, we join the array back into a string.
		public string SortWords(string paragraph)
		{
			string[] words = paragraph.Split(' ');
			Array.Sort(words);
			return string.Join(" ", words);
		}

		//we first create a SHA384 hash.
		//then we compute the hash of the byte array of the paragraph.
		//finally, we join the byte array into a string.
		public string Encrypt(string paragraph)
		{
			byte[] data = Encoding.UTF8.GetBytes(paragraph);
			SHA384 hash = new SHA384Managed();
			byte[] result = hash.ComputeHash(data);
			return Encoding.UTF8.GetString(result);
		}
	}
}
