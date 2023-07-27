import java.io.*;
import java.util.*;
public class ConcertTickets {

    public static void main(String[] args) throws IOException
    {

        r.tokenizer = new StringTokenizer(r.reader.readLine());

        int n = r.nextInt();
        int m = r.nextInt();

        TreeMap<Integer,Integer> cust_map =  new TreeMap<>();
        StringBuffer res =  new StringBuffer();

        Map.Entry<Integer,Integer> val;

        r.tokenizer = new StringTokenizer(r.reader.readLine());
        Integer temp;
        for(Integer i=0;i < n; i++)
        {
            temp = r.nextInt();
            if(cust_map.containsKey(temp))
            {
                cust_map.put(temp,cust_map.get(temp)+1);
            }
            else cust_map.put(temp, 1);
        }
        r.tokenizer = new StringTokenizer(r.reader.readLine());
        for (Integer i=0;i<m;i++)
        {
            temp = r.nextInt();
            val  = cust_map.lowerEntry(temp+1);
            if(val!=null)
            {
                res.append(val.getKey()).append("\n");
                if(val.getValue()==1)
                {
                    cust_map.remove(val.getKey());
                }
                else
                {
                    cust_map.put(val.getKey(),val.getValue()-1);
                }
            }
            else
            {
                res.append("-1\n");
            }
        }
        System.out.println(res);
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

    static InputReader r = new InputReader(System.in);
    static PrintWriter pw = new PrintWriter(System.out);

}
