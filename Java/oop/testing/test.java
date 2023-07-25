import java.io.PrintWriter;
import java.io.*;
import java.util.*;

public final class test extends a {

    static PrintWriter pw = new PrintWriter(System.out);
    final int index = 50;
    public static void main(String[] args) {
         first:{
            System.out.println("First statement");
            break first;
         }

         char c = '\u001F';
        System.out.println(c);
        for(int i=0; i< args.length;i++)
        {
            System.out.println(args[i]);   
           // break;   
        }

        for(;;){
            break;
        }            

       pw.println("hello");
    }    
}

sealed class a permits test {

} 
