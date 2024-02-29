# -*- coding: utf-8 -*-
"""
Created on Wed Feb 28 10:13:11 2024

@author: mindo
"""
numbers = [9, 1, 5, 3, 6, 2] #[2, 3, 3, 5]	
# case 1  
# result = [3, 5, 5, -1]
# 2보다 큰수는 바로 3 
# 3보다 큰수는 5 
# 3보다 큰수는 5 
# 5보다 큰수는 없으므로 -1 
# case 2
#  9 1 5 3  6  2
# -1 5 6 6 -1 -1
# -1 은 나올수있지만
# 5는 맥스가 아닌데? 
# 
def solution(numbers):
    answer = [0]* len(numbers)
    # 크기만큼 answer [0, 0, 0, 0]
    # 나는 큐로 접근했는데 스택에 이유는? 
    
    # 나는 접근못했지만 다른쪽의 접근을 참고해보면
    # stack에는 이전의 인덱스 중에 아직 뒷 큰수를 찾지 못한 인덱스들이 인덱스가 큰 순으로 담겨있다. 
    # 그리고, 아직 뒷 큰수를 찾지 못한 인덱스들이 담겨있는 것이기 때문에, 
    # stack 안에 있는 원소들을 인덱스 -> numbers[인덱스]로 치환하고 봤을 때는 숫자가 작은 순으로 담겨 있다
    # 이점에서 내가 실수를 했다고 생각한다
    # q에 max값을 저장해두면 더이상 안봐도 되는게 아닐까??
    """
    q = deque(numbers)
    max_mean = max(q)
    next_max = 0
    print(max_mean)
    for i in numbers:
        if max(q) == i:
            answer.append(-1)
            q.popleft()
        else:
           if q[0] < q[1]:
                answer.append(q[1])
                q.popleft()
           else:
               answer.append(-1)
    """
    stack = []
    for i in range(len(numbers)):
        #print("for문 스택 : ",stack)
        while stack and numbers[stack[-1]] < numbers[i]:
            # [1, 3, 2] > pop() 애들만 두면 
            print("while문 스택 : ",stack)
            # null < numbers[0] = 9 > 0  
            # 1회 stack = [0, 1] 
            # 2회 stack = [0, 2, 3]
            # 3회 stack = [0, 2]
            # stack[-1] 1, 3, 2 
            # numbers[1] = 3 , numbers[3] = 5 , numbers[2] = 3 
            # 3 < 5 
            # pop > 마지막 원소 순서니까 1 , 2는 3 , 3는 2 
            # answer[1] = 5
            answer[stack.pop()] = numbers[i]
            print(numbers[i])
        stack.append(i)
    print(stack)
    # 0, 4 ,5 
    while stack:
        answer[stack.pop()] -= 1
    return answer

solution(numbers)
