# -*- coding: utf-8 -*-
"""
Created on Tue Mar 12 06:47:31 2024

@author: mindo
"""
X= "425310"
Y= "120321"
#  "12321" "42531"	
#   "5525" "1255"
# result 321 
def solution(X, Y):
    answer = ''
    # 최대값으로한번에 하는건
    # 정렬 리버스
    # X, Y 같은 값만 빼올수있음 
    # x, y 가 크다 작다가 없는데 
    # len 최대는 7 
    su = ""
    if X < Y :
        return Y
    else:
        su = X
        # su값이 X가 됨 
        X = Y
        # Y는 X값을 가지게됨
        Y = su
        
    

    max_len = 7 
    cal= 7-len(X)
    # 핵심은 range갯수를 따지는거였는데 윽엑 
    # 위에건 갯수를 줄이자 생각하면서 난리친 코드
    # 9 > -1 까지 += -1 > 총 10번 
    for i in range(9,-1,-1):
        # min 을 생각해내지 못했다 
        answer += str(i) * min(X.count(str(i)), Y.count((str(i))))
        print(str(i),X.count(str(i)), Y.count(str(i)))
    if answer == "":
        return "-1"
    elif len(answer) == answer.count("0"):
        return "0"
    else:
        return answer
    return answer

solution(X, Y)
