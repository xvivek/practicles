package com.vivek.HowToSolveItByComputer;

public class reverse_value {
    public static void main(String[] args) {
        
        reverse_value rev =  new reverse_value();

        System.out.println("*********reverse_with_temp_variable***********");
        rev.reverse_with_temp_variable();

        System.out.println("*********reverse_with_out_temp_variable***********");
        rev.reverse_with_out_temp_variable();
    }

    private void reverse_with_temp_variable()
    {

        int x,y,z;
        x=5000;
        y=6000;

        System.out.println("*********BEFORE***********");
        System.out.println(" First Value is " + x);
        System.out.println(" Second Value is " + y);

        z = x;
        x = y;
        y = z;
        System.out.println("*********AFTER***********");
        System.out.println(" First Value is " + x);
        System.out.println(" Second Value is " + y);
    }

    private void reverse_with_out_temp_variable()
    {
        int x,y;
        x=5000;
        y=6000;

        System.out.println("*********BEFORE***********");
        System.out.println(" First Value is " + x);
        System.out.println(" Second Value is " + y);

        x = x + y;
        y = x - y;
        x = x - y;
        System.out.println("*********AFTER***********");
        System.out.println(" First Value is " + x);
        System.out.println(" Second Value is " + y);
    }
}
