package DDA;

import java.io.*;
import java.util.*;

public class max2val {

    static InputReader r = new InputReader(System.in);

    public static void main(String[] args)  throws IOException {

      System.out.println(noDuplicate());
    }

     static void Max2No() throws IOException
    {
        r.tokenizer = new StringTokenizer(r.reader.readLine());

        ArrayList<Integer> a =  new ArrayList();

        while(r.tokenizer.hasMoreTokens())
        {
            a.add(r.nextInt());
        }

        if(a!=null && a.size()!=0)
        {
            Integer max = a.get(0);

            for(int i = 1; i< a.size();i++)
            {
                if(a.get(i) > max)
                {
                    max = a.get(i);
                }
            }

            System.out.print(max);
        }
    }


    static boolean noDuplicate()  throws IOException
    {
        r.tokenizer = new StringTokenizer(r.reader.readLine());

        ArrayList a =  new ArrayList();

        while(r.tokenizer.hasMoreTokens() )
        {
            a.add(r.nextInt());
        }

        for(int i=0; i< a.size(); i++)
        {
            for(Integer j=i+1; j< a.size();j++)
            {
                if(a.get(i)==a.get(j))
                    return false;
            }
        }

        return true;
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
