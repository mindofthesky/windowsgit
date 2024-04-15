# -*- coding: utf-8 -*-
"""
Created on Mon Apr 15 20:41:19 2024

@author: mindo
"""
temperature = 28
t1 =  18
t2 =  26
a =   10
b =    8
onboard = [0, 0, 1, 1, 1, 1, 1]	
def solution(temperature, t1, t2, a, b, onboard):
    answer = 0
    
    k = 1000*100 
    # 큰값을 넘어줘도 되지만 만이상의 값을 넘어야함
    # 왜일까?
    t1 += 10
    t2 += 10
    # 무조건 t1, t2 에 매분 10분씩 올리기때문에 무조건적인 10분이 소모 
    temperature += 10
    # 온도도 동일 
    # 온도 상승 전력 
    dp = [[k] * 51 for i in range(len(onboard))] 
    # 모든 값에 100000 을곱한값을 넣어주자 
    dp[0][temperature] = 0 
    # 첫번째에 28 번째값은 0을 가진다 
    #print(dp)
    flag = 1 # 온도 방향위치 
    if temperature > t2:
        flag  = -1
    # 온도가 t2보다크면 낮춰줘야하고
    
    for i in range(1, len(onboard)):
        for j in range(51):
            arr = [k]
            if (onboard[i] == 1 and t1 <= j <= t2) or onboard[i] == 0:
                print("j, flag :",j,flag )
                if 0 <= j + flag <= 50:
                    arr.append(dp[i-1][j+flag])
                if j == temperature:
                    arr.append(dp[i-1][j])
                if 0 <= j-flag <= 50:
                    arr.append(dp[i-1][j-flag] + a)
                if t1 <=j <= t2:
                    arr.append(dp[i-1][j] + b )
                dp[i][j] = min(arr)
    answer = min(dp[len(onboard)-1])
    print(answer)
    #print(dp)
    return answer
solution(temperature, t1, t2, a, b, onboard)