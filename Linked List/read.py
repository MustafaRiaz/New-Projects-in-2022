# -*- coding: utf-8 -*-
"""
Created on Sat Oct 29 10:05:00 2022

@author: Mustafa
"""

ifstream infile;
        infile.open("Stock.txt");

        string id; string title; string colour; string size; string quantity; string cost;

        //If file open is successful
        while(infile.good()){
            getline(infile,id,',');
            getline(infile,title,',');
            getline(infile,colour,',');
            getline(infile,size,',');
            getline(infile,quantity,',');
            getline(infile,cost,'\n');        
        }

        infile.close();