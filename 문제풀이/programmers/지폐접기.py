# -*- coding: utf-8 -*-
"""
Created on Wed Nov 27 01:22:18 2024

@author: mindo
"""

def solution(wallet, bill):
    wallet = sorted(wallet)
    bill = sorted(bill)
    
    # 접기 횟수를 저장하는 변수
    answer = 0
    
    # 지폐의 크기가 지갑의 크기 안에 들어갈 때까지 반복
    while bill[0] > wallet[0] or bill[1] > wallet[1]:
        # 더 긴 쪽을 반으로 접는다
        if bill[1] > bill[0]:
            bill[1] //= 2
        else:
            bill[0] //= 2
        
        # 접은 횟수 증가
        answer += 1
        
        # 지폐 크기 정렬 (작은 쪽과 큰 쪽 순으로 유지)
        bill = sorted(bill)
    
    return answer