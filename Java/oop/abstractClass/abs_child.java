package com.vivek.abstractclass;

import com.vivek.abstractclass.abs_parent;

public abstract class abs_child extends  abs_parent{

    public static void main(String[] args) 
    {        
        abs_child c =  new com.vivek.abstractclass.abs_child2();
        c.m1();
        c.m2();
    }

    @Override
    public void m1() {
        System.out.println("m1");
    }  
    
 
}
