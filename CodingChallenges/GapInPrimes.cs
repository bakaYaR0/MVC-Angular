using System;

class GapInPrimes
{
    public static long[] Gap(int g, long m, long n)
    {
        // your code
        for (long i = m; i <= n - g; i++)
        {
            long first = i;
            long second = i + g;
            if (GapInPrimes.IsPrime(first) & GapInPrimes.IsPrime(second))
            {
                if (!ContainsPrimes(first, second))
                    return new long[] { first, second };
            }
        }
        return null;
    }

    public static bool ContainsPrimes(long first, long second)
    {
        for (long i = first + 1; i < second; i++)
        {
            if (GapInPrimes.IsPrime(i))
                return true;
        }
        return false;
    }

    public static bool IsPrime(long number)
    {
        if (number % 2 == 0) return false;

        var boundary = (long)Math.Floor(Math.Sqrt(number));

        for (long i = 3; i <= boundary; i += 2)
            if (number % i == 0)
                return false;

        return true;
    }
}
