# 小怪物探险

 

## 01 - 游戏介绍：



### **规则：**

可爱的小橡皮糖去探险，玩家需要帮助小怪物，控制小怪物躲避危险，奋力前进，并沿途收集金币。玩家通过键盘按键控制小橡皮糖的运动，控制小怪物躲避危险，并沿途收集金币，掉下去就算结束。

### **风格：**

像素简约风

### **游戏类型：**

休闲类

### 游戏主要内容：

**1.** **主人公：**

小橡皮糖

**2.** **游戏场景：**

晴朗清新风格场景 + 神秘幻夜风格场景

**3.** **各种道具;**

金币，方块，蹦床，任意门，移动浮板

**4.** **游戏界面GUI ：**

开始游戏界面，结束游戏界面（金币结算），暂停游戏界面（音量调节、返回游戏、重新开始游戏、退出游戏）

**5.** **背景音乐、音效：**

开始结束页面音效，游戏进行时背景音效，收集金币音效，失败音效，跳跃音效，碰到木块音效，蹦床音效



## 02 - 整体系统效果：
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/start.png)
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/game01.png)
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/game02.png)
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/pause.png)
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/game03.png)
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/game04.png)
![image](https://github.com/Felicityty/Unity_MosterJump/blob/master/Assets/Renderings/over.png)


## 03 - 遇到问题及其解决方案

**问题一：**

理想效果是camera自己有一个速度向右运动，若moster速度过快，camera会跟着moster加快移动速度。但是camera可以跟随moster移动，不能添加自己的向右移动速度了。

**解决方案：**

不设置Cinemachine跟随moster移动了。为camera添加一个脚本，设置正常移动速度。并通过计算camera和moster的距离的变化，自动改变camera的移动速度，这样若moster速度过快，camera会跟着moster加快移动速度，反之，变为正常的速度。

 

**问题二：**

Platform是需要层级关系的。

**解决方案：**

多建几个Tilemap，并为它们设置不同的层级顺序，从而就可以有前后的遮挡样式。 

 

**问题三：**

在几个场景切换时，coin的数量应该是一直递增的，而不是都从零开始。并且死亡或重新开始游戏，coin数量应该清零。

**解决方案：**

在coin的脚本中，把统计数量的变量设置成全局变量，这样就可以几个场景通用计数了。在moster死亡或者按下重新开始游戏按钮后，在脚本中把coin的数量设置成0。

 

**问题四：**

Moster的跳跃很僵硬，游戏体验感比较差。

**解决方案：**

为moster的跳跃在脚本中添加重力加成，起跳时添加1.5倍，下落时添加3.5倍，这样跳跃的感觉会好一点。

 

**问题五：**

场景二中的浮动平台，当moster站上去后，不能跟着平台一起移动，而是需要手动按键盘进行移动。

**解决方案：**

在检测到moster站上平台后，让moster变成平台的孩子，在退出的时候，平台的孩子设置为空，这样就可以让moster跟着平台一起移动了。

 

**问题六：**

场景二的浮动平台，在左右移动的时候，在到边界后马上就向另一边移动了，moster跳上去的难度过大。

**解决方案：**

在移动平台脚本中，增加平台等待时间，在平台移动到一边的边界时，先停顿几秒钟，再变换目标点进行移动，这样操作会更简单一些。

 

**问题七：**

由于为platform设置的Composite Collider 2D，会自动识别platform的边界，自己绘制的平台左右两侧会突出来一点，当moster在蹦床弹跳时，经常会被突出来的地方磕住。

**解决方案：**

为Composite Collider 2D设置一定的偏移。

 

**问题八：**

Moster左右移动时，脸的朝向不变，比较机械。

**解决方案：**

通过拿到输入的左右，来控制scale的正负，就可以改变moster的朝向。

 

**问题九：**

通过点击暂停界面的重新开始游戏按钮重新开始的游戏，所有动画是暂停的。

**解决方案：**

在脚本的Restart函数中，添加Time.timeScale = 1，使得时间继续正常进行。

