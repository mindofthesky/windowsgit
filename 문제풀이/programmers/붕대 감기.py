# -*- coding: utf-8 -*-
"""
Created on Sat Feb 10 19:16:00 2024

@author: mindo
"""
# 
bandage= [5, 1, 5]
health = 30
attacks = [[2, 10], [9, 15], [10, 5], [11, 5]]
# 2초에 10의 데미지를 받습니다
# 3 ~ 8초 회복 3+=1 
# 9초에 15의 데미지를 받습니다
# 10초에 5 데미지를 받습니다
# 11초에 5 데미지를 받습니다
# 최종적으로 5의 체력이 남습니다 
def solution(bandage, health, attacks):
    answer = 0
    # 5초이상 회복하면 보너스 5초 
    # 단 체력이상을 회복은 불가능
    # 이중 포문은 아니다 
    # 포문 하나로 해결이될거같다 
    # 배열을 어떻게 다룰래가 문제
    maxhealth = health
    heal = 0
    m,n = len(attacks)-1, 0 
    print(m,n)
    for i in range(1,attacks[m][0]+1):
        if i == attacks[n][0]:
            print("attack[n][0] 값 : ",attacks[n][0])
            health -= attacks[n][1]
            n+=1
            heal = 0
            print("공격받아서 남은 피 : " ,health)
            
            answer = health
        else:
            heal += 1 #% bandage[0]
            print("회복중인 피 : ",health)
            health+= bandage[1]
            print("heal : " , heal)
            if health > 30:
                health = maxhealth
            if bandage[0] == heal:
                health+=bandage[2]
                heal = 0
        if health <= 0:
            answer = -1
   
    print(answer)
    return answer

solution(bandage, health, attacks)