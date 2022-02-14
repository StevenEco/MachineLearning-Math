import numpy as np
import matplotlib.pyplot as plt
from matplotlib.animation import FuncAnimation 
def f(x):
    return 1-x**3
x_0 = 0.4
x0 = [0.4]
y0=[0]
a = True
for i in range(8):
    if a:
        x0.append(x_0)
        y0.append(f(x_0))
        x_0=f(x_0)
        a = not a
    else:
        x0.append(y0[-1])
        y0.append(y0[-1])
        a = not a


x1=np.linspace(0,1,100)
y1=f(x1)

x2 = np.linspace(0,1,100)
y2 = x2

x3 = np.array(x0)
y3 = np.array(y0)

fig = plt.figure(num=3,figsize=(8,8))
plt.plot(x1,y1,color='red',linewidth=1.0)
plt.plot(x2,y2,color='blue',linewidth=1.0,linestyle='--')
plt.plot(x3,y3,color='green',linewidth=1.0,linestyle='-')

plt.xlim(0,1.2)
plt.ylim(0,1.2)
plt.xlabel('x')
plt.ylabel('y')

new_ticks=np.linspace(0,1.2,3)
plt.xticks(new_ticks,['0','0.6','1.2'])
plt.yticks(new_ticks,['0','0.6','1.2'])


# 设置坐标轴 gca() 获取坐标轴信息
ax=plt.gca()
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

# 设置标签
ax.set_title('g(x) = 1-x**3',fontsize=10)
# 显示图像
plt.show()