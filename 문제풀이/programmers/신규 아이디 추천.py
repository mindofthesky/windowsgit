# -*- coding: utf-8 -*-
"""
Created on Wed May  1 22:51:45 2024

@author: mindo
"""
new_id = "...!@BaT#*..y.abcdefghijklm."	
def solution(new_id):
    answer = ''
    #대문자 제거 
    new_id = new_id.lower()
    
    #소문자, 숫자, "-", "_", "." 외 단어 제거
    check = []
    for i in range(len(new_id)):
        if new_id[i] not in ["-", "_", "."]:
            if new_id[i].isalpha() or new_id[i].isdigit():
                new_id 
                # continue 필요없는 코드부 
                print(new_id)
                # 빈메모리 생성
            else:
                check.append(new_id[i])
    for j in range(len(check)):
        new_id = new_id.replace(check[j], "") # 특수문자 제거
        
    #"." 두 번 이상 등장 -> "." 하나로 치환
    while '..' in new_id:
        new_id = new_id.replace('..', '.')
    print("여기",new_id)
    # "."이 처음 or 끝에 있다면?
    if len(new_id) > 0:
        if new_id[0] == '.':
            new_id = new_id[1:]
            print("'.'",new_id)
    # 제일 처음으로 보내고 루프문으로 돌림 
        
    if len(new_id) > 0:
        if new_id[-1] == '.':
            new_id = new_id[:-1]
    
    # 빈 문자열이면 a 대입
    if len(new_id) == 0:
        new_id = 'a'
        
    # id의 길이가 16 이상이면 0:15까지만 남기고 슬라이싱
    if len(new_id) > 15:
        new_id = new_id[0:15] # 0번 ~ 14번
        if new_id[-1] == ".": # 만약 마지막 글자가 . 이면 제거
            new_id = new_id[:-1]
    
    # id의 길이가 2자 이하라면 new_id의 마지막 문자를 new_id의 길이가 3이 될 때까지 붙임.
    if len(new_id) <= 2:
        while True:
            if len(new_id) == 3:
                break
            else:
                last_a = new_id[-1]
                new_id = new_id + last_a
                
    answer = new_id
    return answer
solution(new_id)