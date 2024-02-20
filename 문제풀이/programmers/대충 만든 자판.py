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
        count = 0
        for char in word:
            flag = False
            # 여기서 time을 101로 넣었지만 안넣어도될때까 있긴하지만
            # 딱 걸리게하는 반례가 있다면 101로 해도괜찮다 
            # 여기서 파이썬코드에서는 저 배열에서만에서는 0로해도 성립한다
            time = 101
            # key 이중 포문으로 할려고 해서 복잡해진것같다 
            # 접근은 같다 둘다 비교하면서 가야하니까 
            # 최소값을 어떻게 넣지를 생각이 부족했다 
            for key in keymap:
                if char in key:
                    # index +1 이유는 배열은 0부터 시작하기때문에 0을 따로 넣어줘야함 
                    # targets 'A' > keymap[0] = 0 , keymap[1] = -1
                    # targets 'B' > keymap[0] = 1 , keymap[1] = 0
                    # targets 'C' > keymap[0] = 3, keymap[1] = 1
                    # targets 'D' > keymap[0] = 4 , keymap[1] = 4
                    # 1 , 1 , 2,  5 = 9
                    time = min(key.index(char)+1,time)
                    flag = True
            # 코드를 따라하다 여기서 에러 발생했지만 
            # if문이 위 for에 들어가있어서 생긴에러 
            if not flag:
                count = -1 
                break
            count += time
        answer.append(count)
        # append는 접근방식이 같았다 
    print(answer)
    return answer

solution(keymap, targets)