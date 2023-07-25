package com.vivek.access1;

public class accessModifiers {
    public static void main(String[] args) {
       // com.vivek.access1.write1 w =  new com.vivek.access1.write1(3);
       // w.f1();

        //w.f2();
        //w.f3();

        x x1 =  new x(6);
        x1.show();
    }
}

class x{
    
    public x()
    {
        System.out.println("default");
    }
    public x(int i)
    {       
        System.out.println("non default");
    }

    public void show(){}
}
