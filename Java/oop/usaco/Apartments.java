import java.io.*;
import java.util.*;
public class Apartments {

    public static void main(String[] args) throws IOException
    {

        r.tokenizer = new StringTokenizer(r.reader.readLine());

        int number_of_applicant = r.nextInt();
        int number_of_apparment_size = r.nextInt();
        int max_allowed_diff = r.nextInt();

        ArrayList<Integer> apparment_size =  new ArrayList<Integer>();
        TreeSet<Integer> allowed_to_allot =  new TreeSet<Integer>();
        StringTokenizer appli_st = new StringTokenizer(r.reader.readLine());

        r.tokenizer = new StringTokenizer(r.reader.readLine());

        Integer count=0;
        while(r.tokenizer.hasMoreTokens() && number_of_apparment_size > count++)
        {
            apparment_size.add(r.nextInt());
        }
        count=0;
        while(appli_st.hasMoreTokens() && number_of_applicant > count++)
        {
            int applicant = Integer.parseInt(appli_st.nextToken());

            //|| apparment_size.stream().anyMatch(i-> i <= applicant + max_allowed_diff && i >= applicant - max_allowed_diff )
            if(apparment_size.contains(applicant) ){
                allowed_to_allot.add(applicant);
            }
            else{
                for (int item:apparment_size) {
                    if(item >= applicant - max_allowed_diff && item <= applicant + max_allowed_diff)
                    {
                        allowed_to_allot.add(applicant);
                        continue;
                    }
                }
            }
        }

        System.out.println(allowed_to_allot.size());

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