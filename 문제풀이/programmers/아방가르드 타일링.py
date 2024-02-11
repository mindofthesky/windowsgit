# -*- coding: utf-8 -*-
"""
Created on Sat Feb 10 13:00:26 2024

@author: mindo
"""
n=1
MOD = 1000000007
# n= 1 & 1개  n = 2 & 3개 n = 3 & 10개 n = 4 & n1+n2+n3
# A 1 
#   1 1 * 4 
# B 1 * 2
#   1
#   1
# A,B 타올을 둘다 사용한다 
def solution(n):
    answer = 0
    
    # 포문이있다고가정하자
    # i값이 3과 j값이 n 행렬이 나타난다 | ★ 틀린접근 BFS 가아니라서 이중 포문을 쓸 필요가없다
    # 예측으로는 a1 회전 불가능한 하나 
    # a2 회전하여 3x2 2개 | 회전 불가능한 a1 이 포함된다 
    # 동서남북 * 4  뒤집기 * 2 dx, dy이용한 | ★ BFS 아니니까 무조건 동서남북을 생각할 필요가 없다
    # BFS라고 생각해         | 다시 고친 이유는 10만개에서 다 연산을 할수없으니까 BFS는 포기했어 아래 내용과 같이 
    # BFS를 하되 문제는 A = 1 0 로 취급한다면 
    #                      1 1 너무 많아진다
    # B 1 - 1 - 1 로 연결해서 동서남북하면 2개 타입밖에 존재하지않는다 
    # 위에 lambda도 할필요 없어보인다 
    # 그럼 BFS도 아닌것같다
    # a1,a2,a3 연관이 있다면 다 넣을 필요가없다 
    # 그렇지만 연산은 해야한다 
    # 조건이 너무 많은 수가 있을때 1,000,000,007 나눈 나머지로 값을 한다 
    # 이걸 수식화한다  n <10만까지 가능한데 이걸 계산해서 넣게한다? 
    # 런타임이 난다 
    # a1 a2 a3 a4 연관성이 있으니까 곱한다로 가야하는게 아닐까? 
    # a2 A: 1개인데 회전해서 2개거든 ? 
    # a1 = 1 a2 = 3 a3 = 10 a4 = 일자형 3개 a5 = 일자형 4개
    # 답 보고나서 작성부분 
    # DP이다 
    # 예측이 맞았다 a1,a2,a3,a4 는 연관성이있다 
    # 재귀형이기때문에 접근방식을 너무 허접하겠다 
    # 이런코드를 참조했었는데 
    # 문제가 있다 이건 a4 값을 셀수있을때 할수있는 개념이다 재귀형으로 하라고 한 문제인데 
    # 연관성이있다 생각하고 접근한건 좋다 근데 a6 알아야 할수있는점 
    # 이문제는 a4를 몰라도 만들어 내라는게 핵심인데 이걸 쓰면 안좋을거같다 
    """
    DP = [0]*100001
    if n == 1:
        DP[1]=1
        return 1
    elif n==2:
        DP[2]=3
        return 3
    elif n==3:
        DP[3]=10
        return 10
    elif n==4:
        DP[4]=23
        return 23
    elif n==5:
        DP[5]=62
    elif n==6:
        DP[6] =170
        
        
    if DP[n-1]:
        answer += DP[n-1]
    else:
        answer += block(n-1)
    if DP[n-2]:
        answer += block[n-2]*2
    else:
        answer += block(n-2)*2
    if DP[n-3]:
        answer += block[n-3]*6
    else:
        answer += block(n-3)*6
    if DP[n-4]:
        answer += block[n-4]*1
    else:
        answer += block(n-4)*1
    if DP[n-6]:
        answer -= block[n-6]*1
    else:
        answer -= block(n-6)*1

    DP[n]=answer
    """ 
    # 다른 코드 참조하기로했다
    # 이코드를 참조한 이유 
    # a0 = 0 개 a1 =1 a2 = 3 a3 10 
    # 주어진값에서 실행 
    
    dp = [0,1,3,10] +[0] *(n-3) 
    #print(dp)
    # 뒤에는 알수없는 값이니까 0을 넣는다 
    cache = [8, 0, 2]
    # 4이상인수는 계산해야한다 
    for i in range(4, n + 1):
        # 4부터는 계산을 해봐야하니까 
        remainder = i % 3
        # 4일때 나머지를 넣으니까 remainder = 1
        sum_value = cache[remainder]
        # 4인 경우 remainder=1 > cache[1] = 0을 지칭 
        # cache = [8, 0, 2]
        print("---------------------------")
        print("초기, 호출 된 cache[remainder] :",sum_value)
        #sum_value = 0 = cache[1] = "0"
        plus = 4 if i % 3 == 0 else 2        
        # 1 ~ 3까지 볼수있으니 4만 연산한다 
        sum_value += dp[i - 1] * 1
        #print(i-1,i-2,i-3, i )
        print("+=dp[i - 1] * 1 :" ,sum_value)
        # sum_value += dp[3]
        sum_value += dp[i - 2] * 2
        print("+=dp[i - 2] * 2 :" ,sum_value)
        # sum_value += dp[2]
        sum_value += dp[i - 3] * 5
        print("+=dp[i - 3] * 5 :" ,sum_value)
        # sum_value += dp[1]
        print("plus값 : ",plus)
        sum_value += plus
        # 3의로 나눈 나머지가 0이라면 4개 추가되는경우지만 
        # 1,2 같은 경우는 1개 밖에 존재하지않는다 
        sum_value %= MOD
        print("타일링값 : ",sum_value)
        # 1,2,3 이후 캐시를 사용하지않음 상관없음  
        # n이 4이상일 일때는 2 2 4 가 반복
        cache[remainder] += dp[i - 1] * 2
        print("cache[remainder] += dp[i - 1] * 2 =",cache[remainder])
        cache[remainder] += dp[i - 2] * 2
        print("cache[remainder] += dp[i - 2] * 2 =",cache[remainder])
        cache[remainder] += dp[i - 3] * 4
        print("cache[remainder] += dp[i - 3] * 4 =",cache[remainder])
        cache[remainder] %= MOD
        print("총합 chach[remainder] :" ,cache[remainder])
        dp[i] = sum_value
        print(dp[i],dp[i-1],dp[i-2],dp[i-3])
        print("---------------------------")
    answer = dp[n]
    print(dp[n])
    return answer

solution(n)