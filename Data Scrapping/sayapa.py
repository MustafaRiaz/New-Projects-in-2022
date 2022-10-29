# -*- coding: utf-8 -*-
"""
Created on Sat Oct 15 02:04:11 2022

@author: Mustafa
"""

from bs4 import BeautifulSoup
import requests
import pandas as pd
import time

Data=[] 
brandName=[]
price=[]
sold = [] 
dicount = [] 
diliver_charge = []
Type = []  
mobileData = [] 
rating = [] 
topRatedSeller =[]
count = 0  
counter =0 
URL  = "https://www.ebay.com/sch/i.html?_from=R40&_trksid=p2380057.m570.l1313&_nkw=iphone&_sacat="


 

for page in range(1,250):
    print(page)
    req =  requests.get(URL +str(page)+"&rt=nc")
    soup = BeautifulSoup(req.content, 'html.parser')   
    mobiles = soup.find_all('div', attrs = {'class' : 's-item__info clearfix'})     
    if mobiles==[]:  
        print(mobiles) 
        break 
    for i in mobiles:    
        D = i.find('div',class_='s-item__title').text 
        p = (i.find('span',class_='s-item__price').text)
        sold_Product = (i.find("span",class_='s-item__hotness s-item__itemHotness'))  
        Dis = (i.find("span",class_='s-item__discount s-item__discount')) 
        dliver = (i.find("span",class_='s-item__shipping s-item__logisticsCost'))    
        titel =   str(D).split("New Listing")  
        if len(titel) == 1:
              Data.append(titel[0]) 
        else:
            Data.append(titel[1])  
        b =  str(titel).split(" ")  
        if dliver != None:
            diliver_charge.append(dliver.text)  
        else :
            diliver_charge.append("NA") 
        if Dis != None:
            dicount.append(Dis.text)   
        else:
            dicount.append("NA")   
        if sold_Product != None:
            sold.append(sold_Product.text)  
        else:
            sold.append("NA")
        price.append(p)
        if len(b) == 1:
                  brandName.append(b[0])
        else:
            brandName.append(b[1])
        Type.append("laptop")

        ratings=i.find('div','s-item__reviews')
        if ratings!=None:
            ratings=ratings.find('div','x-star-rating').text
            rating.append(ratings)
        else:
            ratings="NA"
            rating.append(ratings) 
        a=i.find("span",class_='s-item__etrs-text')    
        if a!=None:
              a=a.text
              topRatedSeller.append(a)
        else:
              a="Not a top Ratted Seller"
              topRatedSeller.append(a)    
        if count==20:
             time.sleep(1)
             count=0
        count=count+1
        counter+=1

df=pd.DataFrame({"Product Name":Data,"Brand":brandName,"Price":price,"Shipping Charges":dicount ,"Sold Product":sold,"Dilevery Charges":diliver_charge ,"Type" :Type,"Ratings":rating,"Top Rated Seller":topRatedSeller,"Availability":"Yes"})
df.to_csv("laptop.csv",mode = 'a',header= False,index=False).drop_duplicates()
Data=[]
brandName=[]
price=[]
sold = []
dicount = []
diliver_charge = []
Type = []
mobileData = []
rating = []
topRatedSeller =[]
counter =0