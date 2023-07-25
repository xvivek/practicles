package usaco.template;

import java.io.*;
import java.util.*;

public class template1 {
    public static void main(String[] args)  throws IOException
    {
        BufferedReader r = new BufferedReader(new FileReader("template.in"));
        PrintWriter pw = new PrintWriter(new BufferedWriter(new FileWriter("template.out")));
        StringTokenizer st = new StringTokenizer(r.readLine());
        int n = Integer.parseInt(st.nextToken());

        r.close();  
        pw.close();

    }
}
