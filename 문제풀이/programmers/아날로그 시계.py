# -*- coding: utf-8 -*-
"""
Created on Fri Apr  5 22:48:57 2024

@author: mindo
"""
h1=0
m1=5
s1=30
h2=0
m2=7
s2=0
def timeswitch(h,m,s):
    return 3600*h + m*60 + s
def solution(h1, m1, s1, h2, m2, s2):
    answer = -1
    # 초침이 시침과 분침을 합치는 시간에 알람이 울린다
    # 시침은 1분이 지났다면 무조건 1번을 울린다 
    # 분침은 다를수있다 
    starttime, endtime = timeswitch(h1, m1, s1), timeswitch(h2, m2, s2)
    times = {}
    
    for t in range(timeswitch(24, 0, 0)):
        times[t] = {"cur":0 , "after" :0}
    preS, preM, preH = 0, 0, 0    
    
    for t in range(1,timeswitch(24, 0, 0)):
        aftercount, curcount = 0,0
        
        curs,curm, curh = 6*t%360, (t/10)%360, (t/120)%360
        
        if preS < preM and curs > curm:
            aftercount += 1
        elif preS < preM and curs == 0:
            aftercount += 1
        elif curs == curm:
            curcount += 1 
        
        
        if preS < preH and curs > curh:
            aftercount += 1 
        elif preS < preH and curs == 0:
            aftercount += 1 
        elif curs == curh:
            curcount += 1
        
        
        if t != 3600 * 12:
            if curcount != 0:
                times[t]["cur"] += curcount
            if aftercount != 0:
                times[t-1]["after"] += aftercount
        preS,preM,preH = curs,curm,curh
    times[0] = {"cur":1, "after": 0}
    times[3600*12] = {"cur":1, "after" : 0}
    
    answer = 0
    for time in range(starttime,endtime):
        if time in times:
            answer += times[time]["after"]
            answer += times[time]["cur"]
    answer += times[endtime]["cur"]
            
    
    return answer

solution(h1, m1, s1, h2, m2, s2)