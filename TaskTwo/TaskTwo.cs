using System;

namespace TaskTwo
{
    class TaskTwo
    {
        static void Main(string[] args)
        {
            Console.WriteLine(solution(new int[4] {1, 2, 3, 4}));
        }
        public static int solution(int[] A) {
            int ans = 0;
            for (int i = 1; i < A.Length; i++) {
                if (A[i] < ans) {
                    ans = A[i];
                }
            }
            return ans;
        }
    }
}
