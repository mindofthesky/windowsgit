# -*- coding: utf-8 -*-
"""
Created on Mon Feb 19 01:27:41 2024

@author: mindo
"""
keymap = ["ABACD", "BCEFD"]	
targets =["ABCD","AABB"]
def solution(keymap, targets):
    # keymap[0], [1] 동시에 사용함
    # A 1번
    # B 1번
    # AB나와있고
    # C 더 작은걸 선택해야하니까 B 2번 
    # D는 둘다 존재하나 A키패드를 선택하든 B를 선택하든 같기때문에 5 
    # [9가 나오는이유 , 4가 나오는이유]
    # 문자열 다루기 
    # 그러나 배열에서 문자열을 어떻게 다룰수있는가?
    # 몇번할지는 몰라
    # 완성하면 break
    # 최소값으로 던져야한다
    # 둘다 봐야한다 keymap[0], keymap[1] > 
    # 
    answer = []
    # 얘가 핵심같은데
    #print(keymap[0].find(targets[0][0]),keymap[1].find(targets[0][0]))
    # target보다 적게 갈거아니냐?
    # 접근이 복잡하게갔다
    
    for word in targets:
        count =0
        for char in word:
            flag = False
            time = 101
            for key in keymap:
                if char in key:
                    time = min(key.index(char)+1,time)
                    flag = True
                if not flag:
                    count = -1 
                    break
            count += time
        answer.append(count)
    print(answer)
    return answer

solution(keymap, targets)