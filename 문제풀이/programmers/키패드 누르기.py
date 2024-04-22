# -*- coding: utf-8 -*-
"""
Created on Mon Apr 22 21:36:11 2024

@author: mindo
"""
numbers = [1, 3, 4, 5, 8, 2, 1, 4, 5, 9, 5]	
hand= "right"
def solution(numbers, hand):
    answer = ''
    # 왜 dic 쓰는걸까 # 이문제 못풀었음
    key = {1:[0,0], 2:[0,1], 3:[0,2],
           4:[1,0], 5:[1,1], 6:[1,2],
           7:[2,0], 8:[2,1], 9:[2,2],
           "*":[3,0], 0:[3,1], "#":[3,2]}
    left_hand = "*"
    right_hand = "#"
    for i in numbers:
        if i == 1 or i==4 or i==7:
            answer += 'L'
            left_hand = i
        elif i == 3 or i == 6 or i== 9:
            answer += 'R'
            right_hand =i 
        else:
            left_key = key[left_hand]
            right_key = key[right_hand]
            
            left_dis = abs(left_key[0] - key[i][0]) + abs(left_key[1] - key[i][1])
            right_dis = abs(right_key[0] - key[i][0]) + abs(right_key[1] - key[i][1])
            
            if left_dis < right_dis:
                answer += 'L'
                left_hand = i
            elif left_dis > right_dis:
                answer +='R'
                right_hand = i
            else:
                if hand == 'left':
                    answer += 'L'
                    left_hand =i
                else:
                    answer += 'R'
                    right_hand = i
            
    print(answer)
    return answer
solution(numbers, hand)