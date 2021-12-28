namespace patternMatching
{
    public class PatternMatcher
    {

        public PatternMatcher()
        {
        }

        public bool Test(string text, string pattern)
        {            
            var textLength = ( text != null ?  text.Length : 0 );
            var patternLength = ( pattern != null ? pattern.Length : 0);

            if (patternLength == 0 ) {
                return textLength == 0;  // empty pattern can only match with empty string
            }

            // lookup table for storing the result of subproblems
            bool [,] lookup  = new bool[textLength +1, patternLength + 1];

            // empty pattern matches empty string
            lookup[0,0] = true;

            // only * can match with empty string
            for (int patternIndex = 1; patternIndex < patternLength; patternIndex++) {
                if (pattern[patternIndex-1] == '*') {
                    lookup[0,patternIndex] = lookup[0, patternIndex -1];
                }
            }

            // fill the table in bottom up fashion
            for (int textIndex = 1; textIndex <= textLength; textIndex++) {
                for (int patternIndex = 1; patternIndex <= patternLength; patternIndex++) {
                    //2 case we ither ignore * and move to next charact or * matches the current char
                    if (pattern[patternIndex-1] == '*'){
                        lookup[textIndex, patternIndex] = lookup[textIndex,patternIndex-1] || lookup[textIndex-1, patternIndex];   
                    } else if (pattern[patternIndex-1]  == '?' || pattern[patternIndex-1 ] == text[textIndex-1]) {
                        // ? or chars really match
                        lookup[textIndex, patternIndex] = lookup[textIndex - 1, patternIndex - 1];
                    }
                    else{
                        lookup[textIndex, patternIndex] = false;
                    }
                }
            }
            
            return lookup[textLength,patternLength];
        }

    }
}

