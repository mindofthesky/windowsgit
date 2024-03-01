# -*- coding: utf-8 -*-
"""
Created on Fri Mar  1 17:45:53 2024

@author: mindo
"""
x = 10
y = 40
n = 5
def solution(x, y, n):
    answer = 0
    answer1 = 0
    res = []
    x_nplus = x
    x_2 = x
    x_3 = x 
    pcount = 0 
    count2 = 0
    count3 = 0
    # 그냥 하나하나 다 넣자 생각하고 코딩함
    
    # 잘못된 접근이고DP 임 
    if x+n >= y and x *2 > y and x*3 > y:
        answer = -1
    while x+n < y and x*2 < y and x*3 < y:
        
        if x_nplus < y:
            x_nplus += n
            pcount +=1
            if x_nplus == y:
                res.append(pcount)
                break
        if x_2 == y:
            res.append(count2)
        else:
            x_2 *= 2
            count2 += 1
        if x_3 == y:
            res.append(count3)
        else:
            x_3 *= 3
            count3 += 1
        if x+n >= y and x *2 > y and x*3 > y:
            answer1 = -1
            break
        # 이코드는 반례가 가장 뚜렷하게 발생함
        # x= 2 y = 5 n = 4 
        # 무한루프걸림 
        # 접근이 틀렸다는걸 알았지만
        # DP는 접근을 못했다
    MAX = 1000000
    dp =[float('inf')] * (MAX +1)
    dp[x] = 0
    for i in range(x,y):
        if dp[y] != float('inf'):
            return dp[y]
        for new_x in (i + n, 2* i, 3 * i):
            if MAX < new_x:
                continue
            dp[new_x] = min(dp[new_x], dp[i] + 1)
    answer = dp[y] if dp[y] != float('inf') else -1
    print(res)
    answer1 = min(res)      
    dp = [float()]
    return answer

solution(x, y, n)