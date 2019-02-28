using System.Text;

namespace Google
{
    public class SummaryRanges
    {
        // 228
        public string SummaryRanges2(int[] nums)
        {
            StringBuilder sb = new StringBuilder();
            int head = 0;
            int tail = 0;
            for (head = 1; head < nums.Length; head++)
            {
                int tailVal = nums[tail];
                int headVal = nums[head];
                if (headVal - nums[head - 1] == 1)
                {
                    continue;
                }

                if (head - tail > 1)
                {
                    sb.Append(nums[tail] + "->" + nums[head - 1]);
                    tail = head;
                }
                else
                {
                    sb.Append(nums[tail]);
                    tail = head;
                }
            }

            return sb.ToString();
        }
    }
}