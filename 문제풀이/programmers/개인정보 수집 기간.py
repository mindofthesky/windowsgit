# -*- coding: utf-8 -*-
"""
Created on Thu Feb 22 18:36:47 2024

@author: mindo
"""
today = "2022.05.19"	
terms = ["A 6", "B 12", "C 3"]	
privacies = ["2021.05.02 A", "2021.07.01 B", "2022.02.19 C", "2022.02.20 C"]
# 한달은 28일 1<= DD <= 28
# 1년은 12달 정해짐 
# 2000 <= YYYY <= 2022
# 1년 336일
# today는 비교값일뿐
# A 168, B 336 , C 84
# 기초적인 생각에는
# YYYY.MM.DD 
# YYYY.MM.DD+168 올려주는걸 생각하자
# 1=<MM<=12  MM % 12  
def solution(today, terms, privacies):
    answer = []
    today_list = list(map(int,today.split('.')))
    dic = {}
    print(today) # 문자열이라서 덧셈이런거 않됨
    # 코드 구현에서 생각못한건 딕셔너리 
    # 딕셔너리 접근을 할까 생각했던건
    #  으로 하면되지않을까 {6:A} 고민은했다 
    for i in terms:
        n, m = i.split()
        print(n,m)
        dic[n]= int(m)*28 #딕셔너리형으로 먼저 계산
    for i in range(len(privacies)):
        # date 날짜 , k key 
        date , k = privacies[i].split() # 문자열을 미리 나눈다 20210502, A 
        date_list = list(map(int,date.split('.'))) # date 문자열을 정수형으로 그리고 . 을제거 
        year = (today_list[0] - date_list[0])*336  # 1년은 12달이고 28일 1달이기때문에 
        month = (today_list[1] - date_list[1])*28  # 한달이 28일
        day = today_list[2] - date_list[2]  #날짜는비교가 쉽다
        total = year+month+day # 사실 반례가없는건아니다 13을 넣으면 에러난다 
        if dic[k] <= total:
            answer.append(i+1)
    
        
    return answer

solution(today, terms, privacies)

#24240 + 