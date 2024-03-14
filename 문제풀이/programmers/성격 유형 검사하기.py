# -*- coding: utf-8 -*-
"""
Created on Thu Mar 14 09:00:52 2024

@author: mindo
"""
survey  = ["AN", "CF", "MJ", "RT", "NA"]	
choices = [5, 3, 2, 7, 5]	
# 비동의 할수록 A 동의할수록 N 
# 1 2 3     4      5 6 7 
# 4는 점수가없음 
# result TCMA
survey1 = ["TR", "RT", "TR"]	
choices1 = [7, 1, 3]	
# result RCJA
def solution(survey, choices):
    answer = ''
    dic = {}
    # 문제 해결 방법
    # split 나누고
    # dic 형으로 점수를 받을수있게만든다
    # A :0 , N : 0 
    # A 1 2 3  4  N 5 6 7
    #   3 2 1  0    1 2 3 
    dic = {"T":0 ,"R":0 , "C": 0 , "F":0, "J":0 , "M" :0 , "A":0, "N":0}
    m = len(survey)
    # dic 형으로 하면 간단하게 정렬이된다 
    for i in range(m):
        # survey , choices로 둘중 아무거나해도된다 값은 같으니까 
        if choices[i]-4 < 0: # 4 보다 작을때
            dic[survey[i][0]] += 4 - choices[i]
        elif choices[i] - 4 > 0: # 4보다 큰값을 선택했을때 
            dic[survey[i][1]] += choices[i] -4 
            
    print(dic)
    # 0 이라도 앞에것을 선택하니까 
    # 기본적으로는 R , C , J , A를 선택 0 일때도 R C J A 
    answer += "R" if dic["R"] >= dic["T"] else "T"
    answer += "C" if dic["C"] >= dic["F"] else "F"
    answer += "J" if dic["J"] >= dic["M"] else "M"
    answer += "A" if dic["A"] >= dic["N"] else "N"
    print(answer)
    return answer
solution(survey, choices)
solution(survey1, choices1)