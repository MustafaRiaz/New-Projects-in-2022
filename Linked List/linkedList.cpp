#include<iostream>
#include<stdlib.h>
#include<string.h>
#include<fstream>
using namespace std;

class Node{
    public:
    string data;
    Node* next;
    Node(string val)
    {
        data=val;
        next=NULL;
    }  
};
class LinkList
{
    private:
    Node* head=NULL;
    public:
    void *getHead()
    {
        return head;
    }
    void setPointer(Node* n)
    {
        head=n;
    }
    void insert(string data,int loc)
    {
        Node* temp=head;
        Node* newNode=new Node(data);
        for(int i=0;i<loc-1;i++)
        {
            temp=temp->next;
        }
        newNode->next=temp->next;
        temp->next=newNode;

    }
    bool search(string val)
    {
        Node* temp=head;
    while(temp!=NULL)
    {
        if (temp->data==val)
        {
            return true;
        }
    }
    return false;
    }
    void addData(string data)
    {
        Node* n=new Node(data);
        n->next=head;
        head=n;
    }
    void deleteNode(int loc)
    {
        Node* temp=head;
        for(int i=0;i<loc-1;i++)
        {
            temp=temp->next;
        }
        temp->next=temp->next->next;
        
    }
    void updateKey(string data,int loc)
    {
        Node* n=new Node(data);
        Node* temp=head;
        for(int i=0;i<loc-1;i++)
        {
            temp=temp->next;
        }
        n->next=temp->next;
        temp->next=n;
    }
    void addDataTail(string data)
        {
            Node* n=new Node(data);
            if(head==NULL)
            {
                head=n;
                return;
            }
            Node* temp=head;
            while(temp->next!=NULL)
            {
                temp=temp->next;
            }
            temp->next=n;
        }
    void displayLinkedList()
    {
        Node* temp=head;
        while(temp!=NULL)
        {
            cout<<temp->data <<" ";
            temp=temp->next;    
        }
    }
    void findLength()
    {
        int count=0;
        Node* temp=head;
        while(temp!=NULL)
        {
            temp=temp->next;
            count=count+1;
        }
        cout<<count;
    }
    void reverseList()
    {
        Node* previoce=NULL;
        Node* current=head;
        Node* next;
        while(current!=NULL)
        {
            next=current->next;
            current->next=previoce;

            previoce=current;
            current=next;
        }
        while(previoce!=NULL){
            cout<<previoce->data;
            previoce=previoce->next;
        }
    }
};


int main()
{
    
    Node* head=NULL;
    LinkList l;
    ifstream infile;
        infile.open("file.txt");

        string words;

        //If file open is successful
        while(infile.good()){
            getline(infile,words,'\n');
            l.addDataTail(words);        
        }

        infile.close();
     //l.addDataTail("Hello");
    // l.addDataTail(2);
    // l.addDataTail(3);
    // l.addDataTail(4);
    // l.updateKey(9,2);
    // l.insert(5,2);
    // l.deleteNode(1);
    l.displayLinkedList();
    //l.findLength();
    //l.reverseList();

    return 0;
}