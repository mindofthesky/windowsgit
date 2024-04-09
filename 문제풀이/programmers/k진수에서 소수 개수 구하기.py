# -*- coding: utf-8 -*-
"""
Created on Tue Apr  9 20:32:54 2024

@author: mindo
"""
n = 437674
k = 3
# result = 3
def solution(n, k):
    answer = 0
    #0P0처럼 소수 양쪽에 0이 있는 경우
    #P0처럼 소수 오른쪽에만 0이 있고 왼쪽에는 아무것도 없는 경우
    #0P처럼 소수 왼쪽에만 0이 있고 오른쪽에는 아무것도 없는 경우
    #P처럼 소수 양쪽에 아무것도 없는 경우
    #단, P는 각 자릿수에 0을 포함하지 않는 소수입니다.
    #예를 들어, 101은 P가 될 수 없습니다.
    # 211 , 2 , 11  > 211, 2 ,11 
    
    # 진법 전환코드가 작성해야한다 
    base = ""
    # 진법 전환 코드 
    while n > 0:
        n, mod = divmod(n, k)
        base += str(mod)
        # base[::-1] > 역순으로 원래값으로 
    # n진법 전환 코드 끝
    print(base[::-1].split("0"))
    
    # 양쪽에 어떻게 소수를 생각할건데
    # 그냥 0 아니면 다 소수취급하면되는거 아님? 
    # print저값이 다뽑아낸값
    for i in base[::-1].split("0"):
        if len(i) == 0:
            continue
        if int(i) < 2:
            continue
        prime = True
        # 트루만 소수 아닌경우 False로 처리 
        print(i)
        for j in range(2,int(int(i)**0.5)+1):    
            # 자기 자신의 제곱이외로 나눠지면 소수가아님 
            if int(i)%j == 0:                
                prime=False
                break           
        if prime:            
            answer+=1
    print(answer)
    return answer

solution(n, k)