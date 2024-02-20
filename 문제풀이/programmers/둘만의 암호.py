s = "aukks"
skip = 	"wbqd"
index = 5
# result = happy 
# wbqd 는 스킵 
# b c d e f 
# a b c d e f g h 
# abcde는 Code 번호가 있잖아 
def solution(s, skip, index):
    answer = ''
    # 쉽게간 남의 정답
    alpha = "abcdefghijklmnopqrstuvwxyz"
    
    for sk in skip:
        alpha = alpha.replace(sk, '')
    for a in s:
        index_result = (alpha.index(a) + index) % len(alpha)
        answer += alpha[index_result]
        
    # 아래와 간 이유는 복잡하게 간이유는 뭐지?
    # replace를 생각 하지 않고 접근했기때문에
    # 문자열에는 무조건 대응하게 하겠다는 식으로 코드를 작성했기때문에 
    # 쓸대없이 복잡하게 간 코드 
    # 이것도 끝까지 가면서 코드수정하면되는데 
    # 진짜 index , skip으로 접근해서 문제였다 
    skip_sort = sorted(skip)
    res =[]
    k = 0
    for i in range(len(skip_sort)):
        res.append(ord(skip_sort[i]))
    
    for i in range(len(s)):
        for j in range(len(skip)):
            if res[j] < ord(s[i])+index:
                index+=1
                
            else: 
                if ord(s[i])+index > 122:
                    ord(s[i])+index-26
        
    #    answer+= chr(ord(s[i])+index)  
        # chr 숫자를 문자로  
        # ord 문자열을 숫자로
        #answer += chr(ord(s[i])+index)  
        # 필요개념    
        #print(chr(ord(s[i])+index))
        #print("chr ", chr(ord(s[1])+6-26))
        #ord 값이 123 넘으면 30을 빼줘야한다 
    #print(res)
    
    #print(ord(skip_sort))
    # 넣어 지니까 고민하지말자 
    #answer += chr(97)
    #answer += chr(98)
    
    print(answer)
    return answer

solution(s, skip, index)