PlatinioTween
==============
Copyright (c) 2017 -2019 Unity Project by James Roman


What is this?
==============
This is a Unity3D Asset that let you create animations by code, and works very well animating UI.

Getting started
==============


Creating a tween
==============
this scale a transform from his current scale to (10.0f , 10.0f , 10.0f) in 2 seconds.
```c#
PlatinioTween.instance.ScaleTween(transform, Vector3.one * 10.0f , 2.0f);
```

Canceling a tween before it end
==============

Sometimes you will like to cancel a tween before it ends, if that is the case the recomended way is to set a GameObject as te owner, typically the GameObject creating the tween, and later use it to cancel the tween.

```c#
IEnumerator CO_TweenRoutine()
{
    PlatinioTween.instance.Move(gameObject , Vector3.zero , 5.0f).SetOwner(gameObject);
    yield return new WaitForSeconds(2.5f);
    PlatinioTween.instance.CancelTween(gameObject);
}
```
This will cancel all the tweens associate to the current GameObject.

But if you want you can cancel it using the id.

```c#
IEnumerator CO_TweenRoutine()
{
    int id = PlatinioTween.instance.Move( gameObject, Vector3.zero, 5.0f ).id;
    yield return new WaitForSeconds(2.5f);
    PlatinioTween.instance.CancelTween(id);
}
```

this will do the same as cancael using the GameObject.

Using Eases
==============
The best way to exaplain a Ease is just to see it on action :)

![](easeoutelastic.gif)

Animating UI Elements
==============

Ok it is really usefull create tweens via code, but the real stuff is to create UI Animations.