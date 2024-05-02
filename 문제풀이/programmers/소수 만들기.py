arr = [] 
count = 0

nums=[1,2,3,4]
def dfs(_nums, idx, _len):
    global count

    if _len == 3:
        if is_prime(sum(arr)):
            count += 1
        return

    for i in range(idx, len(_nums)):
        if _len < 3:
            arr.append(_nums[i])  
            dfs(_nums, i+1, _len+1)
            arr.pop()  
    print(count)
    
# 소수 판정에는 global 이 필수가 없음
def is_prime(n):
    for i in range(2, n):
        if n % i == 0:
            return False
    return True


def solution(nums):
    global count
    # 이코드에서는 global 이 전역에서 영향을 미친다 
    count = 0
    dfs(nums, 0, 0)
    print(count)
    return count
solution(nums)