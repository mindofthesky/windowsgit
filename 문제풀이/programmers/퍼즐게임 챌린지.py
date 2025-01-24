def solution(diffs, times, limit):
    n = len(diffs)
    
    # 총 소요 시간을 계산하는 함수
    def calculate_total_time(level):
        total_time = 0
        time_prev = 0  # 이전 퍼즐의 소요 시간
        
        for i in range(n):
            diff = diffs[i]
            time_cur = times[i]
            
            if diff <= level:
                # 퍼즐을 한 번에 해결
                total_time += time_cur
            else:
                # 퍼즐을 diff - level번 틀림
                mistakes = diff - level
                total_time += mistakes * (time_cur + time_prev) + time_cur
            
            # 현재 퍼즐을 이전 퍼즐로 설정
            time_prev = time_cur
            
            # 제한 시간을 초과하면 더 이상 계산할 필요 없음
            if total_time > limit:
                return total_time
        
        return total_time

    # 이분 탐색으로 최솟값 찾기
    low, high = 1, max(diffs)
    while low < high:
        mid = (low + high) // 2
        if calculate_total_time(mid) <= limit:
            high = mid
        else:
            low = mid + 1

    return low
