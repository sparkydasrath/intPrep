namespace Arrays
{
    /*
     * https://www.youtube.com/watch?v=a7D77DdhlFc&list=PLamzFoFxwoNjw4EpaVZzP-8lqWA9hOmnD&index=2&t=0s
     */

    public class PeakElement
    {
        public int GetPeakElement(int[] elements)
        {
            for (int i = 1; i < elements.Length - 1; i++)
            {
                int left = i - 1;
                int right = i + 1;
                if (elements[i] > elements[left] && elements[i] > elements[right])
                    return elements[i];
            }

            return -1;
        }
    }
}