package com.vivek.abstractclass;

import com.vivek.abstractclass.abs_child;

public class abs_child2 extends abs_child {

    @Override
    public void m2() {
        System.out.println("m2");

        m3();

        abs_child3 m3 =  new abs_child3();
        m3.m3();
    }
    
    @Override
    protected void m3() {
        System.out.println("abs_child.m3()");
    } 
}

class abs_child3 
{
    protected void m3()
    {
        System.out.println("abs_child3.m3()");
    }
}