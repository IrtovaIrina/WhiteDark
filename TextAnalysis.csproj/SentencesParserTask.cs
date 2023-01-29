using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();

            char[] delimiterChars = { '.', '!', '?', ':', ';', '(', ')' };

            string[] sentences = text.ToLower().Split(delimiterChars).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            foreach (string sentence in sentences)
            {
                List<string> words = new List<string>();

                int startLetter = -1;
                for (int i = 0; i < sentence.Length; i++)
                {
                    if (char.IsLetter(sentence[i]) || sentence[i].Equals('\''))
                    {
                        if (startLetter == -1)
                            startLetter = i;
                    }
                    else
                    {
                        if (startLetter != -1)
                            words.Add(sentence.Substring(startLetter, i - startLetter));

                        startLetter = -1;
                    }

                    if (i == sentence.Length - 1 && startLetter != -1)
                        words.Add(sentence.Substring(startLetter, sentence.Length - startLetter));
                }

                if (words.Count > 0)
                    sentencesList.Add(words);
            }

            return sentencesList;
        }
    }
}