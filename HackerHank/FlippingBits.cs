namespace HackerHank
{
    public static class FlippingBits
    {
        //You will be given a list of 32 bit unsigned integers. Flip all the bits.
        public static long flippingBits(long n)
            => n ^ 0b_1111_1111_1111_1111_1111_1111_1111_1111;
    }
}
