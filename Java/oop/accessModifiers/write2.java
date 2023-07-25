package com.vivek.access1;

public class write2 {
    
    private int number_of_files = 10;

    private void f3()
    {
        number_of_files=11;
        f2();
    }

    private void f2()
    {

        System.out.println("write2->f2()");

    }
}
