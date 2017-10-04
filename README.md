# DragFormControl
Allows you to drag the form from a control. 

* Add new items to your toolbox and select the DLL 
### pDragForm - uses pinvokes
### DragForm - doesn't use pinvokes

* Just select what control you want to allow to move the form in the properties section of the designer. 

![Alt text](https://i.imgur.com/TackoVl.png) 



# Extension Methods
The folder is completely unrelated to the dll, I just added it in here in case you didn't want an entire new component. 

* Add extension methods to your project and build 

```CSharp
Control.Dragable(); //with pinvokes 
Control.Dragable2(); //without pinvokes
```



