# -*- coding: utf-8 -*-
"""
Created on Mon Apr  1 21:48:20 2024

@author: mindo
"""
scores = [[2,2],[1,4],[3,2],[3,2],[2,1]]	
# result = 4
# scores[0] > 완호 
# scores[i][0] > value는 근무태도점수 scores[i][1] 동료 평가점수 
# 제일 둘다 인센티브를 받을수없다 
# sum  = 4, 5, 5, 5, 3 
# rank = 4, 1, 1, 1, 안봄 
# 
# 완호가 제일 낮으면 -1 
# 동점이면 1등끼리 유지
# 2등끼리 동점이면 2명이면 다음은 4등시작 
# 동석차인경우 등수 건너뜀 
# scores[i][0] , scores[i][1] 의 min값을 받아와야하나? 
def solution(scores):
    answer = 0
    rank = 1 
    # scores[0] > rank 무조건 1로 취급이됨 시작이니까
    # rank는 완호 기준으로 보고있으면 된다고 생각함 
    # 근데 만약 완호가 꼴지라면? > 이건 최종까지 가볼 필요가없지않을까? min 으로 한번 다볼까?  
    # scores[1] > scores[0] rank += 1 
    # scores[1] = scores[2] rank += 1
    # scores[0] > scores[4] rank 변화없음
    """
    for i in range(len(scores)):
        a = 1
        wan_num = scores[0][0] + scores[0][1]
        diff = scores[a][0] + scores[a][1]
        if wan_num < diff :
            rank += 1
            
            a +=1
        else:
            answer = -1
        answer = rank
    """
    # 정렬 
    k = 0
    wanho = scores[0]
    # 완호는 scores[0] 무조건 완호를 가르킴
    wanho_num = sum(wanho)
    # 완호의 점수는 sum(scores[0]) 
    # 소트전 
    before_scoresort =[[2,2],[1,4],[3,2],[3,2],[2,1]]
    # 람다식으로 정렬 
    scores.sort(key=lambda x :(-x[0], x[1]))
    # 소트 후
    print(before_scoresort)
    print(scores)
    # 정렬된건 scores[i][0] 의 내림차순이기때문에 같지만않다면 순회를 for문 하나로 해결이됨
    # [[3, 2], [3, 2], [2, 1], [2, 2], [1, 4]]
    for i in scores:
        if wanho[0] < i[0] and wanho[1] < i[1]:
            
            return -1
        elif wanho_num < sum(i) and k <= i[1]:
            answer +=1 
            k = i[1]
            print(i[0],i[1]) # 큰값이면 비교값을 정확히 볼수있게 
            print(k)
    answer += 1
    # 등수라서 1 추가적으로 더하고 처리 
    return answer
solution(scores)