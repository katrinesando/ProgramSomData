
public class Merge
{
    static int[] merge(int[] xs, int[] ys)
    {
        int[] arr = new int[xs.Length + ys.Length];
        int ind = 0;
        int i = 0, j = 0;
        while (ind < arr.Length)
        {
            if (xs[i] <= ys[j])
            {
                arr[ind++] = xs[i++];
            }
            else
            {
                arr[ind++] = ys[j++];
            }
        }

        return arr;
    }

    
}