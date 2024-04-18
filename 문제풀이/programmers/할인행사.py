# -*- coding: utf-8 -*-
"""
Created on Sat Jan 27 20:17:27 2024

@author: mindo
"""
want = ["banana", "apple", "rice", "pork", "pot"]	
number = [3, 2, 2, 2, 1]
discount = ["chicken", "apple", "apple", "banana", "rice", "apple", "pork", "banana", "pork", "rice", "pot", "banana", "apple", "banana"]

def solution(want, number, discount):
    answer = 0
    # 예를 들어, 정현이가 원하는 제품이 바나나 3개,
    # 사과 2개, 쌀 2개, 돼지고기 2개, 냄비 1개이며, 
    # XYZ 마트에서 14일간 회원을 대상으로 할인하는 제품이
    # 날짜 순서대로 치킨, 사과, 사과, 바나나, 쌀, 사과, 
    # 돼지고기, 바나나, 돼지고기, 쌀, 냄비, 바나나, 사과,
    # 바나나인 경우에 대해 알아봅시다. 첫째 날부터 열흘 간에는
    # 냄비가 할인하지 않기 때문에 첫째 날에는 회원가입을 하지 않습니다.
    # 둘째 날부터 열흘 간에는 바나나를 원하는 만큼 할인구매할 수 없기 
    # 때문에 둘째 날에도 회원가입을 하지 않습니다. 
    # 셋째 날, 넷째 날, 다섯째 날부터 각각 열흘은 원하는 제품과
    # 수량이 일치하기 때문에 셋 중 하루에 회원가입을 하려 합니다.
    
    # 날짜에는 해당하는 할인 상품만 기록할수있음 
    # want 크기는 10이니까 재귀로 가도 상관없음 
    # 그러나 이문제는 재귀를 원하는 형태가아님
    # dict 으로 dict 형으로 잡아야하는게 아닐가?
    dic = {}
    dics = []
    # number는 want 와 같 크기 값 
    # 
    for i in range(len(want)):
        for j in range(number[i]):
            dics.append(want[i])
    dics.sort()
    
    for i in range(len(discount) - 9):
        dics_ = discount[i:i+10]
        dics_.sort()
        if dics_ == dics:
            answer += 1
    return answer

solution(want, number, discount)