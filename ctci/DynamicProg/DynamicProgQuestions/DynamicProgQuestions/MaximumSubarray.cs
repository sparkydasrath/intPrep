namespace DynamicProgQuestions
{
    public class MaximumSubarray
    {
        public MaximumSubarrayResult GetMaxSubarray(int[] array)
        {
            int maxEndHere = 0;
            int maxSoFar = array[0];
            int start = 0;
            int end = 0;
            int s = 0;

            for (int i = 0; i < array.Length; i++)
            {
                // maxEnd = Math.Max(array[i], maxEnd + array[i]); maxSoFar = Math.Max(maxSoFar, maxEnd);
                maxEndHere = maxEndHere + array[i];
                if (maxEndHere < 0)
                {
                    maxEndHere = 0;
                    s = i + 1;
                }

                if (maxSoFar < maxEndHere)
                {
                    maxSoFar = maxEndHere;
                    start = s;
                    end = i;
                }
            }

            return new MaximumSubarrayResult { MaxSum = maxSoFar, StartIndex = start, EndIndex = end };
        }

        public struct MaximumSubarrayResult
        {
            public int EndIndex { get; set; }
            public int MaxSum { get; set; }
            public int StartIndex { get; set; }
        }
    }
}