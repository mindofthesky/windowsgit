# -*- coding: utf-8 -*-
"""
Created on Mon Apr  8 20:58:45 2024

@author: mindo
"""
k =6 
tangerine = [1, 3, 2, 5, 4, 5, 2, 3]	
# result = 3 
# 1, 4 제외 
# 3 2 5 5 2 3 > 3 
# set > 
# 1개짜리를 지우면됨 
# 2개씩 3개 
# 
def solution(k, tangerine):
    answer = 0
    dic = {} 
    # 딕셔너리로 판명하자 
    for i in tangerine:
        if i in dic:
            dic[i] +=1 
        else:
            dic[i] = 1
    print(dic)
    # 내림 차순 정렬처리
    sortdic = sorted(dic.items(), key = lambda x : x[1] , reverse=True)
    print(sortdic)
    for i in range(len(sortdic)):
        k -= sortdic[i][1]
        answer +=1  
        # 빼면서 갯수처리  
        # 남는건 1개짜리기때문에 
        if k <= 0:
            break
    print(answer)
    return answer

solution(k, tangerine)