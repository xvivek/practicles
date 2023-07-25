import java.io.*;
import java.util.*;

public class DistinctNumbers {
    static InputReader r = new InputReader(System.in);
    static PrintWriter pw = new PrintWriter(System.out);
    public static void main(String[] args) throws IOException
    {
        r.tokenizer = new StringTokenizer(r.reader.readLine());
        TreeSet<Integer> set = new TreeSet<>();
        int nemberOfItems = r.nextInt();

        r.tokenizer = new StringTokenizer(r.reader.readLine());
        int tokensRead = 0;

        while(r.tokenizer.hasMoreTokens() && nemberOfItems>tokensRead++){
            int a = r.nextInt();
            set.add(a);
        }
        System.out.println(set.size());
    }

    static class InputReader {
        BufferedReader reader;
        StringTokenizer tokenizer;

        public InputReader(InputStream stream) {
            reader = new BufferedReader(new InputStreamReader(stream), 32768);
            tokenizer = null;
        }

        String next()
        { // reads in the next string
            while (tokenizer == null || !tokenizer.hasMoreTokens()) {
                try {
                    tokenizer = new StringTokenizer(reader.readLine());
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
            return tokenizer.nextToken();
        }

        public int nextInt()
        { // reads in the next int
            return Integer.parseInt(next());
        }

        public long nextLong()
        { // reads in the next long
            return Long.parseLong(next());
        }

        public double nextDouble()
        { // reads in the next double
            return Double.parseDouble(next());
        }
    }
}