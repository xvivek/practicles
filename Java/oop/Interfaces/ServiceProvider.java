package com.vivek.interfaces.implememtations;

import com.vivek.declare.interfaces.IServiceProvider;

public class ServiceProvider implements IServiceProvider {

    public static void main(String[] args) {
           IServiceProvider sp =  new ServiceProvider();
           sp.m1();
           sp.m2();
    }

    public void m1() {
        
        System.out.println("impl->m1");
        
    }

    public void m2() {
         System.out.println("impl->m2");     
    }
    
}
