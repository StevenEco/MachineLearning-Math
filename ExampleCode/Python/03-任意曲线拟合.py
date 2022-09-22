def Lagrange(x,y,xi):
    if len(x) != len(y):
        raise IndexError("ERROR")
    result = []
    for p in range(len(xi)):
        value = 0
        for i in range(len(x)):
            mulValue = 1
            for k in range(len(x)):
                if i == k:
                    continue
                mulValue = mulValue*(xi[p] - x[k])/ (x[i]-x[k])
            value = value + mulValue * y[i]
        result.append(value)
    return result