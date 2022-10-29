#include<iostream>
#include<string.h>
#include<fstream>
using namespace std;

int main(){

        ifstream infile;
        infile.open("file.txt");

        string words;

        //If file open is successful
        while(infile.good()){
            getline(infile,words,'\n');
            cout<<words<<"\n";        
        }

        infile.close();
        return 0;
}