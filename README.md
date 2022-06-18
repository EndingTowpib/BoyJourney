# Intro

A game now developing with Unity 2021.3.2.f1c1 LTS

# For Developers

**just for reference , not neccessary**

## Git Commit Naming Principle

git commit -m"[CONTENT]"

- Add new scripts,features : [ FEA: +details]
- Modify maps : [MAP: +details]
- Fix bug: [FIX: +details]
- Refractor code: [REF: +details]
- Modify asset: [ASS: +details]

- Documents or readme: [DOC: +details]

### Example

git commit -m"MAP: add level2"

git commit -m"REF: adjust the structure of PlayerController.cs"

## C# Variable And Function Naming Principle

- private property : **_m + lower camel**	
  e.g.  `_mCurrentSpeed`

  - exception : [SerializeField] ahead of the property , use lower camel 

    e.g.

  ```c#
  [SerializeField] private bool groundCheckObject;
  ```

- public property: **upper camel**

  e.g.  `IsGrounded`

- readonly property (or const) : **upper camel**

​		e.g. `MaxSpeed`

- function : all **upper camel**

​		e.g. `public void Jump(){}`

## Class Structure

property -> private or protected functions -> public functions (interface)

e.g.

```c#
class Vec2{
    // Properties
    private float x;
    private float y;
    
    // Private Functions
    private void InternalFunc(){}
    
    private void InternalFunc2(){}
    
    // Public Functions
    public float Magnitude()
    {
        return sqrt(x * x + y *y);
    }
}
```

