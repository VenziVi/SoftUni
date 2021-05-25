using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04Froggy
{
    public class Lake : IEnumerable<int>
    {
        List<int> stones;

        public Lake(List<int> stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int count = stones.Count;

            for (int i = 0; i < stones.Count; i += 2)
            {
                yield return stones[i];
            }

            if (stones.Count % 2 != 0)
            {
                count = stones.Count - 1;
            }
            for (int i = count - 1; i >= 0; i -= 2)
            {
                yield return stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
