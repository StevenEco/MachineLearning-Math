import numpy as np
import matplotlib.pyplot as plot

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

def f(x):
    return 1/(1+x**2)
def Runge():
    x = np.linspace(-5,5,1000)
    y = f(x)

    x1=np.linspace(-5,5,6)
    y1 = f(x1)
    xl1 = np.linspace(-5,5,1000)
    yl1 = Lagrange(x1,y1,xl1)

    x2=np.linspace(-5,5,11)
    y2 = f(x2)
    xl2 = np.linspace(-5,5,1000)
    yl2 = Lagrange(x2,y2,xl2)

    fig = plot.figure(num=3,figsize=(8,8))
    ax=plot.gca()
    # 使用.spines设置边框：x轴；将右边颜色设置为 none。
    # 使用.set_position设置边框位置：y=0的位置；（位置所有属性：outward，axes，data）
    ax.spines['right'].set_color('none')
    ax.spines['top'].set_color('none')

    # 移动坐标轴
    # 将 bottom 即是 x 坐标轴设置到 y=0 的位置。
    ax.xaxis.set_ticks_position('bottom')
    ax.spines['bottom'].set_position(('data',0))

    # 将 left 即是 y 坐标轴设置到 x=0 的位置。
    ax.yaxis.set_ticks_position('left')
    ax.spines['left'].set_position(('data',0))
    
    ax.set_title('Runge,5&12',fontsize=10)
    plot.plot(x,y,color='red',linewidth=1.0)
    plot.plot(xl1,yl1,color='green',linewidth=1.0)
    plot.plot(xl2,yl2,color='blue',linewidth=1.0)
    plot.show()

if __name__ == '__main__':    
    Runge()